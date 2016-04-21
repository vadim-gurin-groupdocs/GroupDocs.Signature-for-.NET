using System;
using System.IO;
using System.Text;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Handler.Input;
using GroupDocs.Signature.Handler.Output;

namespace GroupDocs.Samples.TextSignature.CellsFiles
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

            // setup Cells text signature options
            CellsSignTextOptions cellsOptions = new CellsSignTextOptions(@"Test signature");
            
            cellsOptions.SheetNumber = 1;
            cellsOptions.ColumnNumber = 0;
            cellsOptions.RowNumber = 0;
            cellsOptions.Width = 150;
            cellsOptions.Height = 50;
            cellsOptions.SignAllPages = true;

            SaveOptions saveOptions = new SaveOptions(OutputType.String);

            // Set a license if you have one
            handler.SetLicense(@"GroupDocs.Signature3.lic");

            // sign the document
            string fileName = handler.Sign<string>(@"test.xlsx", cellsOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = "123";
            fileName = handler.Sign<string>(@"testPassword123.xlsx", cellsOptions, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
            
            saveOptions = new SaveOptions(OutputType.Stream);
            using (Stream stream = handler.Sign<Stream>(@"test.xlsx", cellsOptions, saveOptions))
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            saveOptions = new SaveOptions(OutputType.String);
            using (Stream fileStream = File.OpenRead(Path.Combine(storagePath, "test.xlsx")))
            {
                fileName = handler.Sign<string>(fileStream, cellsOptions, saveOptions);
            }
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
