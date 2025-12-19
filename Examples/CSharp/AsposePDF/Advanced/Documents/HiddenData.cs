using Aspose.Pdf.Optimization;
using Aspose.Pdf.Security.HiddenDataSanitization;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

internal class HiddenData
{
    //https://docs.aspose.com/pdf/net/clear-hidden-data/

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ClearHiddenData()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Layers();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
        {
            // Create preconfigured “all-enabled” options (except conversion to images):
            var options = Aspose.Pdf.Security.HiddenDataSanitization.HiddenDataSanitizationOptions.All();

            // Additionally enable page conversion to images with a specified DPI:
            options.ConvertPagesToImages = true;
            options.ImageDpi = 200;

            HiddenDataSanitizer sanitizer = new HiddenDataSanitizer(options);
            sanitizer.Sanitize(document);

            // Save updated PDF document
            document.Save(dataDir + "output.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ClearHiddenDataToImages()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Layers();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
        {
            // Sanitize all hidden data to images with DPI = 100
            HiddenDataSanitizer.SanitizeAllToImages(document, 100);

            // Save updated PDF document
            document.Save(dataDir + "output.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ClearHiddenDataWithImageCompression()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Layers();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
        {
            // Create preconfigured “all-enabled” options (except conversion to images):
            var options = Aspose.Pdf.Security.HiddenDataSanitization.HiddenDataSanitizationOptions.All();
            options.ImageCompressionOptions = new ImageCompressionOptions
            {
                MaxResolution = 72,
                ResizeImages = true,
                CompressImages = true
            };
            HiddenDataSanitizer sanitizer = new HiddenDataSanitizer(options);
            sanitizer.Sanitize(document);

            // Save updated PDF document
            document.Save(dataDir + "output.pdf");
        }
    }
}
