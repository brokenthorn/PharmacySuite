namespace PharmacyCore.Tests.Sales

module Drug =
  open Xunit
  open PharmacyCore.Sales.Drug

  [<Fact>]
  let ``Can create CimCode`` () =
    let idStr = "W1234"
    let cim: CimCode = Id idStr

    Assert.Equal(
      idStr,
      match cim with
      | Id value -> value
    )

  [<Fact>]
  let ``The active substance strength must be positive`` () =
    let strengthResult = Strength.create -1.0 Milligram

    match strengthResult with
    | Ok _ -> Assert.Fail "The constructor result should have been an Error"
    | Error err -> Assert.Equal("The active substance strength must be positive", err.Message)
