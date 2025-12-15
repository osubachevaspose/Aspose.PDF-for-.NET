using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PDFtoPDFX
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-pdfx/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PDFtoPDFX");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PDFtoPDFX");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPdfToPdfX example...");
        ConvertPdfToPdfX(Path.Combine(dataDir, "PDFToPDFX.pdf"),
            Path.Combine(outDir, "PDFToPDFX4.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPdfToPdfX(string inFileName, string outFileName)
    {
        // Set up the desired PDF/X format with PdfFormatConversionOptions
        PdfFormatConversionOptions conversionOptions = new PdfFormatConversionOptions(PdfFormat.PDF_X_4, ConvertErrorAction.Delete)
        {
            // Provide the name of the external ICC profile file (optional)
            IccProfileFileName = Path.Combine(Path.GetDirectoryName(inFileName), "ISOcoated_v2_eci.icc"),
            // Provide an output condition identifier and other necessary OutputIntent properties (optional)
            OutputIntent = new OutputIntent("FOGRA39")
        };
        using (Document doc = new Document(inFileName))
        {
            // Convert to PDF/X compliant document
            doc.Convert(conversionOptions);
            doc.Save(outFileName);
        }
    }
}
