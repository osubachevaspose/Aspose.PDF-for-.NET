using System;
using System.Linq;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

internal class ManipulateOrig
{
    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void ValidateToPdfA1aStandard()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Open PDF document
    //    using (Document document = new Document(dataDir + "ValidatePDFAStandard.pdf"))
    //    {
    //        // Validate PDF for PDF/A-1a
    //        document.Validate(dataDir + "validation-result-A1A.xml", PdfFormat.PDF_A_1A);
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void ValidateToPdfA1bStandard()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Open PDF document
    //    using (Document document = new Document(dataDir + "ValidatePDFAStandard.pdf"))
    //    {
    //        // Validate PDF for PDF/A-1b
    //        document.Validate(dataDir + "validation-result-A1B.xml", PdfFormat.PDF_A_1B);
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void AddTOCToPdf()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Open PDF document
    //    using (Document document = new Document(dataDir + "AddTOC.pdf"))
    //    {
    //        // Get access to the first page of PDF file
    //        Page tocPage = document.Pages.Insert(1);

    //        // Create an object to represent TOC information
    //        TocInfo tocInfo = new TocInfo();
    //        TextFragment title = new TextFragment("Table Of Contents")
    //        {
    //            TextState =
    //            {
    //                FontSize = 20,
    //                FontStyle = FontStyles.Bold
    //            }
    //        };

    //        // Set the title for TOC
    //        tocInfo.Title = title;
    //        tocPage.TocInfo = tocInfo;

    //        // Create string objects which will be used as TOC elements
    //        string[] titles = { "First page", "Second page", "Third page", "Fourth page" };

    //        for (int i = 0; i < 2; i++)
    //        {
    //            // Create Heading object
    //            Heading heading = new Heading(1);
    //            TextSegment segment = new TextSegment();
    //            heading.TocPage = tocPage;
    //            heading.Segments.Add(segment);

    //            // Specify the destination page for the heading object
    //            heading.DestinationPage = document.Pages[i + 2];

    //            // Destination page
    //            heading.Top = document.Pages[i + 2].Rect.Height;

    //            // Destination coordinate
    //            segment.Text = titles[i];

    //            // Add heading to the page containing TOC
    //            tocPage.Paragraphs.Add(heading);
    //        }

    //        // Save PDF document
    //        document.Save(dataDir + "TOC_out.pdf");
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void CreateTocWithCustomFormatting()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Create PDF document
    //    using (Document doc = new Document())
    //    {
    //        // Add a TOC page
    //        Page tocPage = doc.Pages.Add();

    //        // Create TOC information
    //        TocInfo tocInfo = new TocInfo
    //        {
    //            // Set LeaderType
    //            LineDash = TabLeaderType.Solid
    //        };

    //        // Set the title for TOC
    //        TextFragment title = new TextFragment("Table Of Contents")
    //        {
    //            TextState =
    //            {
    //                FontSize = 30
    //            }
    //        };
    //        tocInfo.Title = title;

    //        // Add the TOC section to the document
    //        tocPage.TocInfo = tocInfo;

    //        // Define the format of the four levels list by setting the left margins
    //        // and text format settings of each level
    //        tocInfo.FormatArrayLength = 4;

    //        // Level 1
    //        tocInfo.FormatArray[0].Margin.Left = 0;
    //        tocInfo.FormatArray[0].Margin.Right = 30;
    //        tocInfo.FormatArray[0].LineDash = TabLeaderType.Dot;
    //        tocInfo.FormatArray[0].TextState.FontStyle = FontStyles.Bold | FontStyles.Italic;

    //        // Level 2
    //        tocInfo.FormatArray[1].Margin.Left = 10;
    //        tocInfo.FormatArray[1].Margin.Right = 30;
    //        tocInfo.FormatArray[1].LineDash = TabLeaderType.None;
    //        tocInfo.FormatArray[1].TextState.FontSize = 10;

    //        // Level 3
    //        tocInfo.FormatArray[2].Margin.Left = 20;
    //        tocInfo.FormatArray[2].Margin.Right = 30;
    //        tocInfo.FormatArray[2].TextState.FontStyle = FontStyles.Bold;

