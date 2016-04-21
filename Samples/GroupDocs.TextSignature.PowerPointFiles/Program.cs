using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.TextSignature.PowerPointFiles
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

            // setup Words image signature options
            SlidesSignTextOptions options = new SlidesSignTextOptions(@"Test signature");
            // setup coordinates of image
            options.Left = 500;
            options.Top = 100;
            options.Width = 100;
            options.Height = 50;

            // setup document page number
            options.DocumentPageNumber = 0;
            options.SignAllPages = true;

            // Set a license if you have one
            handler.SetLicense(@"GroupDocs.Signature3.lic");

            SaveOptions saveOptions = new SaveOptions(OutputType.String);
            string fileName;
            using (Stream fileStream = File.OpenRead(Path.Combine(storagePath, "GroupDocs_Demo_2_pages.pptx")))
            {
                fileName = handler.Sign<string>(fileStream, options, saveOptions);
            }
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            // sign the document
            fileName = handler.Sign<string>(@"GroupDocs_Demo_2_pages.pptx", options, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            LoadOptions loadOptions = new LoadOptions();
            fileName = handler.Sign<string>(@"GroupDocs_Demo_2_pages.pptx", options, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);

            loadOptions.Password = "123";
            fileName = handler.Sign<string>(@"GroupDocs_Demo_2_pagesPassword123.pptx", options, loadOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
            saveOptions = new SaveOptions(OutputType.Stream);
            using (Stream stream = handler.Sign<Stream>(@"GroupDocs_Demo_2_pages.pptx", options, loadOptions, saveOptions))
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}
