namespace PharmacyCore.Stocks

/// ParaPharmaceutical SKU.
module ParaPharmaceuticalSku =
  open PharmacyCore.Products

  /// ParaPharmaceutical SKU ID.
  type Id = Id of string

  /// ParaPharmaceutical SKU.
  type T =
    { Id: Id
      ParaPharmaceuticalId: ParaPharmaceutical.Id
      Name: string }

/// Drug SKU.
module DrugKu =
  open PharmacyCore.Products

  /// <summary>Defines the packaging profile of the Drug SKU.</summary>
  /// <remarks>
  /// The packaging profile is a hierarchy of packaging levels, defined recursively.
  /// The definition starts from the outermost level (.e.g., secondary or tertiary packaging) and goes inwards.
  /// The recursion stops once the PackagingProfile is of the variant PrimaryPackaging.
  /// </remarks>
  type PackagingProfile =
    | SecondaryPackaging of SecondaryPackaging
    | PrimaryPackaging of PrimaryPackaging

  /// Secondary or tertiary packaging that does not contact the drug directly.
  /// E.g.: 1 box.
  and SecondaryPackaging =
    { PackagingCount: uint32
      PackagingType: Packaging.T
      PackagingProfile: PackagingProfile }

  /// Primary packaging that contacts the drug directly and protects it.
  /// E.g.: 2 blisters, with 10 pills each.
  and PrimaryPackaging =
    { PackagingCount: uint32
      PackagingType: Packaging.T
      ConsumableUnitQuantity: uint32
      ConsumableUnit: Drug.ConsumableUnit.T }

  /// Drug SKU ID.
  type Id = Id of System.Guid

  /// Create new Drug SKU ID.
  let createId () = System.Guid.CreateVersion7()

  /// Drug SKU.
  type T =
    {
      /// Drug SKU ID.
      Id: Id
      /// Stock tracking ID, usually a Global Trade Item Number (GTIN).
      TrackingId: string
      /// The brand or proprietary name of the product SKU.
      Name: string
      /// The complete packaging definition, starting at the outermost level for this SKU.
      PackagingProfile: PackagingProfile
    }
