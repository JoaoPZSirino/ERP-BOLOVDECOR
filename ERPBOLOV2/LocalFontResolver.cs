using System;
using PdfSharp.Fonts;

namespace ERPBOLOV2
{
    // Simple font resolver that maps requested families to themselves and does not embed fonts.
    // Returning null from GetFont signals PdfSharp to use the platform font.
    public class LocalFontResolver : IFontResolver
    {
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (string.IsNullOrEmpty(familyName))
                familyName = "Arial";

            // Normalize common names
            if (familyName.IndexOf("Arial", StringComparison.OrdinalIgnoreCase) >= 0)
                return new FontResolverInfo("Arial");

            if (familyName.IndexOf("Courier", StringComparison.OrdinalIgnoreCase) >= 0)
                return new FontResolverInfo("Courier New");

            // default: return requested family name
            return new FontResolverInfo(familyName);
        }

        public byte[] GetFont(string faceName)
        {
            // Returning null indicates use of the platform font (no embedding).
            return null;
        }
    }
}
