using System;
using System.IO;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PDFtoPDFA
{

    //https://docs.aspose.com/pdf/net/convert-pdf-to-pdfa/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PDFtoPDFA");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PDFtoPDFA");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPdfToPdfA example...");
        ConvertPdfToPdfA(Path.Combine(dataDir, "PDFToPDFA.pdf"),
            Path.Combine(outDir, "PDFToPDFA.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ValidatePdfAStandard example...");
        ValidatePdfAStandard(Path.Combine(dataDir, "ValidatePDFAStandard.pdf"), outDir);
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPdfToPdfA3b example...");
        ConvertPdfToPdfA3b(Path.Combine(dataDir, "PDFToPDFA.pdf"),
            Path.Combine(outDir, "PDFToPDFA3b.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPdfToPdfA4 example...");
        ConvertPdfToPdfA4(Path.Combine(dataDir, "PDFToPDFA.pdf"),
            Path.Combine(outDir, "PDFToPDFA4.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running AddAttachmentToPdfA example...");
        AddAttachmentToPdfA(Path.Combine(dataDir, "PDFToPDFA.pdf"),
            Path.Combine(outDir, "AddAttachmentToPDFA.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ReplaceMissingFonts example...");
        ReplaceMissingFonts(Path.Combine(dataDir, "PDFToPDFA.pdf"),
            Path.Combine(outDir, "ReplaceMissingFonts.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertToPdfAWithAutomaticTagging example...");
        ConvertToPdfAWithAutomaticTagging(Path.Combine(dataDir, "PDFToPDFA.pdf"),
            Path.Combine(outDir, "ConvertToPdfAWithAutomaticTagging.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPdfToPdfA(string inFileName, string outFileName)
    {
        string outLogFileName = Path.Combine(Path.GetDirectoryName(outFileName), "PDFA1bConversionLog.xml");
        using (Document doc = new Document(inFileName))
        {
            // Convert to PDF/A compliant document
            // During conversion process, the validation is also performed
            doc.Convert(outLogFileName, PdfFormat.PDF_A_1B, ConvertErrorAction.Delete);
            doc.Save(outFileName);
        }
    }

    public static void ValidatePdfAStandard(string inFileName, string outDir)
    {
        using (Document doc = new Document(inFileName))
        {
            // Validate PDF for PDF/A-1a
            doc.Validate(Path.Combine(outDir, "ValidationResultA1b.xml"), PdfFormat.PDF_A_1B);
        }
    }

    public static void ConvertPdfToPdfA3b(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Convert to PDF/A compliant document, log file is omitted
            doc.Convert(Stream.Null, PdfFormat.PDF_A_3B, ConvertErrorAction.Delete);
            doc.Save(outFileName);
        }
    }

    public static void ConvertPdfToPdfA4(string inFileName, string outFileName)
    {
        string outLogFileName = Path.Combine(Path.GetDirectoryName(outFileName), "PDFA4ConversionLog.xml");
        using (Document doc = new Document(inFileName))
        {
            // If the document version is less than PDF-2.0, it must be converted to PDF-2.0
            doc.Convert(Stream.Null, PdfFormat.v_2_0, ConvertErrorAction.Delete);
            // Convert to the PDF/A-4 format
            doc.Convert(outLogFileName, PdfFormat.PDF_A_4, ConvertErrorAction.Delete);
            doc.Save(outFileName);
        }
    }

    public static void AddAttachmentToPdfA(string inFileName, string outFileName)
    {
        string outDir = Path.GetDirectoryName(outFileName);
        using (Document doc = new Document(inFileName))
        {
            // Setup new file to be added as attachment
            using (FileSpecification fileSpecification =
                   new FileSpecification(Path.Combine(outDir, "aspose-logo.jpg"), "Large Image file"))
            {
                // Add attachment to document's attachment collection
                doc.EmbeddedFiles.Add(fileSpecification);
                // Perform conversion to PDF/A-3a, so that the attachment is included in the resultant file
                doc.Convert(Path.Combine(outDir, "PDFA3aConversionLog.xml"), PdfFormat.PDF_A_3A, ConvertErrorAction.Delete);
                doc.Save(outFileName);
            }
        }
    }

    public static void ReplaceMissingFonts(string inFileName, string outFileName)
    {
        try
        {
            // Check whether a font, used in the source document, is installed in the system
            FontRepository.FindFont("AgencyFB");
        }
        catch (FontNotFoundException)
        {
            // Font is missing on the destination machine. Replace it with the Arial font installed in the system
            SimpleFontSubstitution fontSubstitution = new SimpleFontSubstitution("AgencyFB", "Arial");
            FontRepository.Substitutions.Add(fontSubstitution);
        }
        string outLogFileName = Path.Combine(Path.GetDirectoryName(outFileName), "ReplaceMissingFonts.xml");
        using (Document doc = new Document(inFileName))
        {
            // During the conversion, the missing font will be replaced with the substitution one
            doc.Convert(outLogFileName, PdfFormat.PDF_A_1B, ConvertErrorAction.Delete);
            doc.Save(outFileName);
        }
    }

    public static void ConvertToPdfAWithAutomaticTagging(string inFileName, string outFileName)
    {
        // Aspose.Pdf.AutoTaggingSettings.Default may be used to set the same settings as given below
        AutoTaggingSettings autoTaggingSettings = new AutoTaggingSettings
        {
            // Enable auto-tagging during the conversion process
            EnableAutoTagging = true,
            // Use the heading recognition strategy that's optimal for the given document structure
            HeadingRecognitionStrategy = HeadingRecognitionStrategy.Auto
        };
        string outLogFileName = Path.Combine(Path.GetDirectoryName(outFileName), "ConvertToPdfAWithAutomaticTagging.xml");
        PdfFormatConversionOptions conversionOptions =
            new PdfFormatConversionOptions(outLogFileName, PdfFormat.PDF_A_1B, ConvertErrorAction.Delete)
            {
                // Assign auto-tagging settings to be used during the conversion process
                AutoTaggingSettings = autoTaggingSettings
            };
        using (Document doc = new Document(inFileName))
        {
            // During the conversion, the document logical structure will be automatically created
            doc.Convert(conversionOptions);
            doc.Save(outFileName);
        }
    }
}
