using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;

namespace Checkers
{
    public class ChallengeObjects
    {
        public List<Tuple<string, string>> fighters;
        public ChallengeObjects()
        {
            //provides fighters combinations
            fighters = GetFighters();
        }

        public List<Tuple<string, string>> GetFighters()
        {
            var dlls = Directory.GetFiles("DLLS").ToList();
            var result = new List<Tuple<string, string>>();
            var temp = "fighter";
            var used = new HashSet<Tuple<string, string>>();
            foreach (var first in dlls)
            {
                temp = first;
                foreach (var second in dlls)
                {
                    if (temp != second )
                    {
                        result.Add(new Tuple<string, string>(temp, second));
                        used.Add(new Tuple<string,string>(temp, second));
                        used.Add(new Tuple<string,string>(second, temp));
                    }
                }
            }
            return result;
        }

    }

    class Program1
    {
        static void Main(string[] args)
        {
            var gamesCount = 9;
            var challenge = new ChallengeObjects();
            foreach (var e in challenge.fighters)
            {
                var process = new Process();
                process.StartInfo.FileName = "Checkers.Tournament.exe";
                process.StartInfo.Arguments = e.Item1 + " " + e.Item2;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                //дописать тле -
                //рантаймы дописать -
                //по памяти тоже поставить барьерчик -
                //прописать из стандартного аутпута -
                Console.WriteLine(e.Item1 + " " + e.Item2);
                Console.WriteLine(process.StandardOutput.ReadLine());
            }
            Console.ReadKey();
        }
    }
}
