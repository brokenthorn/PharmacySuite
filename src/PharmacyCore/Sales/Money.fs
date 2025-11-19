namespace PharmacyCore.Sales

/// <summary>
/// Money Module (Sales).
/// </summary>
/// <remarks>
/// Implements money types (currencies) and associated functionality, in the context of sales.
/// </remarks>
module Money =
  /// <summary>
  /// Remove the unit off a decimal monetary value of any currency.
  /// </summary>
  /// <remarks>
  /// <b>WARNING:</b> Be careful when doing arithmetic with unit-less currency values!
  /// The type system can no longer catch errors for you, such adding together values of different currencies.
  /// </remarks>
  let removeUnit (value: decimal<_>) : decimal = decimal value

  /// Romanian New Lei (RON) currency module.
  module RON =
    open System
    open System.Text.RegularExpressions

    /// The RON currency measure, which can be used to tag primitive numeric values.
    [<Measure>]
    type RON

    /// The RON currency type, which is a decimal tagged with the RON currency measure.
    type T = decimal<RON>

    /// Create a new RON currency value from a decimal.
    let create (value: decimal) : T =
      LanguagePrimitives.DecimalWithMeasure<RON> value

    // TODO: Enhance tryParse to allow 2 situations: a decimal-only string, a string with a decimal followed by 0 or
    // more spaces and then the currency symbol(s) (case-insensitive).

    /// Attempt to parse a RON value from a string. Handle strings with only a decimal value,
    /// or a decimal value followed by optional spaces and the currency symbol "RON" (case-insensitive).
    let tryParse (s: string) : T option =
      let s = s.Trim()

      // "number [optional spaces] RON" (case-insensitive)
      let ronPattern = new Regex(@"^([\s\d\.\,\-]+)\s*RON$", RegexOptions.IgnoreCase)

      match ronPattern.Match s with
      | m when m.Success ->
        // Matched the "number RON" pattern:
        let numberPart = m.Groups.[1].Value.Trim()

        match Decimal.TryParse numberPart with
        | true, d -> Some(create d)
        | false, _ -> None
      | _ ->
        // Did not match the "number RON" pattern, try simple decimal parse:
        match Decimal.TryParse s with
        | true, d -> Some(create d)
        | false, _ -> None

    /// <summary>
    /// Split the given RON value into its integral (Lei) and fractional (Bani) components.
    /// </summary>
    /// <remarks>
    /// This function handles unrounded monetary values (which may temporarily exceed two decimal places during
    /// intermediate arithmetic) by truncating the Lei component and rounding the Bani component.
    /// The resulting Lei and Bani values are returned as decimal values representing whole numbers.
    /// Example: A value from an intermediate calculation is 200.168 RON.
    /// This is split into 200 Lei and 16.8 Bani. The 16.8 Bani is then rounded to the nearest integer,
    /// which is 17 Bani, resulting in the final pair of 200 Lei and 17 Bani.
    /// </remarks>
    let splitIntoLeiAndBani (ron: T) : decimal * decimal =
      let value = removeUnit ron
      let lei = Decimal.Truncate value
      let bani = Decimal.Remainder(value, 1M) * 100M
      lei, Decimal.Round bani

  /// Money (currency) type union.
  type T = RON of RON.T
