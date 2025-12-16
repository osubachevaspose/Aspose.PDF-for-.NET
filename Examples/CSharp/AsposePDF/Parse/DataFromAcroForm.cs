using System;
using System.IO;
using System.Linq;
using Aspose.Pdf.Facades;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF.Parse;

public static class DataFromAcroForm
{
    //https://docs.aspose.com/pdf/net/extract-data-from-acroform/

    public static void RunExamples()
    {
        string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Parse", "DataFromAcroForm");
        string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Parse", "DataFromAcroForm");
        Directory.CreateDirectory(outDir);

        //Console.WriteLine("Running ExtractFormFields example...");
        //ExtractFormFields(Path.Combine(dataDir, "StudentInfoFormElectronic.pdf"));
        //Console.WriteLine("...finished.");

        //Console.WriteLine("Running ExtractFormFieldsToJson example...");
        //ExtractFormFieldsToJson(Path.Combine(dataDir, "StudentInfoFormElectronic.pdf"));
        //Console.WriteLine("...finished.");

        Console.WriteLine("Running ExportFormDataToXml example...");
        ExportFormDataToXml(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "input.xml"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExportDataToFDF example...");
        ExportDataToFDF(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "ExportDataToFDF.pdf"));
        Console.WriteLine("...finished.");

        Console.WriteLine("Running ExportDataToXFDF example...");
        ExportDataToXFDF(Path.Combine(dataDir, "input.pdf"),
            Path.Combine(outDir, "ExportDataToXFDF.pdf"));
        Console.WriteLine("...finished.");
    }

    public static void ExtractFormFields(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Get values from all fields
            foreach (Forms.Field formField in doc.Form)
            {
                Console.WriteLine("Field Name: {0}", formField.PartialName);
                Console.WriteLine("Value: {0}", formField.Value);
            }
        }
    }

    public static void ExtractFormFieldsToJson(string inFileName)
    {
        using (Document doc = new Document(inFileName))
        {
            // Extract form fields and convert to JSON
            var formData = doc.Form.Cast<Forms.Field>().Select(f => new { Name = f.PartialName, f.Value });
            string jsonString = System.Text.Json.JsonSerializer.Serialize(formData);
            // Output the JSON string
            Console.WriteLine(jsonString);
        }
    }

    public static void ExportFormDataToXml(string inFileName, string outFileName)
    {
        using (Form form = new Form())
        {
            // Bind PDF document
            form.BindPdf(inFileName);
            using (FileStream xmlStream = File.OpenWrite(outFileName))
            {
                form.ExportXml(xmlStream);
            }
        }
    }

    public static void ExportDataToFDF(string inFileName, string outFileName)
    {
        using (Form form = new Form())
        {
            // Bind PDF document
            form.BindPdf(inFileName);
            using (FileStream fdfStream = File.OpenWrite(Path.Combine(Path.GetDirectoryName(outFileName), "student.fdf")))
            {
                form.ExportFdf(fdfStream);
            }
            form.Save(outFileName);
        }
    }

    public static void ExportDataToXFDF(string inFileName, string outFileName)
    {
        using (Form form = new Form())
        {
            // Bind PDF document
            form.BindPdf(inFileName);
            using (FileStream xfdfStream = File.OpenWrite(Path.Combine(Path.GetDirectoryName(outFileName), "student.xfdf")))
            {
                form.ExportXfdf(xfdfStream);
            }
            form.Save(outFileName);
        }
    }
}
