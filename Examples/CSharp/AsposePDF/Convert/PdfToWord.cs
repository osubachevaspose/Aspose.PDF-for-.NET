using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PdfToWord
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-word/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PdfToWord");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PdfToWord");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFtoWord example... ");
        ConvertPDFtoWord(Path.Combine(dataDir, "PDFToDOC.pdf"), Path.Combine(outDir, "PDFToDOC.doc"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoWordDocAdvanced example... ");
        ConvertPDFtoWordDocAdvanced(Path.Combine(dataDir, "PDFToDOC.pdf"),
            Path.Combine(outDir, "PDFToDOC_with_options.doc"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoWord_DOCX_Format example... ");
        ConvertPDFtoWord_DOCX_Format(Path.Combine(dataDir, "PDFToDOC.pdf"),
            Path.Combine(outDir, "PDFToDOC.docx"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoWord_Advanced_DOCX_Format example... ");
        ConvertPDFtoWord_Advanced_DOCX_Format(Path.Combine(dataDir, "PDFToDOC.pdf"),
            Path.Combine(outDir, "PDFToDOC_with_options.docx"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFtoWord(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Save the file into MS document format
            doc.Save(outFileName, SaveFormat.Doc);
        }
    }

    public static void ConvertPDFtoWordDocAdvanced(string inFileName, string outFileName)
    {
        DocSaveOptions saveOptions = new DocSaveOptions
        {
            // Set format to save MS document
            Format = DocSaveOptions.DocFormat.Doc,
            // Set the recognition mode as Flow
            Mode = DocSaveOptions.RecognitionMode.Flow,
            // Set the Horizontal proximity as 2.5
            RelativeHorizontalProximity = 2.5f,
            // Enable the value to recognize bullets during the conversion process
            RecognizeBullets = true
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file into MS document with save options
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoWord_DOCX_Format(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Save the file into MS document format
            doc.Save(outFileName, SaveFormat.DocX);
        }
    }

    public static void ConvertPDFtoWord_Advanced_DOCX_Format(string inFileName, string outFileName)
    {
        DocSaveOptions saveOptions = new DocSaveOptions
        {
            // Set format to save MS document
            Format = DocSaveOptions.DocFormat.DocX,
            // Set the recognition mode as EnhancedFlow
            Mode = DocSaveOptions.RecognitionMode.EnhancedFlow
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file into MS document format
            doc.Save(outFileName, saveOptions);
        }
    }
}
