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
    public class VolleyballMatchTests
    {
        [Test]
        public void VolleyballCtorTest()
        {
            Team t1 = new Team("test1");
            Team t2 = new Team("test2");
            VolleyballMatch vm = new VolleyballMatch(t1, t2);
            Assert.Equals(0, t1.Points);
            t1.Points = 30;
            Assert.Equals(30, t1.Points);
        }
        [Test]
        public void VolleyballSecondCtorTest()
        {
            Team t1 = new Team("test1");
            Team t2 = new Team("test2");
            VolleyballMatch vm = new VolleyballMatch(t1, t2, "Półfinał");
            Assert.Equals("Półfinał", vm.Description);
        }
    }
}
