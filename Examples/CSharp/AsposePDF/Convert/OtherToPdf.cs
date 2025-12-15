using System;
using System.Drawing;
using System.IO;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class OtherToPdf
{
    //https://docs.aspose.com/pdf/net/convert-other-files-to-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "OtherToPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "OtherToPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertEPUBtoPDF example...");
        ConvertEPUBtoPDF(Path.Combine(dataDir, "EPUBToPDF.epub"),
            Path.Combine(outDir, "ConvertEPUBtoPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertEPUBtoPDFAdv example...");
        ConvertEPUBtoPDFAdv(Path.Combine(dataDir, "EPUBToPDF.epub"),
            Path.Combine(outDir, "ConvertEPUBtoPDFAdv.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertMarkdownToPDF example...");
        ConvertMarkdownToPDF(Path.Combine(dataDir, "sample.md"),
            Path.Combine(outDir, "ConvertMarkdownToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPCLtoPDF example...");
        ConvertPCLtoPDF(Path.Combine(dataDir, "ConvertPCLtoPDF.pcl"),
            Path.Combine(outDir, "ConvertPCLtoPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPCLtoPDFAdvanced example...");
        ConvertPCLtoPDFAdvanced(Path.Combine(dataDir, "ConvertPCLtoPDFAdvanced.pcl"),
            Path.Combine(outDir, "ConvertPCLtoPDFAdvanced.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPlainTextFileToPDF example...");
        ConvertPlainTextFileToPDF(Path.Combine(dataDir, "TextToPDFInput.txt"),
            Path.Combine(outDir, "TextToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPreFormattedTextToPdf example...");
        ConvertPreFormattedTextToPdf(Path.Combine(dataDir, "ConvertPreFormattedTextToPdf.txt"),
            Path.Combine(outDir, "PreFormattedTextToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertXPSToPDF example...");
        ConvertXPSToPDF(Path.Combine(dataDir, "XPSToPDF.xps"),
            Path.Combine(outDir, "ConvertXPSToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPostScriptToPDF example...");
        ConvertPostScriptToPDF(Path.Combine(dataDir, "ConvertPostscriptInput.ps"),
            Path.Combine(outDir, "PSToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPostscriptToPDFAdvanced example...");
        ConvertPostscriptToPDFAdvanced(Path.Combine(dataDir, "ConvertPostscriptInput.ps"),
            Path.Combine(outDir, "ConvertPostscriptToPDFAdvanced.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertXSLFOToPDF example...");
        ConvertXSLFOToPDF(Path.Combine(dataDir, "XSLFOToPdfInput.xslt"),
            Path.Combine(dataDir, "XSLFOToPdfInput.xml"),
            Path.Combine(outDir, "XSLFOToPdf.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertTeXtoPDF example...");
        ConvertTeXtoPDF(Path.Combine(dataDir, "samplefile.tex"),
            Path.Combine(outDir, "TeXToPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertOFDToPDF example...");
        ConvertOFDToPDF(Path.Combine(dataDir, "ConvertOFDToPDF.ofd"),
            Path.Combine(outDir, "ConvertOFDToPDF.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertEPUBtoPDF(string inFileName, string outFileName)
    {
        EpubLoadOptions loadOptions = new EpubLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertEPUBtoPDFAdv(string inFileName, string outFileName)
    {
        EpubLoadOptions loadOptions = new EpubLoadOptions(new SizeF(1190, 1684));
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertMarkdownToPDF(string inFileName, string outFileName)
    {
        MdLoadOptions loadOptions = new MdLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertPCLtoPDF(string inFileName, string outFileName)
    {
        PclLoadOptions loadOptions = new PclLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertPCLtoPDFAdvanced(string inFileName, string outFileName)
    {
        PclLoadOptions loadOptions = new PclLoadOptions
        {
            SupressErrors = true
        };
        using (Document doc = new Document(inFileName, loadOptions))
        {
            if (loadOptions.Exceptions != null)
            {
                foreach (Exception ex in loadOptions.Exceptions)
                    Console.WriteLine(ex.Message);
            }
            doc.Save(outFileName);
        }
    }

    public static void ConvertPlainTextFileToPDF(string inFileName, string outFileName)
    {
        using (StreamReader streamReader = new StreamReader(inFileName))
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            // Create an instance of TextFragment and pass the text from reader object to its constructor as argument
            TextFragment text = new TextFragment(streamReader.ReadToEnd());
            // Add a new text paragraph in paragraphs collection and pass the TextFragment object
            page.Paragraphs.Add(text);
            doc.Save(outFileName);
        }
    }

    public static void ConvertPreFormattedTextToPdf(string inFileName, string outFileName)
    {
        string[] lines = File.ReadAllLines(inFileName);
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            // Set left and right margins for better presentation
            page.PageInfo.Margin.Left = 20;
            page.PageInfo.Margin.Right = 10;
            page.PageInfo.DefaultTextState.Font = FontRepository.FindFont("Courier New");
            page.PageInfo.DefaultTextState.FontSize = 12;
            foreach (string line in lines)
            {
                // check if line contains "form feed" character
                // see https://en.wikipedia.org/wiki/Page_break
                if (line.StartsWith(@"\x0c"))
                {
                    page = doc.Pages.Add();
                    page.PageInfo.Margin.Left = 20;
                    page.PageInfo.Margin.Right = 10;
                    page.PageInfo.DefaultTextState.Font = FontRepository.FindFont("Courier New");
                    page.PageInfo.DefaultTextState.FontSize = 12;
                }
                else
                {
                    // Create an instance of TextFragment and pass the line to its constructor as argument
                    TextFragment text = new TextFragment(line);
                    // Add a new text paragraph in paragraphs collection and pass the TextFragment object
                    page.Paragraphs.Add(text);
                }
            }
            doc.Save(outFileName);
        }
    }

    public static void ConvertXPSToPDF(string inFileName, string outFileName)
    {
        XpsLoadOptions loadOptions = new XpsLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertPostScriptToPDF(string inFileName, string outFileName)
    {
        PsLoadOptions loadOptions = new PsLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertPostscriptToPDFAdvanced(string inFileName, string outFileName)
    {
        string inDir = Path.GetDirectoryName(inFileName);
        PsLoadOptions loadOptions = new PsLoadOptions
        {
            FontsFolders = new[]
            {
                Path.Combine(inDir, "fonts1"),
                Path.Combine(inDir, "fonts2")
            }
        };
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertXSLFOToPDF(string inXslFileName, string inXmlFileName, string outFileName)
    {
        XslFoLoadOptions loadOptions = new XslFoLoadOptions(inXslFileName)
        {
            // Set error handling strategy
            ParsingErrorsHandlingType = XslFoLoadOptions.ParsingErrorsHandlingTypes.ThrowExceptionImmediately
        };
        using (Document doc = new Document(inXmlFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertTeXtoPDF(string inFileName, string outFileName)
    {
        TeXLoadOptions loadOptions = new TeXLoadOptions();
        //loadOptions.OutputDirectory = Path.GetDirectoryName(outFileName);
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertOFDToPDF(string inFileName, string outFileName)
    {
        OfdLoadOptions loadOptions = new OfdLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }
}
