using System;
using System.IO;
using Aspose.Pdf.Optimization;
using Aspose.Pdf.Security.HiddenDataSanitization;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

public static class HiddenData
{
    //https://docs.aspose.com/pdf/net/clear-hidden-data/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Advanced", "Documents", "HiddenData");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "HiddenData");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ClearHiddenData example...");
        ClearHiddenData(Path.Combine(dataDir, "PdfWithLayers.pdf"),
            Path.Combine(outDir, "ClearHiddenData.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ClearHiddenDataToImages example...");
        ClearHiddenDataToImages(Path.Combine(dataDir, "PdfWithLayers.pdf"),
            Path.Combine(outDir, "ClearHiddenDataToImages.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ClearHiddenDataWithImageCompression example...");
        ClearHiddenDataWithImageCompression(Path.Combine(dataDir, "PdfWithLayers.pdf"),
            Path.Combine(outDir, "ClearHiddenDataWithImageCompression.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ClearHiddenData(string inFileName, string outFileName)
    {
        // Create preconfigured "all-enabled" options (except conversion to images):
        HiddenDataSanitizationOptions options = HiddenDataSanitizationOptions.All();
        // Additionally enable page conversion to images with a specified DPI:
        options.ConvertPagesToImages = true;
        options.ImageDpi = 200;
        HiddenDataSanitizer sanitizer = new HiddenDataSanitizer(options);
        using (Document doc = new Document(inFileName))
        {
            sanitizer.Sanitize(doc);
            doc.Save(outFileName);
        }
    }

    public static void ClearHiddenDataToImages(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Sanitize all hidden data to images with DPI = 100
            HiddenDataSanitizer.SanitizeAllToImages(doc, 100);
            doc.Save(outFileName);
        }
    }

    public static void ClearHiddenDataWithImageCompression(string inFileName, string outFileName)
    {
        // Create preconfigured "all-enabled" options (except conversion to images):
        HiddenDataSanitizationOptions options = HiddenDataSanitizationOptions.All();
        options.ImageCompressionOptions = new ImageCompressionOptions
        {
            MaxResolution = 72,
            ResizeImages = true,
            CompressImages = true
        };
        HiddenDataSanitizer sanitizer = new HiddenDataSanitizer(options);
        using (Document doc = new Document(inFileName))
        {
            sanitizer.Sanitize(doc);
            doc.Save(outFileName);
        }
    }
}
