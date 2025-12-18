using System;
using System.IO;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Optimization;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

/// <summary>
/// This class contains examples of how to use optimization features in Aspose.PDF for .NET.
/// </summary>
public static class Optimize
{
    /// <summary>
    /// Runs the examples.
    /// </summary>
    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Advanced", "Documents", "Optimize");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents", "Optimize");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running OptimizeDocument example...");
        OptimizeDocument(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "OptimizeDocument.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ShrinkDocument example...");
        ShrinkDocument(Path.Combine(dataDir, "ShrinkDocument.pdf"),
            Path.Combine(outDir, "ShrinkDocument.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ShrinkImage example...");
        ShrinkImage(Path.Combine(dataDir, "Shrinkimage.pdf"),
            Path.Combine(outDir, "Shrinkimage.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ResizeImages example...");
        ResizeImages(Path.Combine(dataDir, "ResizeImage.pdf"),
            Path.Combine(outDir, "ResizeImages.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running FastShrinkImages example...");
        FastShrinkImages(Path.Combine(dataDir, "Shrinkimage.pdf"),
            Path.Combine(outDir, "FastShrinkImages.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running RemoveUnusedObjects example...");
        RemoveUnusedObjects(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "RemoveUnusedObjects.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running OptimizePdfDocument example...");
        OptimizePdfDocument(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "OptimizePdfDocument.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running OptimizePdfDocumentWithLinkDuplicateStreams example...");
        OptimizePdfDocumentWithLinkDuplicateStreams(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "OptimizePdfDocumentWithLinkDuplicateStreams.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running OptimizePdfDocumentWithReusePageContent example...");
        OptimizePdfDocumentWithReusePageContent(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "OptimizePdfDocumentWithReusePageContent.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running OptimizePdfDocumentWithUnembedFonts example...");
        OptimizePdfDocumentWithUnembedFonts(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "OptimizePdfDocumentWithUnembedFonts.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running OptimizeResourcesCompressAllContentStreams example...");
        OptimizeResourcesCompressAllContentStreams(
            Path.Combine(dataDir, "OptimizeResourcesCompressAllContentStreams.pdf"),
            Path.Combine(outDir, "OptimizeResourcesCompressAllContentStreams.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running FlattenAnnotationsInPdfDocument example...");
        FlattenAnnotationsInPdfDocument(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "FlattenAnnotationsInPdfDocument.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running FlattenPdfForms example...");
        FlattenPdfForms(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "FlattenPdfForms.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertRgbToGrayScale example...");
        ConvertRgbToGrayScale(Path.Combine(dataDir, "OptimizeDocument.pdf"),
            Path.Combine(outDir, "TestGray.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running OptimizeDocumentImagesWithFlateCompression example...");
        OptimizeDocumentImagesWithFlateCompression(Path.Combine(dataDir, "AddImage.pdf"),
            Path.Combine(outDir, "OptimizeDocumentImagesWithFlateCompression.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running AddImageToPdfWithFlateCompression example...");
        AddImageToPdfWithFlateCompression(Path.Combine(dataDir, "aspose-logo.jpg"),
            Path.Combine(outDir, "AddImageToPdfWithFlateCompression.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void OptimizeDocument(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            doc.Optimize();
            doc.Save(outFileName);
        }
    }

    public static void ShrinkDocument(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Optimize PDF document
            // Note, that this method cannot guarantee document shrinking
            doc.OptimizeResources();
            doc.Save(outFileName);
        }
    }

    public static void ShrinkImage(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                ImageCompressionOptions =
                {
                    // Set CompressImages option
                    // If this flag is set to true images will be compressed in the document
                    CompressImages = true,
                    // Set ImageQuality option
                    // Specifies level of image compression when CompressImages flag is used
                    ImageQuality = 50
                }
            };
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
    }

    public static void ResizeImages(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                ImageCompressionOptions =
                {
                    // Set CompressImages option
                    // If this flag is set to true images will be compressed in the document
                    CompressImages = true,
                    // Set ImageQuality option
                    // Specifies level of image compression when CompressImages flag is used
                    ImageQuality = 75,
                    // Set ResizeImage option
                    // If this flag set to true and CompressImages is true
                    // images will be resized if image resolution is greater than specified MaxResolution parameter
                    ResizeImages = true,
                    // Set MaxResolution option
                    // Specifies maximum resolution of images. If image has higher resolution it will be scaled
                    MaxResolution = 300
                }
            };
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
    }

    public static void FastShrinkImages(string inFileName, string outFileName)
    {
        long time = DateTime.Now.Ticks;
        using (Document doc = new Document(inFileName))
        {
            // Initialize OptimizationOptions
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                ImageCompressionOptions =
                {
                    // Set CompressImages option
                    // If this flag is set to true images will be compressed in the doc
                    CompressImages = true,
                    // Set ImageQuality option
                    // Specifies level of image compression when CompressImages flag is used
                    ImageQuality = 75,
                    // Set Image Compression Version to fast
                    // Version of compression algorithm. Possible values are:
                    // 1. standard compression
                    // 2. fast (improved compression which is faster then standard but may be applicable not for all images)
                    // 3. mixed (standard compression is applied to images which can not be compressed by faster algorithm, 
                    // this may give best compression but more slow then "fast" algorithm. Version "Fast" is not applicable for 
                    // resizing images (standard method will be used). Default is "Standard"
                    Version = ImageCompressionVersion.Fast
                }
            };
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
        // Output the time taken for the operation
        Console.WriteLine("Ticks: {0}", DateTime.Now.Ticks - time);
    }

    public static void RemoveUnusedObjects(string inFileName, string outFileName)
    {
        OptimizationOptions optimizeOptions = new OptimizationOptions
        {
            RemoveUnusedObjects = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
    }

    public static void OptimizePdfDocument(string inFileName, string outFileName)
    {
        OptimizationOptions optimizeOptions = new OptimizationOptions
        {
            RemoveUnusedStreams = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
    }

    public static void OptimizePdfDocumentWithLinkDuplicateStreams(string inFileName, string outFileName)
    {
        OptimizationOptions optimizeOptions = new OptimizationOptions
        {
            LinkDuplicateStreams = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
    }

    public static void OptimizePdfDocumentWithReusePageContent(string inFileName, string outFileName)
    {
        OptimizationOptions optimizeOptions = new OptimizationOptions
        {
            AllowReusePageContent = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
        // Calculate and display file sizes
        FileInfo fi1 = new FileInfo(inFileName);
        FileInfo fi2 = new FileInfo(outFileName);
        Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
    }

    public static void OptimizePdfDocumentWithUnembedFonts(string inFileName, string outFileName)
    {
        OptimizationOptions optimizeOptions = new OptimizationOptions
        {
            UnembedFonts = true
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
        // Calculate and display file sizes
        FileInfo fi1 = new FileInfo(inFileName);
        FileInfo fi2 = new FileInfo(outFileName);
        Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
    }

    public static void OptimizeResourcesCompressAllContentStreams(string inFileName, string outFileName)
    {
        OptimizationOptions optimizeOptions = new OptimizationOptions
        {
            // Other optimization options, such as RemoveUnusedObjects or CompressObjects, can be added as well
            CompressAllContentStreams = true,
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizeOptions);
            doc.Save(outFileName);
        }
        // Calculate and display file sizes
        FileInfo fi1 = new FileInfo(inFileName);
        FileInfo fi2 = new FileInfo(outFileName);
        Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
    }

    public static void FlattenAnnotationsInPdfDocument(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Flatten annotations
            foreach (Page page in doc.Pages)
                foreach (Annotation annotation in page.Annotations)
                    annotation.Flatten();
            doc.Save(outFileName);
        }
    }

    public static void FlattenPdfForms(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Flatten Forms
            if (doc.Form.Fields.Length > 0)
                foreach (Field item in doc.Form.Fields)
                    item.Flatten();
            doc.Save(outFileName);
        }
    }

    public static void ConvertRgbToGrayScale(string inFileName, string outFileName)
    {
        // Create RGB to DeviceGray conversion strategy
        RgbToDeviceGrayConversionStrategy strategy = new RgbToDeviceGrayConversionStrategy();
        using (Document doc = new Document(inFileName))
        {
            for (int i = 1; i <= doc.Pages.Count; i++)
            {
                Page page = doc.Pages[i];
                // Convert the RGB colorspace image to GrayScale colorspace
                strategy.Convert(page);
            }
            doc.Save(outFileName);
        }
    }

    public static void OptimizeDocumentImagesWithFlateCompression(string inFileName, string outFileName)
    {
        OptimizationOptions optimizationOptions = new OptimizationOptions
        {
            ImageCompressionOptions =
            {
                // To optimize images using FlateDecode compression, set optimization options to Flate
                Encoding = ImageEncoding.Flate
            }
        };
        using (Document doc = new Document(inFileName))
        {
            doc.OptimizeResources(optimizationOptions);
            doc.Save(outFileName);
        }
    }

    public static void AddImageToPdfWithFlateCompression(string imageFileName, string outFileName)
    {
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            using (FileStream imageStream = File.OpenRead(imageFileName))
            {
                // Add the image to the page resources with Flate compression
                page.Resources.Images.Add(imageStream, ImageFilterType.Flate);
            }
            // Get the added image
            XImage ximage = page.Resources.Images[page.Resources.Images.Count];
            // Save the current graphics state
            page.Contents.Add(new Operators.GSave());
            // Set coordinates for the image placement
            int lowerLeftX = 0;
            int lowerLeftY = 0;
            int upperRightX = 600;
            int upperRightY = 600;
            Rectangle rect = new Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
            Matrix matrix = new Matrix(new double[]
            {
                rect.URX - rect.LLX, 0, 0, rect.URY - rect.LLY, rect.LLX, rect.LLY
            });
            // Use ConcatenateMatrix operator to define how the image must be placed
            page.Contents.Add(new Operators.ConcatenateMatrix(matrix));
            page.Contents.Add(new Operators.Do(ximage.Name));
            // Restore the graphics state
            page.Contents.Add(new Operators.GRestore());
            doc.Save(outFileName);
        }
    }
}
