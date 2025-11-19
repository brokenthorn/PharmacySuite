namespace PharmacyCore.Sales

/// # Packaging Module
/// Defines the generic container types used to assemble the packaging profile.

module Packaging =
  open PharmacyCore

  /// Represents the type of container.
  /// The name should be unique and descriptive, such as "Blister", or "Vial".
  type T = { Name: string }

  /// Creates a new Packaging.
  let create (name: string) =
    let trimmedName = name.Trim()

    match String.length trimmedName with
    | len when len >= 2 && len <= 50 -> Ok { Name = trimmedName }
    | _ ->
      Error(
        { EntityName = "Packaging"
          Message = "A packaging's name must have between 2 and 50 characters" }
        : DomainErrors.CreationError
      )