    //        // Level 4
    //        tocInfo.FormatArray[3].LineDash = TabLeaderType.Solid;
    //        tocInfo.FormatArray[3].Margin.Left = 30;
    //        tocInfo.FormatArray[3].Margin.Right = 30;
    //        tocInfo.FormatArray[3].TextState.FontStyle = FontStyles.Bold;

    //        // Create a section in the Pdf document
    //        Page page = doc.Pages.Add();

    //        // Add four headings in the section
    //        for (int level = 1; level <= 4; level++)
    //        {
    //            Heading heading = new Heading(level);
    //            TextSegment segment = new TextSegment();
    //            heading.Segments.Add(segment);
    //            heading.IsAutoSequence = true;
    //            heading.TocPage = tocPage;
    //            segment.Text = "Sample Heading " + level;
    //            heading.TextState.Font = FontRepository.FindFont("Arial Unicode MS");

    //            // Add the heading into Table Of Contents.
    //            heading.IsInList = true;
    //            page.Paragraphs.Add(heading);
    //        }

    //        // Save PDF document
    //        doc.Save(dataDir + "TOC_out.pdf");
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void CreateTocWithHiddenPageNumbers()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Create PDF document
    //    using (Document doc = new Document())
    //    {
    //        // Add a TOC page
    //        Page tocPage = doc.Pages.Add();

    //        // Create TOC information
    //        TocInfo tocInfo = new TocInfo();

    //        // Set the title for TOC
    //        TextFragment title = new TextFragment("Table Of Contents")
    //        {
    //            TextState =
    //            {
    //                FontSize = 20,
    //                FontStyle = FontStyles.Bold
    //            }
    //        };
    //        tocInfo.Title = title;

    //        // Add the TOC section to the document
    //        tocPage.TocInfo = tocInfo;

    //        // Hide page numbers in TOC
    //        tocInfo.IsShowPageNumbers = false;

    //        // Define the format of the four levels list by setting the left margins and
    //        // text format settings of each level
    //        tocInfo.FormatArrayLength = 4;

    //        // Level 1
    //        tocInfo.FormatArray[0].Margin.Right = 0;
    //        tocInfo.FormatArray[0].TextState.FontStyle = FontStyles.Bold | FontStyles.Italic;

    //        // Level 2
    //        tocInfo.FormatArray[1].Margin.Left = 30;
    //        tocInfo.FormatArray[1].TextState.Underline = true;
    //        tocInfo.FormatArray[1].TextState.FontSize = 10;

    //        // Level 3
    //        tocInfo.FormatArray[2].TextState.FontStyle = FontStyles.Bold;

    //        // Level 4
    //        tocInfo.FormatArray[3].TextState.FontStyle = FontStyles.Bold;

    //        // Create a section in the Pdf document
    //        Page page = doc.Pages.Add();

    //        // Add four headings in the section
    //        for (int level = 1; level <= 4; level++)
    //        {
    //            Heading heading = new Heading(level);
    //            TextSegment segment = new TextSegment();
    //            heading.TocPage = tocPage;
    //            heading.Segments.Add(segment);
    //            heading.IsAutoSequence = true;
    //            segment.Text = "this is heading of level " + level;
    //            heading.IsInList = true;
    //            page.Paragraphs.Add(heading);
    //        }

    //        // Save PDF document
    //        doc.Save(dataDir + "TOC_out.pdf");
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void CustomizePageNumbersAddingToC()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Open PDF document
    //    using (Document doc = new Document(dataDir + "CustomizePageNumbersAddingToC.pdf"))
    //    {
    //        // Get access to first page of PDF file
    //        Page tocPage = doc.Pages.Insert(1);

    //        // Create object to represent TOC information
    //        TocInfo tocInfo = new TocInfo();
    //        TextFragment title = new TextFragment("Table Of Contents")
    //        {
    //            TextState =
    //            {
    //                FontSize = 20,
    //                FontStyle = FontStyles.Bold
    //            }
    //        };

    //        // Set the title for TOC
    //        tocInfo.Title = title;
    //        tocInfo.PageNumbersPrefix = "P";
    //        tocPage.TocInfo = tocInfo;

    //        // Loop through the pages to create TOC entries
    //        for (int i = 1; i < doc.Pages.Count; i++)
    //        {
    //            // Create Heading object
    //            Heading heading2 = new Heading(1);
    //            TextSegment segment2 = new TextSegment();
    //            heading2.TocPage = tocPage;
    //            heading2.Segments.Add(segment2);

