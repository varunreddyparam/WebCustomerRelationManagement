using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using WebCustomerRelationManagement.Interface;

namespace WebCustomerRelationManagement.Concrete
{
    public class DataManagerUtility
    {
        private static CloudStorageAccount storageAccount;
        private static CloudBlobClient blobClient;

        /// <summary>
        /// Get a CloudBlob instance with the specified name and type in the given container.
        /// </summary>
        /// <param name="options">BlobOptions</param>
        /// <returns>A CloudBlob instance with the specified name and type in the given container.</returns>
        public static CloudBlob GetCloudBlob(BlobOptions options)
        {
            var client = GetCloudBlobClient(options.ConnectionString);
            var container = client.GetContainerReference(options.ContainerName);
            container.CreateIfNotExists();

            CloudBlob cloudBlob;
            switch (options.BlobType)
            {
                case BlobType.AppendBlob:
                    cloudBlob = container.GetAppendBlobReference(options.BlobName);
                    break;
                case BlobType.BlockBlob:
                    cloudBlob = container.GetBlockBlobReference(options.BlobName);
                    break;
                case BlobType.PageBlob:
                    cloudBlob = container.GetPageBlobReference(options.BlobName);
                    break;
                default:
                    throw new ArgumentException($"Invalid blob type {options.BlobName}");
            }

            if (options.Public)
            {
                var permission = container.GetPermissions();

                permission.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(permission);
            }

            return cloudBlob;
        }
        private static CloudBlobClient GetCloudBlobClient(string connectionString)
        {
            return blobClient ?? (blobClient = GetStorageAccount(connectionString).CreateCloudBlobClient());
        }
        private static CloudStorageAccount GetStorageAccount(string connectionString)
        {
            return storageAccount ?? (storageAccount = CloudStorageAccount.Parse(connectionString));
        }
    }
}
