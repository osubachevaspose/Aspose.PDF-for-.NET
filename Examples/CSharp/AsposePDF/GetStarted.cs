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
            string outDir = Path.Combine(Examples.GetOutDir(), "GetStarted");
            Directory.CreateDirectory(outDir);

            HelloWorld(Path.Combine(outDir, "HelloWorld_out.pdf"));
            CreatingComplexPdf(Path.Combine(dataDir, "aspose-logo.jpg"),
                Path.Combine(outDir, "Complex_out.pdf"));
            //SetLicenseExample("Aspose.Pdf.lic");
            //SetLicenseFromStream("Aspose.Pdf.lic");
        }

        public static void HelloWorld(string outputFileName)
        {
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Add text to new page
                page.Paragraphs.Add(new TextFragment("Hello World!"));
                // Save PDF document
                doc.Save(outputFileName);
            }
        }

        public static void CreatingComplexPdf(string imageFileName, string outputFileName)
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
                doc.Save(outputFileName);
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
    }
}
