using System;
using System.IO;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF
{
    public static class GetStarted
    {
        public static void RunExamples()
        {
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "GetStarted");
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "GetStarted");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running HelloWorld example... ");
            HelloWorld(Path.Combine(outDir, "HelloWorld_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running CreatingComplexPdf example... ");
            CreatingComplexPdf(Path.Combine(dataDir, "aspose-logo.jpg"),
                Path.Combine(outDir, "Complex_out.pdf"));
            Console.WriteLine("...finished.");

            //SetLicenseExample("Aspose.Pdf.lic");
            //SetLicenseFromStream("Aspose.Pdf.lic");

            Console.WriteLine("Running LatexWithoutPreambleAndDocEnvironmentexample... ");
            LatexWithoutPreambleAndDocEnvironment(Path.Combine(outDir, "LatextScriptInPdf_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running LatexWithPreambleAndDocEnvironment example... ");
            LatexWithPreambleAndDocEnvironment(Path.Combine(outDir, "LatextScriptInPdf2_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running LatexTagsSupport example... ");
            LatexTagsSupport(Path.Combine(outDir, "Script_out.pdf"));
            Console.WriteLine("...finished.");
        }

        public static void HelloWorld(string outFileName)
        {
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Add text to new page
                page.Paragraphs.Add(new TextFragment("Hello World!"));
                // Save PDF document
                doc.Save(outFileName);
            }
        }

        public static void CreatingComplexPdf(string imageFileName, string outFileName)
        {
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Add image
                page.AddImage(imageFileName, new Rectangle(20, 730, 120, 830));
                // Add Header
                TextFragment header = new TextFragment("New ferry routes in Fall 2020")
                {
                    TextState =
                    {
                        Font = FontRepository.FindFont("Arial"),
                        FontSize = 24
                    },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Position = new Position(130, 720)
                };
                page.Paragraphs.Add(header);
                // Add description
                string descriptionText = "Visitors must buy tickets online and tickets are limited to 5,000 per day. Ferry service is operating at half capacity and on a reduced schedule. Expect lineups.";
                TextFragment description = new TextFragment(descriptionText)
                {
                    TextState =
                    {
                        Font = FontRepository.FindFont("Times New Roman"),
                        FontSize = 14
                    },
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                page.Paragraphs.Add(description);
                // Add table
                Table table = new Table
                {
                    ColumnWidths = "200",
                    Border = new BorderInfo(BorderSide.Box, 1f, Color.DarkSlateGray),
                    DefaultCellBorder = new BorderInfo(BorderSide.Box, 0.5f, Color.Black),
                    DefaultCellPadding = new MarginInfo(4.5, 4.5, 4.5, 4.5),
                    Margin = { Bottom = 10 },
                    DefaultCellTextState = { Font = FontRepository.FindFont("Helvetica") }
                };
                Row headerRow = table.Rows.Add();
                headerRow.Cells.Add("Departs City");
                headerRow.Cells.Add("Departs Island");
                foreach (Cell headerRowCell in headerRow.Cells)
                {
                    headerRowCell.BackgroundColor = Color.Gray;
                    headerRowCell.DefaultCellTextState.ForegroundColor = Color.WhiteSmoke;
                }
                TimeSpan time = new TimeSpan(6, 0, 0);
                TimeSpan incTime = new TimeSpan(0, 30, 0);
                for (int i = 0; i < 10; i++)
                {
                    Row dataRow = table.Rows.Add();
                    dataRow.Cells.Add(time.ToString(@"hh\:mm"));
                    time = time.Add(incTime);
                    dataRow.Cells.Add(time.ToString(@"hh\:mm"));
                }
                page.Paragraphs.Add(table);
                doc.Save(outFileName);
            }
        }

        public static void SetLicenseExample(string licenseFileName)
        {
            new License().SetLicense(licenseFileName);
            Console.WriteLine("License set successfully from file.");
        }

        public static void SetLicenseFromStream(string licenseFileName)
        {
            using (FileStream fileStream = File.OpenRead(licenseFileName))
                new License().SetLicense(fileStream);
            Console.WriteLine("License set successfully from stream.");
        }

        public static void LatexWithoutPreambleAndDocEnvironment(string outFileName)
        {
            // Create a Table
            Table table = new Table();
            // Add a row into Table
            Row row = table.Rows.Add();
            // Add Cell with Latex Script to add mathematical expressions/formulae
            Cell cell = row.Cells.Add();
            cell.Margin = new MarginInfo { Left = 20, Right = 20, Top = 20, Bottom = 20 };
            string latexText = "$123456789+\\sqrt{1}+\\int_a^b f(x)dx$";
            // TeXFragment constructor bool parameter provides LaTeX paragraph indents elimination
            TeXFragment latex = new TeXFragment(latexText, true);
            cell.Paragraphs.Add(latex);
            using (Document doc = new Document())
            {
                Page page = doc.Pages.Add();
                // Add table inside page
                page.Paragraphs.Add(table);
                doc.Save(outFileName);
            }
        }

        public static void LatexWithPreambleAndDocEnvironment(string outFileName)
        {
            string latexText = @"\documentclass{article}
                \begin{document}
                Latex and the document class will normally take care of page layout issues for you. For submission to an academic publication, this entire topic will be out
                \end{document}";
            HtmlFragment html = new HtmlFragment(latexText);
            //TeXFragment latex = new TeXFragment(latexText);
            // Create a Table
            Table table = new Table();
            // Add a row into Table
            Row row = table.Rows.Add();
            // Add Cell with Latex Script to add mathematical expressions/formulae
            Cell cell = row.Cells.Add();
            cell.Margin = new MarginInfo { Left = 20, Right = 20, Top = 20, Bottom = 20 };
            cell.Paragraphs.Add(html);
            using (Document doc = new Document())
            {
                Page page = doc.Pages.Add();
                // Add table inside page
                page.Paragraphs.Add(table);
                doc.Save(outFileName);
            }
        }

        public static void LatexTagsSupport(string outFileName)
        {
            string latexText = @"
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
            TeXFragment latex = new TeXFragment(latexText);
            using (Document doc = new Document())
            {
                Page page = doc.Pages.Add();
                page.Paragraphs.Add(latex);
                doc.Save(outFileName);
            }
        }
    }
}
