using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Options;
using GroupDocs.Signature;

namespace GroupDocs.Samples.ImageSignature.PdfFiles
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
            
            // setup PDF image signature options
            PdfSignImageOptions options = new PdfSignImageOptions(@"Autograph_of_Benjamin_Franklin.png");
            options.DocumentPageNumber = 1;
            options.Top = 500;
            //options.SignAllPages = true;
            options.Width = 20;
            options.Height = 10;

            // Set a license if you have one
            License license = new License();
            license.SetLicense(@"GroupDocs.Signature3.lic");

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            // sign the document
            LoadOptions loadOptions = new LoadOptions();
            string fileName = handler.Sign<string>(@"candy.pdf", options, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
                
            loadOptions.Password = "123";
            fileName = handler.Sign<string>(@"candyPassword123.pdf", options, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
