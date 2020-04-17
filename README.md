# Toy Robot Simulator
A code test project for Jetstar in 2017

Development Environment:
    Visual Studio Community 2017 for Mac
    .Net Core 2.0
    C# 7
    xUnit
    GitHub

Main design patterns:
    Command pattern
    Dependency Injection

Highlights:
    TDD
    SOLID
    C# 7 [ codes in Invoker class in Robots.Commands project]

NB: althought this project was implemented by partly using TTD, the Robots.Models project was not totally realised 
    by TDD as xUnit does not work currently in this project.
    after all test cases were developed, ToyRobot class could not be tested by those test cases.

Solution Instructions
    Entrances.Prompt        -> A console project, the startup project of this solution.
                                Supports a User Interface to get commands from the input

    Frameworks.Exceptions   ->  Define all customs exception and default actions for exceptions

    Frameworks.Logging      ->  Define logging mechanism.

    Robots.Actions          ->  Define all possible actions of what robots are able to do,
                                such as, moveforward, turnleft or report etc.

    Robots.Commands         ->  Private all valid commands the system defined.
                                And also define what actions would be used to respond for.

    Robots.Common           ->  The common properties of robots.

    Robots.Models           ->  Define the baseclass for all robots.
                                Define a particular robot model[ToyRobot]

    Robots.Responses        ->  This class is used to support common responses for robot actions interface.
                                Differenct robot models could have differenct response for a same action.
                                For example, the MoveForward action in IMovable interface, the toyrobot
                                calls MoveForwardOneStep to move one step, while other robots could move more
                                steps. And antoher robot may also calls MoveForwardOneStep to respond to MoveForward action.

    Robots.Surfaces         ->  Define positioin-related information,
                                such as surface size and position class

    UnitTests.RobotModels   ->  Private all unit testcases for Robot.Models project.
                                Currently just developed ToyRobot-related test cases.
