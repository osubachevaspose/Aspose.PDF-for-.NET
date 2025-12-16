using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class ParagraphFromPdf
{
    //https://docs.aspose.com/pdf/net/extract-paragraph-from-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "ParagraphFromPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "ParagraphFromPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractParagraphWithDrawingTheBorder example...");
        ExtractParagraphWithDrawingTheBorder(Path.Combine(dataDir, "DocumentForExtract.pdf"),
            Path.Combine(outDir, "DocumentWithBorder.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractParagraphByIteratingThroughParagraphsCollection example...");
        ExtractParagraphByIteratingThroughParagraphsCollection(Path.Combine(dataDir, "DocumentForExtract.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractParagraphWithDrawingTheBorder(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Page page = doc.Pages[2];
            ParagraphAbsorber absorber = new ParagraphAbsorber();
            absorber.Visit(page);
            PageMarkup markup = absorber.PageMarkups[0];
            foreach (MarkupSection section in markup.Sections)
            {
                DrawRectangleOnPage(section.Rectangle, page);
                foreach (MarkupParagraph paragraph in section.Paragraphs)
                    DrawPolygonOnPage(paragraph.Points, page);
            }
            doc.Save(outFileName);
        }
    }

    private static void DrawRectangleOnPage(Rectangle rectangle, Page page)
    {
        page.Contents.Add(new Operators.GSave());
        page.Contents.Add(new Operators.ConcatenateMatrix(1, 0, 0, 1, 0, 0));
        page.Contents.Add(new Operators.SetRGBColorStroke(0, 1, 0));
        page.Contents.Add(new Operators.SetLineWidth(2));
        page.Contents.Add(
            new Operators.Re(rectangle.LLX,
                rectangle.LLY,
                rectangle.Width,
                rectangle.Height));
        page.Contents.Add(new Operators.ClosePathStroke());
        page.Contents.Add(new Operators.GRestore());
    }

    private static void DrawPolygonOnPage(Point[] polygon, Page page)
    {
        page.Contents.Add(new Operators.GSave());
        page.Contents.Add(new Operators.ConcatenateMatrix(1, 0, 0, 1, 0, 0));
        page.Contents.Add(new Operators.SetRGBColorStroke(0, 0, 1));
        page.Contents.Add(new Operators.SetLineWidth(1));
        page.Contents.Add(new Operators.MoveTo(polygon[0].X, polygon[0].Y));
        for (int i = 1; i < polygon.Length; i++)
            page.Contents.Add(new Operators.LineTo(polygon[i].X, polygon[i].Y));
        page.Contents.Add(new Operators.LineTo(polygon[0].X, polygon[0].Y));
        page.Contents.Add(new Operators.ClosePathStroke());
        page.Contents.Add(new Operators.GRestore());
    }

    public static void ExtractParagraphByIteratingThroughParagraphsCollection(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            ParagraphAbsorber absorber = new ParagraphAbsorber();
            absorber.Visit(doc);
            foreach (PageMarkup markup in absorber.PageMarkups)
            {
                int i = 1;
                foreach (MarkupSection section in markup.Sections)
                {
                    int j = 1;
                    foreach (MarkupParagraph paragraph in section.Paragraphs)
                    {
                        StringBuilder paragraphText = new StringBuilder();
                        foreach (List<TextFragment> line in paragraph.Lines)
                        {
                            foreach (TextFragment fragment in line)
                                paragraphText.Append(fragment.Text);
                            paragraphText.Append(Environment.NewLine);
                        }
                        paragraphText.Append(Environment.NewLine);
                        Console.WriteLine("Paragraph {0} of section {1} on page {2}:", j, i, markup.Number);
                        Console.WriteLine(paragraphText.ToString());
                        j++;
                    }
                    i++;
                }
            }
        }
    }
}
