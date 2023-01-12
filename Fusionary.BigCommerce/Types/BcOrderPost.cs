namespace Fusionary.BigCommerce.Types;

public record BcOrderPost
{
    private BcBillingAddressBase? _billingAddress;
    private List<BcOrderCatalogProductPost>? _products;
    private List<BcShippingAddressBase>? _shippingAddresses;

    [JsonPropertyName("customer_id")]
    public int? CustomerId { get; set; }

    [JsonPropertyName("products")]
    public List<BcOrderCatalogProductPost> Products
    {
        get => LazyInitializer.EnsureInitialized(ref _products);
        set => _products = value;
    }

    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("subtotal_ex_tax")]
    public BcFloat? SubtotalExTax { get; set; }

    [JsonPropertyName("subtotal_inc_tax")]
    public BcFloat? SubtotalIncTax { get; set; }

    [JsonPropertyName("subtotal_tax")]
    public BcFloat? SubtotalTax { get; set; }

    [JsonPropertyName("base_shipping_cost")]
    public BcFloat? BaseShippingCost { get; set; }

    [JsonPropertyName("shipping_cost_ex_tax")]
    public BcFloat? ShippingCostExTax { get; set; }

    [JsonPropertyName("shipping_cost_inc_tax")]
    public BcFloat? ShippingCostIncTax { get; set; }

    [JsonPropertyName("shipping_cost_tax")]
    public BcFloat? ShippingCostTax { get; set; }

    [JsonPropertyName("base_handling_cost")]
    public BcFloat? BaseHandlingCost { get; set; }

    [JsonPropertyName("handling_cost_ex_tax")]
    public BcFloat? HandlingCostExTax { get; set; }

    [JsonPropertyName("handling_cost_inc_tax")]
    public BcFloat? HandlingCostIncTax { get; set; }

    [JsonPropertyName("handling_cost_tax")]
    public BcFloat? HandlingCostTax { get; set; }

    [JsonPropertyName("base_wrapping_cost")]
    public BcFloat? BaseWrappingCost { get; set; }

    [JsonPropertyName("wrapping_cost_ex_tax")]
    public BcFloat? WrappingCostExTax { get; set; }

    [JsonPropertyName("wrapping_cost_inc_tax")]
    public BcFloat? WrappingCostIncTax { get; set; }

    [JsonPropertyName("wrapping_cost_tax")]
    public BcFloat? WrappingCostTax { get; set; }

    [JsonPropertyName("total_ex_tax")]
    public BcFloat? TotalExTax { get; set; }

    [JsonPropertyName("total_inc_tax")]
    public BcFloat? TotalIncTax { get; set; }

    [JsonPropertyName("total_tax")]
    public BcFloat? TotalTax { get; set; }

    [JsonPropertyName("items_total")]
    public int? ItemsTotal { get; set; }

    [JsonPropertyName("items_shipped")]
    public int? ItemsShipped { get; set; }

    [JsonPropertyName("payment_method")]
    public string? PaymentMethod { get; set; }

    [JsonPropertyName("payment_provider_id")]
    public string? PaymentProviderId { get; set; }

    [JsonPropertyName("payment_status")]
    public string? PaymentStatus { get; set; }

    [JsonPropertyName("refunded_amount")]
    public BcFloat? RefundedAmount { get; set; }

    [JsonPropertyName("order_is_digital")]
    public bool? OrderIsDigital { get; set; }

    [JsonPropertyName("store_credit_amount")]
    public BcFloat? StoreCreditAmount { get; set; }

    [JsonPropertyName("gift_certificate_amount")]
    public BcFloat? GiftCertificateAmount { get; set; }

    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("ip_address_v6")]
    public string? IpAddressV6 { get; set; }

    [JsonPropertyName("geoip_country")]
    public string? GeoipCountry { get; set; }

    [JsonPropertyName("geoip_country_iso2")]
    public string? GeoipCountryIso2 { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("currency_exchange_rate")]
    public string? CurrencyExchangeRate { get; set; }

    [JsonPropertyName("default_currency_code")]
    public string? DefaultCurrencyCode { get; set; }

    [JsonPropertyName("staff_notes")]
    public string? StaffNotes { get; set; }

    [JsonPropertyName("customer_message")]
    public string? CustomerMessage { get; set; }

    [JsonPropertyName("discount_amount")]
    public BcFloat? DiscountAmount { get; set; }

    [JsonPropertyName("coupon_discount")]
    public BcFloat? CouponDiscount { get; set; }

    [JsonPropertyName("ebay_order_id")]
    public string? EbayOrderId { get; set; }

    [JsonPropertyName("cart_id")]
    public string CartId { get; set; } = null!;

    [JsonPropertyName("billing_address")]
    public BcBillingAddressBase BillingAddress
    {
        get => LazyInitializer.EnsureInitialized(ref _billingAddress);
        set => _billingAddress = value;
    }

    [JsonPropertyName("credit_card_type")]
    public object? CreditCardType { get; set; }

    [JsonPropertyName("order_source")]
    public string? OrderSource { get; set; }

    [JsonPropertyName("channel_id")]
    public int? ChannelId { get; set; }

    [JsonPropertyName("external_source")]
    public string? ExternalSource { get; set; }

    [JsonPropertyName("shipping_addresses")]
    public List<BcShippingAddressBase> ShippingAddresses
    {
        get => LazyInitializer.EnsureInitialized(ref _shippingAddresses);
        set => _shippingAddresses = value;
    }

    [JsonPropertyName("external_id")]
    public object? ExternalId { get; set; }

    [JsonPropertyName("external_merchant_id")]
    public object? ExternalMerchantId { get; set; }

    [JsonPropertyName("tax_provider_id")]
    public string? TaxProviderId { get; set; }

    [JsonPropertyName("store_default_currency_code")]
    public string? StoreDefaultCurrencyCode { get; set; }

    [JsonPropertyName("store_default_currency_exchange_rate")]
    public string? StoreDefaultToTransactionalExchangeRate { get; set; }

    [JsonPropertyName("custom_status")]
    public string? CustomStatus { get; set; }

    [JsonPropertyName("customer_locale")]
    public string? CustomerLocale { get; set; }

    [JsonPropertyName("external_order_id")]
    public string? ExternalOrderId { get; set; }
}