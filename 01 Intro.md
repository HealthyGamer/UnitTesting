# Introduction

## What Are Unit Tests?

A unit test is a piece of code that checks another piece of code to ensure it behaves as expected. Tests will pass or fail based on whether or not we get the expected result. Generally speaking, a unit test will not include any external dependencies.

### System Under Test

Also known as Code Under Test, this is the part of the code that we are checking in a test to ensure it works as expected.

### Unit of Work

A unit of work is a single call to a public API/method that results in an observable change without looking at the private state of the system. Defining each unit of work is a large piece of writing testable code.

### Integration and End-to-End Testing

Unit tests can catch a lot of the issues we run into as developers, but since each unit test only looks at a small piece of code, they don't help determine whether or not the entire system is behaving as expected.

Integration tests will look at how different parts of a system work together. End-to-end tests will automate an entire process from beginning to end to ensure it behaves as expected. These types of tests might also include things like external dependencies like databases that aren't strictly part of your code.

Sometimes it simply isn't possible to write good unit tests for a piece of code because it relies on legacy or external code that doesn't support it. Integration testing can help cover those sorts of cases in addition to checking that the system all works together.

## Why Are They Important?

The biggest downside of unit tests is that they are painful and time consuming to write. You know what else is painful? Getting called in to work at 2 AM on a Saturday night to fix a bug in production.

There are several reasons why testing is an important part of a piece of software.

1. As mentioned, it reduces the number of bugs and "unintended features" that make it into the release builds. Tests can be added to bugs that do make it into the build so that you can prevent these issues from reoccuring.
2. It can highlight bad code design. It doesn't necessarily mean a piece of code is "good", but there are a lot of issues in code design that will be caught by using tests. Bad code is rarely easy to test.
3. It helps keep the project maintainable. Tests cost time up front, but over the life of a piece of software, they can definitely give a lot of return on that investment. Not only is your code quality likely to be higher, you will avoid things like regression bugs, which are bugs that got released, fixed, and have now popped up again.

## What Makes a Good Unit Test?

Not every unit test will have every property of a "good" test, but we want to hit as many points as possible.

## Test Driven Development: TDD

If you've been in the dev world long enough, you've probably met or read something about TDD. Particularly, that it is the only correct way to code and if you don't you are a bad developer.

The main issue with TDD is that it is *hard*, and in my opinion things like single use code won't benefit enough from this approach to make it worth it. The counterargument is that with practice it is possible to become quick enough with this method that it can be applied to anything.

The traditional TDD process is:

1. Create a test that checks for the desired outcome.
2. Run it and watch it fail.
3. Write the minimum amount of code required to get the test to pass, even if you know you need to expand it later.
4. Run the test again to make sure it passes.
5. Refactor if needed to clean up the code.
