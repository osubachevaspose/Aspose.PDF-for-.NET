using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf.Vector;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class VectorDataFromPdf
{
    //https://docs.aspose.com/pdf/net/extract-vector-data-from-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "VectorDataFromPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "VectorDataFromPdf");
        Directory.CreateDirectory(outDir);

        //Console.WriteLine("Running ProcessGraphicsInPDF example...");
        //ProcessGraphicsInPDF(Path.Combine(dataDir, "input.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running SaveVectorGraphicsFromPage example...");
        //SaveVectorGraphicsFromPage(Path.Combine(dataDir, "VectorGraphics.pdf"),
        //    Path.Combine(outDir, "VectorGraphics.svg"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ExtractAllSubpathsToImagesSeparately example...");
        //ExtractAllSubpathsToImagesSeparately(Path.Combine(dataDir, "VectorGraphics.pdf"), outDir);
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ExtractListOfElementsToSingleImage example...");
        //ExtractListOfElementsToSingleImage(Path.Combine(dataDir, "VectorGraphics.pdf"),
        //    Path.Combine(outDir, "SvgOutput", "VectorGraphics_SingleImage.svg"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ExtractSingleElement example...");
        //ExtractSingleElement(Path.Combine(dataDir, "VectorGraphics.pdf"),
        //    Path.Combine(outDir, "SvgOutput", "VectorGraphics_SingleElement.svg"));
        //Console.WriteLine("...finished.");
    }

    public static void ProcessGraphicsInPDF(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Instantiate a new GraphicsAbsorber object to process graphic elements
            using (GraphicsAbsorber graphicsAbsorber = new GraphicsAbsorber())
            {
                graphicsAbsorber.Visit(doc.Pages[1]);
                // Retrieve the list of graphic elements from the GraphicsAbsorber
                GraphicElementCollection elements = graphicsAbsorber.Elements;
                // Access the operators associated with the second graphic element
                List<Operator> operations = elements[1].Operators;
                // Retrieve the rectangle associated with the second graphic element
                Rectangle rectangle = elements[1].Rectangle;
                // Get the position of the second graphic element
                Point position = elements[1].Position;
            }
        }
    }

    public static void SaveVectorGraphicsFromPage(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Save vector graphics from the first page to SVG file
            doc.Pages[1].TrySaveVectorGraphics(outFileName);
        }
    }

    public static void ExtractAllSubpathsToImagesSeparately(string inFileName, string outDir)
    {
        // Create extraction options
        SvgExtractionOptions extractionOptions = new SvgExtractionOptions
        {
            ExtractEverySubPathToSvg = true
        };
        using (Document doc = new Document(inFileName))
        {
            // Get the first page of the document
            Page page = doc.Pages[1];
            // Create SVG extractor
            SvgExtractor svgExtractor = new SvgExtractor(extractionOptions);
            // Extract SVGs from the page
            svgExtractor.Extract(page, Path.Combine(outDir, "SvgOutput"));
        }
    }

    public static void ExtractListOfElementsToSingleImage(string inFileName, string outFileName)
    {
        // Initialize the list of graphic elements
        List<GraphicElement> elements = new List<GraphicElement>();

        // Example: Fill elements list with needed graphic elements (implement your logic here)

        using (Document doc = new Document(inFileName))
        {
            // Get the first page of the document
            Page page = doc.Pages[1];
            // Use SvgExtractor to extract SVGs
            SvgExtractor svgExtractor = new SvgExtractor();
            // Extract SVGs from graphic elements on the page
            svgExtractor.Extract(elements, page, outFileName);
        }
    }

    public static void ExtractSingleElement(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Create a GraphicsAbsorber object to extract graphic elements
            GraphicsAbsorber graphicsAbsorber = new GraphicsAbsorber();
            // Get the first page of the document
            Page page = doc.Pages[1];
            // Process the page to extract graphic elements
            graphicsAbsorber.Visit(page);
            // Extract the graphic element (XFormPlacement) and save it as SVG
            XFormPlacement xFormPlacement = graphicsAbsorber.Elements[1] as XFormPlacement;
            xFormPlacement.Elements[2].SaveToSvg(outFileName);
        }
    }
}
