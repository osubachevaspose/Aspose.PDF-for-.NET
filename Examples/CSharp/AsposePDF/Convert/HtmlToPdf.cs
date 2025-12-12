using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class HtmlToPdf
{
    //https://docs.aspose.com/pdf/net/convert-html-to-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "HtmlToPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "HtmlToPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertHTMLtoPDF example...");
        ConvertHTMLtoPDF(Path.Combine(dataDir, "SampleHtmlFile.html"),
            Path.Combine(outDir, "ConvertHTMLtoPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertHTMLtoPDFAdvancedMediaType example...");
        ConvertHTMLtoPDFAdvancedMediaType(Path.Combine(dataDir, "SampleHtmlFile.html"),
            Path.Combine(outDir, "ConvertHTMLtoPDFAdvancedMediaType.pdf"));
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertHTMLtoPDFAdvancedEmbedFonts example...");
        //ConvertHTMLtoPDFAdvancedEmbedFonts(Path.Combine(dataDir, "test_fonts.html"),
        //    Path.Combine(outDir, "ConvertHTMLtoPDFAdvanced_EmbedFonts.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertHTMLtoPDFAdvanced_DummyImage example...");
        //ConvertHTMLtoPDFAdvanced_DummyImage(Path.Combine(dataDir, "test.html"),
        //    Path.Combine(dataDir, "test.jpg"),
        //    Path.Combine(outDir, "html_test.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertHTMLtoPDFAdvanced_WebPage example...");
        //ConvertHTMLtoPDFAdvanced_WebPage(Path.Combine(outDir, "ConvertHTMLtoPDF_WebPage.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertHTMLtoPDFAdvancedAuthorized example...");
        //ConvertHTMLtoPDFAdvancedAuthorized(Path.Combine(outDir, "ConvertHTMLtoPDF_Authorized.pdf"));
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertHTMLtoPDFAdvancedSinglePageRendering example...");
        ConvertHTMLtoPDFAdvancedSinglePageRendering(Path.Combine(dataDir, "HTMLToPDF.html"),
            Path.Combine(outDir, "RenderContentToSamePage.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertHTMLtoPDFWithSVG example...");
        ConvertHTMLtoPDFWithSVG(Path.Combine(dataDir, "HTMLSVG.html"),
            Path.Combine(outDir, "RenderHTMLwithSVGData.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertMHTtoPDF example...");
        ConvertMHTtoPDF(Path.Combine(dataDir, "sample.mht"), Path.Combine(outDir, "MhtmlTest.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertHTMLtoPDF(string inFileName, string outFileName)
    {
        HtmlLoadOptions loadOptions = new HtmlLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertHTMLtoPDFAdvancedMediaType(string inFileName, string outFileName)
    {
        HtmlLoadOptions loadOptions = new HtmlLoadOptions
        {
            // Set Print or Screen mode
            HtmlMediaType = HtmlMediaType.Print
        };
        // Load the HTML file into a document using HtmlLoadOptions with Print media type
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertHTMLtoPDFAdvancedEmbedFonts(string inFileName, string outFileName)
    {
        HtmlLoadOptions loadOptions = new HtmlLoadOptions
        {
            // Disable font embedding
            IsEmbedFonts = false
        };
        // Load the HTML file into a document using HtmlLoadOptions with the font embedding option set
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertHTMLtoPDFAdvanced_DummyImage(string inFileName, string imageFileName, string outFileName)
    {
        HtmlLoadOptions loadOptions = new HtmlLoadOptions
        {
            CustomLoaderOfExternalResources = SamePictureLoader
        };
        // Load the HTML file into a document with a custom resource loader for external images
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
        return;

        LoadOptions.ResourceLoadingResult SamePictureLoader(string resourceURI)
        {
            LoadOptions.ResourceLoadingResult result;
            if (resourceURI.EndsWith(".png"))
            {
                byte[] resultBytes = File.ReadAllBytes(imageFileName);
                result = new LoadOptions.ResourceLoadingResult(resultBytes)
                {
                    // Set MIME Type
                    MIMETypeIfKnown = "image/jpeg"
                };
            }
            else
            {
                result = new LoadOptions.ResourceLoadingResult(GetContentFromUrl(resourceURI));
            }
            return result;
        }

        static byte[] GetContentFromUrl(string url)
        {
            HttpClient httpClient = new HttpClient();
            return httpClient.GetByteArrayAsync(url).GetAwaiter().GetResult();
        }
    }

    public static void ConvertHTMLtoPDFAdvanced_WebPage(string outFileName)
    {
        const string url = "https://en.wikipedia.org/wiki/Aspose_API";
        // Set page size A3 and Landscape orientation;   
        HtmlLoadOptions loadOptions = new HtmlLoadOptions(url)
        {
            PageInfo =
            {
                Width = 842,
                Height = 1191,
                IsLandscape = true
            }
        };
        // Load the web page content as a stream and create a PDF document
        using (Document doc = new Document(GetContentFromUrlAsStream(url), loadOptions))
        {
            doc.Save(outFileName);
        }
        return;

        static Stream GetContentFromUrlAsStream(string url, ICredentials credentials = null)
        {
            using (HttpClientHandler handler = new HttpClientHandler { Credentials = credentials })
            using (HttpClient httpClient = new HttpClient(handler))
            {
                return httpClient.GetStreamAsync(url).GetAwaiter().GetResult();
            }
        }
    }

    public static void ConvertHTMLtoPDFAdvancedAuthorized(string outFileName)
    {
        const string url = "http://httpbin.org/basic-auth/user1/password1";
        NetworkCredential credentials = new NetworkCredential("user1", "password1");
        HtmlLoadOptions loadOptions = new HtmlLoadOptions(url)
        {
            ExternalResourcesCredentials = credentials
        };
        using (Document doc = new Document(GetContentFromUrlAsStream(url, credentials), loadOptions))
        {
            doc.Save(outFileName);
        }
        return;

        static Stream GetContentFromUrlAsStream(string url, ICredentials credentials = null)
        {
            using (HttpClientHandler handler = new HttpClientHandler { Credentials = credentials })
            using (HttpClient httpClient = new HttpClient(handler))
            {
                return httpClient.GetStreamAsync(url).GetAwaiter().GetResult();
            }
        }
    }

    public static void ConvertHTMLtoPDFAdvancedSinglePageRendering(string inFileName, string outFileName)
    {
        HtmlLoadOptions loadOptions = new HtmlLoadOptions
        {
            // Set Render to single page property
            IsRenderToSinglePage = true
        };
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertHTMLtoPDFWithSVG(string inFileName, string outFileName)
    {
        HtmlLoadOptions loadOptions = new HtmlLoadOptions(Path.GetDirectoryName(inFileName));
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertMHTtoPDF(string inFileName, string outFileName)
    {
        // Initialize MhtLoadOptions with page setup
        MhtLoadOptions loadOptions = new MhtLoadOptions()
        {
            PageInfo =
            {
                Width = 842,
                Height = 1191,
                IsLandscape = true
            }
        };
        // Initialize Document object using the MHT file and options
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }
}
