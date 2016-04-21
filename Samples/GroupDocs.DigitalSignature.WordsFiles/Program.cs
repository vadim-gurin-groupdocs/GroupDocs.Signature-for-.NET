using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Handler.Input;
using GroupDocs.Signature.Handler.Output;
using GroupDocs.Signature.Options;

namespace GroupDocs.Samples.DigitalSignature.WordsFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");

            WordSignDigitalOptions wordSignatureDigitalOptions = new WordSignDigitalOptions(Path.Combine(storagePath, @"a.pfx"));
            // setup coordinates of image
            wordSignatureDigitalOptions.Left = 10;
            wordSignatureDigitalOptions.Top = 10;
            wordSignatureDigitalOptions.Width = 100;
            wordSignatureDigitalOptions.Height = 100;

            // setup document page number
            wordSignatureDigitalOptions.DocumentPageNumber = 1;

            // setup document password if required
            wordSignatureDigitalOptions.Password = "1234567890";

            // setup configuration
            SignatureConfig config = new SignatureConfig()
            {
                StoragePath = storagePath,
                OutputPath = outputPath,
                ImagesPath = imagesPath
            };
            // instantiating the handler
            SignatureHandler handler = new SignatureHandler(config);

            // sign document
            string fileName = handler.Sign<string>(@"test.docx", wordSignatureDigitalOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
