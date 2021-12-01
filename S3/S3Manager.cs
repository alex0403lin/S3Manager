using Amazon.S3.Model;

namespace S3;

public class S3Manager : IS3Manager
{
    private readonly S3Provider _provider;
    public S3Manager(string accessKeyId, string secretAccessKey, string region)
    {
        _provider = new S3Provider(accessKeyId, secretAccessKey, region);
    }

    public async Task<bool> DeleteObjectByKeyAsync(string bucketName, string objectKey)
    {
        try
        {
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey
            };

            DeleteObjectResponse response = await  _provider.Client.DeleteObjectAsync(request);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw e;
        }
    }

    public async Task<GetObjectResponse?> GetFileAsync(string bucketName, string objectKey)
    {
        try
        {
            var metaData = await _provider.Client.GetObjectMetadataAsync(bucketName, objectKey);

            GetObjectResponse response = await _provider.Client.GetObjectAsync(bucketName, objectKey);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK ? response : null;
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw e;
        }
    }

    public async Task<bool> UploadObjectFromContentAsync(string bucketName, string objectKey, string content)
    {
        try
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                ContentBody = content
            };

            PutObjectResponse response = await _provider.Client.PutObjectAsync(putRequest);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw e;
        }
    }

    public async Task<bool> UploadObjectFromFileAsync(string bucketName, string objectKey, string filePath)
    {
        try
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                FilePath = filePath,
                ContentType = "text/plain"
            };

            PutObjectResponse response = await _provider.Client.PutObjectAsync(putRequest);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw e;
        }
    }

    public async Task<bool> UploadObjectFromStreamAsync(string bucketName, string objectKey, Stream stream)
    {
        try
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = stream
            };

            PutObjectResponse response = await _provider.Client.PutObjectAsync(putRequest);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw e;
        }
    }
}
