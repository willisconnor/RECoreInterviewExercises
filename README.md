# Interview Exercises

Welcome, and thanks for taking the time to work through this project.

The repository contains three small, independent exercises written in C#. Each one has a class with methods that are not implemented yet, plus a set of xUnit tests that describe the expected behaviour. Your job is to make the tests pass, add a few tests of your own, and leave the code in a state you would be happy to have reviewed by a teammate.

There are no trick questions. We're interested in how you approach a problem, how you check your work, and how clearly you explain your decisions.

---

## Getting started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An editor or IDE of your choice (Visual Studio, VS Code, Rider, etc.)

### Build and run the tests

From the repository root:

```bash
dotnet build
dotnet test
```

All tests fail at first because the methods throw `NotImplementedException`. That's expected.

To run the tests for one exercise only:

```bash
dotnet test --filter "FullyQualifiedName~PalindromeChecker"
dotnet test --filter "FullyQualifiedName~PermissionsEvaluator"
dotnet test --filter "FullyQualifiedName~InMemoryEventBus"
```

### Project layout

```
InterviewExercises/
├── PalindromeChecker/
│   ├── PalindromeChecker.cs          <- implement IsPalindrome
│   └── PalindromeCheckerTests.cs
├── PermissionsEvaluator/
│   ├── PermissionEvaluator.cs        <- implement IsAllowed
│   └── PermissionEvaluatorTests.cs
├── InMemoryEventBus/
│   ├── EventBus.cs                   <- implement Subscribe and Publish
│   └── EventBusTests.cs
├── InterviewExercises.csproj
└── InterviewExercises.sln
```

---

## The exercises

We suggest doing them in the order below. Each one builds on slightly different skills.

### 1. Palindrome Checker

**File:** `PalindromeChecker/PalindromeChecker.cs`

Implement `PalindromeChecker.IsPalindrome(string value)`, which returns `true` if the input reads the same forwards and backwards.

**Requirements**

- Ignore letter casing (`"Racecar"` is a palindrome).
- Ignore anything that is not a letter or digit, such as spaces and punctuation (`"A man, a plan, a canal: Panama!"` is a palindrome).
- An empty string, or a string with no letters or digits, counts as a palindrome.
- Passing `null` throws an `ArgumentNullException`.

**Add at least two tests of your own**, for example for inputs containing digits, or for even-length versus odd-length palindromes.

### 2. Permissions Evaluator

**File:** `PermissionsEvaluator/PermissionEvaluator.cs`

A `PermissionEvaluator` is created with a list of `Permission` records. Each record grants one **user** permission to perform one **action** on one **resource**.

Implement `IsAllowed(string user, string resource, string action)`.

**Requirements**

- Return `true` only when a permission exists that matches the user, resource **and** action exactly.
- Return `false` otherwise. Nothing is allowed by default.
- Matching is case-sensitive (`"Alice"` and `"alice"` are different users).

**Add at least two tests of your own**, for example:

- An evaluator created with no permissions.
- A user who has several permissions, where only one of them matches.

### 3. In-Memory Event Bus

**File:** `InMemoryEventBus/EventBus.cs`

An event bus lets one part of an application publish an event without knowing which other parts are interested in it. Implement a simple in-memory version.

- `Subscribe<TEvent>(Action<TEvent> handler)` registers a handler for events of type `TEvent`.
- `Publish<TEvent>(TEvent @event)` invokes every handler subscribed to `TEvent`, passing the event to it.

**Requirements**

- A handler receives only events of the type it subscribed to.
- An event type can have **more than one** handler, and every one of them is invoked.
- Handlers run in the order they were subscribed.
- Publishing an event with no subscribers does nothing and doesn't throw.

**Add tests that cover each requirement above.** The provided test covers only the single-handler case.

---

## Optional extensions

These are not required. If you finish early and want to go further, pick **one** that interests you. Correct, tested, readable core work matters more to us than attempting extensions.

- **Palindrome Checker:** handle the input without allocating a new string (for example with two indexes moving towards each other).
- **Permissions Evaluator:** support a wildcard `"*"` for resource and/or action (for example, `Permission("alice", "reports", "*")` lets Alice perform any action on reports). Document what you decided about edge cases.
- **Event Bus:** add a way to unsubscribe a handler, and decide what should happen if one handler throws an exception while others are still waiting to run.

---

## Guidelines

- **Time:** aim for about **90 minutes**. Please don't spend more than 2 hours. If you run out of time, stop and write down what you would do next.
- **Scope:** only change the files listed above and their test files. You don't need to add NuGet packages. The standard library is enough.
- **Public API:** keep the existing method signatures, since the provided tests depend on them.
- **Resources:** you can use documentation and search engines as you would on the job. If you use AI tools, tell us where and how, and be ready to explain every line you submit.
- **Commits:** if you're working in Git, small commits with clear messages are welcome but not required.

## What we look for

- All provided tests pass, and your own tests cover the requirements and the edge cases.
- The code is easy to read: clear names, small methods, no unnecessary complexity.
- Inputs and edge cases are handled deliberately, not by accident.
- You can explain why you chose your approach, and what you would change with more time.

## Submitting your work

1. Make sure `dotnet test` passes.
2. Add a short `NOTES.md` file to the repository root covering:
   - Any assumptions you made where the requirements were unclear.
   - Trade-offs or alternatives you considered.
   - Anything you didn't finish, or would improve with more time.
   - Roughly how long you spent.
3. Send the repository back as a zip file (without the `bin/` and `obj/` folders) or as a link to a Git repository, whichever you prefer.

In the follow-up conversation, we'll walk through your solution together. You may be asked to make a small change live, so make sure you're comfortable with the code you submit.

Good luck, and have fun!
