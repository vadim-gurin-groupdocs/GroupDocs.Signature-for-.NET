using System;
using System.IO;
using GroupDocs.Samples.CustomStorage.Signature.Azure;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Handler.Input;
using GroupDocs.Signature.Handler.Output;
using GroupDocs.Signature.Options;

namespace GroupDocs.Samples.CustomStorage.Signature
{
    class CustomStorageSample
    {
        const string DevStorageEmulatorUrl = "http://127.0.0.1:10000/devstoreaccount1/";
        const string DevStorageEmulatorAccountName = "devstoreaccount1";
        const string DevStorageEmulatorAccountKey =
            "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";

        public void CustomInputHandlerTest(string inputFileName)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");
            SignatureConfig config = new SignatureConfig()
            {
                OutputPath = outputPath,
            };

            string fileName;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            IInputDataHandler customInputStorageProvider = new SampleAzureInputDataHandler(DevStorageEmulatorUrl,
                DevStorageEmulatorAccountName, DevStorageEmulatorAccountKey, "testbucket");
            SignatureHandler handlerWithCustomStorage = new SignatureHandler(config, customInputStorageProvider);
            LicenseSetter.SetSignatureLicense(handlerWithCustomStorage);

            using (Stream imageStream = File.OpenRead(Path.Combine(imagesPath, "Autograph_of_Benjamin_Franklin.png")))
            {
                PdfSignImageOptions options = new PdfSignImageOptions(imageStream);
                options.DocumentPageNumber = 1;
                options.Top = 500;
                options.Width = 200;
                options.Height = 100;
                fileName = handlerWithCustomStorage.Sign<string>(inputFileName, options, saveOptions);
            }
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }

        public void CustomOutputHandlerTest(string inputFileName)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string imagesPath = Path.Combine(rootPath, @"Images");

            SignatureConfig config = new SignatureConfig()
            {
                StoragePath = storagePath
            };
            
            string fileName;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            IOutputDataHandler customOutputStorageProvider = new SampleAzureOutputDataHandler(
                DevStorageEmulatorUrl, DevStorageEmulatorAccountName, DevStorageEmulatorAccountKey, "tempbucket");
            SignatureHandler handlerWithCustomStorage = new SignatureHandler(config, customOutputStorageProvider);
            LicenseSetter.SetSignatureLicense(handlerWithCustomStorage);

            using (Stream imageStream = File.OpenRead(Path.Combine(imagesPath, "Autograph_of_Benjamin_Franklin.png")))
            {
                PdfSignImageOptions options = new PdfSignImageOptions(imageStream);
                options.DocumentPageNumber = 1;
                options.Top = 500;
                options.Width = 200;
                options.Height = 100;
                fileName = handlerWithCustomStorage.Sign<string>(inputFileName, options, saveOptions);
            }
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }

        public void CustomStorageTests(string inputFileName)
        {
            SignatureConfig config = new SignatureConfig();
            string rootPath = Path.GetFullPath(@"..\..\");
            string imagesPath = Path.Combine(rootPath, @"Images");
            
            string fileName;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            IInputDataHandler customInputStorageProvider = new SampleAzureInputDataHandler(DevStorageEmulatorUrl,
                DevStorageEmulatorAccountName, DevStorageEmulatorAccountKey, "testbucket");
            IOutputDataHandler customOutputStorageProvider = new SampleAzureOutputDataHandler(
                DevStorageEmulatorUrl, DevStorageEmulatorAccountName, DevStorageEmulatorAccountKey, "tempbucket");
            SignatureHandler handlerWithCustomStorage = new SignatureHandler(config, customInputStorageProvider, customOutputStorageProvider);
            LicenseSetter.SetSignatureLicense(handlerWithCustomStorage);

            using (Stream imageStream = File.OpenRead(Path.Combine(imagesPath, "Autograph_of_Benjamin_Franklin.png")))
            {
                PdfSignImageOptions options = new PdfSignImageOptions(imageStream);
                options.DocumentPageNumber = 1;
                options.Top = 500;
                options.Width = 200;
                options.Height = 100;
                fileName = handlerWithCustomStorage.Sign<string>(inputFileName, options, saveOptions);
            }
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }

        public void UploadTestFile(string inputFileName)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");

            IOutputDataHandler customOutputStorageProvider = new SampleAzureOutputDataHandler(
                DevStorageEmulatorUrl, DevStorageEmulatorAccountName, DevStorageEmulatorAccountKey, "testbucket");
            using (Stream blobStream = customOutputStorageProvider.CreateFile(inputFileName))
            {
                byte[] fileBytes = File.ReadAllBytes(Path.Combine(storagePath, inputFileName));
                using (MemoryStream inputStream = new MemoryStream(fileBytes))
                {
                    inputStream.CopyTo(blobStream);
                }
            }
        }
    }
}
