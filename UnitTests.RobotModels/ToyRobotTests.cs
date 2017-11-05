using System;
using Xunit;
using Robots.Surfaces;
using Robots.Models;
using Frameworks.Exceptions;
using Robots.Commands;
using Robots.Common;

namespace UnitTests.RobotModels
{
    public class ToyRobotTests
    {
        const int SURFACESIZE = 5;
        private ExceptionFactory _exceptionFactory = new ExceptionFactory();

        [Theory]
        [InlineData(CompassDirections.SOUTH, -1, -1)]
        [InlineData(CompassDirections.NORTH, -1, 1)]
        [InlineData(CompassDirections.EAST, SURFACESIZE + 1, SURFACESIZE + 1)]
        [InlineData(CompassDirections.NORTH, 4, SURFACESIZE + 1)]
        public void Place_WhenStatusIsOff_InvaliadPosition(CompassDirections direction, int positionX, int positionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = positionX, Y = positionY, Direction = direction });
            Assert.Equal(RobotStatus.Off, robot.Status);
        }

        [Theory]
        [InlineData(CompassDirections.SOUTH, 0, 0)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE, SURFACESIZE)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE, SURFACESIZE - 1)]
        public void Place_WhenStatusIsOff_ValiadPosition(CompassDirections direction, int positionX, int positionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = positionX, Y = positionY, Direction = direction });

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(positionX, robot.Position.X);
            Assert.Equal(positionY, robot.Position.Y);
            Assert.Equal(direction, robot.Position.Direction);
        }

        [Theory]
        [InlineData(CompassDirections.SOUTH, -1, -1)]
        [InlineData(CompassDirections.NORTH, -1, 1)]
        [InlineData(CompassDirections.EAST, SURFACESIZE + 1, SURFACESIZE + 1)]
        [InlineData(CompassDirections.NORTH, 4, SURFACESIZE + 1)]
        public void Place_WhenStatusIsOn_InvaliadPosition(CompassDirections direction, int positionX, int positionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = 2, Y = 2, Direction = CompassDirections.NORTH });
            robot.MoveForward();
            robot.Place(new RobotPosition { X = positionX, Y = positionY, Direction = direction });

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(positionX, 2);
            Assert.Equal(positionY, 3);
            Assert.Equal(direction, CompassDirections.NORTH);
        }

        [Theory]
        [InlineData(CompassDirections.SOUTH, 0, 0)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE, SURFACESIZE)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE, SURFACESIZE - 1)]
        public void Place_WhenStatusIsOn_ValiadPosition(CompassDirections direction, int positionX, int positionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = 2, Y = 2, Direction = CompassDirections.NORTH });
            robot.MoveForward();
            robot.Place(new RobotPosition { X = positionX, Y = positionY, Direction = direction });

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(positionX, robot.Position.X);
            Assert.Equal(positionY, robot.Position.Y);
            Assert.Equal(direction, robot.Position.Direction);
        }

        [Fact]
        public void Move_WhenStatusIsOff()
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.MoveForward();

            Assert.Equal(RobotStatus.Off, robot.Status);
        }

        [Theory]
        [InlineData(CompassDirections.NORTH, 1, 1, 1, 2)]
        [InlineData(CompassDirections.SOUTH, 1, 1, 1, 0)]
        [InlineData(CompassDirections.WEST, 1, 1, 0, 1)]
        [InlineData(CompassDirections.EAST, 1, 1, 2, 1)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE - 1, SURFACESIZE - 1, SURFACESIZE - 1, SURFACESIZE)]
        [InlineData(CompassDirections.SOUTH, SURFACESIZE - 1, SURFACESIZE - 1, SURFACESIZE - 1, 3)]
        [InlineData(CompassDirections.WEST, SURFACESIZE - 1, SURFACESIZE - 1, 3, SURFACESIZE - 1)]
        [InlineData(CompassDirections.EAST, SURFACESIZE - 1, SURFACESIZE - 1, SURFACESIZE, SURFACESIZE - 1)]
        [InlineData(CompassDirections.NORTH, 2, 3, 2, SURFACESIZE - 1)]
        [InlineData(CompassDirections.SOUTH, 2, 3, 2, 3)]
        [InlineData(CompassDirections.WEST, 2, 3, 1, 3)]
        [InlineData(CompassDirections.EAST, 2, 3, 3, 3)]
        public void Move_WhenStatusIsOn_InBoundary(CompassDirections currentDirection, int currentPositionX, int currentPositionY, int expectedPositionX, int expectedPositionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = currentPositionX, Y = currentPositionY, Direction = currentDirection });
            robot.MoveForward();

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(expectedPositionX, robot.Position.X);
            Assert.Equal(expectedPositionY, robot.Position.Y);
            Assert.Equal(currentDirection, robot.Position.Direction);
        }

        [Theory]
        [InlineData(CompassDirections.NORTH, 0, 0, 0, 1)]
        [InlineData(CompassDirections.SOUTH, 0, 0, 0, 0)]
        [InlineData(CompassDirections.WEST, 0, 0, 0, 0)]
        [InlineData(CompassDirections.EAST, 0, 0, 1, 0)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE, SURFACESIZE, SURFACESIZE, SURFACESIZE)]
        [InlineData(CompassDirections.SOUTH, SURFACESIZE, SURFACESIZE, SURFACESIZE, SURFACESIZE - 1)]
        [InlineData(CompassDirections.WEST, SURFACESIZE, SURFACESIZE, SURFACESIZE - 1, SURFACESIZE)]
        [InlineData(CompassDirections.EAST, SURFACESIZE, SURFACESIZE, SURFACESIZE, SURFACESIZE)]
        [InlineData(CompassDirections.SOUTH, 2, 0, 2, 0)]
        [InlineData(CompassDirections.NORTH, 2, SURFACESIZE, 2, SURFACESIZE)]
        public void Move_WhenStatusIsOn_AtBoundary(CompassDirections currentDirection, int currentPositionX, int currentPositionY, int expectedPositionX, int expectedPositionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = currentPositionX, Y = currentPositionY, Direction = currentDirection });
            robot.MoveForward();

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(expectedPositionX, robot.Position.X);
            Assert.Equal(expectedPositionY, robot.Position.Y);
            Assert.Equal(currentDirection, robot.Position.Direction);
        }

        [Theory]
        [InlineData(CompassDirections.NORTH, CompassDirections.NORTH)]
        [InlineData(CompassDirections.EAST, CompassDirections.EAST)]
        [InlineData(CompassDirections.SOUTH, CompassDirections.SOUTH)]
        [InlineData(CompassDirections.WEST, CompassDirections.WEST)]
        public void Left_WhenStatusIsOff(CompassDirections currentDirection, CompassDirections expectedDirection )
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.RotateToLeft();

            Assert.Equal(RobotStatus.Off, robot.Status);
        }

        [Theory]
        [InlineData(CompassDirections.NORTH, CompassDirections.WEST)]
        [InlineData(CompassDirections.WEST, CompassDirections.SOUTH)]
        [InlineData(CompassDirections.SOUTH, CompassDirections.EAST)]
        [InlineData(CompassDirections.EAST, CompassDirections.NORTH)]
        public void Left_WhenStatusIsOn(CompassDirections currentDirection,CompassDirections expectedDirection)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = 2, Y = 3, Direction = currentDirection });
            robot.RotateToLeft();

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(expectedDirection, robot.Position.Direction);
        }

        [Theory]
        [InlineData(CompassDirections.NORTH, CompassDirections.NORTH)]
        [InlineData(CompassDirections.EAST, CompassDirections.EAST)]
        [InlineData(CompassDirections.SOUTH, CompassDirections.SOUTH)]
        [InlineData(CompassDirections.WEST, CompassDirections.WEST)]
        public void Right_WhenStatusIsOff(CompassDirections currentDirection, CompassDirections expectedDirection)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.RotateToRight();

            Assert.Equal(RobotStatus.Off, robot.Status);
        }

        [Theory]
        [InlineData(CompassDirections.NORTH, CompassDirections.EAST)]
        [InlineData(CompassDirections.EAST, CompassDirections.SOUTH)]
        [InlineData(CompassDirections.SOUTH, CompassDirections.WEST)]
        [InlineData(CompassDirections.WEST, CompassDirections.NORTH)]
        public void Right_WhenStatusIsOn(CompassDirections currentDirection, CompassDirections expectedDirection)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = 2, Y = 3, Direction = currentDirection });
            robot.RotateToRight();

            Assert.Equal(RobotStatus.On, robot.Status);
            Assert.Equal(expectedDirection, robot.Position.Direction);
        }
    }
}
