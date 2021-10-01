using System;
using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Model_Driver_GetTeamColorAsConsoleColor
    {
        private Driver _driver;
        
        [SetUp]
        public void SetUp()
        {
            _driver = new Driver("John", new Car(Qualities.Average, Performances.Normal), TeamColors.Green, "1");
        }

        [Test]
        public void Should_Get_Team_Color_As_Console_Color()
        {
            _driver.TeamColor = TeamColors.Blue;
            var color = _driver.GetTeamColorAsConsoleColor();
            Assert.AreEqual(color, ConsoleColor.Blue);
            
            _driver.TeamColor = TeamColors.Green;
            color = _driver.GetTeamColorAsConsoleColor();
            Assert.AreEqual(color, ConsoleColor.Green);
            
            _driver.TeamColor = TeamColors.Red;
            color = _driver.GetTeamColorAsConsoleColor();
            Assert.AreEqual(color, ConsoleColor.Red);
            
            _driver.TeamColor = TeamColors.White;
            color = _driver.GetTeamColorAsConsoleColor();
            Assert.AreEqual(color, ConsoleColor.White);
            
            _driver.TeamColor = TeamColors.Yellow;
            color = _driver.GetTeamColorAsConsoleColor();
            Assert.AreEqual(color, ConsoleColor.Yellow);
        }
    }
}