using System;
using System.IO;
using Aspose.Pdf.Examples.CSharp.AsposePDF.Basic;
using Aspose.Pdf.Examples.CSharp.AsposePDF.Convert;
using Aspose.Pdf.Examples.CSharp.AsposePDF.GetStarted;

namespace Aspose.Pdf.Examples.CSharp;

public static class Examples
{
    public static void Main()
    {
        Console.WriteLine("Open Examples.cs.");
        Console.WriteLine("In Main() method uncomment the example that you want to run.");
        Console.WriteLine("=====================================================");
        //Uncomment the one you want to try out

        //=====================================================
        //=====================================================
        //Aspose.Pdf
        //=====================================================
        //=====================================================

        //GetStarted.RunExamples();
        //Basic.RunExamples();
        //PdfToWord.RunExamples();
        //PdfToExcel.RunExamples();
        //PdfToPowerPoint.RunExamples();
        HtmlToPdf.RunExamples();

        //QuickStart
        //=====================================================
        //HelloWorld.Run();
        //LoadLicenseFromFile.Run();
        //LoadLicenseFromStreamObject.Run();
        //SetLicenseUsingEmbeddedResource.Run();

        #region Annotations
        // =====================================================
        //AddAnnotation.Run();
        //AddLinkAnnotation.Run();
        //AddSwfFileAsAnnotation.Run();
        //DeleteAllAnnotationsFromPage.Run();
        //DeleteParticularAnnotation.Run();
        //ExtractHighlightedText.Run();
        //GetAllAnnotationsFromPage.Run();
        //GetParticularAnnotation.Run();
        //GetResourceOfAnnotation.Run();
        //InvisibleAnnotation.Run();
        //LnkAnnotationLineWidth.Run();
        //SetCalloutProperty.Run();
        //SetCalloutProperty.SetCalloutPropertyXFDF();
        //SetFreeTextAnnotationFormatting.Run();
        //StrikeOutWords.Run();
        #endregion

        #region Attachments
        // Attachments
        // =====================================================
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Attachments.AddAttachment.Run();
        //DisableFilesCompression.Run();
        //GetAllTheAttachments.Run();
        //GetAttachmentInfo.Run();
        //GetIndividualAttachment.Run();
        #endregion

        #region Bookmarks
        // =====================================================
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Bookmarks.AddBookmark.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Bookmarks.AddChildBookmark.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Bookmarks.DeleteAllBookmarks.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Bookmarks.DeleteParticularBookmark.Run();
        //ExpandBookmarks.Run();
        //GetBookmarks.Run();
        //GetChildBookmarks.Run();
        //InheritZoom.Run();
        //UpdateBookmarks.Run();
        //UpdateChildBookmarks.Run();
        //ExpandBookmarks.Run();
        #endregion

        #region  Document Conversion
        // =====================================================
        //AddAttachmentToPDFA.Run();
        //CGMToPDF.Run();
        //EPUBToPDF.Run();
        //GetSVGDimensions.Run();
        //HTMLToPDF.RenderContentToSamePage();
        //HTMLToPDF.RenderHTMLwithSVGData();
        //HTMLToPDF.Run();
        //MarkdownToPDF.Run();
        //MHTToPDF.Run();
        //PageOrientationAccordingImageDimensions.Run();
        //PCLToPDF.PCLstream(); //TODO: Fix
        //PCLToPDF.Run();
        //PDFAToPDF.Run();
        //PDFToDOC.Run();
        //PDFToEPUB.Run();
        //PDFToHTML.CreatingHtmlWithFullContentWidth();
        //PDFToHTML.CenterAlignText();
        //PDFToHTML.ExcludeFontResources();
        //PDFToHTML.LayersRendering();
        //PDFToHTML.Run();
        //PDFToPDFA.Run();
        //PDFToPDFA3b.Run();
        //PDFToPNGFontHinting.Run();
        //PDFToPPT.PDFtoPPTXWithSlidesAsImages();
        //PDFToPPT.PDFtoPTTXWithProgressTracking();
        //PDFToPPT.Run();
        //PDFToSVG.Run();
        //PDFToTeX.Run();
        //PDFToXLS.PDFtoXLSX();
        //PDFToXLS.Run();
        //PDFToXML.Run();
        //PDFToXPS.Run();
        //PostscriptToPDF.Run();
        //RemoveHyperlinksAfterConvertingFromHtml.Run();
        //SetDefaultFontName.Run();
        //SVGToPDF.Run();
        //TextToPDF.Run();
        //TIFFtoPDFPerformanceImprovement.Run();
        //XMLToPDF.Run();
        //XMLToPDFSetImagePath.Run();
        #endregion

        #region Forms
        // =====================================================
        //AddTooltipToField.Run();
        //ArabicTextFilling.Run();
        //ComboBox.Run();
        //DeleteFormField.Run();
        //DetermineRequiredField.Run();
        //DynamicXFAToAcroForm.Run();
        //FillFormField.Run();
        //FillXFAFields.Run();
        //FlattenForms.Run();
        //FormFieldFont14.Run();
        //GetFieldsFromRegion.Run();
        //GetValueFromField.Run();
        //GetValueFromField.Run();
        //GetXFAProperties.Run();
        //GroupedCheckBoxes.Run();
        //HorizontallyAndVerticallyRadioButtons.Run();
        //ModifyFormField.Run();
        //MoveFormField.Run();
        //RadioButtonWithOptions.Run();
        //RetrieveFormFieldInTabOrder.Run();
        //SelectRadioButton.Run();
        //SetFieldLimit.Run();
        //SetJavaScript.Run();
        //SetRadioButtonCaption.Run();
        //TextBox.Run();
        #endregion

        #region Graphs
        // =====================================================
        //AddDrawing.Run();
        //AddDrawingWithGradientFill.Run();
        //AddLineObject.Run();
        //ControlRectangleZOrder.Run();
        //CreateFilledRectangle.Run();
        //CreateRectangleWithAlphaColor.Run();
        //DashLength.Run();
        //DrawingLine.Run();
        #endregion

        #region Headings
        // =====================================================
        //ApplyNumberStyle.Run();
        #endregion

        #region Images
        // =====================================================
        //AllPagesToTIFF.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Images.ExtractImages.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Images.ReplaceImage.Run();
        //AsposePDF.Images.AddImage.AddDicomImage();
        //BradleyAlgorithm.Run();
        //CGMImageToPDF.Run();
        //ConvertAllPagesToEMF.Run();
        //ConvertAllPagesToPNG.Run();
        //ConvertImageStreamToPDF.Run();
        //ConvertPageRegionToDOM.Run();
        //ConvertToBMP.Run();
        //DeleteImages.Run();
        //FastShrinkImages.Run();
        //IdentifyImages.Run();
        //ImageToPDF.Run();
        //LargeCGMImageToPDF.Run();
        //PagesToImages.Run();
        //PageToEMF.Run();
        //PageToTIFF.Run();
        //ResizeImages.Run();
        //SetImageSize.Run();
        //ShrinkImages.Run();
        //StoreImageInXImageCollection.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Images.AddImage.Run();
        #endregion

        #region Links-Actions
        // =====================================================
        //AddHyperlink.Run();
        //CreateApplicationLink.Run();
        //CreateDocumentLink.Run();
        //CreateLocalHyperlink.Run();
        //ExtractLinks.Run();
        //GetHyperlinkDestinations.Run();
        //GetHyperlinkText.Run();
        //RemoveOpenAction.Run();
        //SetDestinationLink.Run();
        //SpecifyPageWhenViewing.Run();
        //UpdateLinks.Run();
        //UpdateLinkTextColor.Run();
        #endregion

        #region Miscellaneous
        // =====================================================
        //GetBuildInformation.Run();
        //UseMeasureWithLineAnnotation.Run();
        //UseMeasureWithPolylineAnnotation.Run();
        #endregion

        #region Operators
        // =====================================================
        //DrawXFormOnPage.Run();
        //PDFOperators.Run();
        //RemoveGraphicsObjects.Run();// TODO: Fix
        #endregion

        #region Pages
        // =====================================================
        //ChangeOrientation.Run();
        //ConcatenatePdfFiles.Run();
        //DeleteParticularPage.Run();
        //DeterminePageColor.Run();
        //GetDimensions.Run();
        //GetNumberOfPages.Run();
        //GetPageCount.Run();
        //GetParticularPage.Run();
        //GetProperties.Run();
        //ImageAsBackground.Run();
        //InsertEmptyPage.Run();
        //InsertEmptyPageAtEnd.Run();
        //SplitToPages.Run();
        //UpdateDimensions.Run();
        //ZoomToPageContents.Run();
        #endregion

        #region Security -Signatures
        // =====================================================
        //ChangePassword.Run();
        //Decrypt.Run();
        //DetermineCorrectPassword.Run();
        //Encrypt.Run();
        //ExtractingImage.Run();
        //IsPasswordProtected.Run();
        //SetPrivileges.Run();
        //SignWithSmartCardUsingPdfFileSignature.Run();
        //SignWithSmartCardUsingSignatureField.Run();
        #endregion

        #region Stamps-Watermarks
        // =====================================================
        //AddDateTimeStamp.Run();
        //AddImageStamp.AddImageStampAsBackgroundInFloatingBox();
        //AddImageStamp.Run();
        //AddingDifferentHeaders.Run();
        //AddPDFPageStamp.Run();
        //AddTextStamp.Run();
        //DefineAlignment.Run();
        //ExtractTextFromStampAnnotation.Run(); //TODO
        //FillStrokeText.Run();
        //ImageAndPageNumberinHeaderFooterSection.Run();
        //ImageandPageNumberinHeaderFooterSectionInline.Run();
        //ImageInFooter.Run();
        //ImageInHeader.Run();
        //PageNumberingHeaderFooterUsingFloatingBox.Run();
        //PageNumberStamps.Run();
        //TableInHeaderFooterSection.Run();
        //TextInFooter.Run();
        //TextInHeader.Run();
        #endregion

        #region Tables
        // =====================================================
        //AddImageInATableCell.Run();
        //AddRepeatingColumn.Run();
        //AddSVGObject.Run();
        //AddTable.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Tables.IntegrateWithDatabase.Run();
        //AutoFitToWindow.Run();
        //DetermineTableBreak.Run();
        //ExportExcelWorksheetDataToTable.Run();
        //ExtractBorder.Run();
        //GetTableWidth.Run();
        //HTMLTagsInsideTable.Run();
        //InsertPageBreak.Run();
        //MarginsOrPadding.Run();
        //RemoveMultipleTables.Run();
        //RemoveTable.Run();
        //RenderTable.Run();
        //ReplaceTable.Run();
        //SetBorder.Run();
        //TextAlignmentForTableRowContent.Run();
        #endregion

        #region TechnicalArticles
        // =====================================================
        //CreatePDFPortfolio.Run();
        //ExtractFilesFromPortfolio.Run();
        //RemoveFilesFromPortfolio.Run();
        #endregion

        #region Text
        // =====================================================
        //AddHTMLOrderedListIntoDocuments.Run();
        //AddHTMLUsingDOM.HTMLFragmentRectangle();
        //AddHTMLUsingDOM.Run();
        //AddHTMLUsingDOMAndOverwrite.Run();
        //AddSubsequentLinesIndent.Run();
        //AddTextBorder.Run();
        //AddTooltipToText.Run();
        //AddTransparentText.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Text.AddText.Run();
        //AsposePDF.Text.CustomTabStops.Run();
        //CreateMultiColumnPdf.Run();
        //EmbedStandardType1Fonts.Run();
        //ExtractColumnsText.Run();
        //ExtractParagraphs.Run();
        //ExtractParagraphsByDrawingBorder.Run();
        //ExtractTextUsingTextDevice.Run();
        //FootAndEndNotes.Run();
        //HiddenTextBlock.Run();
        //HighlightCharacterInPDF.Run();
        //PlacingTextAroundImage.Run();
        //RearrangeContentsUsingTextReplacement.Run();
        //RenderingReplaceableSymbols.Run();
        //ReplaceableSymbolsInHeaderFooter.Run();
        //ReplaceFirstOccurrence.Run();
        //ReplaceFonts.Run();
        //ReplaceTextAll.Run();
        //ReplaceTextOnRegularExpression.Run();
        //SearchAndGetTextAll.Run();
        //SearchAndGetTextPage.Run();
        //SearchRegularExpression.Run();
        //SearchTextAndAddHyperlink.Run();
        //SearchTextAndDrawRectangle.Run();
        //SearchTextSegmentsPage.Run();
        //SearchTextWithDotNetRegex.Run();
        //SetHTMLStringFormatting.Run();
        //SpecifyCharacterSpacing.Run();
        //SpecifyLineSpacing.Run();
        //TextAndImageAsParagraph.Run();
        //UseLatexScript.Run();
        //UseLatexScript2.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.Text.ExtractTextPage.Run();
        #endregion

        #region Working-Document
        // =====================================================
        //AddJavaScriptToPage.Run();
        //AddLayers.Run();
        //AddRemoveJavaScriptToDoc.Run();
        //AddTOC.Run();
        //AllowReusePageContent.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.EmbedFont.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.GetFileInfo.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.GetXMPMetadata.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.GetZoomFactor.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.SetFileInfo.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.SetXMPMetadata.Run();
        //Aspose.Pdf.Examples.CSharp.AsposePDF.WorkingDocuments.SetZoomFactor.Run();
        //ConvertFromRGBToGrayscale.Run();
        //CreateMultilayerPDFFirstApproach.Run();
        //CreateMultilayerPDFSecondApproach.Run();
        ////CreatePDFA1WithAsposePdf.Run(); //TODO: Fix
        //CustomizePageNumbersWhileAddingTOC.Run();
        //CreateThumbnailImages.Run();
        //EmbedFontsUsingSubsetStrategy.Run();
        //EmbedFontWhileDocCreation.Run();
        //FlattenAnnotation.Run();
        //GetAllFonts.Run();
        //GetDocumentWindow.Run();
        //GetWarningsForFontSubstitution.Run();
        //HelloWorldPDFUsingXmlAndXslt.Run();
        //HidePageNumbersInTOC.Run();
        //LinkDuplicateStreams.Run();
        //OptimizeDocument.Run();
        //OptimizeFileSize.Run();
        //RemoveUnusedObjects.Run();
        //RemoveUnusedStreams.Run();
        //SetDefaultFont.Run();
        //SetDocumentWindow.Run();
        //SetExpiryDate.Run();
        //SetPresetPropertiesForPrintDialog.Run();
        //SetPresetPropertiesForPrintDialog.SetPrintDlgPropertiesUsingPdfContentEditor();
        //ShrinkDocuments.Run();
        //TrimWhiteSpace.Run();
        //UnembedFonts.Run();
        //ValidatePDFAStandard.Run();
        ////ValidatePDFUAStandard.Run(); //TODO: Fix
        #endregion

        #region Working-with-Tagged PDFs
        // =====================================================
        ////AccessChildrenElements.Run();
        //AddStructureElementIntoElement.Run();
        //CreateNoteStructureElement.Run();
        //CreatePDFWithTaggedImage.Run();
        //CreatePDFWithTaggedText.Run();
        //CreateStructureElements.Run();
        ////CreateStructureElementsTree.Run();//TODO: FIX
        //CreateTableElement.Run();
        //CustomTagName.Run();
        //IllustrationStructureElements.Run();
        //InlineStructureElements.Run();
        //LinkStructureElements.Run();
        //RootStructure.Run();
        //SetupLanguageAndTitle.Run();
        //StructureElementsProperties.Run();
        //StyleTableCell.Run();
        //StyleTableElement.Run();
        //StyleTableRow.Run();
        //StyleTextStructure.Run();
        //TaggedPDFContent.Run();
        //TagImageInExistingPDF.Run();
        //TextBlockStructureElements.Run();
        //TextStructureElements.Run();
        //ValidatePDF.Run();
        #endregion

        #region XML And XLST
        // =====================================================
        //BreakfastMenuUsingXmlAndXslt.Run();
        //HelloWorldPDFUsingXmlAndXslt.Run();
        #endregion

        // Stop before exiting
        Console.WriteLine();
        Console.WriteLine("Program finished.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static string GetDataDir()
    {
        DirectoryInfo parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
        string startDirectory = null;
        if (parent != null)
        {
            DirectoryInfo directoryInfo = parent.Parent;
            if (directoryInfo != null)
                startDirectory = directoryInfo.FullName;
        }
        else
            startDirectory = parent.FullName;
        return Path.Combine(startDirectory, @"Data\");
    }

    public static string GetOutDir()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), "Output");
    }

