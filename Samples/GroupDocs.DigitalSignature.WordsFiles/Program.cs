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

            WordsSignDigitalOptions signOptions = new WordsSignDigitalOptions(Path.Combine(storagePath, @"a.pfx"));
            // setup coordinates of image
            signOptions.Left = 10;
            signOptions.Top = 10;
            signOptions.Width = 100;
            signOptions.Height = 100;

            // set document page number
            signOptions.DocumentPageNumber = 1;

            // set document password if required
            signOptions.Password = "1234567890";

            // setup configuration
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

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            // sign document
            string fileName = handler.Sign<string>(@"test.docx", signOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
