/// Contact information module.
module PharmacyCore.ContactInfo

/// Phone number.
type PhoneNumber = PhoneNumber of string

/// Email address.
type Email = Email of string

/// Physical (PO Box) address.
type Address =
  { Country: string
    County: string
    City: string
    Street: string
    HouseNumber: string }
