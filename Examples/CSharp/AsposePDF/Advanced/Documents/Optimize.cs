using System;
using System.IO;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Optimization;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents;

internal class Optimize
{
    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizeDocument()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Optimize for web
            document.Optimize();

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ShrinkDocument()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "ShrinkDocument.pdf"))
        {
            // Optimize PDF document. Note, though, that this method cannot guarantee document shrinking
            document.OptimizeResources();

            // Save PDF document
            document.Save(dataDir + "ShrinkDocument_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ShrinkImage()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Images();

        // Open PDF document
        using (Document document = new Document(dataDir + "Shrinkimage.pdf"))
        {
            // Initialize OptimizationOptions
            OptimizationOptions optimizeOptions = new OptimizationOptions();

            // Set CompressImages option
            // If this flag is set to true images will be compressed in the document
            optimizeOptions.ImageCompressionOptions.CompressImages = true;

            // Set ImageQuality option
            // Specifies level of image compression when CompressImages flag is used
            optimizeOptions.ImageCompressionOptions.ImageQuality = 50;

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "Shrinkimage_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ResizeImages()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Images();

        // Open PDF document
        using (Document document = new Document(dataDir + "ResizeImage.pdf"))
        {
            // Initialize OptimizationOptions
            OptimizationOptions optimizeOptions = new OptimizationOptions();

            // Set CompressImages option
            // If this flag is set to true images will be compressed in the document
            optimizeOptions.ImageCompressionOptions.CompressImages = true;

            // Set ImageQuality option
            // Specifies level of image compression when CompressImages flag is used
            optimizeOptions.ImageCompressionOptions.ImageQuality = 75;

            // Set ResizeImage option
            // If this flag set to true and CompressImages is true images will be resized if image resolution is greater then specified MaxResolution parameter
            optimizeOptions.ImageCompressionOptions.ResizeImages = true;

            // Set MaxResolution option
            // Specifies maximum resolution of images. If image has higher resolition it will be scaled
            optimizeOptions.ImageCompressionOptions.MaxResolution = 300;

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "ResizeImages_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void FastShrinkImages()
    {
        // Initialize Time
        long time = DateTime.Now.Ticks;

        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Images();

        // Open PDF document
        using (Document document = new Document(dataDir + "Shrinkimage.pdf"))
        {
            // Initialize OptimizationOptions
            OptimizationOptions optimizeOptions = new OptimizationOptions();

            // Set CompressImages option
            // If this flag is set to true images will be compressed in the document
            optimizeOptions.ImageCompressionOptions.CompressImages = true;

            // Set ImageQuality option
            // Specifies level of image compression when CompressImages flag is used
            optimizeOptions.ImageCompressionOptions.ImageQuality = 75;

            // Set Image Compression Version to fast
            // Version of compression algorithm. Possible values are:
            // 1. standard compression
            // 2. fast (improved compression which is faster then standard but may be applicable not for all images)
            // 3. mixed (standard compression is applied to images which can not be compressed by faster algorithm, 
            // this may give best compression but more slow then "fast" algorithm. Version "Fast" is not applicable for 
            // resizing images (standard method will be used). Default is "Standard"
            optimizeOptions.ImageCompressionOptions.Version = ImageCompressionVersion.Fast;

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "FastShrinkImages_out.pdf");
        }

        // Output the time taken for the operation
        Console.WriteLine("Ticks: {0}", DateTime.Now.Ticks - time);
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void RemoveUnusedObjects()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Set RemoveUsedObject option
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                RemoveUnusedObjects = true
            };

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizePdfDocument()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Set RemoveUsedStreams option
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                RemoveUnusedStreams = true
            };

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizePdfDocumentWithLinkDuplicateStreams()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Set LinkDuplicateStreams option
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                LinkDuplicateStreams = true
            };

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizePdfDocumentWithReusePageContent()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Set AllowReusePageContent option
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                AllowReusePageContent = true
            };

            Console.WriteLine("Start");

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }

        Console.WriteLine("Finished");

        // Calculate and display file sizes
        FileInfo fi1 = new FileInfo(dataDir + "OptimizeDocument.pdf");
        FileInfo fi2 = new FileInfo(dataDir + "OptimizeDocument_out.pdf");
        Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizePdfDocumentWithUnembedFonts()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Set UnembedFonts option
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                UnembedFonts = true
            };

            Console.WriteLine("Start");

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }

        Console.WriteLine("Finished");

        // Calculate and display file sizes
        FileInfo fi1 = new FileInfo(dataDir + "OptimizeDocument.pdf");
        FileInfo fi2 = new FileInfo(dataDir + "OptimizeDocument_out.pdf");
        Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizeResourcesCompressAllContentStreams()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocumentCompressStreams.pdf"))
        {
            // Set CompressAllContentStreams option
            OptimizationOptions optimizeOptions = new OptimizationOptions
            {
                // Other optimization options, such as RemoveUnusedObjects or CompressObjects, can be added as well
                CompressAllContentStreams = true,
            };

            // Optimize PDF document using OptimizationOptions
            document.OptimizeResources(optimizeOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocumentCompressStreams_out.pdf");
        }

        // Calculate and display file sizes
        FileInfo fi1 = new FileInfo(dataDir + "OptimizeDocumentCompressStreams.pdf");
        FileInfo fi2 = new FileInfo(dataDir + "OptimizeDocumentCompressStreams_out.pdf");
        Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void FlattenAnnotationsInPdfDocument()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "OptimizeDocument.pdf"))
        {
            // Flatten annotations
            foreach (Page page in document.Pages)
            {
                foreach (Annotation annotation in page.Annotations)
                {
                    annotation.Flatten();
                }
            }

            // Save PDF document
            document.Save(dataDir + "OptimizeDocument_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void FlattenPdfForms()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Forms();

        // Load source PDF form
        using (Document document = new Document(dataDir + "input.pdf"))
        {
            // Flatten Forms
            if (document.Form.Fields.Lenght > 0)
            {
                foreach (Field item in document.Form.Fields)
                {
                    item.Flatten();
                }
            }

            // Save PDF document
            document.Save(dataDir + "FlattenForms_out.pdf");
        }
    }

    // For complete examples and data files, visit https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void ConvertRgbToGrayScale()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_WorkingDocuments();

        // Open PDF document
        using (Document document = new Document(dataDir + "input.pdf"))
        {
            // Create RGB to DeviceGray conversion strategy
            RgbToDeviceGrayConversionStrategy strategy = new RgbToDeviceGrayConversionStrategy();

            // Iterate through each page
            for (int idxPage = 1; idxPage <= document.Pages.Count; idxPage++)
            {
                // Get instance of particular page inside PDF
                Page page = document.Pages[idxPage];

                // Convert the RGB colorspace image to GrayScale colorspace
                strategy.Convert(page);
            }

            // Save PDF document
            document.Save(dataDir + "TestGray_out.pdf");
        }
    }

    // For complete examples and data files, please go to https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void OptimizeDocumentImagesWithFlateCompression()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Images();

        // Open PDF document
        using (Document document = new Document(dataDir + "AddImage.pdf"))
        {
            // Initialize OptimizationOptions
            OptimizationOptions optimizationOptions = new OptimizationOptions();

            // To optimize images using FlateDecode compression, set optimization options to Flate
            optimizationOptions.ImageCompressionOptions.Encoding = ImageEncoding.Flate;

            // Set optimization options
            document.OptimizeResources(optimizationOptions);

            // Save PDF document
            document.Save(dataDir + "OptimizeDocumentImagesWithFlateCompression_out.pdf");
        }
    }

    // For complete examples and data files, please go to https://github.com/aspose-pdf/Aspose.PDF-for-.NET
    private static void AddImageToPdfWithFlateCompression()
    {
        // The path to the documents directory
        var dataDir = RunExamples.GetDataDir_AsposePdf_Images();

        // Create PDF document
        using (Document document = new Document())
        {
            // Add page
            Page page = document.Pages.Add();

            // Open the image file stream
            using (FileStream imageStream = new FileStream(dataDir + "aspose-logo.jpg", FileMode.Open))
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

            Rectangle rectangle = new Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
            Matrix matrix = new Matrix(new double[]
            {
                rectangle.URX - rectangle.LLX, 0, 0, rectangle.URY - rectangle.LLY, rectangle.LLX, rectangle.LLY
            });

            // Use ConcatenateMatrix operator to define how the image must be placed
            page.Contents.Add(new Operators.ConcatenateMatrix(matrix));
            page.Contents.Add(new Operators.Do(ximage.Name));

            // Restore the graphics state
            page.Contents.Add(new Operators.GRestore());

            // Save the document
            document.Save(dataDir + "AddImageToPdfWithFlateCompression_out.pdf");
        }
    }
}
