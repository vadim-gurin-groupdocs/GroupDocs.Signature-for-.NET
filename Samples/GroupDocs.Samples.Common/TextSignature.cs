using System;

using GroupDocs.Signature.Config;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.Common
{
    public class TextSignature
    {
        public static void CellsDocument()
        {
            // set up Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();
            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // set text signature options
            var signOptions = new CellsSignTextOptions("John Smith");
            // text position
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
            // setup text signature options
            var signOptions = new PdfSignTextOptions("John Smith");
            // text position
            signOptions.Left = 100;
            signOptions.Top = 100;
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
            var signOptions = new SlidesSignTextOptions("John Smith");
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
            var signOptions = new WordsSignTextOptions("John Smith");
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
