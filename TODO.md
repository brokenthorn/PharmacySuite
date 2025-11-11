# TODO

Project todo list.

- move these todos into project stories/tasks and implement one at a time.
- create unit tests
- when creating the logic to calculate sale price of fractions, always calculate
  a price per each packaging, for each level, and round up to the nearest market
  denominator, e.g. 10 bani for Romania. This way we don't lose money and we are
  also fair to customers.
- introduce .fsi file once API has solidified and is no longer expected to
  change significantly.
  - <https://learn.microsoft.com/en-us/dotnet/fsharp/style-guide/component-design-guidelines#consider-using-explicit-signature-files-fsi-for-stable-library-and-component-apis>

  Steps to create a new product:
  1. Create packagings and sub-packagings if they don't exist.
  2. Create manufacturer if it doesn't exist.
  3. Create product.

  Hierarchy of product packagings:

  - Packaging: Box
  - PackagingQty: 1
  - InnerPackaging: Some() ->
    - Packaging: Blister
    - PackagingQty: 2
    - InnerPackaging: Some() ->
      - Packaging: Pill
      - PackagingQty: 5
      - InnerPackaging: None()

The above is:

- 1 Box,
- with 2 Blisters,
- with 5 pills each,
- with no other subdivisions.
