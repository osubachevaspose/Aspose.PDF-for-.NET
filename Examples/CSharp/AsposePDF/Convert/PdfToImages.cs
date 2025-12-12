using System;
using System.IO;
using Aspose.Pdf.Devices;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class PdfToImages
{
    //https://docs.aspose.com/pdf/net/convert-pdf-to-images-format/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "PdfToImages");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "PdfToImages");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ConvertPDFtoTIFF example...");
        ConvertPDFtoTIFF(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFtoTIFF.tif"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoTiffSinglePage example...");
        ConvertPDFtoTiffSinglePage(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFtoTiffSinglePage.tif"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoTiffBradleyBinarization example...");
        ConvertPDFtoTiffBradleyBinarization(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "PDFtoTiffBradleyBinarization.tif"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFusingImageDevice example...");
        ConvertPDFusingImageDevice(Path.Combine(dataDir, "input.pdf"), outDir);
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoImageWithTransparentBackground example...");
        ConvertPDFtoImageWithTransparentBackground(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "ConvertPDFtoImageWithTransparentBackground.png"));
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertParticularPageRegionToImage example...");
        //ConvertParticularPageRegionToImage(Path.Combine(dataDir, "input.pdf"),
        //    Path.Combine(outDir, "ConvertParticularPageRegionToImage.png"));
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertPDFtoSVG example...");
        ConvertPDFtoSVG(Path.Combine(dataDir, "input.pdf"), Path.Combine(outDir, "PDFToSVG.svg"));
        Console.WriteLine("...finished.");
    }

    public static void ConvertPDFtoTIFF(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Resolution resolution = new Resolution(300);
            TiffSettings tiffSettings = new TiffSettings
            {
                Compression = CompressionType.None,
                Depth = ColorDepth.Default,
                Shape = ShapeType.Landscape,
                SkipBlankPages = false
            };
            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);
            tiffDevice.Process(doc, outFileName);
        }
    }

    public static void ConvertPDFtoTiffSinglePage(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Resolution resolution = new Resolution(300);
            TiffSettings tiffSettings = new TiffSettings
            {
                Compression = CompressionType.None,
                Depth = ColorDepth.Default,
                Shape = ShapeType.Landscape,
            };
            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);
            // Convert a particular page and save the image to file
            tiffDevice.Process(doc, 1, 1, outFileName);
        }
    }

    public static void ConvertPDFtoTiffBradleyBinarization(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            string outputBinImageFile = Path.Combine(
                Path.GetDirectoryName(outFileName),
                Path.GetFileNameWithoutExtension(outFileName) + "-bin" + Path.GetExtension(outFileName)
            );
            Resolution resolution = new Resolution(300);
            TiffSettings tiffSettings = new TiffSettings
            {
                Compression = CompressionType.LZW,
                Depth = ColorDepth.Format1bpp
            };
            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);
            tiffDevice.Process(doc, outFileName);
            // Binarize the image using Bradley method
            using (FileStream inStream = File.OpenRead(outFileName))
            using (FileStream outStream = File.OpenWrite(outputBinImageFile))
            {
                tiffDevice.BinarizeBradley(inStream, outStream, 0.1);
            }
        }
    }

    public static void ConvertPDFusingImageDevice(string inFileName, string outDir)
    {
        // Create Resolution object            
        Resolution resolution = new Resolution(300);
        BmpDevice bmpDevice = new BmpDevice(resolution);
        JpegDevice jpegDevice = new JpegDevice(resolution);
        GifDevice gifDevice = new GifDevice(resolution);
        PngDevice pngDevice = new PngDevice(resolution);
        EmfDevice emfDevice = new EmfDevice(resolution);
        using (Document doc = new Document(inFileName))
        {
            ConvertPDFtoImage(bmpDevice, "bmp", doc, outDir);
            ConvertPDFtoImage(jpegDevice, "jpeg", doc, outDir);
            ConvertPDFtoImage(gifDevice, "gif", doc, outDir);
            ConvertPDFtoImage(pngDevice, "png", doc, outDir);
            ConvertPDFtoImage(emfDevice, "emf", doc, outDir);
        }
    }

    private static void ConvertPDFtoImage(ImageDevice imageDevice,
        string ext, Document doc, string outDir)
    {
        Console.WriteLine($"Converting to {ext}...");
        for (int i = 1; i <= doc.Pages.Count; i++)
        {
            using (FileStream imageStream = File.OpenWrite(Path.Combine(outDir, $"page{i}.{ext}")))
            {
                // Convert a particular page and save the image to stream
                imageDevice.Process(doc.Pages[i], imageStream);
            }
        }
    }

    public static void ConvertPDFtoImageWithTransparentBackground(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            PngDevice pngDevice = new PngDevice();
            pngDevice.TransparentBackground = true;
            using (FileStream pngStream = File.OpenWrite(outFileName))
            {
                // Convert page to PNG image
                pngDevice.Process(doc.Pages[1], pngStream);
            }
        }
    }

    public static void ConvertParticularPageRegionToImage(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Get rectangle of particular XImage
            ImagePlacementAbsorber imagePlacementAbsorber = new ImagePlacementAbsorber();
            doc.Pages[1].Accept(imagePlacementAbsorber);
            Rectangle imageRectangle = imagePlacementAbsorber.ImagePlacements[1].Rectangle;
            Rectangle pageRect = new Rectangle(imageRectangle.LLX, imageRectangle.LLY, imageRectangle.URX, imageRectangle.URY);
            // Set CropBox value as per rectangle of desired page region
            doc.Pages[1].CropBox = pageRect;
            Resolution resolution = new Resolution(300);
            // Create PNG device with specified attributes
            PngDevice pngDevice = new PngDevice(resolution);
            // Convert a particular page and save the image
            pngDevice.Process(doc.Pages[1], outFileName);
        }
    }

    public static void ConvertPDFtoSVG(string inFileName, string outFileName)
    {
        SvgSaveOptions saveOptions = new SvgSaveOptions
        {
            // Do not compress SVG image to Zip archive
            CompressOutputToZipArchive = false,
            TreatTargetFileNameAsDirectory = true
        };
        using (Document doc = new Document(inFileName))
        {
            // Save SVG file
            doc.Save(outFileName, saveOptions);
        }
    }
}
