## Assumptions I made:
1. In the Palindrome and PermissionsEvaluator test classes, I generally assumed that the inline data format was for further test cases. I am not too familiar with this style of testing, but it was easy enough to pick up.
2. I assumed the permissions checker problem is would in practice be treated with a SQL search of a database of some kind, so I approached the problem as such. This meant that I also treated the test cases as rows in some kind of users database. Very similar to the Role Based Access control I worked on as a part of a recent project.

## Trade-offs or alternatives considered:
Most of my thinking for these exercises was pretty linear. Although I technically implemented the "optional" implementation of the palindrome exercise, it was the first optiion that my mind went to. The solution I did not go with would be very similar, just copying the string and reversing said copy, and iterating along the same indices and comparing.

## Improvements:
Most of my improvements would probably come in the third task, the EventBus. Admittedly, this took me quite a bit longer than the other two as I had to actually conceptualize the task for longer and didn't have any immediate answer jumping out at me. I would want to further optimize the problem, as I have a feeling that I could've have implemented it better. I'm not sure. I did use AI for this problem, but it was mainly to understand what was asked of me, and for some C# standard library syntax and methods I could employ.
