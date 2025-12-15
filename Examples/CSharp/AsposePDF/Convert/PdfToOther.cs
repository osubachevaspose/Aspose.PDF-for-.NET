using System;
using System.IO;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PdfToOther
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-other-files/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PdfToOther");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PdfToOther");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFtoEPUB example...");
        ConvertPDFtoEPUB(Path.Combine(dataDir, "PDFToEPUB.pdf"),
            Path.Combine(outDir, "PDFToEPUB.epub"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoTeX example...");
        ConvertPDFtoTeX(Path.Combine(dataDir, "PDFToTeX.pdf"), Path.Combine(outDir, "PDFToTeX.tex"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoTXT example...");
        ConvertPDFtoTXT(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "input_Text_Extracted.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoTXT_Pages example...");
        ConvertPDFtoTXT_Pages(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "input_Text_Extracted_Pages.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoXPS example...");
        ConvertPDFtoXPS(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFtoXPS.xps"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoMarkdown example...");
        ConvertPDFtoMarkdown(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFtoMarkdown.md"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPdfToMobiXml example...");
        ConvertPdfToMobiXml(Path.Combine(dataDir, "PDFToXML.pdf"),
            Path.Combine(outDir, "PDFToXML.xml"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFtoEPUB(string inFileName, string outFileName)
    {
        // Instantiate Epub Save options
        EpubSaveOptions saveOptions = new EpubSaveOptions
        {
            // Specify the layout for contents
            ContentRecognitionMode = EpubSaveOptions.RecognitionMode.Flow
        };
        using (Document doc = new Document(inFileName))
        {
            // Save ePUB document
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoTeX(string inFileName, string outFileName)
    {
        LaTeXSaveOptions saveOptions = new LaTeXSaveOptions
        {
            // Specify the output directory
            OutDirectoryPath = Path.GetDirectoryName(outFileName)
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoTXT(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            TextAbsorber textAbsorber = new TextAbsorber();
            textAbsorber.Visit(doc);
            // Save the extracted text in text file
            File.WriteAllText(outFileName, textAbsorber.Text);
        }
    }

    public static void ConvertPDFtoTXT_Pages(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            TextAbsorber textAbsorber = new TextAbsorber();
            int[] pages = new[] { 2 };
            foreach (int i in pages)
                textAbsorber.Visit(doc.Pages[i]);
            // Save the extracted text in text file
            File.WriteAllText(outFileName, textAbsorber.Text);
        }
    }

    public static void ConvertPDFtoXPS(string inFileName, string outFileName)
    {
        XpsSaveOptions saveOptions = new XpsSaveOptions
        {
            SaveTransparentTexts = true
        };
        using (Document doc = new Document(inFileName))
        {
            // Save XPS document
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoMarkdown(string inFileName, string outFileName)
    {
        MarkdownSaveOptions saveOptions = new MarkdownSaveOptions
        {
            // Set to false to prevent the use of HTML <img> tags for images in the Markdown output
            UseImageHtmlTag = false,
            // Specify the directory where resources (like images) will be stored
            ResourcesDirectoryName = "images"
        };
        using (Document doc = new Document(inFileName))
        {
            // Save PDF document in Markdown format to the specified output file path using the defined save options   
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPdfToMobiXml(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Save PDF document in XML format
            doc.Save(outFileName, SaveFormat.MobiXml);
        }
    }
}
