using System;

namespace GroupDocs.Samples.CustomStorage.Signature
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"candy.pdf";
            Console.WriteLine("In order to run this sample, you have to " +
                              "start the Microsoft Azure Storage Emulator " +
                              "and create a file named '{0}' in a container named 'testbucket'", fileName);

            CustomStorageSample customStorageSample = new CustomStorageSample();
            customStorageSample.CustomStorageTests(fileName);
        }
    }
}
