using System;
using System.IO;
using Aspose.Pdf.Annotations;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents
{
    public static class Manipulate
    {
        public static void RunExamples()
        {
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Working-Document");
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "Manipulate");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running ValidateToPdfA1aStandard example...");
            ValidateToPdfA1aStandard(Path.Combine(dataDir, "ValidatePDFAStandard.pdf"), Path.Combine(outDir, "validation-result-A1A.xml"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ValidateToPdfA1bStandard example...");
            ValidateToPdfA1bStandard(Path.Combine(dataDir, "ValidatePDFAStandard.pdf"), Path.Combine(outDir, "validation-result-A1B.xml"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running AddTocToPdf example...");
            AddTocToPdf(Path.Combine(dataDir, "AddTOC.pdf"), Path.Combine(outDir, "TOC_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running CreateTocWithCustomFormatting example...");
            CreateTocWithCustomFormatting(Path.Combine(outDir, "TOC_CustomFormatting_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running CreateTocWithHiddenPageNumbers example...");
            CreateTocWithHiddenPageNumbers(Path.Combine(outDir, "TOC_HiddenPageNumbers_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running CustomizePageNumbersAddingToC example...");
            CustomizePageNumbersAddingToC(Path.Combine(dataDir, "CustomizePageNumbersAddingToC.pdf"), Path.Combine(outDir, "CustomizePageNumbersAddingToC_out.pdf"));
            Console.WriteLine("...finished.");
            
            Console.WriteLine("Running SetExpiryDate example...");
            SetExpiryDate(Path.Combine(outDir, "SetExpiryDate_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running DetermineProgress example...");
            DetermineProgress(Path.Combine(dataDir, "AddTOC.pdf"), Path.Combine(outDir, "DetermineProgress_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running FlattenForms example...");
            FlattenForms(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "FlattenForms_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running IncrementalUpdatesCheck example...");
            IncrementalUpdatesCheck(Path.Combine(Examples.GetDataDir_AsposePdf_QuickStart(), "input.pdf"));
            Console.WriteLine("...finished.");
        }

        public static void ValidateToPdfA1aStandard(string inputFile, string outputFile)
        {
            using (var document = new Document(inputFile))
            {
                document.Validate(outputFile, PdfFormat.PDF_A_1A);
            }
        }

        public static void ValidateToPdfA1bStandard(string inputFile, string outputFile)
        {
            using (var document = new Document(inputFile))
            {
                document.Validate(outputFile, PdfFormat.PDF_A_1B);
            }
        }

        public static void AddTocToPdf(string inputFile, string outputFile)
        {
            using (var document = new Document(inputFile))
            {
                var tocPage = document.Pages.Insert(1);
                var tocInfo = new TocInfo();
                var title = new Text.TextFragment("Table Of Contents");
                title.TextState.FontSize = 20;
                title.TextState.FontStyle = Text.FontStyles.Bold;
                tocInfo.Title = title;
                tocPage.TocInfo = tocInfo;

                string[] titles = { "First page", "Second page", "Third page", "Fourth page" };

                for (int i = 0; i < 2; i++)
                {
                    var heading = new Heading(1);
                    var segment = new Text.TextSegment();
                    heading.TocPage = tocPage;
                    heading.Segments.Add(segment);
                    heading.DestinationPage = document.Pages[i + 2];
                    heading.Top = document.Pages[i + 2].Rect.Height;
                    segment.Text = titles[i];
                    tocPage.Paragraphs.Add(heading);
                }

                document.Save(outputFile);
            }
        }

        public static void CreateTocWithCustomFormatting(string outputFile)
        {
            using (var document = new Document())
            {
                var tocPage = document.Pages.Add();
                var tocInfo = new TocInfo();
                tocInfo.LineDash = Text.TabLeaderType.Solid;
                var title = new Text.TextFragment("Table Of Contents");
                title.TextState.FontSize = 30;
                tocInfo.Title = title;
                tocPage.TocInfo = tocInfo;
                tocInfo.FormatArrayLength = 4;
                tocInfo.FormatArray[0].Margin.Left = 0;
                tocInfo.FormatArray[0].Margin.Right = 30;
                tocInfo.FormatArray[0].LineDash = Text.TabLeaderType.Dot;
                tocInfo.FormatArray[0].TextState.FontStyle = Text.FontStyles.Bold | Text.FontStyles.Italic;
                tocInfo.FormatArray[1].Margin.Left = 10;
                tocInfo.FormatArray[1].Margin.Right = 30;
                tocInfo.FormatArray[1].LineDash = Text.TabLeaderType.None;
                tocInfo.FormatArray[1].TextState.FontSize = 10;
                tocInfo.FormatArray[2].Margin.Left = 20;
                tocInfo.FormatArray[2].Margin.Right = 30;
                tocInfo.FormatArray[2].TextState.FontStyle = Text.FontStyles.Bold;
                tocInfo.FormatArray[3].LineDash = Text.TabLeaderType.Solid;
                tocInfo.FormatArray[3].Margin.Left = 30;
                tocInfo.FormatArray[3].Margin.Right = 30;
                tocInfo.FormatArray[3].TextState.FontStyle = Text.FontStyles.Bold;
                
                var page = document.Pages.Add();

                for (int level = 1; level <= 4; level++)
                {
                    var heading = new Heading(level);
                    var segment = new Text.TextSegment();
                    heading.Segments.Add(segment);
                    heading.IsAutoSequence = true;
                    heading.TocPage = tocPage;
                    segment.Text = "Sample Heading " + level;
                    heading.TextState.Font = Text.FontRepository.FindFont("Arial Unicode MS");
                    heading.IsInList = true;
                    page.Paragraphs.Add(heading);
                }
                
                document.Save(outputFile);
            }
        }
        
        public static void CreateTocWithHiddenPageNumbers(string outputFile)
        {
            using (var document = new Document())
            {
                var tocPage = document.Pages.Add();
                var tocInfo = new TocInfo();
                var title = new Text.TextFragment("Table Of Contents");
                title.TextState.FontSize = 20;
                title.TextState.FontStyle = Text.FontStyles.Bold;
                tocInfo.Title = title;
                tocPage.TocInfo = tocInfo;
                tocInfo.IsShowPageNumbers = false;
                tocInfo.FormatArrayLength = 4;
                tocInfo.FormatArray[0].Margin.Right = 0;
                tocInfo.FormatArray[0].TextState.FontStyle = Text.FontStyles.Bold | Text.FontStyles.Italic;
                tocInfo.FormatArray[1].Margin.Left = 30;
                tocInfo.FormatArray[1].TextState.Underline = true;
                tocInfo.FormatArray[1].TextState.FontSize = 10;
                tocInfo.FormatArray[2].TextState.FontStyle = Text.FontStyles.Bold;
                tocInfo.FormatArray[3].TextState.FontStyle = Text.FontStyles.Bold;
                
                var page = document.Pages.Add();

                for (int level = 1; level <= 4; level++)
                {
                    var heading = new Heading(level);
                    var segment = new Text.TextSegment();
                    heading.TocPage = tocPage;
                    heading.Segments.Add(segment);
                    heading.IsAutoSequence = true;
                    segment.Text = "this is heading of level " + level;
                    heading.IsInList = true;
                    page.Paragraphs.Add(heading);
                }

                document.Save(outputFile);
            }
        }
        
        public static void CustomizePageNumbersAddingToC(string inputFile, string outputFile)
        {
            using (var document = new Document(inputFile))
            {
                Page tocPage = document.Pages.Insert(1);
                var tocInfo = new TocInfo();
                var title = new Text.TextFragment("Table Of Contents");
                title.TextState.FontSize = 20;
                title.TextState.FontStyle = Text.FontStyles.Bold;
                tocInfo.Title = title;
                tocInfo.PageNumbersPrefix = "P";
                tocPage.TocInfo = tocInfo;

                for (int i = 1; i < document.Pages.Count; i++)
                {
                    var heading2 = new Heading(1);
                    var segment2 = new Text.TextSegment();
                    heading2.TocPage = tocPage;
                    heading2.Segments.Add(segment2);
                    heading2.DestinationPage = document.Pages[i + 1];
                    heading2.Top = document.Pages[i + 1].Rect.Height;
                    segment2.Text = "Page " + i.ToString();
                    tocPage.Paragraphs.Add(heading2);
                }
                document.Save(outputFile);
            }
        }
        
        public static void SetExpiryDate(string outputFile)
        {
            using (var document = new Document())
            {
                var page = document.Pages.Add();
                page.Paragraphs.Add(new Text.TextFragment("Hello World..."));
                var javaScript = new JavascriptAction(
                    "var year=2017;" +
                    "var month=5;" +
                    "today = new Date(); today = new Date(today.getFullYear(), today.getMonth());" +
                    "expiry = new Date(year, month);" +
                    "if (today.getTime() > expiry.getTime())" +
                    "app.alert('The file is expired. You need a new one.');"
                );
                document.OpenAction = javaScript;
                document.Save(outputFile);
            }
        }
        
        public static void DetermineProgress(string inputFile, string outputFile)
        {
            using (var document = new Document(inputFile))
            {
                var saveOptions = new DocSaveOptions();
                saveOptions.CustomProgressHandler = new UnifiedSaveOptions.ConversionProgressEventHandler(ShowProgressOnConsole);
                document.Save(outputFile, saveOptions);
            }
        }

        private static void ShowProgressOnConsole(UnifiedSaveOptions.ProgressEventHandlerInfo eventInfo)
        {
            switch (eventInfo.EventType)
            {
                case ProgressEventType.TotalProgress:
                    Console.WriteLine(String.Format("{0}  - Conversion progress : {1}% .", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString()));
                    break;
                case ProgressEventType.SourcePageAnalysed:
                    Console.WriteLine(String.Format("{0}  - Source page {1} of {2} analyzed.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString()));
                    break;
                case ProgressEventType.ResultPageCreated:
                    Console.WriteLine(String.Format("{0}  - Result page's {1} of {2} layout created.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString()));
                    break;
                case ProgressEventType.ResultPageSaved:
                    Console.WriteLine(String.Format("{0}  - Result page {1} of {2} exported.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString()));
                    break;
                default:
                    break;
            }
        }

        public static void FlattenForms(string inputFile, string outputFile)
        {
            using (var document = new Document(inputFile))
            {
                if (document.Form.Fields.Count > 0)
                {
                    foreach (var item in document.Form.Fields)
                    {
                        item.Flatten();
                    }
                }
                document.Save(outputFile);
            }
        }

        public static void IncrementalUpdatesCheck(string inputFile)
        {
            using (var document = new Document(inputFile))
            {
                bool updatedIncrementally = document.HasIncrementalUpdate();
                if (updatedIncrementally)
                {
                    Console.WriteLine("This document has been incrementally updated.");
                }
                else
                {
                    Console.WriteLine("This document has no incremental updates.");
                }
            }
        }
    }
}