Compression newCompress = new WindowsZipCompression();
newCompress.PerformCompression();
Compression newCompress2 = new WindowsRARCompression();
newCompress2.PerformCompression();

public class Client
{

}
public abstract class Compression
{
    public ICompressionBehaviour CompressionBehaviour { get; set; }

    public void PerformCompression()
    {
        CompressionBehaviour.Compress();
    }


}
public class WindowsZipCompression : Compression
{
    public WindowsZipCompression()
    {
        CompressionBehaviour = new ZIPCompressBehaviour();
    }
}

public class WindowsRARCompression : Compression
{
    public WindowsRARCompression()
    {
        CompressionBehaviour = new RARCompressBehaviour();
    }
}

    public interface ICompressionBehaviour
{
    public void Compress()
    {
        Console.WriteLine("This is a compressor");
    }
}

public class RARCompressBehaviour : ICompressionBehaviour
{
    public void Compress()
    {
        Console.WriteLine("Compressing as RAR");
    }
}

public class ZIPCompressBehaviour : ICompressionBehaviour
{
    public void Compress()
    {
        Console.WriteLine("Compressing as Zip");
    }
}

