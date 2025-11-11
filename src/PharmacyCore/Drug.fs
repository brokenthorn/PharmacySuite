/// # Drug Module
/// Defines the intrinsic properties of the finished pharmaceutical product.
/// These properties (Formulation and Strength) are immutable characteristics of the drug unit itself.
module Drug

/// Defines the physical form of the drug.
type Formulation =
  | Tablet
  /// A solid dosage form where the drug is enclosed in a gelatin shell.
  | Capsule
  /// A sterile solution or suspension designed to be administered by injection.
  | InjectableSolution
  /// A concentrated, sweetened, aqueous liquid formulation.
  | Syrup
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

/// # Strength Module
/// Represents the fixed amount of the active substance in a single unit.
/// This is the intrinsic potency of the drug, not the prescribed regimen (Dosage).
module Strength =
  /// Represents the fixed amount of the active substance in a single unit.
  /// This is the intrinsic potency of the drug, not the prescribed regimen (Dosage).
  type T = { Value: float; Unit: Unit }

  /// Creates a new Strength.
  let create value unit =
    match value with
    | value when value <= 0 ->
      Error(
        { EntityName = "Strength"
          Message = "The active substance strength must be positive" }
        : DomainErrors.CreationError
      )
    | _ -> Ok { Value = value; Unit = unit }

/// # ProductUnit Module.
/// Defines the single, consumable drug item.
/// E.g.: capsule with 2.0 milligrams.
module ProductUnit =
  /// Defines the single, consumable drug item.
  /// E.g.: a capsule (Formulation) with 2.0 milligrams (Strength).
  type T =
    { Formulation: Formulation
      Strength: Strength.T }

  let create formulation strength =
    match formulation with
    | Other name when String.length name < 2 ->
      Error(
        { EntityName = "ProductUnit"
          Message = "The name of a custom Formulation for a drug ProductUnit must have at least 2 characters" }
        : DomainErrors.CreationError
      )
    | _ ->
      Ok
        { Formulation = formulation
          Strength = strength }
