namespace PharmacyCore.Product

/// <summary>
/// ParaPharmaceutical Product Module.
/// </summary>
/// <remarks>
/// Implements the parapharmaceutical product types and associated functionality.
/// </remarks>
module ParaPharmaceutical =
  type Id = Id of string

  type T =
    { Id: Id
      Name: string
      ProductPackaging: string }


// module Product =
//   module Errors =
//     /// Error creating a Product instance.
//     type MakeError =
//       | CreationError of DomainErrors.CreationError
//       | BusinessRuleValidationError of DomainErrors.BusinessRuleValidationError
//
//   /// Unique ID of the Product.
//   type ProductId = ProductId of string
//   /// The Product's official name, typically as printed on the package.
//   type ProductName = ProductName of string
//   /// A physical product.
//   type Product = { Id: ProductId; Name: ProductName }
