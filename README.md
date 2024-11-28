# Colour Sort Solver

## Overview

I was playing one of those colour sorting games on my phone and thought it would be an interesting challenge to write an application which could solve it.

Most of them follow the same format where you move colours from one container to another until each container is full with the same colour.  

Rules
- A colour(s) can be moved to an empty container.
- A colour(s) can be moved a container where the top most colour is the same and there is enough space for the colour(s)
- When the source container has multiple instance of the same colour then all are moved. If enough space in target container.

This is a simple console application in C# which can solve these colour puzzle.  The application will output the minimum number of steps required to solve the game, if possible.

I have put here on GitHub as a public repository for general interest and example of my coding style.  Feel free to use or suggest improvements.

## Design
I didn't want to just use some solution on the internet so I decided to write my own.  I knew a brute force approach would not work for anything but the smallest puzzle.  I knew I would have to use a back track approach.
From an initial puzzle layout I determine the avaialble moves and then apply the first one storing it and remaining moves on a stack. I then get all the available moves for this new layout, apply the first one and store the rest on the stack again. This is repeated until there no valid moves left. At which point I get the last entry from the stack and use the first of the saved moves and updating the stack with the reduced list of remaining moves.
If a solution is found, it is recorded and the number of moves taken stored.  I then back track two moves and begin looking for more solutions.  I am now only interested in solutions with fewer moves so I can stop seaching any path that would result in same or more moves. Eventually it will complete having found the quickest solution.

## Unit/Developer Testing
One of my goals was to write all the tests using a better naming convention.  I find the When Should Then approach to test names limiting and cumbersome. I wanted the stucture of the tests in the project and test runner to be simpler and clearer. I have created a folder for each Subject Under Test and test class for each method or logically grouped functions. As this give each test much better context in terms of namespace and class name the test names themselves are much clearer. I have used a simple convention of separating the desciption of the test from the expected result with an underscope.  
For example:

The tests for the IsEmpty property in the Container class are in the ContainerTests folder and the IsEmptyTests class. 
```
ContainerTests.IsEmptyTests.SlotCountIsZero_ReturmsTrue
ContainerTests.IsEmptyTests.SlotCountIsGreaterThanZero_ReturmsFalse
```
Using the Project, Namespace, class grouping in the test runners makes it much easier to find the tests you are looking for.  It also fits with the hierarchical nature of the Unit Test Coverage view used by DotCover

When modifying the code or checking the coverage you can quickly identify the class where you need to add additional tests.


## Usage
Either use the unit tests or run the application passing the name of .json file containing the puzzle layout. See the unit tests for example layouts.

## Performance
I have tested it on increasingly larger puzzles. Small puzzles with a few containers and colours are solved in a few seconds.  Larger puzzles with more colours and containers can take a few to several minutes.  There is room for optimization and you can sometimes get into scenarios where it appears to continually doing the same sequence of moves.  I do check if exactly the same move has been made previously during the current set of moves and back track if it has.  I need to spend some more time analysing the moves.
