using System;
using System.Collections.Generic;

namespace _0282
{
    public class Solution
    {
        public IList<string> AddOperators(string num, int target)
        {
            var answers = new List<string>();
            DFS(num, target, 0, answers, String.Empty, 0, 0);
            return answers;
        }

        private void DFS(string num, int target, int nextIndex, List<string> answers, string answer, long answerResult, long previousResult)
        {
            if (num.Length == nextIndex)
            {
                if (answerResult == target)
                {
                    answers.Add(answer);
                }
                return;
            }
            // loop through how many digits are been using in this stage
            // loop through all 3 operations, +, -, *.
            for (var i = nextIndex; i < num.Length; ++i)
            {
                var n = Int64.Parse(num.Substring(nextIndex, i - nextIndex + 1));
                // handle 0... case
                if (n.ToString().Length != i - nextIndex + 1)
                {
                    break;
                }

                // +
                {
                    var nextAnswer = (answer == String.Empty ? n.ToString() : answer + "+" + n.ToString());
                    var nextAnswerResult = answerResult + n;
                    var nextPreviousResult = n;
                    DFS(num, target, i + 1, answers, nextAnswer, nextAnswerResult, nextPreviousResult);
                }
                // -
                if (answer != String.Empty)
                {
                    var nextAnswer = answer + "-" + n.ToString();
                    var nextAnswerResult = answerResult - n;
                    var nextPreviousResult = -n;
                    DFS(num, target, i + 1, answers, nextAnswer, nextAnswerResult, nextPreviousResult);
                }
                // *
                if (answer != String.Empty)
                {
                    var nextAnswer = answer + "*" + n.ToString();
                    // e.g. 1 + 2 * 3
                    var nextAnswerResult = answerResult - previousResult + previousResult * n;
                    var nextPreviousResult = previousResult * n;
                    DFS(num, target, i + 1, answers, nextAnswer, nextAnswerResult, nextPreviousResult);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
