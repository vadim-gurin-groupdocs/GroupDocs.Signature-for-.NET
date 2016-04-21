using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Options;

namespace GroupDocs.Samples.DigitalSignature.CellsFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");

            CellsSignDigitalOptions cellsDigitalOptions =
                new CellsSignDigitalOptions(Path.Combine(storagePath, @"a.pfx"));
            // setup coordinates of image
            cellsDigitalOptions.Left = 10;
            cellsDigitalOptions.Top = 10;
            cellsDigitalOptions.Width = 100;
            cellsDigitalOptions.Height = 100;

            // setup document page number
            cellsDigitalOptions.DocumentPageNumber = 1;

            // setup document password if required
            cellsDigitalOptions.Password = "1234567890";

            // setup configuration
            SignatureConfig config = new SignatureConfig()
            {
                StoragePath = storagePath,
                OutputPath = outputPath,
                ImagesPath = imagesPath
            };
            // instantiating the handler
            SignatureHandler handler = new SignatureHandler(config);

            SaveOptions saveOptions = new SaveOptions(OutputType.String);

            // sign document
            string fileName = handler.Sign<string>(@"test.xlsx", cellsDigitalOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}