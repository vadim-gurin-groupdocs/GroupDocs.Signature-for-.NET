using System.IO;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Handler.Input;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GroupDocs.Samples.CustomStorage.Signature.Azure
{
    public class SampleAzureInputDataHandler : SampleAzureDataHandler, IInputDataHandler
    {
        public SampleAzureInputDataHandler(string endpoint,
                                           string accountName,
                                           string accountKey,
                                           string containerName) :
            base(endpoint, accountName, accountKey, containerName)
        {
        }

        public FileDescription GetFileDescription(string guid)
        {
            FileDescription result = new FileDescription(guid);
            return result;
        }


        public Stream GetStream(string guid)
        {
            MemoryStream result = new MemoryStream();
            CloudBlobContainer container = GetContainerReference();
            CloudBlockBlob blob = container.GetBlockBlobReference(guid);

            using (Stream content = blob.OpenRead())
            {
                content.CopyTo(result);
            }
            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
    }
}
