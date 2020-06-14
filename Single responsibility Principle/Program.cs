using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_responsibility_Principle
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            string stringview= string.Join(Environment.NewLine, entries); 
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
    class Program
    {    
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Nguyen Tuan Ngoc");
            j.AddEntry("Nguyen Thi Truong Giang");
            j.AddEntry("I ate a bug");
            j.AddEntry("I love money");
            Console.WriteLine(j);
            var p = new Persistence();
            var filename = @"D:\Test\journal.txt";
            p.SaveToFile(j, filename,true);
            Process.Start(filename);
            Console.ReadKey();

        }
    }
}
