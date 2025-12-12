using System;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PdfToExcel
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-excel/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PdfToExcel");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PdfToExcel");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFtoExcel example...");
        ConvertPDFtoExcel(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFToXLS.xlsx"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoExcelAdvanced_InsertBlankColumnAtFirst example...");
        ConvertPDFtoExcelAdvanced_InsertBlankColumnAtFirst(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFToXLS_InsertBlankColumnAtFirst.xlsx"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoExcelAdvanced_MinimizeTheNumberOfWorksheets example...");
        ConvertPDFtoExcelAdvanced_MinimizeTheNumberOfWorksheets(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFToXLS_MinimizeTheNumberOfWorksheets.xlsx"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoExcelAdvanced_SaveXLS2003 example...");
        ConvertPDFtoExcelAdvanced_SaveXLS2003(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFToXLS.xls"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToCSV example...");
        ConvertPDFToCSV(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFToXLS.csv"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToODS example...");
        ConvertPDFToODS(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFToODS.ods"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFToXLSM example...");
        ConvertPDFToXLSM(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFToODS.xlsm"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFtoExcel(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions();
        using (Document doc = new Document(inFileName))
        {
            // Save the file in XLSX format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoExcelAdvanced_InsertBlankColumnAtFirst(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions
        {
            InsertBlankColumnAtFirst = false
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in XLSX format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoExcelAdvanced_MinimizeTheNumberOfWorksheets(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions
        {
            MinimizeTheNumberOfWorksheets = true
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in XLSX format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFtoExcelAdvanced_SaveXLS2003(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions
        {
            Format = ExcelSaveOptions.ExcelFormat.XMLSpreadSheet2003
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in XLS format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToCSV(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions
        {
            Format = ExcelSaveOptions.ExcelFormat.CSV
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in CSV format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToODS(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions
        {
            Format = ExcelSaveOptions.ExcelFormat.ODS
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in ODS format
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void ConvertPDFToXLSM(string inFileName, string outFileName)
    {
        // Instantiate ExcelSaveOptions object
        ExcelSaveOptions saveOptions = new ExcelSaveOptions
        {
            Format = ExcelSaveOptions.ExcelFormat.XLSM
        };
        using (Document doc = new Document(inFileName))
        {
            // Save the file in ODS format
            doc.Save(outFileName, saveOptions);
        }
    }
}
