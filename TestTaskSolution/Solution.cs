using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskSolution
{
    public class Solution
    {
        public static int[] solution(string[] allHosts, string[] blockedHosts)
        {
            Dictionary<string, HashSet<int>> allHostsWithParent = new Dictionary<string, HashSet<int>>();
            HashSet<int> blockedHostsNumbers = new HashSet<int>();
            List<int> availableHostsNumbers = new List<int>();

            for (int hostIndex = 0; hostIndex < allHosts.Length; hostIndex++)
            {
                string tempString = String.Empty;

                DictionaryHostCheck(allHostsWithParent, allHosts[hostIndex], hostIndex);

                for (int symbolIndex = 0; symbolIndex < allHosts[hostIndex].Length; symbolIndex++)
                {
                    if (allHosts[hostIndex][symbolIndex] == '.')
                    {
                        tempString = allHosts[hostIndex].Substring(symbolIndex + 1);
                        DictionaryHostCheck(allHostsWithParent, tempString, hostIndex);
                    }
                }
            }

            for (int hostIndex = 0; hostIndex < blockedHosts.Length; hostIndex++)
            {
                if (allHostsWithParent.ContainsKey(blockedHosts[hostIndex]))
                {
                    blockedHostsNumbers.UnionWith(allHostsWithParent[blockedHosts[hostIndex]]);
                }
            }

            for (int hostIndex = 0; hostIndex < allHosts.Length; hostIndex++)
            {
                if (!blockedHostsNumbers.Contains(hostIndex))
                {
                    availableHostsNumbers.Add(hostIndex);
                }
            }

            int[] availableHostsNumbersArray = availableHostsNumbers.ToArray();
            return availableHostsNumbersArray;
        }

        private static void DictionaryHostCheck(Dictionary<string, HashSet<int>> allHostsWithParent, string currentHost, int hostIndex)
        {
            if (allHostsWithParent.ContainsKey(currentHost))
            {
                allHostsWithParent[currentHost].Add(hostIndex);
            }
            else
            {
                HashSet<int> hostIndexAdded = new HashSet<int>() { hostIndex };
                allHostsWithParent.Add(currentHost, hostIndexAdded);
            }
        }
    }
}
