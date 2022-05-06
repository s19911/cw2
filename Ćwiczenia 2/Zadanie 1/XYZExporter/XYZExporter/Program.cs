using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XYZExporter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var fileName = args[0];
            var outputFileName = args[1];
            var format = args[2];
            var sb = new StringBuilder();
            try{
                var lines = await File.ReadAllLinesAsync(fileName);
                var studenci = new List<Student>();
                foreach (var line in lines)
                {
                    var cells = line.Split(',');
                    if(cells.Length!=9){
                        sb.Append(line+"\n");
                        continue;
                    }
                    if(cells.Contains("")){
                        sb.Append(line+"\n");
                        continue;
                    }
                    studenci.Add(new Student(cells[0],cells[1],cells[2],cells[3],cells[4],cells[5],cells[6],cells[7],cells[8]));
                    Console.WriteLine(cells.Count());
                }
                var pj = new Uczelnia(studenci);
                Console.WriteLine(pj.studenci.Length);
                File.AppendAllText("log.txt",sb.ToString());
                File.WriteAllText(outputFileName, JsonConvert.SerializeObject(pj));
            }
            catch(FileNotFoundException fnfe){
                Console.WriteLine("Nie ma go");
                File.AppendAllText("log.txt",DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()+" Plik nie istnieje\n");
            }
            catch(ArgumentException xd){
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                File.AppendAllText("log.txt",DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()+" Podana ścieżka jest niepoprawna\n");
            }
            catch(IOException xd2){
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                File.AppendAllText("log.txt",DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()+" Podana ścieżka jest niepoprawna ioe\n");
            }
        }
    }
}
