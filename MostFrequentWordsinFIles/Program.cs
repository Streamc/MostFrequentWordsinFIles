using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MostFrequentWordsinFIles
{
    class Program

    {

        static void Main(string[] args)
        {

            string sourceone = null;
            string filepath = @"D:\test";
            foreach (string file in Directory.EnumerateFiles(filepath, "*.txt"))
            {
                string contents = File.ReadAllText(file);
                sourceone += "\t"; // можно и лучше. но по факту получается больше символов
                sourceone += contents;


            }


            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            int highestFreq = 0;
            string combinedString = string.Join(" ", sourceone);

            MatchCollection matches = Regex.Matches(sourceone, @"\b\w+\b"); //any word character 


            foreach (Match match in matches)
            {
                string word = match.Value;

                frequencies.TryGetValue(word, out int freq);
                freq += 1;
                if (freq > highestFreq)
                {
                    highestFreq = freq;
                }
                frequencies[word] = freq;
            }

            List<string> highestWords = frequencies.Where(x => x.Value == highestFreq).Select(x => x.Key).ToList();
            var highestWords5 = frequencies.Where(x => x.Value == highestFreq).Select(x => x.Key).ToList();
            List<KeyValuePair<string, int>> select10 = frequencies.OrderByDescending(key => key.Value).Take(10).ToList();
            Console.WriteLine("Highest freq: {0}", highestFreq);

            foreach (var word in select10)
            {
                Console.WriteLine(word);
            }

        }
    }
}
