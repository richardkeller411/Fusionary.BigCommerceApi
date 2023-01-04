using System.Diagnostics.CodeAnalysis;
using System.Net;

using Fusionary.BigCommerce.Utils;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Fusionary.BigCommerce;

public class BigCommerceApi : IBigCommerceApi
{
    private readonly ILogger _logger;

    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor")]
    public BigCommerceApi(BigCommerceClient client, ILogger<BigCommerceApi> logger) : this(
        (IBigCommerceClient) client,
        logger
    )
    { }

    private BigCommerceApi(IBigCommerceClient client, ILogger logger)
    {
        BigCommerceHttp = client;
        _logger = logger;
    }

    public IBigCommerceClient BigCommerceHttp { get; }

    public async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        var response = await BigCommerceHttp.Client.SendAsync(
                requestMessage,
                cancellationToken
            )
            .ConfigureAwait(false);

        return response;
    }

    public async Task<BcResult<TResult, TMeta>> SendMultipartFormRequestAsync<TResult, TMeta>(
        HttpMethod method,
        string path,
        MultipartFormDataContent content,
        QueryString queryString,
        CancellationToken cancellationToken
    )
    {
        var requestMessage = BcRequestMessageBuilder.CreateRequestMessage(method, path, queryString);

        requestMessage.Content = content;

        return await SendRequestAsync<TResult, TMeta>(requestMessage, cancellationToken);
    }

    public async Task<BcResult<TResult, TMeta>> SendRequestAsync<TResult, TMeta>(
        HttpMethod method,
        string path,
        object? payload,
        QueryString queryString,
        CancellationToken cancellationToken
    )
    {
        var requestMessage = BcRequestMessageBuilder.CreateRequestMessage(method, path, queryString);

        if (payload is not null)
        {
            requestMessage.Content = BcJsonUtil.CreateContent(payload);
        }

        return await SendRequestAsync<TResult, TMeta>(requestMessage, cancellationToken);
    }

    public async Task<BcResult<TResult, TMeta>> SendRequestAsync<TResult, TMeta>(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        var response = await SendAsync(requestMessage, cancellationToken);

        switch (response)
        {
            case { StatusCode: HttpStatusCode.OK }:
            case { StatusCode: HttpStatusCode.NoContent }:
                return await response.ReadResponseAsync<TResult, TMeta>(cancellationToken);
            default:
                return await response.ReadErrorResponseAsync<TResult, TMeta>(cancellationToken);
        }
    }

    public static IBigCommerceApi Create(IBigCommerceClient client) =>
        Create(client, NullLogger.Instance);

    public static IBigCommerceApi Create(IBigCommerceClient client, ILogger logger) =>
        new BigCommerceApi(client, logger);
}