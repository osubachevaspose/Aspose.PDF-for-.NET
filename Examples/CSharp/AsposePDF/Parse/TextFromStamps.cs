using System;
using System.IO;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class TextFromStamps
{
    //https://docs.aspose.com/pdf/net/extract-text-from-stamps/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "TextFromStamps");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "TextFromStamps");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractTextFromStamp example...");
        ExtractTextFromStamp(Path.Combine(dataDir, "ExtractStampText.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractTextFromStamp(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            Annotations.Annotation annotation = doc.Pages[1].Annotations[1];
            if (annotation is Annotations.StampAnnotation stampAnnotation)
            {
                TextAbsorber absorber = new TextAbsorber();
                XForm appearance = stampAnnotation.Appearance["N"];
                absorber.Visit(appearance);
                Console.WriteLine(absorber.Text);
            }
        }
    }
}
