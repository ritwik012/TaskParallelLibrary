using System;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations ops = new Operations();
            string[] words = ops.CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            #region ParallelTasks
            Parallel.Invoke(
                   () =>
                   {
                       Console.WriteLine("Begin First Task ...");
                       ops.GetLongestWord(words);
                   },
                   () =>
                   {
                       Console.WriteLine("Begin Second Task ...");
                       ops.GetMostCommonWords(words);
                   },
                   () =>
                   {
                       Console.WriteLine("Begin Third Task ...");
                       ops.GetCountForWord(words, "sleep");
                   }
                );
            Console.WriteLine("Returned From Parallel.Invoke");
            #endregion
        }
    }
}