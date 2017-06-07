using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csUnit;
using Tournament_Manager;

namespace Tournament_Manager_Tests
{
    [TestFixture]
    public class TeamTests
    {
        [Test]
        public void TeamCtorTest()
        {
            Team team = new Team("Asd");
            Assert.Equals(0, team.Points);
            team.Points += 3;
            Assert.Equals(3, team.Points);
            team.Name = "Dsa";
            Assert.Equals("Dsa", team.Name);
        }
    }
}
