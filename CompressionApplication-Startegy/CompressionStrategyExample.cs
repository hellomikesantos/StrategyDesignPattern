using CompressionApplication_Startegy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CompressionApplication_Startegy
{
    public class Client
    {
        public List<string> Files { get; set; } = new List<string>();
    }

    public class Compressor 
    {
        public ICompressionBehaviour CompressionBehaviour { get; set; }
        public void SwitchCompressionMethod(string compressorType)
        {
            switch (compressorType.ToLower())
            {
                case "rar":
                    CompressionBehaviour = new RARCompressionBehaviour();
                    break;
                case "zip":
                    CompressionBehaviour = new ZipCompressionBehaviour();
                    break;
                case "tar":
                    CompressionBehaviour = new TarCompressionBehaviour();
                    break;
            }
        }
        public void PerformCompression(Client client)
        {
            CompressionBehaviour.Compress(client.Files);
        }

        public Compressor(string compressorType)
        {
            SwitchCompressionMethod(compressorType);
        }
    }

    public interface ICompressionBehaviour
    {
        public string Compress(List<string> files);
    }

    public class RARCompressionBehaviour : ICompressionBehaviour
    {
        public string Compress(List<string> files)
        {
            Console.WriteLine($"Compressed {files.Count} into a RAR file.");
            return $"rarified{files.Count}files.rar";
        }
    }

    public class ZipCompressionBehaviour : ICompressionBehaviour
    {
        public string Compress(List<string> files)
        {
            throw new NotImplementedException();
        }
    }

    public class TarCompressionBehaviour : ICompressionBehaviour
    {
        public string Compress(List<string> files)
        {
            Console.WriteLine($"Compressed {files.Count} into a Tar file.");
            return $"rarified{files.Count}files.rar";
        }
    }
}