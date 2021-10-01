using System.Runtime.CompilerServices;
using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Model_Section_SetPaths
    {
        [Test]
        public void Should_Set_Path()
        {
            var section = new Section(Direction.Right, Direction.Left, SectionType.Start);
            Assert.AreNotEqual(null, section.LeftPath.X);
        }
    }
}