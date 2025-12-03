namespace PharmacyCore.Stocks

module DrugStock =
  open PharmacyCore.Sales

  /// Drug Stock unique ID.
  type Id = Id of string

  // TODO: model stock quantity so that a drug's quantity can be tracked at all packaging levels.
  type Quantity = uint32

  /// Record of a Drug SKU that is kept in stock.
  type StockRecord =
    {
      /// A unique tracking identifier for this Drug SKU.
      TrackingId: string
      /// The ID of the Drug SKU that is kept in stock.
      SkuId: Drug.Sku.Id
      /// The quantity that is recorded to be in stock by this record.
      Quantity: Quantity
    }

  type Stock = { Id: Id; Records: StockRecord list }
