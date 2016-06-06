using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.ImageSignature.WordsFiles
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
            var wordsSignImageOptions = new WordsSignImageOptions(@"Autograph_of_Benjamin_Franklin.png");
            // setup coordinates of image
            wordsSignImageOptions.Left = 10;
            wordsSignImageOptions.Top = 300;
            wordsSignImageOptions.Width = 100;
            wordsSignImageOptions.Height = 100;

            // set document page number
            wordsSignImageOptions.DocumentPageNumber = 1;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            
            // sign the document
            string fileName = handler.Sign<string>(@"test.docx", wordsSignImageOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
