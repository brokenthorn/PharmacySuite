namespace PharmacyCore.Sales

// TODO: consider creating a new namespace PharmacyCore.Product and rename the Product module below to
// ParaPharmaceutical and move it to the new namespace, along with Drug and Packaging.
//
// Then the rest of the modules remaining and now more aligned with the sales domain.
//
// Also, consider if the Sku submodules (Drug,Product/ParaPharmaceutical) should still be part of the Product NS, Sales
// NS or, maybe the Stock NS. Currently, I'm leaning towards the Stock NS. SKU (Stock Keeping Unit) is a model that
// depends a lot of how you want to keep/record an item in stock. Take the old Microsoft example for modeling SKUs: you
// have the Windows product, with several SKUs: Windows 2000, Windows XP, etc. The product has no knowledge of SKUs.

/// <summary>
/// Product Module.
/// </summary>
/// <remarks>
/// Implements the product types and associated functionality.
/// This includes OTC drugs as well as parapharmaceuticals.
/// </remarks>
module Product =
  // TODO: Create the same type of packaging profile modeling as with Drug.PackagingLevel. It will be needed for
  // tracking OTC drugs, which can probably also be sold in fractions, so we would need to track the remaining stock on
  // those.

  /// <summary>
  /// Product Stock Keeping Unit (SKU) Module.
  /// </summary>
  /// <remarks>
  /// Defines how to keep track of a non-prescription drug product in stock.
  /// </remarks>
  module Sku =
    type Id = Id of string
    type T = { Id: Id; TradeName: string }
