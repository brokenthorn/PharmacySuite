namespace PharmacyCore.Products

/// ParaPharmaceutical product.
module rec ParaPharmaceutical =

  /// ParaPharmaceutical ID.
  type Id = Id of string

  /// ParaPharmaceutical.
  type T = { Id: Id; Name: string }
