using System;
using System.IO;
using System.IO.Pipes;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF
{
    public static class GetStarted
    {
        public static void HelloWorld()
        {
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_AsposePdf_GetStarted();
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Add text to new page
                page.Paragraphs.Add(new TextFragment("Hello World!"));
                // Save PDF document
                doc.Save(Path.Combine(dataDir, "HelloWorld_out.pdf"));
            }
        }

        public static void CreatingComplexPdf()
        {
            string dataDir = RunExamples.GetDataDir_AsposePdf_GetStarted();
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();

                // Add image
                page.AddImage(dataDir + "logo.png", new Rectangle(20, 730, 120, 830));

                // Add Header
                TextFragment header = new TextFragment("New ferry routes in Fall 2020");
                header.TextState.Font = FontRepository.FindFont("Arial");
                header.TextState.FontSize = 24;
                header.HorizontalAlignment = HorizontalAlignment.Center;
                header.Position = new Position(130, 720);
                page.Paragraphs.Add(header);

                // Add description
                string descriptionText = "Visitors must buy tickets online and tickets are limited to 5,000 per day. Ferry service is operating at half capacity and on a reduced schedule. Expect lineups.";
                TextFragment description = new TextFragment(descriptionText);
                description.TextState.Font = FontRepository.FindFont("Times New Roman");
                description.TextState.FontSize = 14;
                description.HorizontalAlignment = HorizontalAlignment.Left;
                page.Paragraphs.Add(description);

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
                doc.Save(Path.Combine(dataDir, "Complex_out.pdf"));
            }
        }

        public static void SetLicenseExample()
        {
            new License().SetLicense("Aspose.Pdf.lic");

            //License license = new License();
            //try
            //{
            //    // Set license
            //    license.SetLicense("Aspose.Pdf.lic");
            //}
            //catch (Exception)
            //{
            //    // Something went wrong
            //    throw;
            //}

            Console.WriteLine("License set successfully.");
        }

        public static void SetLicenseFromStream()
        {
            using (FileStream fileStream = File.OpenRead("Aspose.Pdf.lic"))
                new License().SetLicense(fileStream);

            //License license = new License();
            //// Load license from the file stream
            //FileStream myStream = new FileStream(
            //    "Aspose.Pdf.lic",
            //    FileMode.Open);
            //// Set license
            //license.SetLicense(myStream);

            Console.WriteLine("License set successfully.");
        }
    }
}
