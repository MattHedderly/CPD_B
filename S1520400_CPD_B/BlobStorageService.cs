using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace S1520400_CPD_B
{
    public class BlobStorageService
    {
        public CloudBlobContainer getCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse
                (ConfigurationManager.ConnectionStrings["AzureStorage"].ToString());

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer blobContainer = blobClient.GetContainerReference("musicgallery");
            if (blobContainer.CreateIfNotExists())
            {
                // Enable public access on the newly created "musicgallery" container.
                blobContainer.SetPermissions(
                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
            }
            return blobContainer;
        }
    }
}