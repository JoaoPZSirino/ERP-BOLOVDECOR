using PdfSharp.Fonts;
using System;
using System.IO;

namespace ERPBOLOV2
{
    // Ensina o PDFSharp a pegar a fonte Arial do Windows
    public class DefinidorDeFontes : IFontResolver
    {
        public string DefaultFontName => "Arial";

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string sufixo = "";
            if (isBold && isItalic) sufixo = "bi";
            else if (isBold) sufixo = "bd";
            else if (isItalic) sufixo = "i";

            return new FontResolverInfo($"arial{sufixo}.ttf");
        }

        public byte[] GetFont(string faceName)
        {
            var caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), faceName);
            if (File.Exists(caminho)) return File.ReadAllBytes(caminho);
            return null;
        }
    }
}