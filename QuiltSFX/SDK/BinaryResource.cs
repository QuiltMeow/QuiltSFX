using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace QuiltSFX
{
    // 用於產生 Stub 的二進位資源檔案
    public sealed class BinaryResource : IDisposable
    {
        private readonly ResourceWriter writer;

        public BinaryResource(string name)
        {
            writer = new ResourceWriter(name);
        }

        public void addResource(string name, string file)
        {
            writer.AddResource(name, File.ReadAllBytes(file));
        }

        public void save()
        {
            writer.Generate();
        }

        public void Dispose()
        {
            writer.Dispose();
        }
    }
}