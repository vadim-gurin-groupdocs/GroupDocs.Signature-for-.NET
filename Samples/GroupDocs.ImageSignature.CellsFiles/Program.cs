using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature;
using GroupDocs.Signature.Domain;

namespace GroupDocs.Samples.ImageSignature.CellsFiles
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

            // setup Cells image signature options
            var cellsImageSignatureOptions = new CellsSignImageOptions(@"Autograph_of_Benjamin_Franklin.png");
            // set coordinates of image
            cellsImageSignatureOptions.Left = 10;
            cellsImageSignatureOptions.Top = 10;
            cellsImageSignatureOptions.Width = 100;
            cellsImageSignatureOptions.Height = 100;

            // set document page number
            cellsImageSignatureOptions.SheetNumber = 1;
            cellsImageSignatureOptions.ColumnNumber = 0;
            cellsImageSignatureOptions.RowNumber = 5;
            cellsImageSignatureOptions.SignAllPages = false;
            
            SaveOptions saveOptions = new SaveOptions(OutputType.String);

            // sign the document
            string fileName = handler.Sign<string>(@"test.xlsx", cellsImageSignatureOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
