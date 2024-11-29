# Colour Sort Solver

## Overview

I was playing one of those colour sorting games on my phone and thought it would be an interesting challenge to write an application which could solve it.

Most of the puzzles follow the same format where you move coloured items from one container to another until all the items of the same colour are together.  

```
|Green| | Red | |Green|      | Red | |Green| |Blue |
| Red | |Blue | |Blue |  =>  | Red | |Green| |Blue |
|Blue | | Red | |Green|      | Red | |Green| |Blue |
```

Rules
- A colour(s) can be moved to an empty container.
- A colour(s) can be moved a container where the top most colour is the same and there is enough space for the colour(s)
- When the source container has multiple items of the same colour then all are moved. (If there is enough space).

This is a simple console application in C# which can solve these colour puzzle.  It reads in a .json file and outputs the minimum number of steps required to solve the game, if possible.

I have put here on GitHub as a public repository for general interest and example of my coding style.  Feel free to use or suggest improvements.

## Design
I could just use some solution on the internet but I wanted have a go at writing my own. It is not the type of problem I have written a solution for before so it would be an intresting challenge.  
I knew a brute force approach would not work for anything but the smallest puzzle.  I knew about using a back track algorithm for solving these types of puzzle.

From an initial puzzle layout I determine the available moves and then apply the first one storing it and remaining moves on a stack. No I have a new layout, I repeat the process until there no valid moves left. At which point I retrieve the availabe moves from the previous round and repeat the processes.
If a solution is found, it is recorded and the number of moves taken stored.  I then back track two moves and begin looking for more solutions.  I am now only interested in solutions with fewer moves so I can stop seaching any path that would result in same or more moves. Once complete I found the quickest solution.

## Unit/Developer Testing
One of my goals was to write all the tests using a better naming convention.  I find the Given..When..Then or ..Should.. approaches to test names limiting and cumbersome. I wanted the stucture of the tests in the project and test runner to be simpler and clearer. 
Any naming convention that starts with the same prefix always messes up any sorting and makes list difficult to read.  I wanted to keep the test classes small and discrete.
I created a folder for each Subject Under Test and test class for each method or logically grouped functions. As this give each test much better context in terms of namespace and class name the test names themselves can be much clearer. I have used a simple convention of separating the desciption of the test from the expected result with an underscope.  
For example:

The tests for the IsEmpty property in the Container class are in the ContainerTests folder and the IsEmptyTests class. 
The tests names don't need to be cluttered with anything about the method or class being tested.  The test names are simply the condition being tested and the expected result.  
For example:
```
ContainerTests.IsEmptyTests.SlotCountIsZero_ReturmsTrue
ContainerTests.IsEmptyTests.SlotCountIsGreaterThanZero_ReturmsFalse
```
Using the Project, Namespace, class grouping in the test runners makes it much easier to find the tests you are looking for.  It also fits with the hierarchical nature of the Unit Test Coverage view used by DotCover

When modifying the code or checking the coverage you can quickly identify the class where you need to add additional tests.


## Usage
Either use the unit tests or run the application passing the name of .json file containing the puzzle layout. See the unit tests for example layouts.

## Performance
I have tested it on a small range of puzzles. Small puzzles with up to 4 containers and 4 colours are solved in less than second.  Larger puzzles with more colours and containers can take 10s of seconds to a few minutes. It varies greatly depending on the initial start configuration and the number of empty containers available.
The number of moves which are tested can quickly run into millions.  I have optimized the routine so it checks for duplicate moves or repeated layouts.  This has greatly reduced the number of moves that need to be checked. The time taken to find the first solution is often a few milliseconds and within a few seconds 3 to 5 more are found. In most cases no new solutions are found and most of the time appears to be checking all the possible moves. After that the time take grows exponentially. The ten and twelve colour examples take hours. I need to analyse these runs and determine any additional optimizations.

## Conclusion

As a solution to solving these puzzle it works well if you are only interested a possible solution.  As means of finding the quickest solution it is only viable for the smaller puzzles.
It has been an interesting task and I am happy with naming of the tests.  I will continue to use this naming convention in future projects.  Possible future enhancements are to add a GUI to display the progress or at least animate the solutions.

.
