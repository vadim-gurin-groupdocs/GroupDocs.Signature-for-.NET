using System;
using System.IO;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Handler.Output;
using GroupDocs.Signature.Options;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GroupDocs.Samples.CustomStorage.Signature.Azure
{
    public class SampleAzureOutputDataHandler: SampleAzureDataHandler, IOutputDataHandler
    {
        public SampleAzureOutputDataHandler(string endpoint,
                                           string accountName,
                                           string accountKey,
                                           string containerName) :
            base(endpoint, accountName, accountKey, containerName)
        {
        }

        public Stream CreateFile(FileDescription fileDescription, SignOptions signOptions = null,
            SaveOptions saveOptions = null)
        {
            CloudBlobContainer container = GetContainerReference();
            string name = fileDescription.GUID.ToLower();
            CloudBlockBlob blob = container.GetBlockBlobReference(name);
            using (MemoryStream emptyStream = new MemoryStream())
            {
                blob.UploadFromStream(emptyStream);
            }

            try
            {
                CloudAppendBlob appendBlob = container.GetAppendBlobReference(name);
                appendBlob.CreateOrReplace();
                return appendBlob.OpenWrite(true);
            }
            catch (Microsoft.WindowsAzure.Storage.StorageException exception)
            {
                // Azure Storage Emulator does not support append BLOBs,
                // so we emulate appending
                return new CachingAzureStream(blob);
            }
        }

        public Stream CreateStream(FileDescription fileDescription, SignOptions signOptions = null,
            SaveOptions saveOptions = null)
        {
            throw new NotImplementedException();
        }
    }
}
