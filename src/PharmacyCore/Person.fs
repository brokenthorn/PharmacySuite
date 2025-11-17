/// Person module (describes a physical person).
module PharmacyCore.Person

/// The unique ID of the Person.
type Id = PersonId of string

/// A physical person.
type T =
  { Id: Id
    FirstName: string
    LastName: string
    PhoneNumber: ContactInfo.PhoneNumber option
    EmailAddress: ContactInfo.Email option
    Address: ContactInfo.Address option }
