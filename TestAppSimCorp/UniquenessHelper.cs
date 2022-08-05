using System;
using System.Collections.Generic;

namespace TestAppSimCorp
{
    public class UniquenessHelper
    {
        private char[] _delimiters = new char[] { ' ', ',', ';', '.', '!', '?', '\n', '\r', '-', '\u2012', '\u2013', '\u2014', '\u2015', '\u002d',
            '\u058a', '\u05be', '\u1400', '\u1806', '\u2010', '\u2011', '\u2012', '\u2013', '\u2014', '\u2015', '\ufe58', '\ufe63', '\uff0d',
            '<', '>', '?', '«', '»', ':' };

        public Dictionary<string, int> CalcOccurencesSafe(string input)
        {
            if (string.IsNullOrEmpty(input))
            { 
                Console.WriteLine($"{input} is incorrect");
                return new Dictionary<string, int>();
            }

            var words = input.ToLowerInvariant().Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length < 1)
            {
                return new Dictionary<string, int>();
            }

            return CalcOccurences(words);
        }

        private Dictionary<string, int> CalcOccurences(string[] words)
        {
            var occurrences = new Dictionary<string, int>(words.Length);

            foreach (string word in words)
            {
                if (occurrences.ContainsKey(word))
                {
                    occurrences[word]++;
                }
                else
                {
                    occurrences[word] = 1;
                }
            }

            return occurrences;
        }
    }
}
