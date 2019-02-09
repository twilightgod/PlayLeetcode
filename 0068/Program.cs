using System;
using System.Collections.Generic;
using System.Text;

namespace _0068
{
    public class Solution
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var answer = new List<string>();
            var start = 0;
            var lineLength = words[0].Length;

            for (var i = 1; i <= words.Length; ++i)
            {
                // last line or it's too long to include words[i] for this line, then create a line for words[start ... i - 1]
                if (i == words.Length || lineLength + 1 + words[i].Length > maxWidth)
                {
                    var sb = new StringBuilder();
                    var slot = i - 1 - start;
                    // avoid divide by zero for single word
                    if (slot == 0)
                    {
                        slot = 1;
                    }
                    // total space need to append
                    var space = maxWidth - (lineLength - slot);
                    var spacePerSlot = space / slot;
                    var spaceLeft = space % slot;

                    // last line
                    if (i == words.Length)
                    {
                        spacePerSlot = 1;
                        spaceLeft = 0;
                    }

                    for (var j = start; j < i; ++j)
                    {
                        if (j > start)
                        {
                            for (var k = 0; k < spacePerSlot; ++k)
                            {
                                sb.Append(' ');
                            }
                            if (spaceLeft-- > 0)
                            {
                                sb.Append(' ');
                            }
                        }
                        sb.Append(words[j]);
                    }

                    // append spaces for last line or single word
                    for (var j = sb.Length; j < maxWidth; ++j)
                    {
                        sb.Append(' ');
                    }

                    answer.Add(sb.ToString());

                    // reset
                    if (i != words.Length)
                    {
                        start = i;
                        lineLength = words[i].Length;
                    }
                }
                else
                {
                    lineLength += (1 + words[i].Length);
                }
            }

            return answer;
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
