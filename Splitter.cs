using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDF_Ninjon
{
    public static class Splitter
    {
        public static void SplitPDF(SplitSettings splitSettings)
        {
            if (splitSettings.MultiOutput == false)
            {
                PdfReader reader = new PdfReader(splitSettings.InputFile);
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                string outputFullName = GetUniqueFileName(splitSettings.OutputDirectory, splitSettings.PdfName, ".pdf");
                splitSettings.PdfName = Path.GetFileName(outputFullName);
                PdfCopy copyProvider = new PdfCopy(document, new FileStream(outputFullName, FileMode.OpenOrCreate));
                document.Open();

                foreach (int pageNumber in splitSettings.PageNumbers)
                {
                    PdfImportedPage pdfPage = copyProvider.GetImportedPage(reader, pageNumber);
                    copyProvider.AddPage(pdfPage);
                }

                document.Close();
            }
            else
            {
            	if (Directory.GetFiles(splitSettings.OutputDirectory, "*.pdf").Length != 0)
                {
                	splitSettings.OutputDirectory = CreateUniqueFolder(splitSettings.OutputDirectory, splitSettings.PdfName);
                }

                int pagesNeeded = splitSettings.PageNumbers[0];
                PdfReader reader = new PdfReader(splitSettings.InputFile);

                for (int i = 1; i <= splitSettings.PdfLastPage; i+= pagesNeeded)
                {
                	string outputFullName = $"{splitSettings.OutputDirectory}\\{splitSettings.PdfName}_{Convert.ToString((i - 1) / pagesNeeded + 1)}.pdf";
                    Document document = new Document(reader.GetPageSizeWithRotation(1));
                    PdfCopy copyProvider = new PdfCopy(document, new FileStream(outputFullName, FileMode.OpenOrCreate));
                    document.Open();

                    for (int n = 0; n < pagesNeeded && i + n <= splitSettings.PdfLastPage; ++n)
	                {
	                    PdfImportedPage pdfPage = copyProvider.GetImportedPage(reader, i + n);
	                    copyProvider.AddPage(pdfPage);
	                }

                    document.Close();
                }
            }
        }

        private static string GetUniqueFileName(string filePath, string fileName, string extension)
        {
        	string pathWithName = Path.Combine(filePath, fileName);
        	string testFileName = $"{pathWithName}{extension}";

        	if (!(File.Exists(testFileName)))
        	{
        		return testFileName;
        	}
        	else
        	{
        		int i = 1;
        		testFileName = $"{pathWithName}_{i}{extension}";

        		while (File.Exists(testFileName))
        		{
        			++i;
        			testFileName = $"{pathWithName}_{i}{extension}";
        		}

        		return testFileName;
        	}
        }

        private static string CreateUniqueFolder(string filePath, string folderName)
        {
            string combinedFolderName = Path.Combine(filePath, folderName);

            if (!(Directory.Exists(combinedFolderName)))
            {
                Directory.CreateDirectory(combinedFolderName);
                return combinedFolderName;
            }
            else
            {
                int i = 1;
                string testFolder = $"{combinedFolderName}_{i}";

                while (Directory.Exists(testFolder))
                {
                    ++i;
                    testFolder = $"{combinedFolderName}_{i}";
                }

                Directory.CreateDirectory(testFolder);
                return testFolder;
            }
        }
    }
}