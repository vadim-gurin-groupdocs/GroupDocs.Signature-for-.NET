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
        public void CustomStorageTests(string inputFileName)
        {
            SignatureConfig config = new SignatureConfig();
            string rootPath = Path.GetFullPath(@"..\..\");
            string imagesPath = Path.Combine(rootPath, @"Images");
            const string devStorageEmulatorUrl = "http://127.0.0.1:10000/devstoreaccount1/";
            const string devStorageEmulatorAccountName = "devstoreaccount1";
            const string devStorageEmulatorAccountKey =
                "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";
            string fileName;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            IInputDataHandler customInputStorageProvider = new SampleAzureInputDataHandler(devStorageEmulatorUrl,
                devStorageEmulatorAccountName, devStorageEmulatorAccountKey, "testbucket");
            IOutputDataHandler customOutputStorageProvider = new SampleAzureOutputDataHandler(
                devStorageEmulatorUrl, devStorageEmulatorAccountName, devStorageEmulatorAccountKey, "tempbucket");
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
    }
}
