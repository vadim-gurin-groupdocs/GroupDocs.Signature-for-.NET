using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Samples.CustomStorage.Signature;
using GroupDocs.Signature.Config;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Handler.Input;
using GroupDocs.Signature.Handler.Output;

namespace GroupDocs.Samples.Common
{
    class Program
    {
        // output file should be at same location
        static void f1()
        {
            // instantiating the signature handler without Signature Config object
            var handler = new SignatureHandler();
            // setup image signature options
            var signOptions = new PdfSignImageOptions(@"C:\Aspose\signature.jpg");
            // sign document with image
            var signedPath = handler.Sign<string>(@"C:\Aspose\test.pdf", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        static void f2()
        {
            var storagePath = @"c:\Aspose\Test\Storage";
            var outputPath = @"c:\Aspose\Test\Output";
            var imagesPath = @"c:\Aspose\Test\Images";
            // setup Signature configuration
            var signConfig = new SignatureConfig
            {
                StoragePath = storagePath,
                OutputPath = outputPath,
                ImagesPath = imagesPath
            };
            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            var signOptions = new PdfSignImageOptions("signature.jpg");
            // sign document
            var signedPath = handler.Sign<string>("test.pdf", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        static void f3()
        {
            // instantiating the signature handler without Signature Config object
            var handler = new SignatureHandler();
            // setup image signature options
            var signOptions = new PdfSignImageOptions(@"http://groupdocs.com/images/banner/carousel2/conversion.png");
            // save options
            var saveOptions = new SaveOptions(OutputType.String);
            // sign document with image
            var signedPath = handler.Sign<string>("https://www.adobe.com/content/dam/Adobe/en/feature-details/acrobatpro/pdfs/combine-multiple-documents-into-one-pdf-file.pdf", signOptions, saveOptions);
            Console.WriteLine("Signed file path is: " + signedPath);
        }

        
        static void Main(string[] args)
        {
            string fileName = @"candy.pdf";
            Console.WriteLine("In order to run this sample, you have to " +
                              "start the Microsoft Azure Storage Emulator locally");

            CustomStorageSample customStorageSample = new CustomStorageSample();
            // upload a local test file to Microsoft Azure Storage Emulator
            customStorageSample.UploadTestFile(fileName);
            customStorageSample.CustomInputHandlerTest(fileName);
            customStorageSample.CustomOutputHandlerTest(fileName);
            customStorageSample.CustomStorageTest(fileName);

            /**/
            TextSignature.CellsDocument();
            TextSignature.PDFDocument();
            TextSignature.SlidesDocument();
            TextSignature.WordsDocument();
            /**/
            /**/
            ImageSignature.CellsDocument();
            ImageSignature.PDFDocument();
            ImageSignature.SlidesDocument();
            ImageSignature.WordsDocument();
            /**/
            DigitalSignature.CellsDocument();
            DigitalSignature.PDFDocument();
            DigitalSignature.SlidesDocument();
            DigitalSignature.WordsDocument();

            Console.ReadLine();
        }
    }
}
