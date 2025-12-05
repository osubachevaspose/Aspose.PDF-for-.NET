using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples.CSharp.AsposePDF
{
    public static class Basic
    {
        public static void RunExamples()
        {
            string dataDir = Path.Combine(Examples.GetDataDir(), "AsposePDF", "Basic");
            string outDir = Path.Combine(Examples.GetOutDir(), "AsposePDF", "Basic");
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Running HelloWorld example... ");
            HelloWorld(Path.Combine(outDir, "HelloWorld_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OpenDocument example... ");
            OpenDocument(Path.Combine(dataDir, "input.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OpenDocumentStream example... ");
            //OpenDocumentStream(
            //    "https://www.sj.se/content/dam/SJ/pdf/Engelska/",
            //    "SJPR0033_Folder_Utland_16sid_ENG_web3.pdf");
            OpenDocumentStream(Path.Combine(dataDir, "input.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running OpenDocumentWithPassword example... ");
            OpenDocumentWithPassword(Path.Combine(dataDir, "input.qwerty.pdf"), "qwerty");
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SaveDocument example... ");
            SaveDocument(Path.Combine(dataDir, "input.pdf"),
                Path.Combine(outDir, "SaveDocument_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SaveDocumentStream example... ");
            SaveDocumentStream(Path.Combine(dataDir, "input.pdf"),
                Path.Combine(outDir, "SaveDocumentStream_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SaveDocumentAsPDFx example... ");
            SaveDocumentAsPDFx(Path.Combine(dataDir, "input.pdf"),
                Path.Combine(outDir, "SaveDocumentAsPDFx_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running MergeDocuments example... ");
            MergeDocuments(Path.Combine(dataDir, "merge1.pdf"),
                Path.Combine(dataDir, "merge2.pdf"),
                Path.Combine(outDir, "MergeDocuments_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SplitDocument example... ");
            SplitDocument(Path.Combine(dataDir, "input.pdf"), outDir);
            Console.WriteLine("...finished.");

            Console.WriteLine("Running SetPrivilegesOnExistingPdfFile example... ");
            SetPrivilegesOnExistingPdfFile(Path.Combine(dataDir, "input.pdf"),
                Path.Combine(outDir, "SetPrivileges_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running EncryptPdfFile example... ");
            EncryptPdfFile(Path.Combine(dataDir, "input.pdf"),
                Path.Combine(outDir, "EncryptPdfFile_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running DecryptPdfFile example... ");
            DecryptPdfFile(Path.Combine(dataDir, "input.qwerty.pdf"), "qwerty",
                Path.Combine(outDir, "DecryptPdfFile_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running PubSecEncryption example... ");
            PubSecEncryption(Path.Combine(dataDir, "pub_sec.crt"),
                Path.Combine(dataDir, "pub_sec.pfx"), "12345",
                Path.Combine(outDir, "PubSecEncrypted.pdf"),
                Path.Combine(outDir, "PubSecDecrypted.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running ChangePassword example... ");
            ChangePassword(Path.Combine(dataDir, "input.qwerty.pdf"), "qwerty",
            Path.Combine(outDir, "ChangePassword_out.pdf"));
            Console.WriteLine("...finished.");

            Console.WriteLine("Running DetermineCorrectPasswordFromArray example... ");
            DetermineCorrectPasswordFromArray(Path.Combine(dataDir, "input.qwerty.pdf"));
            Console.WriteLine("...finished.");
        }

        public static void HelloWorld(string outFileName)
        {
            // Create PDF document
            using (Document doc = new Document())
            {
                // Add page
                Page page = doc.Pages.Add();
                // Add text to new page
                page.Paragraphs.Add(new TextFragment("Hello World!"));
                // Save PDF document
                doc.Save(outFileName);
            }
        }

        public static void OpenDocument(string inFileName)
        {
            using (Document doc = new Document(inFileName))
                Console.WriteLine("Pages " + doc.Pages.Count);
        }

        //public static void OpenDocumentStream(string address, string fileName)
        //{
        //    // Create a new WebClient instance
        //    WebClient webClient = new WebClient();
        //    Console.WriteLine("Downloading File \"{0}\" from \"{1}\"...\n", fileName, address);
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        // Concatenate the domain with the Web resource filename
        //        webClient.OpenRead(address + fileName)?.CopyTo(ms);
        //        ms.Position = 0;
        //        using (Document doc = new Document(ms))
        //            Console.WriteLine("Pages " + doc.Pages.Count);
        //    }
        //}

        public static void OpenDocumentStream(string inFileName)
        {
            using (FileStream inputStream = File.OpenRead(inFileName))
            using (Document doc = new Document(inputStream))
                Console.WriteLine("Pages " + doc.Pages.Count);
        }

        public static void OpenDocumentWithPassword(string inFileName, string password)
        {
            try
            {
                using (Document doc = new Document(inFileName, password))
                    Console.WriteLine("Pages " + doc.Pages.Count);
            }
            catch (InvalidPasswordException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void SaveDocument(string inFileName, string outFileName)
        {
            using (Document doc = new Document(inFileName))
            {
                // Make some manipulation, e.g. add new empty page
                doc.Pages.Add();
                doc.Save(outFileName);
            }
        }

        public static void SaveDocumentStream(string inFileName, string outFileName)
        {
            using (Document doc = new Document(inFileName))
            {
                // Make some manipulation, e.g. add new empty page
                doc.Pages.Add();
                using (FileStream outputStream = File.OpenWrite(outFileName))
                    doc.Save(outputStream);
            }
        }

        public static void SaveDocumentAsPDFx(string inFileName, string outFileName)
        {
            using (Document doc = new Document(inFileName))
            {
                doc.Pages.Add();
                // Convert a document to a PDF/X-3 format
                doc.Convert(new PdfFormatConversionOptions(PdfFormat.PDF_X_3));
                doc.Save(outFileName);
            }
        }

        public static void MergeDocuments(string inFileName1, string inFileName2,
            string outFileName)
        {
            using (Document doc1 = new Document(inFileName1))
            using (Document doc2 = new Document(inFileName2))
            {
                // Add pages of second document to the first one
                doc1.Pages.Add(doc2.Pages);
                doc1.Save(outFileName);
            }
        }

        public static void SplitDocument(string inFileName, string outDir)
        {
            string justName = Path.GetFileNameWithoutExtension(inFileName);
            // Open PDF document
            using (Document inDoc = new Document(inFileName))
            {
                int pageNumber = 1;
                // Loop through all the pages
                foreach (Page page in inDoc.Pages)
                {
                    // Create PDF document
                    using (Document outDoc = new Document())
                    {
                        outDoc.Pages.Add(page);
                        outDoc.Save(Path.Combine(outDir, justName + ".page_" + pageNumber + ".pdf"));
                        pageNumber++;
                    }
                }
            }
        }

        public static void SetPrivilegesOnExistingPdfFile(string inFileName, string outFileName)
        {
            // Instantiate Document Privileges object
            // Apply restrictions on all privileges
            DocumentPrivilege documentPrivilege = DocumentPrivilege.ForbidAll;
            // Only allow screen reading
            documentPrivilege.AllowScreenReaders = true;
            using (Document doc = new Document(inFileName))
            {
                // Encrypt the file with User and Owner password
                // The user views the file with User password
                // Only screen reading option is enabled
                doc.Encrypt("user", "owner", documentPrivilege, CryptoAlgorithm.AESx128, false);
                doc.Save(outFileName);
            }
        }

        public static void EncryptPdfFile(string inFileName, string outFileName)
        {
            using (Document doc = new Document(inFileName))
            {
                doc.Encrypt("user", "owner", 0, CryptoAlgorithm.RC4x128);
                doc.Save(outFileName);
            }
        }

        public static void DecryptPdfFile(string inFileName, string pass, string outFileName)
        {
            using (Document doc = new Document(inFileName, pass))
            {
                doc.Decrypt();
                doc.Save(outFileName);
            }
        }

        public static void PubSecEncryption(string pubCert, string pfx, string pfxPass,
            string outputFileNameEncrypted, string outFileName)
        {
            using (Document doc1 = new Document())
            {
                // Add an info 
                doc1.Info.Title = "TestTitle";
                doc1.Info.Author = "TestAuthor";
                // Add a page and add some text
                Page page = doc1.Pages.Add();
                TextFragment text = new TextFragment("Hello World!");
                page.Paragraphs.Add(text);
                // Encrypt the PDF document
                doc1.Encrypt(Permissions.PrintDocument, CryptoAlgorithm.RC4x128,
                    new List<System.Security.Cryptography.X509Certificates.X509Certificate2>
                    {
                        new System.Security.Cryptography.X509Certificates.X509Certificate2(pubCert)
                    }
                );
                // Save the PDF document.
                // A private key certificate must be installed in the storage to open the document by Adobe Acrobat.
                doc1.Save(outputFileNameEncrypted);
            }
            // Open the encrypted PDF document.
            // You can use the alternative CertificateEncryptionOptions constructor to use the private key certificate from the storage.
            using (Document doc2 = new Document(outputFileNameEncrypted,
                       new Security.CertificateEncryptionOptions(pubCert, pfx, pfxPass)))
            {
                Console.WriteLine(doc2.Info.Title);
                Console.WriteLine(doc2.Info.Author);
                // Find the text fragment        
                TextAbsorber textAbsorber = new TextAbsorber();
                doc2.Pages[1].Accept(textAbsorber);
                Console.WriteLine(textAbsorber.Text);
                // Decrypt the PDF document if you need
                doc2.Decrypt();
                doc2.Save(outFileName);
            }
        }

        public static void ChangePassword(string inFileName, string ownPass, string outFileName)
        {
            using (Document doc = new Document(inFileName, ownPass))
            {
                doc.ChangePasswords(ownPass, "newuser", "newowner");
                doc.Save(outFileName);
            }
        }

        public static void DetermineCorrectPasswordFromArray(string inFileName)
        {
            using (PdfFileInfo fileInfo = new PdfFileInfo())
            {
                // Bind PDF document
                fileInfo.BindPdf(inFileName);
                // Determine if the source PDF is encrypted
                Console.WriteLine("File is password protected: " + fileInfo.IsEncrypted);
            }
            string[] passwords = { "test", "test1", "test2", "test3", "qwerty", "sample" };
            foreach (string pass in passwords)
                try
                {
                    using (Document doc = new Document(inFileName, pass))
                        if (doc.Pages.Count > 0)
                            Console.WriteLine("Number of pages in document is: " + doc.Pages.Count);
                }
                catch (InvalidPasswordException)
                {
                    Console.WriteLine("Password \"" + pass + "\" is not correct");
                }
        }
    }
}
