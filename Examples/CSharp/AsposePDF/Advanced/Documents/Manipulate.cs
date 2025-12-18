using System;
using System.IO;
using System.Reflection.Metadata;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents
{
    public static class Manipulate
    {
        //https://docs.aspose.com/pdf/net/manipulate-pdf-document/

        public static void RunExamples()
        {
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Advanced", "Documents", "Manipulate");
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "Manipulate");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running ValidateToPdfA1aStandard example...");
            ValidateToPdfA1aStandard(Path.Combine(dataDir, "ValidatePDFAStandard.pdf"),
                Path.Combine(outDir, "validation-result-A1A.xml"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ValidateToPdfA1bStandard example...");
            ValidateToPdfA1bStandard(Path.Combine(dataDir, "ValidatePDFAStandard.pdf"),
                Path.Combine(outDir, "validation-result-A1B.xml"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running AddTocToPdf example...");
            AddTocToPdf(Path.Combine(dataDir, "AddTOC.pdf"), Path.Combine(outDir, "TOC.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running CreateTocWithCustomFormatting example...");
            CreateTocWithCustomFormatting(Path.Combine(outDir, "TOC_CustomFormatting.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running CreateTocWithHiddenPageNumbers example...");
            CreateTocWithHiddenPageNumbers(Path.Combine(outDir, "TOC_HiddenPageNumbers.pdf"));
            Console.WriteLine("...finished.");

            //Console.WriteLine("Running CustomizePageNumbersAddingToC example...");
            //CustomizePageNumbersAddingToC(Path.Combine(dataDir, "CustomizePageNumbersAddingToC.pdf"),
            //    Path.Combine(outDir, "CustomizePageNumbersAddingToC.pdf"));
            //Console.WriteLine("...finished.");

            Console.WriteLine("Running SetExpiryDate example...");
            SetExpiryDate(Path.Combine(outDir, "SetExpiryDate.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running DetermineProgress example...");
            DetermineProgress(Path.Combine(dataDir, "AddTOC.pdf"),
                Path.Combine(outDir, "DetermineProgress.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running FlattenForms example...");
            FlattenForms(Path.Combine(dataDir, "input.pdf"),
                Path.Combine(outDir, "FlattenForms.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running IncrementalUpdatesCheck example...");
            IncrementalUpdatesCheck(Path.Combine(dataDir, "input.pdf"));
            Console.WriteLine("...finished.");
        }

        public static void ValidateToPdfA1aStandard(string inputFile, string outputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                doc.Validate(outputFile, PdfFormat.PDF_A_1A);
            }
        }

        public static void ValidateToPdfA1bStandard(string inputFile, string outputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                doc.Validate(outputFile, PdfFormat.PDF_A_1B);
            }
        }

        public static void AddTocToPdf(string inputFile, string outputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                Page tocPage = doc.Pages.Insert(1);
                TocInfo tocInfo = new TocInfo();
                TextFragment title = new TextFragment("Table Of Contents")
                {
                    TextState =
                    {
                        FontSize = 20,
                        FontStyle = FontStyles.Bold
                    }
                };
                tocInfo.Title = title;
                tocPage.TocInfo = tocInfo;
                // Create string objects which will be used as TOC elements
                string[] titles = { "First page", "Second page", "Third page", "Fourth page" };
                for (int i = 0; i < 2; i++)
                {
                    Heading heading = new Heading(1);
                    TextSegment segment = new TextSegment();
                    heading.TocPage = tocPage;
                    heading.Segments.Add(segment);
                    heading.DestinationPage = doc.Pages[i + 2];
                    heading.Top = doc.Pages[i + 2].Rect.Height;
                    segment.Text = titles[i];
                    tocPage.Paragraphs.Add(heading);
                }
                doc.Save(outputFile);
            }
        }

        public static void CreateTocWithCustomFormatting(string outputFile)
        {
            using (Document doc = new Document())
            {
                // Add a TOC page
                Page tocPage = doc.Pages.Add();

                // Create TOC information
                TocInfo tocInfo = new TocInfo
                {
                    // Set LeaderType
                    LineDash = TabLeaderType.Solid
                };

                // Set the title for TOC
                TextFragment title = new TextFragment("Table Of Contents")
                {
                    TextState =
                    {
                        FontSize = 30
                    }
                };
                tocInfo.Title = title;

                // Add the TOC section to the document
                tocPage.TocInfo = tocInfo;

                // Define the format of the four levels list by setting the left margins
                // and text format settings of each level
                tocInfo.FormatArrayLength = 4;

                // Level 1
                tocInfo.FormatArray[0].Margin.Left = 0;
                tocInfo.FormatArray[0].Margin.Right = 30;
                tocInfo.FormatArray[0].LineDash = TabLeaderType.Dot;
                tocInfo.FormatArray[0].TextState.FontStyle = FontStyles.Bold | FontStyles.Italic;

                // Level 2
                tocInfo.FormatArray[1].Margin.Left = 10;
                tocInfo.FormatArray[1].Margin.Right = 30;
                tocInfo.FormatArray[1].LineDash = TabLeaderType.None;
                tocInfo.FormatArray[1].TextState.FontSize = 10;

                // Level 3
                tocInfo.FormatArray[2].Margin.Left = 20;
                tocInfo.FormatArray[2].Margin.Right = 30;
                tocInfo.FormatArray[2].TextState.FontStyle = FontStyles.Bold;

                // Level 4
                tocInfo.FormatArray[3].LineDash = TabLeaderType.Solid;
                tocInfo.FormatArray[3].Margin.Left = 30;
                tocInfo.FormatArray[3].Margin.Right = 30;
                tocInfo.FormatArray[3].TextState.FontStyle = FontStyles.Bold;

                // Create a section in the Pdf document
                Page page = doc.Pages.Add();

                // Add four headings in the section
                for (int level = 1; level <= 4; level++)
                {
                    Heading heading = new Heading(level);
                    TextSegment segment = new TextSegment();
                    heading.Segments.Add(segment);
                    heading.IsAutoSequence = true;
                    heading.TocPage = tocPage;
                    segment.Text = "Sample Heading " + level;
                    heading.TextState.Font = FontRepository.FindFont("Arial Unicode MS");

                    // Add the heading into Table Of Contents.
                    heading.IsInList = true;
                    page.Paragraphs.Add(heading);
                }

                doc.Save(outputFile);
            }
        }

        public static void CreateTocWithHiddenPageNumbers(string outputFile)
        {
            using (Document doc = new Document())
            {
                // Add a TOC page
                Page tocPage = doc.Pages.Add();

                // Create TOC information
                TocInfo tocInfo = new TocInfo();

                // Set the title for TOC
                TextFragment title = new TextFragment("Table Of Contents")
                {
                    TextState =
                    {
                        FontSize = 20,
                        FontStyle = FontStyles.Bold
                    }
                };
                tocInfo.Title = title;

                // Add the TOC section to the document
                tocPage.TocInfo = tocInfo;

                // Hide page numbers in TOC
                tocInfo.IsShowPageNumbers = false;

                // Define the format of the four levels list by setting the left margins and
                // text format settings of each level
                tocInfo.FormatArrayLength = 4;

                // Level 1
                tocInfo.FormatArray[0].Margin.Right = 0;
                tocInfo.FormatArray[0].TextState.FontStyle = FontStyles.Bold | FontStyles.Italic;

                // Level 2
                tocInfo.FormatArray[1].Margin.Left = 30;
                tocInfo.FormatArray[1].TextState.Underline = true;
                tocInfo.FormatArray[1].TextState.FontSize = 10;

                // Level 3
                tocInfo.FormatArray[2].TextState.FontStyle = FontStyles.Bold;

                // Level 4
                tocInfo.FormatArray[3].TextState.FontStyle = FontStyles.Bold;

                // Create a section in the Pdf document
                Page page = doc.Pages.Add();

                // Add four headings in the section
                for (int level = 1; level <= 4; level++)
                {
                    Heading heading = new Heading(level);
                    TextSegment segment = new TextSegment();
                    heading.TocPage = tocPage;
                    heading.Segments.Add(segment);
                    heading.IsAutoSequence = true;
                    segment.Text = "this is heading of level " + level;
                    heading.IsInList = true;
                    page.Paragraphs.Add(heading);
                }

                doc.Save(outputFile);
            }
        }

        public static void CustomizePageNumbersAddingToC(string inputFile, string outputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                Page tocPage = doc.Pages.Insert(1);
                TocInfo tocInfo = new TocInfo();
                TextFragment title = new TextFragment("Table Of Contents")
                {
                    TextState =
                    {
                        FontSize = 20,
                        FontStyle = FontStyles.Bold
                    }
                };
                tocInfo.Title = title;
                tocInfo.PageNumbersPrefix = "P";
                tocPage.TocInfo = tocInfo;
                // Loop through the pages to create TOC entries
                for (int i = 1; i < doc.Pages.Count; i++)
                {
                    Heading heading2 = new Heading(1);
                    TextSegment segment2 = new TextSegment();
                    heading2.TocPage = tocPage;
                    heading2.Segments.Add(segment2);
                    heading2.DestinationPage = doc.Pages[i + 1];
                    heading2.Top = doc.Pages[i + 1].Rect.Height;
                    segment2.Text = "Page " + i;
                    tocPage.Paragraphs.Add(heading2);
                }
                doc.Save(outputFile);
            }
        }

        public static void SetExpiryDate(string outputFile)
        {
            using (Document doc = new Document())
            {
                Page page = doc.Pages.Add();
                page.Paragraphs.Add(new TextFragment("Hello World..."));
                // Create JavaScript object to set PDF expiry date
                JavascriptAction javaScript = new JavascriptAction(
                    "var year=2017;" +
                    "var month=5;" +
                    "today = new Date(); today = new Date(today.getFullYear(), today.getMonth());" +
                    "expiry = new Date(year, month);" +
                    "if (today.getTime() > expiry.getTime())" +
                    "app.alert('The file is expired. You need a new one.');"
                );
                // Set JavaScript as PDF open action
                doc.OpenAction = javaScript;
                doc.Save(outputFile);
            }
        }

        public static void DetermineProgress(string inputFile, string outputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                DocSaveOptions saveOptions = new DocSaveOptions
                {
                    CustomProgressHandler = ShowProgressOnConsole
                };
                doc.Save(outputFile, saveOptions);
            }
        }

        private static void ShowProgressOnConsole(UnifiedSaveOptions.ProgressEventHandlerInfo eventInfo)
        {
            switch (eventInfo.EventType)
            {
                case ProgressEventType.TotalProgress:
                    Console.WriteLine("{0} - Conversion progress : {1}% .", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString());
                    break;
                case ProgressEventType.SourcePageAnalysed:
                    Console.WriteLine("{0} - Source page {1} of {2} analyzed.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString());
                    break;
                case ProgressEventType.ResultPageCreated:
                    Console.WriteLine("{0} - Result page's {1} of {2} layout created.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString());
                    break;
                case ProgressEventType.ResultPageSaved:
                    Console.WriteLine("{0} - Result page {1} of {2} exported.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString());
                    break;
                default:
                    break;
            }
        }

        public static void FlattenForms(string inputFile, string outputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                if (doc.Form.Fields.Length > 0)
                    foreach (Field item in doc.Form.Fields)
                        item.Flatten();
                doc.Save(outputFile);
            }
        }

        public static void IncrementalUpdatesCheck(string inputFile)
        {
            using (Document doc = new Document(inputFile))
            {
                bool updatedIncrementally = doc.HasIncrementalUpdate();
                if (updatedIncrementally)
                {
                    Console.WriteLine("This doc has been incrementally updated.");
                }
                else
                {
                    Console.WriteLine("This doc has no incremental updates.");
                }
            }
        }
    }
}