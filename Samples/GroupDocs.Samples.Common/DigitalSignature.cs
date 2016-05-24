using System;

using GroupDocs.Signature.Config;
using GroupDocs.Signature.Options;
using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.Common
{
    public class DigitalSignature
    {
        public static void CellsDocument()
        {
            // set up Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup digital signature options
            var signOptions = new CellsSignDigitalOptions("test.pfx");
            signOptions.Password = "1234567890";
            
            // sign document
            var signedPath = handler.Sign<string>("test.xls", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        public static void PDFDocument()
        {
            // set up Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup digital signature options
            var signOptions = new PdfSignDigitalOptions("test.pfx","signature.jpg");
            // image position
            signOptions.Left = 100;
            signOptions.Top = 100;
            signOptions.Width = 100;
            signOptions.Height = 100;
            signOptions.DocumentPageNumber = 1;
            signOptions.Password = "1234567890";
            // sign document
            var signedPath = handler.Sign<string>("test.pdf", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        public static void SlidesDocument()
        {
            // set up Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup digital signature options
            var signOptions = new SlidesSignDigitalOptions("test.pfx", "signature.jpg");
            signOptions.Left = 10;
            signOptions.Top = 10;
            signOptions.Width = 100;
            signOptions.Height = 100;
            signOptions.DocumentPageNumber = 1;
            signOptions.Password = "1234567890";
            // sign document
            var signedPath = handler.Sign<string>("test.ppt", signOptions, new SaveOptions { OutputType = OutputType.String });
            Console.WriteLine("Signed file path is: " + signedPath);
        }
        public static void WordsDocument()
        {
            // set up Signature configuration
            SignatureConfig signConfig = Helper.GetPaths();

            // instantiating the conversion handler
            var handler = new SignatureHandler(signConfig);
            // setup digital signature options
            var signOptions = new WordsSignDigitalOptions("test.pfx");
            //
            signOptions.Password = "1234567890";
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
