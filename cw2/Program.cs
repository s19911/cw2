using System;
using System.IO;

namespace cw2
{
    class Program
    {
        public static void Main(string[] args)
        {
            string file = @"data\dane.csv";

            FileInfo f = new FileInfo(file);
            using (StreamReader stream = new StreamReader(f.OpenRead()))
            {
                string line = " ";
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            //stream.Dispose();
        }
    }
}
