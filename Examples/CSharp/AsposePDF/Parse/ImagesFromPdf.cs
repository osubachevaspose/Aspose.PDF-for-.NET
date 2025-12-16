using System;
using System.Drawing.Imaging;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class ImagesFromPdf
{
    //https://docs.aspose.com/pdf/net/extract-images-from-the-pdf-file/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "ImagesFromPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "ImagesFromPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractImagesFromPDF example...");
        ExtractImagesFromPDF(Path.Combine(dataDir, "ExtractImages.pdf"),
            Path.Combine(outDir, "ExtractImages.jpg"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractImagesFromPDF(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Extract a particular image
            XImage xImage = doc.Pages[1].Resources.Images[1];
            using (FileStream outputImage = File.OpenWrite(outFileName))
            {
                xImage.Save(outputImage, ImageFormat.Jpeg);
            }
        }
    }
}
