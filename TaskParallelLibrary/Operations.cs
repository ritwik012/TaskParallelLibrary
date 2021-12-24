using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;

namespace TaskParallelLibrary
{
    public class Operations
    {
        #region HelperMethods
        public string[] CreateWordArray(string url)
        {
            Console.WriteLine($"Retrieving from {url}");
            string s = new WebClient().DownloadString(url);
            return s.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words orderby w.Length descending select w).First();
            Console.WriteLine($"Task 1 --- The  Longest Word is {longestWord}");
            return longestWord;
        }
        public void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from w in words where w.Length > 6 group w by w into g orderby g.Count() descending select g.Key;
            var commonWords = frequencyOrder.Take(10);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 --- The Most Common words are : ");
            foreach (var v in commonWords)
            {
                sb.AppendLine(" " + v);
            }
            Console.WriteLine(sb.ToString());
        }
        public void GetCountForWord(string[] words, string term)
        {
            var findWord = from w in words where w.ToUpper().Contains(term.ToUpper()) select w;
            Console.WriteLine($@"Task 3 --- The Word ""{term}"" occurs {findWord.Count()} times");
        }
        #endregion
    }
}