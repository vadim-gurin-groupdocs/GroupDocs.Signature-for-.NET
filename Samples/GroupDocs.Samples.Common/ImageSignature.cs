using System;
using System.IO;
using System.Collections.Generic;

using GroupDocs.Signature.Config;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;
using GroupDocs.Signature.Handler.Input;
using GroupDocs.Signature.Handler.Output;

namespace GroupDocs.Samples.Common
{
    public class ImageSignature
    {
        public static void CellsDocument()
        {
            // set up Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup image signature options
            var signOptions = new CellsSignImageOptions("signature.jpg");
            // image position
            signOptions.RowNumber = 10;
            signOptions.ColumnNumber = 10;
            signOptions.SignAllPages = true;
            signOptions.DocumentPageNumber = 1;
            // sign document
            var signedPath = handler.Sign<string>("test.xls", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        public static void PDFDocument()
        {
            // setup Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup image signature options
            var signOptions = new PdfSignImageOptions("signature.jpg");
            // image position
            signOptions.Left = 100;
            signOptions.Top = 100;
            signOptions.Width = 100;
            signOptions.Height = 100;
            signOptions.DocumentPageNumber = 1;
            // sign document
            var signedPath = handler.Sign<string>("test.pdf", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        public static void SlidesDocument()
        {
            // setup Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            var signOptions = new SlidesSignImageOptions("signature.jpg");
            signOptions.Left = 10;
            signOptions.Top = 10;
            signOptions.Width = 100;
            signOptions.Height = 100;
            signOptions.DocumentPageNumber = 1;
            // sign document
            var signedPath = handler.Sign<string>("test.ppt", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        public static void WordsDocument()
        {
            // setup Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup image signature options with relative path - image file stores in config.ImagesPath folder
            var signOptions = new WordsSignImageOptions("signature.jpg");
            signOptions.Left = 10;
            signOptions.Top = 10;
            signOptions.Width = 100;
            signOptions.Height = 100;
            signOptions.DocumentPageNumber = 1;
            // sign document
            var signedPath = handler.Sign<string>("test.docx", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
    }
}
