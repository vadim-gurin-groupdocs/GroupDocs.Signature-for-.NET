using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Options;
using GroupDocs.Signature;
using GroupDocs.Signature.Domain;

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
            PdfSignImageOptions pdfImageSignatureOptions = new PdfSignImageOptions(@"Autograph_of_Benjamin_Franklin.png");
            pdfImageSignatureOptions.DocumentPageNumber = 1;
            pdfImageSignatureOptions.Top = 500;
            pdfImageSignatureOptions.Width = 50;
            pdfImageSignatureOptions.Height = 20;

            // Set a license if you have one
            License license = new License();
            license.SetLicense(@"GroupDocs.Signature3.lic");

            pdfImageSignatureOptions.HorizontalAlignment = HorizontalAlignment.Left;
            pdfImageSignatureOptions.VerticalAlignment = VerticalAlignment.Top;
            pdfImageSignatureOptions.Margin = new Padding()
            {
                Right = 50,
                Top = 50
            };

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            // sign the document
            LoadOptions loadOptions = new LoadOptions();
            string fileName = handler.Sign<string>(@"candy.pdf", pdfImageSignatureOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
                
            loadOptions.Password = "123";
            fileName = handler.Sign<string>(@"candyPassword123.pdf", pdfImageSignatureOptions, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
