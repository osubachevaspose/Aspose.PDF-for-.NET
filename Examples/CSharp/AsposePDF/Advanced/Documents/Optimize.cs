using System;
using System.IO;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Optimization;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Advanced.Documents
{
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
            string workingDocumentsDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Working-Document");
            string imagesDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Images");
            string formsDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Forms");
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Advanced", "Documents");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running OptimizeDocument example...");
            OptimizeDocument(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "OptimizeDocument_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ShrinkDocument example...");
            ShrinkDocument(Path.Combine(workingDocumentsDir, "ShrinkDocument.pdf"), Path.Combine(outDir, "ShrinkDocument_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ShrinkImage example...");
            ShrinkImage(Path.Combine(imagesDir, "Shrinkimage.pdf"), Path.Combine(outDir, "Shrinkimage_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ResizeImages example...");
            ResizeImages(Path.Combine(imagesDir, "ResizeImage.pdf"), Path.Combine(outDir, "ResizeImages_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running FastShrinkImages example...");
            FastShrinkImages(Path.Combine(imagesDir, "Shrinkimage.pdf"), Path.Combine(outDir, "FastShrinkImages_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running RemoveUnusedObjects example...");
            RemoveUnusedObjects(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "RemoveUnusedObjects_out.pdf"));
            Console.WriteLine("...finished.");
            
            Console.WriteLine("Running OptimizePdfDocument example...");
            OptimizePdfDocument(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "OptimizePdfDocument_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OptimizePdfDocumentWithLinkDuplicateStreams example...");
            OptimizePdfDocumentWithLinkDuplicateStreams(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "OptimizePdfDocumentWithLinkDuplicateStreams_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OptimizePdfDocumentWithReusePageContent example...");
            OptimizePdfDocumentWithReusePageContent(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "OptimizePdfDocumentWithReusePageContent_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OptimizePdfDocumentWithUnembedFonts example...");
            OptimizePdfDocumentWithUnembedFonts(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "OptimizePdfDocumentWithUnembedFonts_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OptimizeResourcesCompressAllContentStreams example...");
            OptimizeResourcesCompressAllContentStreams(Path.Combine(workingDocumentsDir, "OptimizeDocumentCompressStreams.pdf"), Path.Combine(outDir, "OptimizeResourcesCompressAllContentStreams_out.pdf"));
            Console.WriteLine("...finished.");
            
            Console.WriteLine("Running FlattenAnnotationsInPdfDocument example...");
            FlattenAnnotationsInPdfDocument(Path.Combine(workingDocumentsDir, "OptimizeDocument.pdf"), Path.Combine(outDir, "FlattenAnnotationsInPdfDocument_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running FlattenPdfForms example...");
            FlattenPdfForms(Path.Combine(formsDir, "input.pdf"), Path.Combine(outDir, "FlattenPdfForms_out.pdf"));
            Console.WriteLine("...finished.");
            
            Console.WriteLine("Running ConvertRgbToGrayScale example...");
            ConvertRgbToGrayScale(Path.Combine(workingDocumentsDir, "input.pdf"), Path.Combine(outDir, "TestGray_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OptimizeDocumentImagesWithFlateCompression example...");
            OptimizeDocumentImagesWithFlateCompression(Path.Combine(imagesDir, "AddImage.pdf"), Path.Combine(outDir, "OptimizeDocumentImagesWithFlateCompression_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running AddImageToPdfWithFlateCompression example...");
            AddImageToPdfWithFlateCompression(Path.Combine(imagesDir, "aspose-logo.jpg"), Path.Combine(outDir, "AddImageToPdfWithFlateCompression_out.pdf"));
            Console.WriteLine("...finished.");
        }

        public static void OptimizeDocument(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
            {
                // Optimize for web
                document.Optimize();

                // Save PDF document
                document.Save(outFileName);
            }
        }

        public static void ShrinkDocument(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
            {
                // Optimize PDF document. Note, though, that this method cannot guarantee document shrinking
                document.OptimizeResources();

                // Save PDF document
                document.Save(outFileName);
            }
        }

        public static void ShrinkImage(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }
        }

        public static void ResizeImages(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }
        }

        public static void FastShrinkImages(string inFileName, string outFileName)
        {
            // Initialize Time
            long time = DateTime.Now.Ticks;
            
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }

            // Output the time taken for the operation
            Console.WriteLine("Ticks: {0}", DateTime.Now.Ticks - time);
        }

        public static void RemoveUnusedObjects(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
            {
                // Set RemoveUsedObject option
                OptimizationOptions optimizeOptions = new OptimizationOptions
                {
                    RemoveUnusedObjects = true
                };

                // Optimize PDF document using OptimizationOptions
                document.OptimizeResources(optimizeOptions);

                // Save PDF document
                document.Save(outFileName);
            }
        }
        
        public static void OptimizePdfDocument(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
            {
                // Set RemoveUsedStreams option
                OptimizationOptions optimizeOptions = new OptimizationOptions
                {
                    RemoveUnusedStreams = true
                };

                // Optimize PDF document using OptimizationOptions
                document.OptimizeResources(optimizeOptions);

                // Save PDF document
                document.Save(outFileName);
            }
        }

        public static void OptimizePdfDocumentWithLinkDuplicateStreams(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
            {
                // Set LinkDuplicateStreams option
                OptimizationOptions optimizeOptions = new OptimizationOptions
                {
                    LinkDuplicateStreams = true
                };

                // Optimize PDF document using OptimizationOptions
                document.OptimizeResources(optimizeOptions);

                // Save PDF document
                document.Save(outFileName);
            }
        }
        
        public static void OptimizePdfDocumentWithReusePageContent(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }

            Console.WriteLine("Finished");

            // Calculate and display file sizes
            FileInfo fi1 = new FileInfo(inFileName);
            FileInfo fi2 = new FileInfo(outFileName);
            Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
        }

        public static void OptimizePdfDocumentWithUnembedFonts(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }

            Console.WriteLine("Finished");

            // Calculate and display file sizes
            FileInfo fi1 = new FileInfo(inFileName);
            FileInfo fi2 = new FileInfo(outFileName);
            Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
        }

        public static void OptimizeResourcesCompressAllContentStreams(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }
            
            // Calculate and display file sizes
            FileInfo fi1 = new FileInfo(inFileName);
            FileInfo fi2 = new FileInfo(outFileName);
            Console.WriteLine("Original file size: {0}. Reduced file size: {1}", fi1.Length, fi2.Length);
        }

        public static void FlattenAnnotationsInPdfDocument(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }
        }

        public static void FlattenPdfForms(string inFileName, string outFileName)
        {
            // Load source PDF form
            using (Document document = new Document(inFileName))
            {
                // Flatten Forms
                if (document.Form.Fields.Length > 0)
                {
                    foreach (Field item in document.Form.Fields)
                    {
                        item.Flatten();
                    }
                }

                // Save PDF document
                document.Save(outFileName);
            }
        }

        public static void ConvertRgbToGrayScale(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
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
                document.Save(outFileName);
            }
        }

        public static void OptimizeDocumentImagesWithFlateCompression(string inFileName, string outFileName)
        {
            // Open PDF document
            using (Document document = new Document(inFileName))
            {
                // Initialize OptimizationOptions
                OptimizationOptions optimizationOptions = new OptimizationOptions();

                // To optimize images using FlateDecode compression, set optimization options to Flate
                optimizationOptions.ImageCompressionOptions.Encoding = ImageEncoding.Flate;

                // Set optimization options
                document.OptimizeResources(optimizationOptions);

                // Save PDF document
                document.Save(outFileName);
            }
        }

        public static void AddImageToPdfWithFlateCompression(string imageFileName, string outFileName)
        {
            // Create PDF document
            using (Document document = new Document())
            {
                // Add page
                Page page = document.Pages.Add();

                // Open the image file stream
                using (FileStream imageStream = new FileStream(imageFileName, FileMode.Open))
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
                document.Save(outFileName);
            }
        }
    }
}