using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureCoreWebMVC.Services
{
    public class ImageStore
    {

        CloudBlobClient blobClient;
        string baseUri = "https://deepakazurestorage01.blob.core.windows.net/";

        public ImageStore()
        {
            var credentials = new StorageCredentials("deepakazurestorage01", "xaMOQbGWdI8iWZixJViO6yhNwzd+98uKI+Vye1CHUMR5YKEgFHMvuZ0K6USWNS7ANJTk0jo1Bl+UR1G3HEIzAQ==");
            blobClient = new CloudBlobClient(new Uri(baseUri), credentials);
        }

        public async Task<string> SaveImage(Stream imageStream)
        {
            var imageId = Guid.NewGuid().ToString();
            var container = blobClient.GetContainerReference("image");
            var blob = container.GetBlockBlobReference(imageId);
            await blob.UploadFromStreamAsync(imageStream);
            return imageId;
        }

        public string UriFor(string imageId)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-15),
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(15)
            };

            var container = blobClient.GetContainerReference("image");
            var blob = container.GetBlockBlobReference(imageId);
            var sas = blob.GetSharedAccessSignature(sasPolicy);
            return $"{baseUri}image/{imageId}{sas}";
        }


    }
}