    public static string GetDataDir_AsposePdf_GetStarted()
    {
        return Path.GetFullPath(Path.Combine(GetDataDir(), "AsposePDF", "GetStarted"));
    }

    public static string GetDataDir_AsposePdf_Basic()
    {
        return Path.GetFullPath(Path.Combine(GetDataDir(), "AsposePDF", "Basic"));
    }

    public static string GetDataDir_AsposePdf_TechnicalArticles()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Technical-Articles/");
    }
    public static string GetDataDir_AsposePdfFacades_TechnicalArticles()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Technical-Articles/");
    }
    public static string GetDataDir_AsposePdf_DocumentConversion_PDFToHTMLFormat()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/DocumentConversion/PDFToHTMLFormat/");
    }
    public static string GetDataDir_AsposePdf_Annotations()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Annotations/");
    }
    public static string GetDataDir_AsposePdf_Graphs()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Graphs/");
    }
    public static string GetDataDir_AsposePdf_Headings()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Headings/");
    }
    public static string GetDataDir_AsposePdf_Miscellaneous()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Miscellaneous/");
    }
    public static string GetDataDir_AsposePdf_Attachments()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Attachments/");
    }
    public static string GetDataDir_AsposePdf_Bookmarks()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Bookmarks/");
    }
    public static string GetDataDir_AsposePdf_DocumentConversion()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/DocumentConversion/");
    }
    public static string GetDataDir_AsposePdf_Forms()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Forms/");
    }
    public static string GetDataDir_AsposePdf_Images()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Images/");
    }
    public static string GetDataDir_AsposePdf_LinksActions()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Links-Actions/");
    }
    public static string GetDataDir_AsposePdf_Operators()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Operators/");
    }
    public static string GetDataDir_AsposePdf_Pages()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Pages/");
    }
    public static string GetDataDir_AsposePdf_SecuritySignatures()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Security-Signatures/");
    }
    public static string GetDataDir_AsposePdf_QuickStart()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/QuickStart/");
    }
    public static string GetDataDir_AsposePdf_StampsWatermarks()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Stamps-Watermarks/");
    }
    public static string GetDataDir_AsposePdf_Tables()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Tables/");
    }
    public static string GetDataDir_AsposePdf_Text()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Text/");
    }
    public static string GetDataDir_AsposePdf_WorkingDocuments()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/Working-Document/");
    }
    public static string GetDataDir_AsposePdfFacades_SecuritySignatures()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Security-Signatures/");
    }
    public static string GetDataDir_AsposePdfFacades_Annotations()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Annotations/");
    }
    public static string GetDataDir_AsposePdfFacades_Attachments()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Attachments/");
    }
    public static string GetDataDir_AsposePdfFacades_Bookmarks()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Bookmarks/");
    }
    public static string GetDataDir_AsposePdfFacades_LinksActions()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Links-Actions/");
    }
    public static string GetDataDir_AsposePdfFacades_Forms()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Forms/");
    }
    public static string GetDataDir_AsposePdfFacades_Images()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Images/");
    }
    public static string GetDataDir_AsposePdfFacades_StampsWatermarks()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Stamps-Watermarks/");
    }
    public static string GetDataDir_AsposePdfFacades_Printing()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Printing/");
    }
    public static string GetDataDir_AsposePdfFacades_Text()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Text/");
    }
    public static string GetDataDir_AsposePdfFacades_WorkingDocuments()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Working-Document/");
    }
    public static string GetDataDir_AsposePdfFacades_Pages()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Pages/");
    }

    public static string GetDataDir_AsposePdf_DocumentCompare()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/DocumentCompare/");
    }

    public static string GetDataDir_AsposePdfFacades_Concatenate()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Concatenate/");
    }

    public static string GetDataDir_AsposePdfFacades_PageBreak()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePdfFacades/Pages/PageBreak/");
    }

    public static string GetDataDir_AsposePdf_AI()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/AI/");
    }

    public static object GetDataDir_AsposePdf_HeaderFooter()
    {
        return Path.GetFullPath(GetDataDir() + "AsposePDF/HeaderFooter/");
    }
}
