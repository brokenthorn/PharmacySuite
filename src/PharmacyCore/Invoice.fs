/// Invoice module.
module Invoice

// Unique ID of the Invoice, which for our invoices it's the invoice's number.
type InvoiceId = { InvoiceNumber: string }

// A line item inside an Invoice.
type InvoiceItem =
  { ProductId: Product.Id
    Quantity: Shared.Types.Quantity }

type Invoice = { Id: InvoiceId }
