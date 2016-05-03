using System;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GroupDocs.Samples.CustomStorage.Signature.Azure
{
    public class CachingAzureStream : Stream
    {
        private CloudBlockBlob _blob;
        private long _position;
        private readonly MemoryStream _cachingStream;

        public CachingAzureStream(CloudBlockBlob blob)
        {
            _blob = blob;
            _cachingStream = new MemoryStream();
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            _cachingStream.Seek(0, SeekOrigin.Begin);
            _blob.UploadFromStream(_cachingStream);
            _cachingStream.Seek(0, SeekOrigin.End);
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
        {
            get { return _position; }
            set { throw new NotImplementedException(); }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (offset != 0 || origin != SeekOrigin.Begin)
                throw new NotImplementedException();
            else
            {
                return 0;
            }
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _cachingStream.Write(buffer, 0, count);
            _position = _cachingStream.Length;
        }

        public override void Close()
        {
            Flush();
        }
    }
}
