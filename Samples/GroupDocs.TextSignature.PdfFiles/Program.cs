using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.TextSignature.PdfFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");

            // setup a configuration
            SignatureConfig config = new SignatureConfig()
            {
                StoragePath = storagePath,
                OutputPath = outputPath,
                ImagesPath = imagesPath
            };

            // instantiating the handler
            SignatureHandler handler = new SignatureHandler(config);

            // Set a license if you have one
            handler.SetLicense(@"GroupDocs.Signature3.lic");

            // set up PDF image signature options
            PdfSignTextOptions signOptions = new PdfSignTextOptions(@"Test signature");
            signOptions.DocumentPageNumber = 1;
            signOptions.Left = 100;
            signOptions.Top = 0;
            signOptions.SignAllPages = true;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            // sign the document
            string fileName = handler.Sign<string>(@"candy.pdf", signOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
