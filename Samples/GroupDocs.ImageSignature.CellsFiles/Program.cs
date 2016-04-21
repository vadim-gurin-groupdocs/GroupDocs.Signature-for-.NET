using System;
using System.IO;
using System.Text;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Handler.Input;
using GroupDocs.Signature.Handler.Output;

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
            handler.SetLicense(@"GroupDocs.Signature3.lic");

            // setup Cells image signature options
            var cellsOptions = new CellsSignImageOptions(@"Autograph_of_Benjamin_Franklin.png");
            // setup coordinates of image
            cellsOptions.Left = 10;
            cellsOptions.Top = 10;
            cellsOptions.Width = 100;
            cellsOptions.Height = 100;

            // setup document page number
            cellsOptions.SheetNumber = 1;
            cellsOptions.HorizontalAlignment = HorizontalAlignment.Right;
            cellsOptions.VerticalAlignment = VerticalAlignment.Bottom;
            cellsOptions.ColumnNumber = 0;
            cellsOptions.RowNumber = 5;
            cellsOptions.SignAllPages = true;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);

            // sign the document
            string fileName = handler.Sign<string>(@"test.xlsx", cellsOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
