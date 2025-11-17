namespace PharmacyCore.Tests.Sales

module Money =
  open Xunit

  /// RON currency tests.
  module RON =
    open PharmacyCore.Sales.Money

    [<Fact>]
    let ``Can create RON currencies from decimal values`` () =
      let ron = RON.create 100.0m
      let expected = 100.0m<RON.RON>
      Assert.Equal(expected, ron)

    [<Fact>]
    let ``Can parse RON currencies from a decimal-only string`` () =
      let expected = 100.5m<RON.RON>
      let actual = RON.tryParse "100.5"
      Assert.Equal(expected, actual.Value)

    [<Fact>]
    let ``Can parse RON currencies from string with currency symbol (uppercase)`` () =
      let expected = 25.75m<RON.RON>
      let actual = RON.tryParse "25.75 RON"
      Assert.Equal(expected, actual.Value)

    [<Fact>]
    let ``Can parse RON currencies from string with currency symbol (lowercase and spaces)`` () =
      let expected = 1.01m<RON.RON>
      let actual = RON.tryParse " 1.01 ron "
      Assert.Equal(expected, actual.Value)

    [<Fact>]
    let ``tryParse returns None for invalid input strings`` () =
      let actual = RON.tryParse "Not a number"
      Assert.True(Option.isNone actual)

    [<Fact>]
    let ``Can split into Lei and Bani, correctly rounding down (e.g., 102.205)`` () =
      let expectedLei = 102m
      let expectedBani = 20m
      let ron = RON.create 102.205m // 20.5 Bani component rounds down to 20
      let (lei, bani) = RON.splitIntoLeiAndBani ron
      Assert.Equal(expectedLei, lei)
      Assert.Equal(expectedBani, bani)

    [<Fact>]
    let ``Can split into Lei and Bani, correctly rounding up (e.g., 102.206)`` () =
      let expectedLei = 102m
      let expectedBani = 21m
      let ron = RON.create 102.206m // 20.6 Bani component rounds up to 21
      let (lei, bani) = RON.splitIntoLeiAndBani ron
      Assert.Equal(expectedLei, lei)
      Assert.Equal(expectedBani, bani)
