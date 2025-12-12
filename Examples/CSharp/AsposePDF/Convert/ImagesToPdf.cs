using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;

public static class ImagesToPdf
{
    //https://docs.aspose.com/pdf/net/convert-images-format-to-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Convert", "ImagesToPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Convert", "ImagesToPdf");
        Directory.CreateDirectory(outDir);

        //Console.WriteLine("Running ConvertBMPtoPDF example...");
        //ConvertBMPtoPDF(Path.Combine(dataDir, "BMPtoPDF.bmp"), Path.Combine(outDir, "BMPtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertCGMtoPDF example...");
        ConvertCGMtoPDF(Path.Combine(dataDir, "CGMtoPDF.cgm"), Path.Combine(outDir, "CGMtoPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertDICOMtoPDF example...");
        //ConvertDICOMtoPDF(Path.Combine(dataDir, "DICOMtoPDF.dcm"), Path.Combine(outDir, "DICOMtoPDF.pdf"));
        ConvertDICOMtoPDF(Path.Combine(dataDir, "0002.dcm"), Path.Combine(outDir, "DICOMtoPDF.pdf"));
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertEMFtoPDF example...");
        //ConvertEMFtoPDF(Path.Combine(dataDir, "EMFtoPDF.emf"), Path.Combine(outDir, "EMFtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertGIFtoPDF example...");
        //ConvertGIFtoPDF(Path.Combine(dataDir, "GIFtoPDF.gif"), Path.Combine(outDir, "GIFtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertJPGtoPDF example...");
        //ConvertJPGtoPDF(Path.Combine(dataDir, "JPGtoPDF.jpg"), 
        //    Path.Combine(outDir, "JPGtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertJPGtoPDF_same_page_size example...");
        //ConvertJPGtoPDF_same_page_size(Path.Combine(dataDir, "JPGtoPDF.jpg"), 
        //    Path.Combine(outDir, "JPGtoPDF_same_page_size.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertPNGtoPDF example...");
        //ConvertPNGtoPDF(Path.Combine(dataDir, "PNGtoPDF.png"), Path.Combine(outDir, "PNGtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertSVGtoPDF example...");
        ConvertSVGtoPDF(Path.Combine(dataDir, "SVGtoPDF.svg"), Path.Combine(outDir, "SVGtoPDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ConvertSVGtoPDF_dimensions example...");
        ConvertSVGtoPDF_dimensions(Path.Combine(dataDir, "SVGtoPDF.svg"),
            Path.Combine(outDir, "SVGtoPDF_dimensions.pdf"));
        Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertTIFFtoPDF example...");
        //ConvertTIFFtoPDF(Path.Combine(dataDir, "TIFFtoPDF.tif"),
        //    Path.Combine(outDir, "TIFFtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertTIFFtoPDF_multi example...");
        //ConvertTIFFtoPDF_multi(Path.Combine(dataDir, "TIFFtoPDF.tif"), 
        //    Path.Combine(outDir, "TIFFtoPDF_multi.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertCDRtoPDF example...");
        //ConvertCDRtoPDF(Path.Combine(dataDir, "CDRtoPDF.cdr"), Path.Combine(outDir, "CDRtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertDJVUtoPDF example...");
        //ConvertDJVUtoPDF(Path.Combine(dataDir, "DJVUtoPDF.djvu"), 
        //    Path.Combine(outDir, "DJVUtoPDF.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ConvertHEICtoPDF example...");
        //ConvertHEICtoPDF(Path.Combine(dataDir, "HEICtoPDF.heic"),
        //    Path.Combine(outDir, "HEICtoPDF.pdf"));
        //Console.WriteLine("...finished.");
    }

    public static void ConvertBMPtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            // Load BMP file
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertCGMtoPDF(string inFileName, string outFileName)
    {
        CgmLoadOptions loadOptions = new CgmLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertDICOMtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            FileType = ImageFileType.Dicom,
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertEMFtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            // Load EMF file
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            // Specify page dimension properties
            page.PageInfo.Margin.Bottom = 0;
            page.PageInfo.Margin.Top = 0;
            page.PageInfo.Margin.Left = 0;
            page.PageInfo.Margin.Right = 0;
            page.PageInfo.Width = image.BitmapSize.Width;
            page.PageInfo.Height = image.BitmapSize.Height;
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertGIFtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            // Load sample GIF image file
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertJPGtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            // Load input JPG file
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertJPGtoPDF_same_page_size(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            // Load JPEG file
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            // Read Height of input image
            page.PageInfo.Height = image.BitmapSize.Height;
            // Read Width of input image
            page.PageInfo.Width = image.BitmapSize.Width;
            page.PageInfo.Margin.Bottom = 0;
            page.PageInfo.Margin.Top = 0;
            page.PageInfo.Margin.Right = 0;
            page.PageInfo.Margin.Left = 0;
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertPNGtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            // Load PNG file
            File = inFileName
        };
        using (Document doc = new Document())
        {
            Page page = doc.Pages.Add();
            // Read Height of input image
            page.PageInfo.Height = image.BitmapSize.Height;
            // Read Width of input image
            page.PageInfo.Width = image.BitmapSize.Width;
            page.PageInfo.Margin.Bottom = 0;
            page.PageInfo.Margin.Top = 0;
            page.PageInfo.Margin.Right = 0;
            page.PageInfo.Margin.Left = 0;
            page.Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertSVGtoPDF(string inFileName, string outFileName)
    {
        SvgLoadOptions loadOptions = new SvgLoadOptions();
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertSVGtoPDF_dimensions(string inFileName, string outFileName)
    {
        SvgLoadOptions loadOptions = new SvgLoadOptions
        {
            AdjustPageSize = true
        };
        using (Document doc = new Document(inFileName, loadOptions))
        {
            doc.Pages[1].PageInfo.Margin.Top = 0;
            doc.Pages[1].PageInfo.Margin.Left = 0;
            doc.Pages[1].PageInfo.Margin.Bottom = 0;
            doc.Pages[1].PageInfo.Margin.Right = 0;
            doc.Save(outFileName);
        }
    }

    public static void ConvertTIFFtoPDF(string inFileName, string outFileName)
    {
        Image image = new Image
        {
            File = inFileName
        };
        using (Document doc = new Document())
        {
            doc.Pages.Add();
            doc.Pages[1].Paragraphs.Add(image);
            doc.Save(outFileName);
        }
    }

    public static void ConvertTIFFtoPDF_multi(string inFileName, string outFileName)
    {
        using (Document doc = new Document())
        {
            using (Bitmap bitmap = new Bitmap(File.OpenRead(inFileName)))
            {
                // Convert multi page or multi frame TIFF to PDF
                FrameDimension dimension = new FrameDimension(bitmap.FrameDimensionsList[0]);
                int frameCount = bitmap.GetFrameCount(dimension);
                for (int frameIdx = 0; frameIdx <= frameCount - 1; frameIdx++)
                {
                    Page page = doc.Pages.Add();
                    bitmap.SelectActiveFrame(dimension, frameIdx);
                    using (MemoryStream currentImage = new MemoryStream())
                    {
                        bitmap.Save(currentImage, ImageFormat.Tiff);
                        Image image = new Image
                        {
                            ImageStream = currentImage,
                            //Apply some other options
                            //ImageScale = 0.5
                        };
                        page.Paragraphs.Add(image);
                    }
                }
            }
            doc.Save(outFileName);
        }
    }

    public static void ConvertCDRtoPDF(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName, new CdrLoadOptions()))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertDJVUtoPDF(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName, new DjvuLoadOptions()))
        {
            doc.Save(outFileName);
        }
    }

    public static void ConvertHEICtoPDF(string inFileName, string outFileName)
    {
        using (FileStream fs = new FileStream(inFileName, FileMode.Open))
        {
            Openize.Heic.Decoder.HeicImage heicImage = Openize.Heic.Decoder.HeicImage.Load(fs);
            byte[] pixels = heicImage.GetByteArray(Openize.Heic.Decoder.PixelFormat.Rgb24);
            int width = (int)heicImage.Width;
            int height = (int)heicImage.Height;
            Image asposeImage = new Image
            {
                BitmapInfo = new BitmapInfo(pixels, width, height, BitmapInfo.PixelFormat.Rgb24)
            };
            using (Document doc = new Document())
            {
                Page page = doc.Pages.Add();
                page.PageInfo.Height = height;
                page.PageInfo.Width = width;
                page.PageInfo.Margin.Bottom = 0;
                page.PageInfo.Margin.Top = 0;
                page.PageInfo.Margin.Right = 0;
                page.PageInfo.Margin.Left = 0;
                page.Paragraphs.Add(asposeImage);
                doc.Save(outFileName);
            }
        }
    }
}
