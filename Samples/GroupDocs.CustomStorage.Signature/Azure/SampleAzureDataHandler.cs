using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GroupDocs.Samples.CustomStorage.Signature.Azure
{
    public abstract class SampleAzureDataHandler
    {
        private CloudBlobClient _remoteStorage;
        private string _containerName;

        protected CloudBlobClient RemoteStorage => _remoteStorage;
        protected string ContainerName => _containerName;

        public SampleAzureDataHandler(string endpoint,
            string accountName,
            string accountKey,
            string containerName)
        {
            var credentials = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount account = new CloudStorageAccount(credentials, new Uri(endpoint), null, null, null);
            _remoteStorage = account.CreateCloudBlobClient();
            _containerName = containerName;

            TimeSpan? defTimeout = _remoteStorage.DefaultRequestOptions.ServerTimeout;
            _remoteStorage.DefaultRequestOptions.ServerTimeout = TimeSpan.FromSeconds(10);

            CloudBlobContainer container = _remoteStorage.GetContainerReference(containerName);
            container.CreateIfNotExists();

            _remoteStorage.DefaultRequestOptions.ServerTimeout = defTimeout;
        }

        public CloudBlobContainer GetContainerReference()
        {
            CloudBlobContainer container = RemoteStorage.GetContainerReference(ContainerName);
            return container;
        }
    }
}
