﻿using System;
using System.IO;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Options;

namespace GroupDocs.Samples.DigitalSignature.PdfFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");

            PdfSignDigitalOptions pdfDigitalOptions = new PdfSignDigitalOptions(Path.Combine(storagePath, @"a.pfx"));
            // setup coordinates of image
            pdfDigitalOptions.Left = 10;
            pdfDigitalOptions.Top = 10;
            pdfDigitalOptions.Width = 100;
            pdfDigitalOptions.Height = 100;

            pdfDigitalOptions.ImageFileName = "Autograph_of_Benjamin_Franklin.png";

            // setup document page number
            pdfDigitalOptions.DocumentPageNumber = 1;

            // setup document password if required
            pdfDigitalOptions.Password = "1234567890";

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
            string fileName = handler.Sign<string>(@"candy.pdf", pdfDigitalOptions, saveOptions);
            Console.WriteLine("Document signed successfully. The output filename: {0}", fileName);
        }
    }
}
