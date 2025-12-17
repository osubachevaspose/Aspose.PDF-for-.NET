using System;
using System.IO;
using Aspose.Pdf.Operators;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

public static class Create
{
    //https://docs.aspose.com/pdf/net/create-pdf-document/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Advanced", "Documents", "Create");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "Create");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running CreateHelloWorldDocument example...");
        CreateHelloWorldDocument(Path.Combine(outDir, "HelloWorld.pdf"));
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running CreateSearchableDocument example...");
        //CreateSearchableDocument(Path.Combine(dataDir, "SearchableDocument.pdf"), 
        //    Path.Combine(outDir, "SearchableDocument.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running CreateAnAccessibleDocument example...");
        //CreateAnAccessibleDocument(Path.Combine(dataDir, "tourguidev2_gb_tags.pdf"),
        //    Path.Combine(outDir, "AccessibleDocument.pdf"));
        //Console.WriteLine("...finished.");
    }

    public static void CreateHelloWorldDocument(string outFileName)
    {
        using (Document doc = new Document())
        {
            // Add page
            Page page = doc.Pages.Add();
            // Add text to new page
            page.Paragraphs.Add(new Text.TextFragment("Hello World!"));
            // Save PDF document
            doc.Save(outFileName);
        }
    }

    //public static void CreateSearchableDocument(string inFileName, string outFileName)
    //{
    //    using (Document doc = new Document(inFileName))
    //    {
    //        doc.Convert(CallBackGetHocr);
    //        doc.Save(outFileName);
    //    }
    //}

    //private static string CallBackGetHocr(System.Drawing.Image img)
    //{
    //    string tmpFile = Path.GetTempFileName();
    //    try
    //    {
    //        using (Bitmap bmp = new Bitmap(img))
    //        {
    //            bmp.Save(tmpFile, System.Drawing.Imaging.ImageFormat.Bmp);
    //        }
    //        string inputFile = string.Concat('"', tmpFile, '"');
    //        string outputFile = string.Concat('"', tmpFile, '"');
    //        string arguments = string.Concat(inputFile, " ", outputFile, " -l eng hocr");
    //        string tesseractProcessName = RunExamples.GetTesseractExePath();
    //        ProcessStartInfo processStartInfo = new ProcessStartInfo(tesseractProcessName, arguments)
    //        {
    //            UseShellExecute = true,
    //            CreateNoWindow = true,
    //            WindowStyle = ProcessWindowStyle.Hidden,
    //            WorkingDirectory = Path.GetDirectoryName(tesseractProcessName)
    //        };
    //        Process process = new Process
    //        {
    //            StartInfo = processStartInfo
    //        };
    //        process.Start();
    //        process.WaitForExit();
    //        using (StreamReader streamReader = new StreamReader(tmpFile + ".hocr"))
    //        {
    //            return streamReader.ReadToEnd();
    //        }
    //    }
    //    finally
    //    {
    //        if (File.Exists(tmpFile)) 
    //            File.Delete(tmpFile);
    //        if (File.Exists(tmpFile + ".hocr")) 
    //            File.Delete(tmpFile + ".hocr");
    //    }
    //}

    public static void CreateAnAccessibleDocument(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Access tagged content
            Tagged.ITaggedContent content = doc.TaggedContent;
            // Create span element
            LogicalStructure.SpanElement span = content.CreateSpanElement();
            // Append span to root element
            content.RootElement.AppendChild(span);
            // Iterate over page contents
            foreach (Operator op in doc.Pages[1].Contents)
            {
                BDC bdc = op as BDC;
                if (bdc != null)
                    span.Tag(bdc);
            }
            doc.Save(outFileName);
        }
    }
}
