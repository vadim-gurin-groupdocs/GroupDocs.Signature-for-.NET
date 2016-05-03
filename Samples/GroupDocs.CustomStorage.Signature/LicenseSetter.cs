using GroupDocs.Signature.Handler;

namespace GroupDocs.Samples.CustomStorage.Signature
{
    internal class LicenseSetter
    {
        internal static void SetSignatureLicense(SignatureHandler handler)
        {
            //handler.SetLicense(@"GroupDocs.Signature3.lic");
            handler.SetLicense(@"d:\temp\SignatureLicense\GroupDocs.Signature3.lic");
        }
    }
}
