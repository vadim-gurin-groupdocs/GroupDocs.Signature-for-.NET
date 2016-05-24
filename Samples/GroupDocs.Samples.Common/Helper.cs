using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GroupDocs.Signature.Config;

namespace GroupDocs.Samples.Common
{
    class Helper
    {
        internal static SignatureConfig GetPaths()
        {
            string rootPath = Path.GetFullPath(@"..\..\");
            string storagePath = Path.Combine(rootPath, @"Storage");
            string outputPath = Path.Combine(rootPath, @"Output");
            string imagesPath = Path.Combine(rootPath, @"Images");
            string certificatesPath = Path.Combine(rootPath, @"Certificates"); 
            SignatureConfig signatureConfig = new SignatureConfig
            {
                StoragePath = storagePath,
                OutputPath = outputPath,
                ImagesPath = imagesPath,
                CertificatesPath = certificatesPath
            };
            return signatureConfig;
        }
    }
}
