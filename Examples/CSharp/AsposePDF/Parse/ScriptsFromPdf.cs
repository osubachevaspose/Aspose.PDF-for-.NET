using System;
using System.IO;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class ScriptsFromPdf
{
    //https://docs.aspose.com/pdf/net/extract-superscripts-subscripts-from-pdf/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "ScriptsFromPdf");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "ScriptsFromPdf");
        Directory.CreateDirectory(outDir);

        Console.WriteLine("Running ExtractSuperScriptsAndSubScripts example...");
        ExtractSuperScriptsAndSubScripts(Path.Combine(dataDir, "TextWithSubscriptsSuperscripts.pdf"),
            Path.Combine(outDir, "SuperScriptExample.txt"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExtractSuperScriptsAndSubScriptsWithTextFragments example...");
        ExtractSuperScriptsAndSubScriptsWithTextFragments(Path.Combine(dataDir, "TextWithSubscriptsSuperscripts.pdf"),
            Path.Combine(outDir, "SuperScriptExample_TextFragment.txt"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractSuperScriptsAndSubScripts(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            TextFragmentAbsorber absorber = new TextFragmentAbsorber();
            doc.Pages[1].Accept(absorber);
            File.WriteAllText(outFileName, absorber.Text);
        }
    }

    public static void ExtractSuperScriptsAndSubScriptsWithTextFragments(string inFileName, string outFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            TextFragmentAbsorber absorber = new TextFragmentAbsorber();
            doc.Pages[1].Accept(absorber);
            using (StreamWriter writer = new StreamWriter(outFileName))
            {
                foreach (TextFragment textFragment in absorber.TextFragments)
                {
                    // Write the extracted text in text file
                    writer.Write(textFragment.Text);
                }

            }
        }
    }
}
