namespace PharmacyCore.Stocks

module DrugStock =
  open PharmacyCore.Sales

  /// Drug Stock unique ID.
  type Id = Id of System.Guid

  type Quantity =
    | SecondaryPackagingQuantity of SecondaryPackagingQuantity
    | PrimaryPackagingQuantity of PrimaryPackagingQuantity

  and SecondaryPackagingQuantity = { Quantity: uint32 }

  /// Records stock quantity at the primary packaging level.
  /// E.g.: 2 blisters, one has 10 consumable units left, the other has 7.
  and PrimaryPackagingQuantity =
    { PackagingCount: uint32
      ConsumableUnitQuantity: uint32 list }

  let newId () = System.Guid.CreateVersion7()

  /// Record of a Drug SKU that is kept in stock.
  type TRecord =
    {
      /// A unique tracking identifier for this Drug SKU.
      TrackingId: string
      /// The ID of the Drug SKU that is kept in stock.
      SkuId: Drug.Sku.Id
      /// The quantity that is recorded to be in stock by this record.
      Quantity: Quantity
    }

  type T =
    {
      Id: Id
      /// Stock records.
      Records: TRecord list
    }

  /// Create a new, empty, Drug Stock.
  let create id = { Id = id; Records = [] }
