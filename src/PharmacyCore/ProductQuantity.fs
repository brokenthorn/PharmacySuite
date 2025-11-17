/// Product quantity module modelled specifically for the pharmaceutical domain
/// and its stringent product tracking requirements.
module PharmacyCore.ProductQuantity

// type Quantity = { Wholes: uint32; Fractions: Fraction }
//
// module Fraction =
//   /// A fractional quantity representing one level of subdividing a
//   /// whole, for example: Box with n blisters.
//   ///
//   /// For multiple subdivisions, these types can be stacked.
//   /// For example the blisters can be further subdivided into "Blister
//   /// with n capsules".
//   type FractionalQuantity =
//     {
//       /// The product packaging.
//       Packaging: DrugSku.T
//       /// The number of fractions, aka. the numerator.
//       FractionsQty: uint32
//       /// The number of equal parts that one whole is divided in, aka. the
//       /// denominator.
//       FractionsInWhole: uint32
//     }
//
//   /// Create a new FractionalQuantity.
//   let makeFractionalQuantity description fractionsQty fractionsInWhole =
//     if fractionsQty < fractionsInWhole then
//       Ok
//         { Description = description
//           FractionsQty = fractionsQty
//           FractionsInWhole = fractionsInWhole }
//     else
//       Error(
//         { EntityName = nameof FractionalQuantity
//           Message = "A packaged product cannot have a fractional quantity with more " }
//         : DomainErrors.CreationError
//       )
