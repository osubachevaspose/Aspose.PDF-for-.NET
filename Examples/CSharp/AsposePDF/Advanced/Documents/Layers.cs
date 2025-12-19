using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

public static class Layers
{
    //https://docs.aspose.com/pdf/net/work-with-pdf-layers/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Advanced", "Documents", "Layers");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "Layers");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running LockLayerInPDF example...");
        LockLayerInPDF(Path.Combine(dataDir, "PdfWithLayers.pdf"),
            Path.Combine(outDir, "LockLayerInPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SaveLayersFromPdf example...");
        SaveLayersFromPdf(Path.Combine(dataDir, "PdfWithLayers.pdf"), outDir);
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running SaveLayersToOutputStream example...");
        //using (FileStream fs = new FileStream(Path.Combine(outDir, "Layers_stream.pdf"), FileMode.Create))
        //{
        //    SaveLayersToOutputStream(Path.Combine(dataDir, "PdfWithLayers.pdf"), fs);
        //}
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running FlattenLayersInPdf example...");
        FlattenLayersInPdf(Path.Combine(dataDir, "PdfWithLayers.pdf"),
            Path.Combine(outDir, "FlattenLayersInPdf.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running MergeLayersInPdf example...");
        MergeLayersInPdf(Path.Combine(dataDir, "PdfWithLayers.pdf"),
            Path.Combine(outDir, "MergeLayersInPdf.pdf"), "new layer");
        Console.WriteLine("...finished.");
    }

    public static void LockLayerInPDF(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Get the first page and the first layer
            Page page = doc.Pages[1];
            Layer layer = page.Layers[0];
            // Lock the layer
            layer.Lock();
            doc.Save(outFileName);
        }
    }

    public static void SaveLayersFromPdf(string inFileName, string outDir)
    {
        string name = Path.GetFileNameWithoutExtension(inFileName);
        string ext = Path.GetExtension(inFileName);
        using (Document doc = new Document(inFileName))
        {
            // Get layers from the first page
            List<Layer> layers = doc.Pages[1].Layers;
            // Save each layer
            for (int i = 0; i < layers.Count; i++)
                layers[i].Save(Path.Combine(outDir, name + ".layer." + i + ext));
        }
    }

    public static void SaveLayersToOutputStream(string inFileName, Stream outputStream)
    {
        using (Document doc = new Document(inFileName))
        {
            // Get layers from the first page
            List<Layer> layers = doc.Pages[1].Layers;

            // Save each layer to the output stream
            foreach (Layer layer in layers)
            {
                layer.Save(outputStream);
            }
        }
    }

    public static void FlattenLayersInPdf(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Page page = doc.Pages[1];
            // Flatten each layer on the page
            foreach (Layer layer in page.Layers)
                layer.Flatten(true);
            doc.Save(outFileName);
        }
    }

    public static void MergeLayersInPdf(string inFileName, string outFileName, string newLayerName, string optionalLayerName = null)
    {
        using (Document doc = new Document(inFileName))
        {
            Page page = doc.Pages[1];
            // Merge layers with a new layer name
            if (optionalLayerName != null)
                page.MergeLayers(newLayerName, optionalLayerName);
            else
                page.MergeLayers(newLayerName);
            doc.Save(outFileName);
        }
    }
}
