// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.TestServerCollectionFixture")]

[assembly: SuppressMessage("Usage", "xUnit1000:Test classes must be public", Justification = "Infrastructure tests inherit from internal base classes and fixtures provided by the template.", Scope = "namespace", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.TestServerCollectionFixture")]

[assembly: SuppressMessage(
    "Usage",
    "xUnit1000:Test classes must be public",
    Justification = "Test base classes and fixtures are internal in the provided template; tests remain internal to avoid accessibility conflicts.")]
