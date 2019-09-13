using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RoboTeste
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO criar o log 
            while (true)
            {


                // Create a new FileSystemWatcher and set its properties.
                using (FileSystemWatcher watcher = new FileSystemWatcher())
                {
                    watcher.Path = "C:\\Users\\Beatriz\\Documents\\Projeto\\Tarifas Pj\\Teste";

                    // Watch for changes in LastAccess and LastWrite times, and
                    // the renaming of files or directories.
                    watcher.NotifyFilter = NotifyFilters.LastAccess
                                         | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName
                                         | NotifyFilters.DirectoryName;

                    // Only watch text files.
                    watcher.Filter = "TesteProjetoTarifa*.txt";

                    // Add event handlers.
                    watcher.Changed += OnChanged;
                    watcher.Created += OnChanged;
                    //watcher.Deleted += OnChanged;
                    // watcher.Renamed += OnRenamed;

                    // Begin watching.
                    watcher.EnableRaisingEvents = true;

                    //// Wait for the user to quit the program.
                    Console.WriteLine("Press 'q' to quit the sample.");
                    while (Console.Read() != 'q') ;
                }


                Thread.Sleep(10000);//TODO colocar o tempo no webconfig 


            }
        }
        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            var lista = new List<Cliente>();
            var sLinha = string.Empty;
            var _reader = new FileStreamReader();//TODO ajustar para teste unitario
            using (StreamReader sFile = _reader.GetReader(e.FullPath))
            //using (StreamReader sFile = _reader.GetReader("C:\\Users\\Beatriz\\Documents\\Projeto\\Tarifas Pj\\Teste"))
            {
                while ((sLinha = sFile.ReadLine()) != null)
                {
                    if (sLinha.StartsWith("Nome") || sLinha.StartsWith(" ") || sLinha.Length == 0)
                        continue;

                    var item = new Cliente();
                    var colunas = sLinha.Split(';');

                    item.Nome = colunas[0];
                    item.Idade = colunas[1];
                    item.Cpf = colunas[2];

                    lista.Add(item);
                }
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e) =>
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");

    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Idade { get; set; }
    }
}
