using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FindWords
{
    internal class Program
    {
        static void Main()
        {

            Regex regex = new Regex("\\b(\\w{3,20})\\b");
            MatchCollection matchCollection = regex.Matches(GetText("Введите свой путь"));

            string[] unique = matchCollection.Cast<Match>().Select(x => x.Value).Distinct().OrderBy(y => y).ToArray();
            int[] count = new int[unique.Length];

            for(int i = 0; i < unique.Length; i++)
            { 
                foreach (Match match in matchCollection)
                {
                    if (unique[i] == match.ToString())
                    {
                        count[i] += 1;
                        
                    }
                }
                Console.WriteLine("{0} - {1}", i, unique.Length);
            }

            Console.Clear();
            Array.Sort(count, unique);
            Array.Reverse(unique);
            Array.Reverse(count);
            if(unique.Length > 50)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("Word: {0} - Count: {1}", unique[i], count[i]);
                }
            }
            else
            {
                for (int i = 0; i < unique.Length; i++)
                {
                    Console.WriteLine("Word: {0} - Count: {1}", unique[i], count[i]);
                }
            }
        }

        static string GetText(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
