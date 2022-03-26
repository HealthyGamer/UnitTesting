# Introduction

## Why Are Unit Tests Important?

The biggest downside of unit tests is that they are painful and time consuming to write. You know what else is painful? Getting called in to work at 2 AM on a Saturday night to fix a bug in production.

There are several reasons why testing is an important part of a piece of software.

1. As mentioned, it reduces the number of bugs and "unintended features" that make it into the release builds. Tests can be added to bugs that do make it into the build so that you can prevent these issues from reoccuring.
2. It can highlight bad code design. It doesn't necessarily mean a piece of code is "good", but there are a lot of issues in code design that will be caught by using tests. Bad code is rarely easy to test.
3. It helps keep the project maintainable. Tests cost time up front, but over the life of a piece of software, they can definitely give a lot of return on that investment. Not only is your code quality likely to be higher, you will avoid things like regression bugs, which are bugs that got released, fixed, and have now popped up again.

When we talk about experienced devs spending more time thinking about a problem than actually writing code, tests can be a useful tool in that process. It puts the emphasis on what the code does instead of how it does it- that comes later during refactoring.

## What Are Unit Tests?

A unit test is a piece of code that checks another piece of code to ensure it behaves as expected. Tests will pass or fail based on whether or not we get the expected result. Generally speaking, a unit test will not include any external dependencies. Traditionally this meant testing a single function or method in isolation, but that can make unit tests unneccessarily cumbersome to write.

### System Under Test

Also known as Code Under Test, this is the part of the code that we are checking in a test to ensure it works as expected.

### Unit of Work

A unit of work is a single call to a public API/method that results in an observable change without looking at the private state of the system. Defining each unit of work is a large piece of writing testable code.

### Regression

Any feature or code that used to work and now doesn't. One of the main reasons to make use of testing is to avoid regressions.

### Legacy Code

Legacy code is often an issue for developers. There are several definitions. [Wikipedia](https://en.wikipedia.org/wiki/Legacy_system#:~:text=Legacy%20code%20is%20old%20computer,obsolete%20or%20supporting%20something%20obsolete.) defines it as code that is still being used but is outdated or related to a previous version of the system.

Some devs will refer to this as "code that works" but isn't necessarily well written. For the purposes of this series, "code with no tests" is the most useful definition.

### Integration and End-to-End Testing

Unit tests can catch a lot of the issues we run into as developers, but since each unit test only looks at a small piece of code, they don't help determine whether or not the entire system is behaving as expected.

Integration tests will look at how different parts of a system work together. End-to-end tests will automate an entire process from beginning to end to ensure it behaves as expected. These types of tests might also include things like external dependencies like databases that aren't strictly part of your code. When we manually test a system we are almost always doing integration testing.

Sometimes it simply isn't possible to write good unit tests for a piece of code because it relies on legacy or external code that doesn't support it. Integration testing can help cover those sorts of cases in addition to checking that the system all works together.

## What Makes a Good Unit Test?

Not every unit test will have every property of a "good" test, but we want to hit as many points as possible. "Bad" unit tests create a system that is just as time consuming and brittle as a system without tests at all. Gaining the benefits of testing means spending the time and effort up front to make sure that the test suite is well written.

- It should be automated, repeatable, and have consistent results.
- It should have full control over what it is testing (this is left for integration and E2E testing).
- It should be easy to implement and maintain. Usually we use test frameworks to allow us to write tests more quickly.
- It should be clear what it is testing and remain relevant over time.
- It should be fully isolated from any other tests.
- It should be easy to understand why a test failed and how to fix it.

## Test Driven Development: TDD

If you've been in the dev world long enough, you've probably met or read something about TDD. Particularly, that it is the only correct way to code and if you don't you are a bad developer. There are a few ways to define this, but my prefered definition is test-first development.

The main issue with TDD is that it is *hard*, and in my opinion things like single use code won't benefit enough from this approach to make it worth it. The counterargument is that with practice it is possible to become quick enough with this method that it can be applied to anything.

### The Traditional TDD Process

1. Create a test that checks for the desired outcome.
2. Run it and watch it fail.
3. Write the minimum amount of code required to get the test to pass, even if you know you need to expand it later.
4. Run the test again to make sure it passes.
5. Refactor if needed to clean up the code.

### Components of Successful TDD

1. Just because you wrote the tests first doesn't make them good. You still need to follow the principals of good unit testing.
2. Test-first does *not* make your code better than writing code-first. It is a tool to help you write better code, not a necessity.
3. TDD doesn't garuntee well designed code.
