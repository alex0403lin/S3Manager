using Amazon.S3;

namespace S3
{
    public interface IS3Provider
    {
        IAmazonS3 Client { get; }
    }
}