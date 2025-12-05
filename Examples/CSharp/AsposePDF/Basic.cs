using System;
using System.IO;
using System.Net;
using Aspose.Pdf.Operators;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF
{
    public static class Basic
    {
        public static void RunExamples()
        {
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Basic");
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Basic");
            Directory.CreateDirectory(outDir);

            Console.Write("Running HelloWorld example... ");
            HelloWorld(Path.Combine(outDir, "HelloWorld_out.pdf"));
            Console.WriteLine("finished.");

            Console.Write("Running OpenDocument example... ");
            OpenDocument(Path.Combine(dataDir, "input.pdf"));
            Console.WriteLine("finished.");

            Console.Write("Running OpenDocumentStream example... ");
            OpenDocumentStream(
                "https://www.sj.se/content/dam/SJ/pdf/Engelska/",
                "SJPR0033_Folder_Utland_16sid_ENG_web3.pdf");
            Console.WriteLine("finished.");
        }

        public static void HelloWorld(string outputFileName)
        {
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Add text to new page
                page.Paragraphs.Add(new Text.TextFragment("Hello World!"));
                // Save PDF document
                doc.Save(outputFileName);
            }
        }

        public static void OpenDocument(string inputFileName)
        {
            using (Document doc = new Document(inputFileName))
                Console.WriteLine("Pages " + doc.Pages.Count);
        }

        public static void OpenDocumentStream(string address, string fileName)
        {
            // Create a new WebClient instance
            WebClient webClient = new WebClient();
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\"...\n", fileName, address);
            using (MemoryStream ms = new MemoryStream())
            {
                // Concatenate the domain with the Web resource filename
                webClient.OpenRead(address + fileName)?.CopyTo(ms);
                ms.Position = 0;
                using (Document doc = new Document(ms))
                    Console.WriteLine("Pages " + doc.Pages.Count);
            }
        }

        public static void OpenDocumentWithPassword()
        {
            string dataDir = Examples.GetDataDir_AsposePdf_Basic();
            const string password = "Aspose2020";
            try
            {
                using (Document doc = new Document(Path.Combine(dataDir, "DocSite.pdf", password)))
                    Console.WriteLine("Pages " + doc.Pages.Count);
            }
            catch (InvalidPasswordException e)
            {
                Console.WriteLine(e);
            }
        }

        //public static void SaveDocument()
        //{
        //    // The path to the documents directory
        //    var dataDir = Examples.GetDataDir_AsposePdf();

        //    // Open PDF document
        //    using (var document = new Aspose.Pdf.Document(dataDir + "SimpleResume.pdf"))
        //    {
        //        // Make some manipation, i.g add new empty page
        //        document.Pages.Add();
        //        // Save PDF document
        //        document.Save(dataDir + "SimpleResume_out.pdf");
        //    }
        //}

        //public static void SaveDocumentStream()
        //{
        //    // The path to the documents directory
        //    var dataDir = Examples.GetDataDir_AsposePdf();

        //    // Open PDF document
        //    using (var document = new Aspose.Pdf.Document(dataDir + "SimpleResume.pdf"))
        //    {
        //        // Make some manipation, i.g add new empty page
        //        document.Pages.Add();
        //        // Save PDF document
        //        document.Save(dataDir + "SimpleResume_out.pdf");
        //    }
        //}

        //public static void SaveDocumentAsPDFx()
        //{
        //    // The path to the documents directory
        //    var dataDir = Examples.GetDataDir_AsposePdf();

        //    // Open PDF document
        //    using (var document = new Aspose.Pdf.Document(dataDir + "SimpleResume.pdf"))
        //    {
        //        // Add page
        //        document.Pages.Add();
        //        // Convert a document to a PDF/X-3 format
        //        document.Convert(new Aspose.Pdf.PdfFormatConversionOptions(Aspose.Pdf.PdfFormat.PDF_X_3));
        //        // Save PDF document
        //        document.Save(dataDir + "SimpleResume_X3.pdf");
        //    }
        //}

        public static void DrawRectangle()
        {
            // The path to the documents directory
            string dataDir = Examples.GetDataDir_AsposePdf_Text();
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add the page
                Page page = doc.Pages.Add();
                // Save graphicState
                page.Contents.Add(new GSave());
                // Colorize rectangle
                SetRGBColorStroke colorStroke = new SetRGBColorStroke(0.7, 0, 0);
                page.Contents.Add(colorStroke);
                // Create and add Rectangle on page
                Rectangle rectangle = new Rectangle(100, 100, 200, 150);
                page.Contents.Add(
                    new Re(rectangle.LLX,
                        rectangle.LLY,
                        rectangle.Width,
                        rectangle.Height));
                // Close path
                page.Contents.Add(new ClosePathStroke());
                // Restore graphic state
                page.Contents.Add(new GRestore());
                // Save PDF document
                doc.Save(dataDir + "DrawRectangle.pdf");
            }
        }
    }
}
