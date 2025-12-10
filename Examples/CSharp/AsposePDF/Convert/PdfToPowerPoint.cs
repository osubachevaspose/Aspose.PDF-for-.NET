using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PdfToPowerPoint
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-powerpoint/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PdfToPowerPoint");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PdfToPowerPoint");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFToPPTX example... ");
        ConvertPDFToPPTX(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFToPPT.pptx"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToPPTWithSlidesAsImages example... ");
        ConvertPDFToPPTWithSlidesAsImages(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFToPPT_SlidesAsImages.pptx"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToPPTWithCustomProgressHandler example... ");
        ConvertPDFToPPTWithCustomProgressHandler(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFToPPTWithProgressTracking.pptx"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFToPPTX(string inFileName, string outFileName)
    {
        // Instantiate PptxSaveOptions object
        PptxSaveOptions saveOptions = new PptxSaveOptions();
        using (Document doc = new Document(inFileName))
        {
            // Save the file in PPTX format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToPPTWithSlidesAsImages(string inFileName, string outFileName)
    {
        // Instantiate PptxSaveOptions object
        PptxSaveOptions saveOptions = new PptxSaveOptions
        {
            SlidesAsImages = true
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in PPTX format with slides as images
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToPPTWithCustomProgressHandler(string inFileName, string outFileName)
    {
        // Instantiate PptxSaveOptions object
        PptxSaveOptions saveOptions = new PptxSaveOptions
        {
            // Specify custom progress handler
            CustomProgressHandler = ShowProgressOnConsole
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in PPTX format with progress tracking
            doc.Save(outFileName, saveOptions);
        }
    }

    private static void ShowProgressOnConsole(UnifiedSaveOptions.ProgressEventHandlerInfo eventInfo)
    {
        switch (eventInfo.EventType)
        {
            case ProgressEventType.TotalProgress:
                // Display overall progress of the conversion
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Conversion progress: {eventInfo.Value}%.");
                break;

            case ProgressEventType.ResultPageCreated:
                // Display progress of the page layout creation
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Result page {eventInfo.Value} of {eventInfo.MaxValue} layout created.");
                break;

            case ProgressEventType.ResultPageSaved:
                // Display progress of the page being exported
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Result page {eventInfo.Value} of {eventInfo.MaxValue} exported.");
                break;

            case ProgressEventType.SourcePageAnalysed:
                // Display progress of the source page analysis
                Console.WriteLine($"{DateTime.Now.TimeOfDay}  - Source page {eventInfo.Value} of {eventInfo.MaxValue} analyzed.");
                break;

            default:
                break;
        }
    }
}
