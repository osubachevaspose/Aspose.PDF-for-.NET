using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents
{
    public static class Layers
    {
        //https://docs.aspose.com/pdf/net/work-with-pdf-layers/

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void RunExamples()
        {
            // The path to the documents directory.
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Layers");
            // The path to the output directory.
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Layers");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running LockLayerInPDF example...");
            LockLayerInPDF(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "LockLayerInPDF_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SaveLayersFromPdf example...");
            SaveLayersFromPdf(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "Layers_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SaveLayersToOutputStream example...");
            using (FileStream fs = new FileStream(Path.Combine(outDir, "Layers_out_stream.pdf"), FileMode.Create))
            {
                SaveLayersToOutputStream(Path.Combine(dataDir, "input.pdf"), fs);
            }
            Console.WriteLine("...finished.");

            Console.WriteLine("Running FlattenLayersInPdf example...");
            FlattenLayersInPdf(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "FlattenLayersInPdf_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running MergeLayersInPdf example...");
            MergeLayersInPdf(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "MergeLayersInPdf_out.pdf"), "new layer");
            Console.WriteLine("...finished.");
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void LockLayerInPDF(string inputPath, string outputPath)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Get the first page and the first layer
                var page = document.Pages[1];
                var layer = page.Layers[0];

                // Lock the layer
                layer.Lock();

                // Save PDF document
                document.Save(outputPath);
            }
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void SaveLayersFromPdf(string inputPath, string outputPath)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Get layers from the first page
                var layers = document.Pages[1].Layers;

                // Save each layer to the output path
                foreach (var layer in layers)
                {
                    layer.Save(outputPath);
                }
            }
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void SaveLayersToOutputStream(string inputPath, Stream outputStream)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Get layers from the first page
                var layers = document.Pages[1].Layers;

                // Save each layer to the output stream
                foreach (var layer in layers)
                {
                    layer.Save(outputStream);
                }
            }
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void FlattenLayersInPdf(string inputPath, string outputPath)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Get the first page
                var page = document.Pages[1];

                // Flatten each layer on the page
                foreach (var layer in page.Layers)
                {
                    layer.Flatten(true);
                }
                
                // Save the document
                document.Save(outputPath);
            }
        }

        // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
        public static void MergeLayersInPdf(string inputPath, string outputPath, string newLayerName, string optionalLayerName = null)
        {
            // Open PDF document
            using (var document = new Document(inputPath))
            {
                // Get the first page
                var page = document.Pages[1];

                // Merge layers with a new layer name
                if (optionalLayerName != null)
                {
                    page.MergeLayers(newLayerName, optionalLayerName);
                }
                else
                {
                    page.MergeLayers(newLayerName);
                }

                // Save PDF document
                document.Save(outputPath);
            }
        }
    }
}