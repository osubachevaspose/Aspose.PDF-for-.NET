using System;
using System.IO;
using Aspose.Pdf.Optimization;
using Aspose.Pdf.Security.HiddenDataSanitization;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents
{
    public static class HiddenData
    {
        //https://docs.aspose.com/pdf/net/clear-hidden-data/

        public static void RunExamples()
        {
            // The path to the documents directory.
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "HiddenData");
            // The path to the output directory.
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "HiddenData");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running ClearHiddenData example...");
            ClearHiddenData(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "ClearHiddenData_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ClearHiddenDataToImages example...");
            ClearHiddenDataToImages(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "ClearHiddenDataToImages_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ClearHiddenDataWithImageCompression example...");
            ClearHiddenDataWithImageCompression(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "ClearHiddenDataWithImageCompression_out.pdf"));
            Console.WriteLine("...finished.");
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void ClearHiddenData(string inputPath, string outputPath)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Create preconfigured “all-enabled” options (except conversion to images):
                var options = HiddenDataSanitizationOptions.All();

                // Additionally enable page conversion to images with a specified DPI:
                options.ConvertPagesToImages = true;
                options.ImageDpi = 200;

                HiddenDataSanitizer sanitizer = new HiddenDataSanitizer(options);
                sanitizer.Sanitize(document);

                // Save updated PDF document
                document.Save(outputPath);
            }
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void ClearHiddenDataToImages(string inputPath, string outputPath)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Sanitize all hidden data to images with DPI = 100
                HiddenDataSanitizer.SanitizeAllToImages(document, 100);

                // Save updated PDF document
                document.Save(outputPath);
            }
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void ClearHiddenDataWithImageCompression(string inputPath, string outputPath)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Create preconfigured “all-enabled” options (except conversion to images):
                var options = HiddenDataSanitizationOptions.All();
                options.ImageCompressionOptions = new ImageCompressionOptions
                {
                    MaxResolution = 72,
                    ResizeImages = true,
                    CompressImages = true
                };
                HiddenDataSanitizer sanitizer = new HiddenDataSanitizer(options);
                sanitizer.Sanitize(document);

                // Save updated PDF document
                document.Save(outputPath);
            }
        }
    }
}