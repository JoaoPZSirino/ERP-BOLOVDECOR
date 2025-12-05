using System;
using System.Windows.Forms;
using PdfSharp.Fonts; // Importante

namespace ERPBOLOV2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ATIVA O CORRETOR DE FONTES
            GlobalFontSettings.FontResolver = new DefinidorDeFontes();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Ou Form1, dependendo da sua tela inicial
        }
    }
}