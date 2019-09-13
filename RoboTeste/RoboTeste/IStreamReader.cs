using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoboTeste
{
    public interface IStreamReader
    {
        StreamReader GetReader(string path);
    }
}
