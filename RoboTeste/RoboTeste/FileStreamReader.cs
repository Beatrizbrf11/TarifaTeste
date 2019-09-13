using System.IO;

namespace RoboTeste
{
    public class FileStreamReader : IStreamReader
    {
        public StreamReader GetReader(string path) =>
         new StreamReader(path, System.Text.Encoding.GetEncoding(28591));
    }
}