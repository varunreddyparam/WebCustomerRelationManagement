using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Interface
{
    public interface IBlobStorageAsync
    {
        Task<string> CreateBlockBlobAsync(string blobId, string contentType, Stream data);
        Task<string> CreateBlockBlobAsync(string blobId, string contentType, byte[] data);
        Task<string> CreateBlockBlobAsync(string blobId, string contentType, string data);
        Task<string> CreateBlockBlobAsync(string blobId, string filePath);
        Task<string> AddDataToAppendBlockBlob(string blobId, string data);
        CloudBlockBlob GetBlockBlobReference(string blobId);
        CloudAppendBlob GetAppendBlockBlobReference(string blobId);
        Task<Stream> GetBlockBlobDataAsStreamAsync(string blobId);
        Task<string> GetBlockBlobDataAsStringAsync(string blobId);
        IEnumerable<IListBlobItem> ListBlobsInContainer(string containerName);
        Task DeleteBlobContainerAsync();
        Task DeleteBlobAsync(string blobId);
    }
}
