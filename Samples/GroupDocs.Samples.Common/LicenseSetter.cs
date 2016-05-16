using GroupDocs.Signature.Handler;
using GroupDocs.Signature;

namespace GroupDocs.Samples.CustomStorage.Signature
{
    internal class LicenseSetter
    {
        internal static void SetSignatureLicense(SignatureHandler handler)
        {
            License license = new License();
            license.SetLicense(@"GroupDocs.Signature3.lic");
        }
    }
}
