using System;
using System.IO;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

public static class Formatting
{
    //https://docs.aspose.com/pdf/net/formatting-pdf-doc/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Advanced", "Documents", "Formatting");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "Formatting");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running GetDocumentWindowProperties example...");
        GetDocumentWindowProperties(Path.Combine(dataDir, "GetDocumentWindow.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SetDocumentWindowProperties example...");
        SetDocumentWindowProperties(Path.Combine(dataDir, "SetDocumentWindow.pdf"),
            Path.Combine(outDir, "SetDocumentWindow.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running EmbedFontsType1ToPdf example...");
        EmbedFontsType1ToPdf(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "EmbeddedFontsUpdated.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running EmbedFontWhileCreatingPdf example...");
        EmbedFontWhileCreatingPdf(Path.Combine(outDir, "EmbedFontWhileDocCreation.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SetDefaultFontOnDocumentSave example...");
        SetDefaultFontOnDocumentSave(Path.Combine(dataDir, "GetDocumentWindow.pdf"),
            Path.Combine(outDir, "DefaultFont.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running GetAllFontsFromPdf example...");
        GetAllFontsFromPdf(Path.Combine(dataDir, "GetDocumentWindow.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running NotificationFontSubstitution example...");
        NotificationFontSubstitution(Path.Combine(dataDir, "GetDocumentWindow.pdf"),
            Path.Combine(outDir, "NotificationFontSubstitution.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SetFontSubsetStrategy example...");
        SetFontSubsetStrategy(Path.Combine(dataDir, "GetDocumentWindow.pdf"),
            Path.Combine(outDir, "SetFontSubsetStrategy.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SetZoomFactor example...");
        SetZoomFactor(Path.Combine(dataDir, "SetZoomFactor.pdf"),
            Path.Combine(outDir, "ZoomFactor.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running GetZoomFactor example...");
        GetZoomFactor(Path.Combine(dataDir, "Zoomed_pdf.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SetPrintDialogPresetProperties example...");
        SetPrintDialogPresetProperties(Path.Combine(outDir, "SetPrintDlgPresetProperties.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running SetPrintDialogPresetPropertiesUsingPdfContentEditor example...");
        SetPrintDialogPresetPropertiesUsingPdfContentEditor(Path.Combine(dataDir, "GetDocumentWindow.pdf"),
            Path.Combine(outDir, "SetPrintDlgPropertiesUsingPdfContentEditor.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void GetDocumentWindowProperties(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Get different doc properties
            // Position of doc's window - Default: false
            Console.WriteLine("CenterWindow : {0}", doc.CenterWindow);

            // Predominant reading order; determines the position of page
            // When displayed side by side - Default: L2R
            Console.WriteLine("Direction : {0}", doc.Direction);

            // Whether window's title bar should display doc title
            // If false, title bar displays PDF file name - Default: false
            Console.WriteLine("DisplayDocTitle : {0}", doc.DisplayDocTitle);

            // Whether to resize the doc's window to fit the size of
            // First displayed page - Default: false
            Console.WriteLine("FitWindow : {0}", doc.FitWindow);

            // Whether to hide menu bar of the viewer application - Default: false
            Console.WriteLine("HideMenuBar : {0}", doc.HideMenubar);

            // Whether to hide toolbar of the viewer application - Default: false
            Console.WriteLine("HideToolBar : {0}", doc.HideToolBar);

            // Whether to hide UI elements like scroll bars
            // And leaving only the page contents displayed - Default: false
            Console.WriteLine("HideWindowUI : {0}", doc.HideWindowUI);

            // Document's page mode. How to display doc on exiting full-screen mode.
            Console.WriteLine("NonFullScreenPageMode : {0}", doc.NonFullScreenPageMode);

            // The page layout i.e. single page, one column
            Console.WriteLine("PageLayout : {0}", doc.PageLayout);

            // How the doc should display when opened
            // I.e. show thumbnails, full-screen, show attachment panel
            Console.WriteLine("PageMode : {0}", doc.PageMode);
        }
    }

    public static void SetDocumentWindowProperties(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Set different doc properties
            // Specify to position doc's window - Default: false
            doc.CenterWindow = true;

            // Predominant reading order; determines the position of page
            // When displayed side by side - Default: L2R
            doc.Direction = Direction.R2L;

            // Specify whether window's title bar should display doc title
            // If false, title bar displays PDF file name - Default: false
            doc.DisplayDocTitle = true;

            // Specify whether to resize the doc's window to fit the size of
            // First displayed page - Default: false
            doc.FitWindow = true;

            // Specify whether to hide menu bar of the viewer application - Default: false
            doc.HideMenubar = true;

            // Specify whether to hide tool bar of the viewer application - Default: false
            doc.HideToolBar = true;

            // Specify whether to hide UI elements like scroll bars
            // And leaving only the page contents displayed - Default: false
            doc.HideWindowUI = true;

            // Document's page mode. Specify how to display doc on exiting full-screen mode.
            doc.NonFullScreenPageMode = PageMode.UseOC;

            // Specify the page layout i.e. single page, one column
            doc.PageLayout = PageLayout.TwoColumnLeft;

            // Specify how the doc should display when opened
            // I.e. show thumbnails, full-screen, show attachment panel
            doc.PageMode = PageMode.UseThumbs;

            doc.Save(outFileName);
        }
    }

    public static void EmbedFontsType1ToPdf(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Set EmbedStandardFonts property of doc
            doc.EmbedStandardFonts = true;
            // Iterate through each page
            foreach (Page page in doc.Pages)
                if (page.Resources.Fonts != null)
                    foreach (Font pageFont in page.Resources.Fonts)
                        if (!pageFont.IsEmbedded)
                            pageFont.IsEmbedded = true;
            doc.Save(outFileName);
        }
    }

    public static void EmbedFontWhileCreatingPdf(string outFileName)
    {
        TextFragment textFragment = new TextFragment("");
        // Create a TextSegment with sample text
        TextSegment textSegment = new TextSegment(" This is a sample text using Custom font.");
        // Create and configure TextState
        TextState textState = new TextState
        {
            Font = FontRepository.FindFont("Arial")
        };
        textState.Font.IsEmbedded = true;
        textSegment.TextState = textState;
        // Add the segment to the fragment
        textFragment.Segments.Add(textSegment);
        using (Document doc = new Document())
        {
            // Create a page in the Document object
            Page page = doc.Pages.Add();
            // Add the fragment to the page
            page.Paragraphs.Add(textFragment);
            doc.Save(outFileName);
        }
    }

    public static void SetDefaultFontOnDocumentSave(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            PdfSaveOptions saveOptions = new PdfSaveOptions
            {
                DefaultFontName = "Arial"
            };
            doc.Save(outFileName, saveOptions);
        }
    }

    public static void GetAllFontsFromPdf(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Font[] fonts = doc.FontUtilities.GetAllFonts();
            foreach (Font font in fonts)
                Console.WriteLine(font.FontName);
        }
    }

    public static void NotificationFontSubstitution(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Attach the FontSubstitution event handler
            doc.FontSubstitution += OnFontSubstitution;
            // You can use lambda
            // (oldFont, newFont) => Console.WriteLine("Font '{0}' was substituted with another font '{1}'",
            //     oldFont.FontName, newFont.FontName);
            doc.Save(outFileName);
        }
    }

    private static void OnFontSubstitution(Font oldFont, Font newFont)
    {
        // Handle the font substitution event here
        Console.WriteLine("Font '{0}' was substituted with another font '{1}'", oldFont.FontName, newFont.FontName);
    }

    public static void SetFontSubsetStrategy(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // All fonts will be embedded as subset into doc in case of SubsetAllFonts.
            doc.FontUtilities.SubsetFonts(FontSubsetStrategy.SubsetAllFonts);
            // Font subset will be embedded for fully embedded fonts,
            // but fonts which are not embedded into doc will not be affected.
            doc.FontUtilities.SubsetFonts(FontSubsetStrategy.SubsetEmbeddedFontsOnly);
            doc.Save(outFileName);
        }
    }

    public static void SetZoomFactor(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Create GoToAction with a specific zoom factor
            GoToAction action = new GoToAction(new XYZExplicitDestination(1, 0, 0, 0.5));
            doc.OpenAction = action;
            doc.Save(outFileName);
        }
    }

    public static void GetZoomFactor(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            if (doc.OpenAction is GoToAction action)
                if (action.Destination is XYZExplicitDestination destination)
                    // Get the Zoom factor of PDF file
                    Console.WriteLine(destination.Zoom);
        }
    }

    public static void SetPrintDialogPresetProperties(string outFileName)
    {
        using (Document doc = new Document())
        {
            doc.Pages.Add();
            // Set duplex printing to DuplexFlipLongEdge
            doc.Duplex = PrintDuplex.DuplexFlipLongEdge;
            //doc.Save(outFileName, SaveFormat.Pdf);
            doc.Save(outFileName);
        }
    }

    public static void SetPrintDialogPresetPropertiesUsingPdfContentEditor(string inFileName, string outFileName)
    {
        using (PdfContentEditor contentEditor = new PdfContentEditor())
        {
            // Bind PDF document
            contentEditor.BindPdf(inFileName);
            // Check if the file has duplex flip short edge
            if ((contentEditor.GetViewerPreference() & ViewerPreference.DuplexFlipShortEdge) > 0)
                Console.WriteLine("The file has duplex flip short edge");
            // Change the viewer preference to duplex flip short edge
            contentEditor.ChangeViewerPreference(ViewerPreference.DuplexFlipShortEdge);
            contentEditor.Save(outFileName);
        }
    }
}
