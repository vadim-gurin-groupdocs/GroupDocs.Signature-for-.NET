using System;

namespace GroupDocs.Samples.CustomStorage.Signature
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"candy.pdf";
            Console.WriteLine("In order to run this sample, you have to " +
                              "start the Microsoft Azure Storage Emulator");

            CustomStorageSample customStorageSample = new CustomStorageSample();
            // upload a local test file to Microsoft Azure Storage Emulator
            customStorageSample.UploadTestFile(fileName);
            customStorageSample.CustomInputHandlerTest(fileName);
            customStorageSample.CustomOutputHandlerTest(fileName);
            customStorageSample.CustomStorageTests(fileName);
        }
    }
}
