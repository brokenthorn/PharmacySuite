namespace PharmacyCore.Product

/// <summary>
/// Drug Product Module.
/// </summary>
/// <remarks>
/// Implements pharmaceutical drug types and associated functionality.
/// </remarks>
module Drug =
  open PharmacyCore

  /// CIM (Codul de Identificare a Medicamentului) is a unique identifier for a drug in the Romanian CANAMED
  /// catalogue/platform.
  type CimCode = Id of string

  /// The physical form of the drug.
  type Formulation =
    | Tablet
    /// A solid dosage form where the drug is enclosed in a gelatin shell.
    | Capsule
    /// A sterile solution or suspension designed to be administered by injection.
    | InjectableSolution
    /// A concentrated, sweetened, aqueous liquid formulation.
    | Syrup
    /// Cream (or ointment).
    | Cream
    /// For formulations not covered by the standard types.
    | Other of string

  /// Represents the unit of measure for the active substance.
  type Unit =
    /// Milligram (mg).
    | Milligram
    /// Milliliter (mL), often used for liquid strengths (e.g., mg/mL).
    | Milliliter
    /// Microgram (ug or mcg).
    | Microgram
    /// Used for substances measured by biological activity, such as insulin or heparin.
    | UnitOfMeasure
    /// Used for strength expressed as a percentage concentration (e.g., 2% cream).
    | Percent

  /// Drug Strength Module.
  /// Represents the fixed amount of the active substance in a single unit.
  /// This is the intrinsic potency of the drug, not the prescribed regimen (Dosage).
  module Strength =
    /// Represents the fixed amount of the active substance in a single unit.
    /// This is the intrinsic potency of the drug, not the prescribed regimen (Dosage).
    type T = { Value: float; Unit: Unit }

    /// Create a new Strength.
    let create value unit =
      match value with
      | value when value <= 0 ->
        Error(
          { EntityName = "Strength"
            Message = "The active substance strength must be positive" }
          : DomainErrors.CreationError
        )
      | _ -> Ok { Value = value; Unit = unit }

  /// <summary>
  /// Consumable drug unit.
  /// </summary>
  /// <remarks>
  /// Defines the single, consumable drug item.
  /// E.g.: capsule with 2.0 milligrams.
  /// </remarks>
  module ConsumableUnit =
    /// Defines the single, consumable drug item.
    /// E.g.: a capsule (Formulation) with 2.0 milligrams (Strength).
    type T =
      { Formulation: Formulation
        Strength: Strength.T }

    let create formulation strength =
      match formulation with
      | Other name when String.length name < 2 ->
        Error(
          { EntityName = "ConsumableUnit"
            Message = "The name of a custom Formulation for a drug ConsumableUnit must have at least 2 characters" }
          : DomainErrors.CreationError
        )
      | _ ->
        Ok
          { Formulation = formulation
            Strength = strength }

  /// <summary>
  /// Drug Stock Keeping Unit (SKU) Module.
  /// </summary>
  /// <remarks>
  /// Defines how to keep track of a drug in stock.
  /// Uses a recursive data structure for tracking remaining stock units at every packaging level, due to how some drugs
  /// can be prescribed in quantities that require at least one full product package to broken up in order to fulfill
  /// the required quantity.
  /// </remarks>
  module Sku =
    /// Represents the innermost packaging level that holds the actual drug units.
    /// This is the termination point of the PackagingLevel type recursion.
    type PrimaryPackaging =
      {
        /// The container that is in direct contact with the drug unit, such as "Blister", or "Bottle".
        PackagingType: Packaging.T
        /// The definition of the drug unit contained within.
        /// E.g.: pill with 2 milligrams of active substance.
        ConsumableUnit: ConsumableUnit.T
        /// The number of ConsumableUnits contained within this primary package.
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
