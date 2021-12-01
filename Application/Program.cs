using Application;
using Microsoft.Extensions.Configuration;
using S3;

Console.WriteLine("開始執行!");

const string BucketName = "BUCKETNAME";
string objectKey = "OBJECTKEY";

IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("awsSettings.json", optional: true, reloadOnChange: true)
           .Build();

var awsSettings = config.GetSection("AwsSettings").Get<AwsSettings>();

IS3Manager s3 = new S3Manager(awsSettings.AccessKeyId, awsSettings.SecretAccessKey, awsSettings.Region);

var response = await s3.GetFileAsync(BucketName, objectKey);

//Get Stream : response.ResponseStream
Console.WriteLine("物件Key: {0}", response?.Key);
Console.WriteLine("mimeType: {0}", response?.Headers.ContentType);

//匯出檔案
using (FileStream outputFileStream = new FileStream("test.png", FileMode.Create))
{
    response?.ResponseStream.CopyTo(outputFileStream);
}

Console.WriteLine("結束執行!");