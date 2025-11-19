/// Invoice module.
module PharmacyCore.Invoice

open PharmacyCore.Sales

// Unique ID of the Invoice, which for our invoices it's the invoice's number.
type InvoiceId = { InvoiceNumber: string }

type ProductRef =
  | Drug of {| CimCode: Drug.CimCode |}
  | ParaPharmaceutical of {| Id: Product.Sku.Id |}

// A line item inside an Invoice.
type InvoiceItem =
  { ProductRef: ProductRef
  // Quantity: Shared.Types.Quantity
  }

type Invoice = { Id: InvoiceId }
