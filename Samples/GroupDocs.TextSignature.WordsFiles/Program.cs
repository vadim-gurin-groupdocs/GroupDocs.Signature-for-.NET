using System;
using System.Drawing;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature;

namespace GroupDocs.Samples.TextSignature.WordsFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");

            // setup a storage configuration
            SignatureConfig config = new SignatureConfig()
            {
                StoragePath = storagePath,
                OutputPath = outputPath,
                ImagesPath = imagesPath
            };

            // instantiating the handler
            SignatureHandler handler = new SignatureHandler(config);

            // setup Words text signature options
            var options = new WordsSignTextOptions();
            
            // set the signature text, font family name and other properties
            options.Text = "Test signature";
            options.Left = 50;
            options.Top = 300;
            options.Width = 100;
            options.Height = 50;

            // put the signature on all the pages
            options.SignAllPages = true;

            SaveOptions saveOptions = new SaveOptions();
            saveOptions.OutputType = OutputType.String;

            // Set a license if you have one
            License license = new License();
            license.SetLicense(@"GroupDocs.Signature3.lic");

            // sign the documents
            string fileName;
            Stream resultStream;
            using (Stream fileStream = File.OpenRead(Path.Combine(storagePath, "test.docx")))
            {
                fileName = handler.Sign<string>(fileStream, options, saveOptions);
            }
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            using (Stream fileStream = File.OpenRead(Path.Combine(storagePath, "test.docx")))
            {
                saveOptions.OutputType = OutputType.Stream;
                resultStream = handler.Sign<Stream>(fileStream, options, saveOptions);
                resultStream.Seek(0, SeekOrigin.Begin);
            }

            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = "123";
            saveOptions.OutputType = OutputType.String;
            fileName = handler.Sign<string>(Path.Combine(storagePath, @"test.docx"), options, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            fileName = handler.Sign<string>(@"test.docx", options, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            fileName = handler.Sign<string>(@"test1PagePassword123.docx", options, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            saveOptions = new SaveOptions(OutputType.Stream);
            saveOptions.OutputType = OutputType.Stream;
            using (Stream stream = handler.Sign<Stream>(@"test.docx", options, loadOptions, saveOptions))
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}
