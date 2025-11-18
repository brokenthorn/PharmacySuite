namespace PharmacyCore

/// Generic domain errors.
module DomainErrors =
  /// Failure to validate a business rule.
  type BusinessRuleValidationError = { RuleId: string; Message: string }

  /// Failure to create an instance of a domain entity or other model.
  type CreationError = { EntityName: string; Message: string }

  /// Failure to perform an operation, such as addition or subtraction.
  type OperationError = { EntityName: string; Message: string }
