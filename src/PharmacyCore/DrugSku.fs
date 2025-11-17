/// # SKU Module
/// Defines the recursive data structure for the pharmaceutical Stock Keeping Unit (SKU).
/// The SKU ties the Product Unit to its full nested packaging profile (Primary, Secondary, and Tertiary levels).
module PharmacyCore.DrugSku

/// Represents the innermost packaging level that holds the actual drug units.
/// This is the termination point of the PackagingLevel type recursion.
type PrimaryPackaging =
  {
    /// The container that is in direct contact with the drug unit, such as "Blister", or "Bottle".
    PackagingType: Packaging.T
    /// The definition of the drug unit contained within.
    /// E.g.: pill with 2 milligrams of active substance.
    ProductUnit: Drug.ProductUnit.T
    /// The number of ProductUnits contained within this primary package.
    Quantity: uint32
  }

/// Defines the hierarchy of packaging levels recursively, starting from the outside-in.
/// The definition starts at the outermost level (.e.g.,Tertiary or Secondary) and nests inward.
type PackagingLevel =
  /// A Container holds one or more items of the next inner level.
  /// For the next inner level to stop the recursion, it must be of the variant
  /// PrimaryPackaging.
  | Container of Container
  /// The PrimaryPackaging is the absolute innermost level, i.e. the primary packaging.
  /// It terminates the recursion of PackagingLevel's by describing the
  | PrimaryPackaging of PrimaryPackaging

/// Represents all packaging levels outside the primary packaging (Tertiary, Secondary).
/// This is the recursive part of the structure.
and Container =
  { Quantity: uint32
    PackagingType: Packaging.T
    InnerLevel: PackagingLevel }

/// The Drug Stock Keeping Unit (SKU) data structure.
/// This trade item identifier encapsulates the drug, strength, quantity, and full packaging profile.
type T =
  {
    /// The unique identifier for stock and trade, often a Global Trade Item Number (GTIN).
    SkuId: string
    /// The brand or proprietary name of the pharmaceutical product.
    TradeName: string
    /// The complete packaging definition, starting at the outermost level for this SKU.
    PackagingProfile: PackagingLevel
  }
