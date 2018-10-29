using System;
using System.Collections.Generic;
using System.Linq;

namespace _0911
{
    public class TopVotedCandidate
    {
        Dictionary<int, (int vote, int lastTime)> personProfiles = new Dictionary<int, (int vote, int lastTime)>();
        SortedSet<(int vote, int lastTime, int p)> elections = new SortedSet<(int vote, int lastTime, int p)>(Comparer<(int vote, int lastTime, int p)>.Create((a, b) => a.vote == b.vote ? -a.lastTime.CompareTo(b.lastTime) : -a.vote.CompareTo(b.vote)));
        List<int> winner = new List<int>();
        List<int> time = new List<int>();
        int n = 0;

        public TopVotedCandidate(int[] persons, int[] times)
        {
            n = persons.Length;
            for (var i = 0; i < n; ++i)
            {
                time.Add(times[i]);
                var p = persons[i];
                if (!personProfiles.ContainsKey(p))
                {
                    personProfiles.Add(p, (0, -1));
                }
                var personInfo = personProfiles[p];
                var oldKey = (personInfo.vote, personInfo.lastTime, p);
                if (elections.Contains(oldKey))
                {
                    elections.Remove(oldKey);
                }
                var newKey = (vote: personInfo.vote + 1, lastTime: i, p: p);
                elections.Add(newKey);
                personProfiles[p] = (newKey.vote, newKey.lastTime);
                winner.Add(elections.First().p);
            }
        }

        public int Q(int t)
        {
            var l = 0;
            var r = n;
            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (time[m] > t)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            l--;
            //Console.WriteLine(l);
            return winner[l];
        }
    }

    /**
     * Your TopVotedCandidate object will be instantiated and called as such:
     * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
     * int param_1 = obj.Q(t);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
