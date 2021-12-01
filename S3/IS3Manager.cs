using Amazon.S3.Model;

namespace S3;

public interface IS3Manager
{
    /// <summary>
    /// 取得檔案串流
    /// </summary>
    /// <param name="bucketName">儲存貯體名稱</param>
    /// <param name="objectKey">物件鍵值</param>
    /// <returns>檔案串流</returns>
    Task<GetObjectResponse?> GetFileAsync(string bucketName, string objectKey);
    /// <summary>
    /// 新增或更新檔案物件
    /// </summary>
    /// <param name="bucketName">儲存貯體名稱</param>
    /// <param name="objectKey">物件鍵值</param>
    /// <param name="filePath">檔案路徑</param>
    /// <returns>是否執行成功</returns>
    Task<bool> UploadObjectFromFileAsync(string bucketName, string objectKey, string filePath);
    /// <summary>
    /// 新增或更新檔案物件
    /// </summary>
    /// <param name="bucketName">儲存貯體名稱</param>
    /// <param name="objectKey">物件鍵值</param>
    /// <param name="content">內容</param>
    /// <returns>是否執行成功</returns>
    Task<bool> UploadObjectFromContentAsync(string bucketName, string objectKey, string content);
    /// <summary>
    /// 新增或更新檔案物件
    /// </summary>
    /// <param name="bucketName">儲存貯體名稱</param>
    /// <param name="objectKey">物件鍵值</param>
    /// <param name="stream"></param>
    /// <returns>是否執行成功</returns>
    Task<bool> UploadObjectFromStreamAsync(string bucketName, string objectKey, Stream stream);
    /// <summary>
    /// 刪除檔案物件
    /// </summary>
    /// <param name="bucketName">儲存貯體名稱</param>
    /// <param name="objectKey">物件鍵值</param>
    /// <returns>是否執行成功</returns>
    Task<bool> DeleteObjectByKeyAsync(string bucketName, string objectKey);
}
