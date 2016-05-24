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
