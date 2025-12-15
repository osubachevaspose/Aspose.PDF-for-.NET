using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PDFtoPDFE
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-pdfe/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PDFtoPDFE");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PDFtoPDFE");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPdfToPdfE example...");
        ConvertPdfToPdfE(Path.Combine(dataDir, "PDFToPDFE.pdf"),
            Path.Combine(outDir, "PDFToPDFE1.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ValidatePdfEStandard example...");
        ValidatePdfEStandard(Path.Combine(dataDir, "ValidatePDFEStandard.pdf"), outDir);
        Console.WriteLine("...finished.");
    }

    public static void ConvertPdfToPdfE(string inFileName, string outFileName)
    {
        // Set up the PDF/E-1 format with PdfFormatConversionOptions
        PdfFormatConversionOptions conversionOptions = new PdfFormatConversionOptions(PdfFormat.PDF_E_1, ConvertErrorAction.Delete);
        using (Document doc = new Document(inFileName))
        {
            // Convert to PDF/E-1 compliant document
            doc.Convert(conversionOptions);
            doc.Save(outFileName);
        }
    }

    public static void ValidatePdfEStandard(string inFileName, string outDir)
    {
        using (Document doc = new Document(inFileName))
        {
            // Validate PDF for PDF/E-1
            doc.Validate(Path.Combine(outDir, "ValidationResultPdfE.xml"), PdfFormat.PDF_E_1);
        }
    }
}
