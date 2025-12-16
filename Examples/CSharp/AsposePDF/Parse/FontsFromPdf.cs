using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class FontsFromPdf
{
    //https://docs.aspose.com/pdf/net/extract-fonts-from-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "FontsFromPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "FontsFromPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractFonts example...");
        ExtractFonts(Path.Combine(dataDir, "ExtractFonts.pdf"));
        Console.WriteLine("...finished.");
    }

    private static void ExtractFonts(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Text.Font[] fonts = doc.FontUtilities.GetAllFonts();
            foreach (Text.Font font in fonts)
                Console.WriteLine(font.FontName);
        }
    }
}
