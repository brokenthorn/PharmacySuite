namespace PharmacyCore.Sales

open PharmacyCore.Sales

/// Line item for non-prescription drug products, i.e., OTC medication and parapharmaceuticals.
module ProductLineItem =
  open PharmacyCore.Products

  type T =
    { Order: uint32
      SkuId: ParaPharmaceutical.Sku.T
      // TODO: How are we going to model line item quantities?
      Quantity: uint32
      Price: Money.T }

/// <summary>
/// Sale Module.
/// </summary>
/// <remarks>
/// Implements the Sale aggregate root that encapsulates the line items, total amount, the customer information, etc.
/// Pharmacies can have various types of sales, which can be quite different from each other. For example a sale coming
/// from dispensing a prescription is different from a sale of products that can be sold over the counter, including OTC
/// drugs, as well as any parapharmaceuticals. The Sale aggregate encapsulates all these types.
/// </remarks>
module Sale =
  type Id = Id of string

  /// Union of all possible types of sales and their details.
  type SaleDetails = Product of ProductSaleDetails
  // add more soon...
  and ProductSaleDetails = { LineItems: ProductLineItem.T list }

  type T =
    { Id: Id
      Details: SaleDetails
      TotalAmount: Money.T }
