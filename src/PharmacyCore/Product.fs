// TODO: create a mapping function that derives the prices at each level for a
// given ProductPackaging, mimicking the same kind of structure, but adding a
// price field. Should be part of the pricing or sales and checkout module.
//
module Product

type Id = Id of string

type T =
  { Id: Id
    Name: string
    ProductPackaging: DrugSku.T }


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
