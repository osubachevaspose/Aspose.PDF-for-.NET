using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PdfToHtml
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-html/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PdfToHtml");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PdfToHtml");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFtoHTML example...");
        ConvertPDFtoHTML(Path.Combine(dataDir, "PDFToHTML.pdf"), Path.Combine(outDir, "output.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoMultiPageHTML example...");
        ConvertPDFtoMultiPageHTML(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "MultiPageHTML.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SavePDFtoHTMLWithSVG example...");
        SavePDFtoHTMLWithSVG(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "SaveSVGFiles.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SavePDFtoCompressedHTMLWithSVG example...");
        SavePDFtoCompressedHTMLWithSVG(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "CompressedSVGHTML.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running PdfToHtmlSaveImagesAsPngBackground example...");
        PdfToHtmlSaveImagesAsPngBackground(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "imagesAsPngBackground.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SavePDFtoHTMLWithSeparateImageFolder example...");
        SavePDFtoHTMLWithSeparateImageFolder(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "HTMLWithSeparateImageFolder.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToHTMLWithBodyContent example...");
        ConvertPDFToHTMLWithBodyContent(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "CreateSubsequentFiles.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToHTMLWithTransparentTextRendering example...");
        ConvertPDFToHTMLWithTransparentTextRendering(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "TransparentTextRendering.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToHTMLWithLayersRendering example...");
        ConvertPDFToHTMLWithLayersRendering(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "LayersRendering.html"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoHTMLWithStream example...");
        ConvertPDFtoHTMLWithStream(Path.Combine(dataDir, "PDFToHTML.pdf"),
            Path.Combine(outDir, "saveToStream.html"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFtoHTML(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Save the output HTML
            doc.Save(outFileName, SaveFormat.Html);
        }
    }

    public static void ConvertPDFtoMultiPageHTML(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Specify to split the output into multiple pages
            SplitIntoPages = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void SavePDFtoHTMLWithSVG(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Specify the folder where SVG images are saved during PDF to HTML conversion
            SpecialFolderForSvgImages = Path.GetDirectoryName(outFileName)
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void SavePDFtoCompressedHTMLWithSVG(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Compress the SVG images if there are any
            CompressSvgGraphicsIfAny = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void PdfToHtmlSaveImagesAsPngBackground(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Option to save images in PNG format as background for each page.
            RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void SavePDFtoHTMLWithSeparateImageFolder(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Specify the separate folder to save images
            SpecialFolderForAllImages = Path.GetDirectoryName(outFileName)
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToHTMLWithBodyContent(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Set HtmlMarkupGenerationMode to generate only body content
            HtmlMarkupGenerationMode = HtmlSaveOptions.HtmlMarkupGenerationModes.WriteOnlyBodyContent,
            // Specify to split the output into multiple pages
            SplitIntoPages = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToHTMLWithTransparentTextRendering(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Enable transparent text rendering
            SaveShadowedTextsAsTransparentTexts = true,
            SaveTransparentTexts = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToHTMLWithLayersRendering(string inFileName, string outFileName)
    {
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Enable rendering of PDF doc layers separately in the output HTML
            ConvertMarkedContentToLayers = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    private static string _folderForReferencedResources;

    public static void ConvertPDFtoHTMLWithStream(string inFileName, string outFileName)
    {
        _folderForReferencedResources = Path.Combine(Path.GetDirectoryName(outFileName), @"saveFolder\");
        // Cleaning existing files
        if (Directory.Exists(_folderForReferencedResources))
            Directory.Delete(_folderForReferencedResources, true);
        // Cleaning existing files
        if (File.Exists(outFileName))
            File.Delete(outFileName);
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Setting up custom strategies for conversion
            CustomCssSavingStrategy = StrategyCssSaving,
            CustomStrategyOfCssUrlCreation = StrategyCssNaming,
            CustomResourceSavingStrategy = StrategyCustomSaveResources
        };
        using (Document doc = new Document(inFileName))
        using (Stream saveStream = File.OpenWrite(outFileName))
        {
            // Save doc to the stream
            doc.Save(saveStream, saveOptions);
        }
    }

    private static void StrategyCssSaving(HtmlSaveOptions.CssSavingInfo resourceInfo)
    {
        // Cleaning existing files
        if (!Directory.Exists(_folderForReferencedResources))
            Directory.CreateDirectory(_folderForReferencedResources);
        // Create a path for a css
        string cssPath = Path.Combine(_folderForReferencedResources, Path.GetFileName(resourceInfo.SupposedURL));
        BinaryReader reader = new BinaryReader(resourceInfo.ContentStream);
        // Recording a css at the created path
        File.WriteAllBytes(cssPath, reader.ReadBytes((int)resourceInfo.ContentStream.Length));
    }

    private static string StrategyCssNaming(HtmlSaveOptions.CssUrlRequestInfo requestInfo)
    {
        return Path.Combine(_folderForReferencedResources, "css_style{0}.css");
    }

    private static string StrategyCustomSaveResources(SaveOptions.ResourceSavingInfo resourceSavingInfo)
    {
        // Cleaning existing files
        if (!Directory.Exists(_folderForReferencedResources))
            Directory.CreateDirectory(_folderForReferencedResources);
        // Create a path for a resource
        string resourcePath = Path.Combine(_folderForReferencedResources, Path.GetFileName(resourceSavingInfo.SupposedFileName));
        BinaryReader binaryReader = new BinaryReader(resourceSavingInfo.ContentStream);
        // Recording a resource at the created path
        File.WriteAllBytes(resourcePath, binaryReader.ReadBytes((int)resourceSavingInfo.ContentStream.Length));
        string urlInHtml = _folderForReferencedResources.Replace(@"\", "/") + Path.GetFileName(resourceSavingInfo.SupposedFileName);
        // Return the resource name to insert into html
        return urlInHtml;
    }
}
