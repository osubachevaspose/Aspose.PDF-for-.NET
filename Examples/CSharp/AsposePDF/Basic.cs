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
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "GetStarted");
            HelloWorld(Path.Combine(dataDir, "HelloWorld_out.pdf"));
        }

        public static void HelloWorld(string outputFileName)
        {
            // The path to the documents directory
            string dataDir = Examples.GetDataDir_AsposePdf_Basic();
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

        public static void OpenDocument()
        {
            string dataDir = Examples.GetDataDir_AsposePdf_Basic();
            using (Document doc = new Document(Path.Combine(dataDir, "tourguidev2_gb_tags.pdf")))
                Console.WriteLine("Pages " + doc.Pages.Count);
        }

        public static void OpenDocumentStream()
        {
            string fileName = "SJPR0033_Folder_Utland_16sid_ENG_web3.pdf";
            string remoteUri = "https://www.sj.se/content/dam/SJ/pdf/Engelska/";
            // Create a new WebClient instance
            WebClient webClient = new WebClient();
            // Concatenate the domain with the Web resource filename
            string strWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, strWebResource);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                webClient.OpenRead(strWebResource)?.CopyTo(memoryStream);
                using (Document doc = new Document(memoryStream))
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

        public static void LatexWithoutPreambleAndDocEnvironment()
        {
            // The path to the documents directory
            string dataDir = Examples.GetDataDir_AsposePdf_Text();
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Create a Table
                Table table = new Table();
                // Add a row into Table
                Row row = table.Rows.Add();
                // Add Cell with Latex Script to add methematical expressions/formulae
                string latexText1 = "$123456789+\\sqrt{1}+\\int_a^b f(x)dx$";
                Cell cell = row.Cells.Add();
                cell.Margin = new MarginInfo { Left = 20, Right = 20, Top = 20, Bottom = 20 };
                // Second TeXFragment constructor bool parameter provides LaTeX paragraph indents elimination
                TeXFragment ltext1 = new TeXFragment(latexText1, true);
                cell.Paragraphs.Add(ltext1);
                // Add table inside page
                page.Paragraphs.Add(table);
                // Save PDF document
                doc.Save(dataDir + "LatextScriptInPdf_out.pdf");
            }
        }

        public static void LatexWithPreambleAndDocEnvironment()
        {
            // The path to the documents directory
            string dataDir = Examples.GetDataDir_AsposePdf_Text();
            // Open PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Create a Table
                Table table = new Table();
                // Add a row into Table
                Row row = table.Rows.Add();
                // Add Cell with Latex Script to add methematical expressions/formulae
                string latexText2 = @"\documentclass{article}
                \begin{document}
                Latex and the document class will normally take care of page layout issues for you. For submission to an academic publication, this entire topic will be out
                \end{document}";
                Cell cell = row.Cells.Add();
                cell.Margin = new MarginInfo { Left = 20, Right = 20, Top = 20, Bottom = 20 };
                HtmlFragment text2 = new HtmlFragment(latexText2);
                cell.Paragraphs.Add(text2);
                // Add table inside page
                page.Paragraphs.Add(table);
                // Save PDF document
                doc.Save(dataDir + "LatextScriptInPdf2_out.pdf");
            }
        }

        public static void LatexTagsSupport()
        {
            string text = @"
            \usepackage{amsmath,amsthm}
            \begin{document}
            \begin{proof} The proof is a follows: 
            \begin{align}
            (x+y)^3&=(x+y)(x+y)^2
            (x+y)(x^2+2xy+y^2)\\
            &=x^3+3x^2y+3xy^3+x^3.\qedhere
            \end{align}
            \end{proof}
            \end{document}";

            // The path to the documents directory
            string dataDir = Examples.GetDataDir_AsposePdf_Text();

            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                TeXFragment latex = new TeXFragment(text);
                page.Paragraphs.Add(latex);
                // Save PDF document
                doc.Save(dataDir + "Script_out.pdf");
            }
        }

        public static void DrawRectangle()
        {
            // The path to the documents directory
            string dataDir = Examples.GetDataDir_AsposePdf_Text();
            // Create PDF document
            using (Document doc = new Document())
            {
                //Add the page
                Page page = doc.Pages.Add();
                //Save graphicState
                page.Contents.Add(new GSave());
                //Colorize rectangle
                SetRGBColorStroke colorStroke = new SetRGBColorStroke(0.7, 0, 0);
                page.Contents.Add(colorStroke);
                //Create and add Rectangle on page
                Rectangle rectangle = new Rectangle(100, 100, 200, 150);
                page.Contents.Add(
                    new Re(rectangle.LLX,
                        rectangle.LLY,
                        rectangle.Width,
                        rectangle.Height));
                //Close path
                page.Contents.Add(new ClosePathStroke());
                //Restore graphic state
                page.Contents.Add(new GRestore());
                // Save PDF document
                doc.Save(dataDir + "DrawRectangle.pdf");
            }
        }
    }
}
