using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;

namespace S3;
public class S3Provider
{
    public IAmazonS3 Client { get; }
    public S3Provider(string accessKeyId, string secretAccessKey, string region)
    {
        var credentials = new BasicAWSCredentials(accessKeyId, secretAccessKey);

        var regionEndpoint = RegionEndpoint.GetBySystemName(region);

        Client = new AmazonS3Client(credentials, regionEndpoint);
    }
}
