using System;
using System.Diagnostics;
using Xunit;
using Robots.Common;
using Robots.Models;
using Frameworks.Exceptions;
using Robots.Surfaces;

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
            Exception ex = Assert.Throws<SafeException>(() => robot.Place(new RobotPosition { X = positionX, Y = positionY, Direction = direction }));

            Assert.Equal("the robot cannot place to expected postion", ex.Message);
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

            Exception ex = Assert.Throws<SafeException>(() => robot.Place(new RobotPosition { X = positionX, Y = positionY, Direction = direction }));

            Assert.Equal("the robot cannot place to expected postion", ex.Message);
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
        public void ReportPosition_WhenStatusIsOff()
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);

            Exception ex = Assert.Throws<SafeException>(() => robot.ReportPosition());

            Assert.Equal("please place this robot first", ex.Message);
        }
        
        [Fact]
        public void Move_WhenStatusIsOff()
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);

            Exception ex = Assert.Throws<SafeException>(() => robot.MoveForward());

            Assert.Equal("please place this robot first", ex.Message);
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
        [InlineData(CompassDirections.EAST, 0, 0, 1, 0)]
        [InlineData(CompassDirections.SOUTH, SURFACESIZE, SURFACESIZE, SURFACESIZE, SURFACESIZE - 1)]
        [InlineData(CompassDirections.WEST, SURFACESIZE, SURFACESIZE, SURFACESIZE - 1, SURFACESIZE)]
        public void Move_WhenStatusIsOn_AtBoundary_ValidMovement(CompassDirections currentDirection, int currentPositionX, int currentPositionY, int expectedPositionX, int expectedPositionY)
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
        [InlineData(CompassDirections.SOUTH, 0, 0)]
        [InlineData(CompassDirections.WEST, 0, 0)]
        [InlineData(CompassDirections.NORTH, SURFACESIZE, SURFACESIZE)]
        [InlineData(CompassDirections.EAST, SURFACESIZE, SURFACESIZE)]
        [InlineData(CompassDirections.SOUTH, 2, 0)]
        [InlineData(CompassDirections.NORTH, 2, SURFACESIZE)]
        public void Move_WhenStatusIsOn_AtBoundary_InValidMovement(CompassDirections currentDirection, int currentPositionX, int currentPositionY)
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);
            robot.Place(new RobotPosition { X = currentPositionX, Y = currentPositionY, Direction = currentDirection });

            Exception ex = Assert.Throws<SafeException>(() => robot.MoveForward());

            Assert.Equal("please place this robot first", ex.Message);
        }

        [Fact]
        public void Left_WhenStatusIsOff()
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);

            Exception ex = Assert.Throws<SafeException>(() => robot.RotateToLeft());

            Assert.Equal("please place this robot first", ex.Message);
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

        [Fact]
        public void Right_WhenStatusIsOff()
        {
            var robot = new ToyRobot(new TableSurface(), _exceptionFactory);

            Exception ex = Assert.Throws<SafeException>(() => robot.RotateToRight());

            Assert.Equal("please place this robot first", ex.Message);
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
