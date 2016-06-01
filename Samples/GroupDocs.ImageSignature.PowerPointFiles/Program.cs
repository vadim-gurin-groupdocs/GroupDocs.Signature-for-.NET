using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.ImageSignature.PowerPointFiles
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
            License license = new License();
            license.SetLicense(@"GroupDocs.Signature3.lic");

            // setup Words image signature options
            SlidesSignImageOptions slidesImageSignatureOptions = new SlidesSignImageOptions(@"Autograph_of_Benjamin_Franklin.png");
            // setup coordinates of image
            slidesImageSignatureOptions.Left = 10;
            slidesImageSignatureOptions.Top = 10;
            slidesImageSignatureOptions.Width = 100;
            slidesImageSignatureOptions.Height = 100;

            // setup document page number
            slidesImageSignatureOptions.DocumentPageNumber = 1;

            slidesImageSignatureOptions.HorizontalAlignment = HorizontalAlignment.Right;
            slidesImageSignatureOptions.VerticalAlignment = VerticalAlignment.Bottom;
            slidesImageSignatureOptions.Margin = new Padding()
            {
                Right = 50,
                Bottom = 50
            };

            SaveOptions saveOptions = new SaveOptions(OutputType.String);

            // sign the document
            string fileName = handler.Sign<string>(@"GroupDocs_Demo_2_pages.pptx", options, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
