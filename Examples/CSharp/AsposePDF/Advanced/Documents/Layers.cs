using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

internal class Layers
{
    //https://docs.aspose.com/pdf/net/work-with-pdf-layers/

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void LockLayerInPDF()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Layers();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
        {
            // Get the first page and the first layer
            var page = document.Pages[1];
            var layer = page.Layers[0];

            // Lock the layer
            layer.Lock();

            // Save PDF document
            document.Save(dataDir + "LockLayerInPDF_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void SaveLayersFromPdf()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Forms();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
        {
            // Get layers from the first page
            var layers = document.Pages[1].Layers;

            // Save each layer to the output path
            foreach (var layer in layers)
            {
                layer.Save(dataDir + "Layers_out.pdf");
            }
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void SaveLayersToOutputStream(Stream outputStream)
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Forms();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
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
    private static void FlattenLayersInPdf()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Forms();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
        {
            // Get the first page
            var page = document.Pages[1];

            // Flatten each layer on the page
            foreach (var layer in page.Layers)
            {
                layer.Flatten(true);
            }
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void MergeLayersInPdf(string newLayerName, string optionalLayerName = null)
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Forms();

        // Open PDF document
        using (var document = new Aspose.Pdf.Document(dataDir + "input.pdf"))
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
            document.Save(dataDir + "MergeLayersInPdf_out.pdf");
        }
    }

}
