/// This is the operational context where a transaction occurs.
/// It focuses on the customer-facing flow.
///
/// Core Domain: Processing orders, calculating totals, handling payments.
/// Key Aggregates: Order, SalesTransaction, Payment.
module Sales

/// Money module.
module Money =
  open System

  /// Remove the unit off a decimal monetary value of any currency.
  let removeUnit (value: decimal<_>) : decimal = decimal value

  /// Romanian New Leu (RON) currency module.
  module RON =
    [<Measure>]
    type RON

    /// RON currency value.
    type T = decimal<RON>

    /// Create a new RON currency value from a decimal.
    let create (value: decimal) : T =
      LanguagePrimitives.DecimalWithMeasure<RON> value

    /// Try-parse a RON from a string.
    let tryParse (s: string) : T option =
      match Decimal.TryParse s with
      | true, d -> Some(create d)
      | false, _ -> None

    /// Normalize the given RON for displaying as a Lei and Bani pair.
    /// The fractional digits are rounded to the nearest integer.
    let normalize (ron: T) : decimal * decimal =
      let value = removeUnit ron
      let lei = Decimal.Truncate value
      let bani = Decimal.Remainder(value, 1M) * 100M
      lei, Decimal.Round bani
