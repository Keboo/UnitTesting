# UnitTesting
A small example repository used for a lunch and learn discussion at IntelliTect on unit testing.
There are several branches showing progression through each of these "levels".

1. [Testing basics](https://docs.microsoft.com/en-us/dotnet/core/testing/#what-are-unit-tests)
    - What code should you test?
    - Types of tests
      - Unit tests
      - Functional tests
      - Integration tests
    - Terminology
      - [System Under Test (SUT)](https://en.wikipedia.org/wiki/System_under_test)
      - [Dependency](https://deviq.com/explicit-dependencies-principle/) – an item you depend on. Another class, interface, struct.
      - [Coupling](https://enterprisecraftsmanship.com/2015/09/02/cohesion-coupling-difference/) – a measurement of the degree of interdependence between two items
      - [Fake vs Stub vs Mock](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#lets-speak-the-same-language)
        - Fake – generic term for either a stub or mock. 
        - Mock - a fake object in the system that decides if a unit test should pass. 
        - Stub – Controllable replacement for a dependency. 
2. Level 0 – [Actually writing tests](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
    - This is a people problem, not a technical problem. [Fast Beats Right](https://deviq.com/fast-beats-right/)
    - Benefits of unit testing
      - Prevent regression
      - One way to document your code
      - Facilitate better code design. Obvious when things are tightly coupled.
3. Level 1 – Writing your own fakes
    - Helps you identify coupling since you must either use your real objects or override virtual members.
    - Dealing with [static cling](https://deviq.com/static-cling/)
      - [Microsoft Fakes](https://docs.microsoft.com/en-us/visualstudio/test/isolating-code-under-test-with-microsoft-fakes) – Requires VS enterprise SKU
      - [Pose](https://github.com/tonerdo/pose) – Free OSS
    - Problems with writing your own fakes?
      - Time consuming, especially to add any sort of behavior verification
      - No assurances that the implementation matches the real implementation
4. Level 2 – Using a mocking library to create fakes
    - [Moq](https://github.com/Moq), [Rhino Mocks](https://github.com/hibernating-rhinos/rhino-mocks), [NSubstiture](https://github.com/nsubstitute/NSubstitute), etc.
    - Using a library to automatically create your SUT. Such as [Moq.AutoMocker](https://github.com/moq/Moq.AutoMocker)
    - Benefits of this approach
      - Able to quickly write unit tests since mocks are quick to create.
      - Behavior of the SUT is validated.
    - Problems with using mocks?
      - More tightly coupled to the implementation. Since it often must provide setups for **all** dependency interaction.
      - No assurances that the mock implementation matches the real implementation
5. Level 3 – Using simulators
    - [Port/Adapter/Simulator pattern](https://blogs.msdn.microsoft.com/ericgu/2014/12/01/unit-test-success-using-ports-adapters-and-simulators/)
      - Port - Something the system uses to *interface* with an external dependency
        - Naming really matters here. Consider what needs to be done rather than how it should be done. ie. Consider the differences between `INotificationService` vs `IDialogService`. Or `IEmailUser` vs `INotifyUser`.
        - Write the interface that you want to code against, and then condier how to implement it.
      - Adapter - An implementation of a port.
      - Simulator - An adapter that is designed to be great for unit testing.
        - [Liskov substitution principle](https://en.wikipedia.org/wiki/Liskov_substitution_principle#Principle) ([S.O.L.I.D](https://www.codemag.com/article/1001061))
    - Write _integration_ tests against the port and run them on all adapters to verify they all behave the same. Because these will be going against the real adapters and may be slow, these should not run as part of the normal unit test suite. Use your simulator in all unit tests that have a dependency on its port.
    - What about cases where you cannot test your real adapter?
      - Error conditions, timeouts
      - Adapter is not deterministic
    - Benefits of this approach
      - Consistent adapter behavior across all of your unit tests
      - If an error is found in an adapter, you can write a test for it and the integrity of the adapter will improve over time. This benefit then scales out to all of the unit tests that are using it.
    - Problems with using simulators
      - Simulators take longer to create than mocks
      - Each time you have to violate the Liskov substitution principle for a unit test, you lower their usefulness. Mocks work better here.
6. Level 4?

### Additional References:
- [Unit Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Mocks Aren't Stubs](https://martinfowler.com/articles/mocksArentStubs.html)
- [P.A.S kata walkthrough](http://ericscodeshack.com/?p=33)
