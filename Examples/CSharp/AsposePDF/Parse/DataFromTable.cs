using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class DataFromTable
{
    //https://docs.aspose.com/pdf/net/extract-data-from-table-in-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "DataFromTable");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "DataFromTable");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractTable example...");
        ExtractTable(Path.Combine(dataDir, "input.pdf"));
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running ExtractMarkedTable example...");
        //ExtractMarkedTable(Path.Combine(dataDir, "input.pdf"));
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractTableSaveExcel example...");
        ExtractTableSaveExcel(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "ExtractTableSaveXLS.xlsx"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractTable(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            foreach (Page page in doc.Pages)
            {
                TableAbsorber absorber = new TableAbsorber();
                absorber.Visit(page);
                foreach (AbsorbedTable table in absorber.TableList)
                {
                    Console.WriteLine("Table");
                    foreach (AbsorbedRow row in table.RowList)
                    {
                        foreach (AbsorbedCell cell in row.CellList)
                        {
                            foreach (TextFragment fragment in cell.TextFragments)
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (TextSegment seg in fragment.Segments)
                                    sb.Append(seg.Text);
                                Console.Write(sb + "|");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }

    public static void ExtractMarkedTable(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Page page = doc.Pages[1];
            SquareAnnotation squareAnnotation =
                page.Annotations.FirstOrDefault(ann => ann.AnnotationType == AnnotationType.Square)
                    as SquareAnnotation;
            TableAbsorber absorber = new TableAbsorber();
            absorber.Visit(page);
            foreach (AbsorbedTable table in absorber.TableList)
            {
                bool isInRegion = (squareAnnotation.Rect.LLX < table.Rectangle.LLX) &&
                                  (squareAnnotation.Rect.LLY < table.Rectangle.LLY) &&
                                  (squareAnnotation.Rect.URX > table.Rectangle.URX) &&
                                  (squareAnnotation.Rect.URY > table.Rectangle.URY);
                if (isInRegion)
                {
                    foreach (AbsorbedRow row in table.RowList)
                    {
                        foreach (AbsorbedCell cell in row.CellList)
                        {
                            foreach (TextFragment fragment in cell.TextFragments)
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (TextSegment seg in fragment.Segments)
                                    sb.Append(seg.Text);
                                Console.Write(sb + "|");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }

    public static void ExtractTableSaveExcel(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            ExcelSaveOptions saveOptions = new ExcelSaveOptions
            {
                Format = ExcelSaveOptions.ExcelFormat.XLSX
            };
            doc.Save(outFileName, saveOptions);
        }
    }
}
