using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IntelligentKioskSample.Storage
{
    public class AzureStorageClient
    {
        public AzureStorageClient() {
            CloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=opgstorage;AccountKey=TC1sqyL2QKoyfpMNikhE81w2l9BmZecUEuUjYg5c79zmDN1kjkTVbUnXPLiUuAkbRlyMPsOKdBHVhKBrl1Fxaw==;EndpointSuffix=core.chinacloudapi.cn");
            BlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        private CloudStorageAccount CloudStorageAccount { get; set; }

        private CloudBlobClient BlobClient { get; set; }

       // private CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

        public async Task<String> UploadVideoFileAsync(Stream stream, string guid)
        {
            var container = BlobClient.GetContainerReference("opg01");
            var blockBlob = container.GetBlockBlobReference(guid + ".mp4");

            await blockBlob.UploadFromStreamAsync(stream);
            return blockBlob.Uri.AbsoluteUri;
        }
    }
}
