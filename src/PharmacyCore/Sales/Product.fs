namespace PharmacyCore.Sales

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
