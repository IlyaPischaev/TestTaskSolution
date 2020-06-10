using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTaskSolution.Tests
{
    [TestClass]
    public class TestTaskSolutionTests
    {
        [TestMethod]
        public void Solution_HostsList_AvailableHostsNumbers_1()
        {
            string[] allHosts = { "unlock.microvirus.md", "visitwar.com", "visitwar.de", "fruonline.co.uk", "australia.open.com", "credit.card.us" };
            string[] blockedHosts = { "microvirus.md", "visitwar.de", "piratebay.co.uk", "list.stolen.credit.card.us" };
            int[] expected = new int[] { 1, 3, 4, 5 };

            int[] actual = Solution.solution(allHosts, blockedHosts);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solution_HostsList_AvailableHostsNumbers_2()
        {
            string[] allHosts = { "new.site.com", "old.site.com", "this.is.new.site.com", "this.is.old.site.com", "new.domen.com", "old.domen.ru", "best.domen.ru" };
            string[] blockedHosts = { "old.site.com", "ru" };
            int[] expected = new int[] { 0, 2, 4 };

            int[] actual = Solution.solution(allHosts, blockedHosts);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