    //            // Specify the destination page for heading object
    //            heading2.DestinationPage = doc.Pages[i + 1];

    //            // Destination page
    //            heading2.Top = doc.Pages[i + 1].Rect.Height;

    //            // Destination coordinate
    //            segment2.Text = "Page " + i.ToString();

    //            // Add heading to page containing TOC
    //            tocPage.Paragraphs.Add(heading2);
    //        }

    //        // Save PDF document
    //        doc.Save(dataDir + "CustomizePageNumbersAddingToC_out.pdf");
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void SetExpiryDate()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Create PDF document
    //    using (Document doc = new Document())
    //    {
    //        // Add page
    //        Page page = doc.Pages.Add();

    //        // Add text fragment to paragraphs collection of page object
    //        page.Paragraphs.Add(new TextFragment("Hello World..."));

    //        // Create JavaScript object to set PDF expiry date
    //        JavascriptAction javaScript = new JavascriptAction(
    //            "var year=2017;" +
    //            "var month=5;" +
    //            "today = new Date(); today = new Date(today.getFullYear(), today.getMonth());" +
    //            "expiry = new Date(year, month);" +
    //            "if (today.getTime() > expiry.getTime())" +
    //            "app.alert('The file is expired. You need a new one.');"
    //        );

    //        // Set JavaScript as PDF open action
    //        doc.OpenAction = javaScript;

    //        // Save PDF Document
    //        doc.Save(dataDir + "SetExpiryDate_out.pdf");
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void DetermineProgress()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Open PDF document
    //    using (Document document = new Document(dataDir + "AddTOC.pdf"))
    //    {
    //        // Create DocSaveOptions instance and set custom progress handler
    //        DocSaveOptions saveOptions = new DocSaveOptions
    //        {
    //            CustomProgressHandler = new UnifiedSaveOptions.ConversionProgressEventHandler(ShowProgressOnConsole)
    //        };

    //        // Save PDF Document
    //        document.Save(dataDir + "DetermineProgress_out.pdf", saveOptions);
    //    }
    //}

    //// Method to handle progress and display it on the console
    //private static void ShowProgressOnConsole(UnifiedSaveOptions.ProgressEventHandlerInfo eventInfo)
    //{
    //    switch (eventInfo.EventType)
    //    {
    //        case ProgressEventType.TotalProgress:
    //            Console.WriteLine(String.Format("{0}  - Conversion progress : {1}% .", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString()));
    //            break;
    //        case ProgressEventType.SourcePageAnalysed:
    //            Console.WriteLine(String.Format("{0}  - Source page {1} of {2} analyzed.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString()));
    //            break;
    //        case ProgressEventType.ResultPageCreated:
    //            Console.WriteLine(String.Format("{0}  - Result page's {1} of {2} layout created.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString()));
    //            break;
    //        case ProgressEventType.ResultPageSaved:
    //            Console.WriteLine(String.Format("{0}  - Result page {1} of {2} exported.", DateTime.Now.ToLongTimeString(), eventInfo.Value.ToString(), eventInfo.MaxValue.ToString()));
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void FlattenForms()
    //{
    //    // The path to the documents directory
    //    var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

    //    // Open PDF document
    //    using (Document doc = new Document(dataDir + "input.pdf"))
    //    {
    //        // Flatten Fillable PDF
    //        if (doc.Form.Fields.Count() > 0)
    //            foreach (Field item in doc.Form.Fields)
    //                item.Flatten();

    //        // Save PDF document
    //        doc.Save(dataDir + "FlattenForms_out.pdf");
    //    }
    //}

    //// For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    //private static void IncrementalUpdatesCheck()
    //{
    //    // The path to the documents directory
    //    string dataDir = RunExamples.GetDataDir_AsposePdf_QuickStart();

    //    // Open PDF document
    //    using (Document doc = new Document(dataDir + "input.pdf"))
    //    {
    //        // Check for incremental updates
    //        bool updatedIncrementally = doc.HasIncrementalUpdate();

    //        // Output the result
    //        if (updatedIncrementally)
    //        {
    //            Console.WriteLine("This document has been incrementally updated.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("This document has no incremental updates.");
    //        }
    //    }
    //}
}
