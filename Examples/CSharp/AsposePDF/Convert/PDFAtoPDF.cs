using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PDFAtoPDF
{
    public static void RunExamples()
    {
        //https://docs.aspose.com/pdf/net/convert-pdfa-to-pdf/

        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PDFAtoPDF");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PDFAtoPDF");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFAtoPDF example...");
        ConvertPDFAtoPDF(Path.Combine(dataDir, "PDFAToPDF.pdf"),
            Path.Combine(outDir, "PDFAToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFAtoPDFAdvanced example...");
        ConvertPDFAtoPDFAdvanced(Path.Combine(dataDir, "PDFAToPDF.pdf"),
            Path.Combine(outDir, "PDFAToPDF_with_empty_page.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFAtoPDF(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Remove PDF/A compliance information
            doc.RemovePdfaCompliance();
            doc.Save(outFileName);
        }
    }

    public static void ConvertPDFAtoPDFAdvanced(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Adding a new (empty) page removes PDF/A compliance information.
            doc.Pages.Add();
            doc.Save(outFileName);
        }
    }
}
