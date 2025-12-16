using System;
using System.IO;
using System.Text;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Devices;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class TextFromPdf
{
    //https://docs.aspose.com/pdf/net/extract-text-from-all-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "TextFromPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "TextFromPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractTextFromDocument example...");
        ExtractTextFromDocument(Path.Combine(dataDir, "ExtractTextAll.pdf"),
            Path.Combine(outDir, "extracted-text_doc.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractTextFromPage example...");
        ExtractTextFromPage(Path.Combine(dataDir, "ExtractTextPage.pdf"),
            Path.Combine(outDir, "extracted-text_page.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractTextFromPagesWithTextDevice example...");
        ExtractTextFromPagesWithTextDevice(Path.Combine(dataDir, "ExtractTextPage.pdf"),
            Path.Combine(outDir, "extracted-text_device.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractTextFromParticularPageRegion example...");
        ExtractTextFromParticularPageRegion(Path.Combine(dataDir, "ExtractTextAll.pdf"),
            Path.Combine(outDir, "extracted-text_region.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractTextBasedOnColumns example...");
        ExtractTextBasedOnColumns(Path.Combine(dataDir, "ExtractTextPage.pdf"),
            Path.Combine(outDir, "ExtractColumnsText.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractTextWithScaleFactor example...");
        ExtractTextWithScaleFactor(Path.Combine(dataDir, "ExtractTextPage.pdf"),
            Path.Combine(outDir, "ExtractTextUsingScaleFactor.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractHighlightedTextFromDocument example...");
        ExtractHighlightedTextFromDocument(Path.Combine(dataDir, "ExtractHighlightedText.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running AccessTextFragmentAndSegmentElementsFromXML example...");
        AccessTextFragmentAndSegmentElementsFromXML(Path.Combine(dataDir, "40014.xml"), 
            Path.Combine(outDir, "DocumentFromXML.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractTextFromDocument(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Create TextAbsorber object to extract text
            TextAbsorber textAbsorber = new TextAbsorber();
            // Accept the absorber for all the pages
            doc.Pages.Accept(textAbsorber);
            // Get the extracted text
            string extractedText = textAbsorber.Text;
            File.WriteAllText(outFileName, extractedText);
        }
    }

    public static void ExtractTextFromPage(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Create TextAbsorber object to extract text
            TextAbsorber textAbsorber = new TextAbsorber();
            // Accept the absorber for a particular page
            doc.Pages[1].Accept(textAbsorber);
            // Get the extracted text
            string extractedText = textAbsorber.Text;
            File.WriteAllText(outFileName, extractedText);
        }
    }

    public static void ExtractTextFromPagesWithTextDevice(string inFileName, string outFileName)
    {
        StringBuilder builder = new StringBuilder();
        // String to hold the extracted text
        using (Document doc = new Document(inFileName))
        {
            foreach (Page page in doc.Pages)
            {
                // Create text device
                TextDevice textDevice = new TextDevice();
                // Set text extraction options - set text extraction mode (Raw or Pure)
                TextExtractionOptions textExtOptions = new TextExtractionOptions(TextExtractionOptions.TextFormattingMode.Pure);
                textDevice.ExtractionOptions = textExtOptions;
                string extractedText;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Convert a particular page and save text to the stream
                    textDevice.Process(page, memoryStream);
                    // Convert a particular page and save text to the stream
                    textDevice.Process(doc.Pages[1], memoryStream);
                    // Get text from memory stream
                    extractedText = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
                builder.Append(extractedText);
            }
        }
        File.WriteAllText(outFileName, builder.ToString());
    }

    public static void ExtractTextFromParticularPageRegion(string inFileName, string outFileName)
    {
        // Create TextAbsorber object to extract text
        TextAbsorber absorber = new TextAbsorber
        {
            TextSearchOptions =
            {
                LimitToPageBounds = true,
                Rectangle = new Rectangle(100, 200, 250, 650)
            }
        };
        using (Document doc = new Document(inFileName))
        {
            // Accept the absorber for first page
            doc.Pages[1].Accept(absorber);
            // Get the extracted text
            string extractedText = absorber.Text;
            File.WriteAllText(outFileName, extractedText);
        }
    }

    public static void ExtractTextBasedOnColumns(string inFileName, string outFileName)
    {
        using (Document sourceDoc = new Document(inFileName))
        {
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber();
            sourceDoc.Pages.Accept(textFragmentAbsorber);
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                // Need to reduce font size at least for 70%
                textFragment.TextState.FontSize *= 0.7f;
            }
            string extractedText;
            using (Stream sourceStream = new MemoryStream())
            {
                sourceDoc.Save(sourceStream);
                using (Document destDoc = new Document(sourceStream))
                {
                    TextAbsorber textAbsorber = new TextAbsorber();
                    destDoc.Pages.Accept(textAbsorber);
                    extractedText = textAbsorber.Text;
                    textAbsorber.Visit(destDoc);
                }
            }
            File.WriteAllText(outFileName, extractedText);
        }
    }

    public static void ExtractTextWithScaleFactor(string inFileName, string outFileName)
    {
        TextAbsorber textAbsorber = new TextAbsorber
        {
            ExtractionOptions = new TextExtractionOptions(TextExtractionOptions.TextFormattingMode.Pure)
            {
                // Setting scale factor to 0.5 is enough to split columns in the majority of documents
                // Setting of zero allows to algorithm choose scale factor automatically
                ScaleFactor = 0.5 /* 0; */
            }
        };
        using (Document doc = new Document(inFileName))
        {
            doc.Pages.Accept(textAbsorber);
            string extractedText = textAbsorber.Text;
            File.WriteAllText(outFileName, extractedText);
        }
    }

    public static void ExtractHighlightedTextFromDocument(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Loop through all the annotations
            foreach (Annotation annotation in doc.Pages[1].Annotations)
            {
                // Filter TextMarkupAnnotation
                if (annotation is TextMarkupAnnotation)
                {
                    TextMarkupAnnotation highlightedAnnotation = annotation as TextMarkupAnnotation;
                    // Retrieve highlighted text fragments
                    TextFragmentCollection collection = highlightedAnnotation.GetMarkedTextFragments();
                    foreach (TextFragment textFragment in collection)
                    {
                        // Display highlighted text
                        Console.WriteLine(textFragment.Text);
                    }
                }
            }
        }
    }

    public static void AccessTextFragmentAndSegmentElementsFromXML(string inFileName, string outFileName)
    {
        using (Document doc = new Document())
        {
            doc.BindXml(inFileName);
            // Get page
            Page page = (Page)doc.GetObjectById("mainSection");
            // Get elements by Id
            TextSegment segment = (TextSegment)doc.GetObjectById("boldHtml");
            segment = (TextSegment)doc.GetObjectById("strongHtml");
            doc.Save(outFileName);
        }
    }
}
