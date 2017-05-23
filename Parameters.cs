using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using iTextSharp.text.pdf;

namespace PDF_Ninjon
{
    public class SplitSettings
    {
        string _inputFile;
        string _outputDirectory;

        public string InputFile
        {
            get
            {
                return _inputFile;
            }
            set
            {
                if (ValidateInputFile(value))
                {
                    _inputFile = value;
                    PdfName = Path.GetFileNameWithoutExtension(value);
                }
            }
        }

        public string OutputDirectory
        {
            get
            {
                return _outputDirectory;
            }
            set
            {
            	if (ValidateOutputDirectory(value))
                {
                    _outputDirectory = value;
                }
            }
        }

        public List<int> PageNumbers { get; set; }
        public bool MultiOutput { get; set; } = false;
        public bool FileExists { get; private set; } = false;
        public string PdfName { get; set; }
        public int PdfLastPage { get; private set; }
        public string ChangedPageNumbers { get; set; }

        /// <summary>
        /// Testing file by getting its last page number. PdfLastPage property is also set.
        /// </summary>
        private bool ValidateInputFile(string inputFile)
        {
        	if (File.Exists(inputFile))
        	{
        		FileExists = true;
            	PdfLastPage = Parameters.NumberOfPages(inputFile);
        	}

            return (PdfLastPage != 0);
        }

        /// <summary>
        /// Tries to create the given directory.
        /// </summary>
        private bool ValidateOutputDirectory(string outputDirectory)
        {
            try
            {
                if (Directory.Exists(outputDirectory))
                {
                    return true;
                }
                else if (outputDirectory == Path.GetFullPath(outputDirectory))
                {
                	Directory.CreateDirectory(outputDirectory);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<int> GenerateNumberList(string numberStr)
        {
            numberStr = numberStr.Replace(" ", "");
            int originalLength = numberStr.Length;
            List<int> numberList = new List<int>();

            if (Parameters.regexTest(numberStr, @"^[0-9,\-]+$") && numberStr.Any(char.IsDigit))
            {
                numberStr = Parameters.RemoveUnnecessaryChars(numberStr, ",-");

                if (numberStr.Length != originalLength)
                {
                    ChangedPageNumbers = numberStr;
                }
            }
            else
            {
                return numberList;
            }

            try
            {
            	int tni = int.Parse(numberStr);

            	if (tni > PdfLastPage)
            	{
            		numberList.Add(PdfLastPage + 1);
            		return numberList;
            	}
            	else
            	{
            		numberList.Add(tni);
            		return numberList;
            	}
            }
            catch
            {
            	return Parameters.ConvertStringToIntList(numberStr, PdfLastPage, MultiOutput);
            }
        }
    }

    public static class Parameters
    {
        public static bool regexTest(string inputString, string regExp)
        {
            Regex r = new Regex(regExp);
            return (r.IsMatch(inputString));
        }

        public static string RemoveUnnecessaryChars(string numberStr, string charsToRemove)
        {
            foreach (char charToRemove in charsToRemove)
            {
                numberStr = CharBetweenNumbers(numberStr, charToRemove);
            }

            return numberStr;
        }

        static string CharBetweenNumbers(string inputString, char testedChar)
        {
            bool wasNumber = false;

            for (int i = inputString.Length - 1; i >= 0; --i)
            {
            	if (inputString[i] == testedChar)
            	{
            		if (i == 0 || i == inputString.Length - 1)
            		{
            			inputString = inputString.Remove(i, 1);
            		}
            		else if (!(char.IsDigit(inputString[i - 1])))
            		{
            			inputString = inputString.Remove(i, 1);
            		}
            		else if (!wasNumber)
            		{
            			inputString = inputString.Remove(i, 1);
            		}
            	}
            	else if (!wasNumber)
            	{
            		if (char.IsDigit(inputString[i]))
            		{
            			wasNumber = true;
            		}
            	}
            }

            return inputString;
        }

        public static List<int> ConvertStringToIntList(string numberStr, int maxNumber, bool multiOutput, char separator = ',', char connector = '-')
        {
            List<int> numberList = new List<int>();
            string[] separatedStringArray = numberStr.Split(separator);

            foreach (string element in separatedStringArray)
            {
            	if (element.Contains(char.ToString(connector)))
                {
            		if (element.Replace("-", "").Length + 1 < element.Length)
            		{
                    	List<int> reduntantHypen = new List<int>();
                    	reduntantHypen.Add(-1);
                    	return reduntantHypen;
            		}
            		
            		int hyphenPosition = element.IndexOf(connector) + 1;
                    int firstNumber = int.Parse(element.Substring(0, hyphenPosition - 1));
                    int secondNumber = int.Parse(element.Substring(hyphenPosition, element.Length - hyphenPosition));

                    if (firstNumber < secondNumber)
                    {
                        for (int i = firstNumber; i <= secondNumber; ++i)
                        {
                        	if ((i <= maxNumber || multiOutput) && i != 0)
                            {
                                numberList.Add(i);
                            }
                        }
                    }
                    else
                    {
                        return new List<int>();
                    }
                }
                else
                {
                	int tni = int.Parse(element);

                	if ((tni <= maxNumber || multiOutput) && tni != 0)
                    {
                        numberList.Add(tni);
                    }
                }
            }

            numberList.Sort();
            numberList = numberList.Distinct().ToList();
            return numberList;
        }

        public static int NumberOfPages(string fileName)
        {
            try
            {
                PdfReader reader = new PdfReader(fileName);
                return reader.NumberOfPages;
            }
            catch
            {
                return 0;
            }
        }

        public static List<string> SearchForErrors(SplitSettings splitSettings)
        {
        	List<string> errorMessage = new List<string>();

        	if (splitSettings.InputFile == null)
            {
        		if (splitSettings.FileExists)
        		{
        			errorMessage.Add("The given file is not a valid PDF.");
                	errorMessage.Add("Wrong file");
                	errorMessage.Add("The given file (1st parameter) is not a valid PDF.");
        		}
        		else
        		{
        			errorMessage.Add("The given file can't be found.");
                	errorMessage.Add("Wrong file");
                	errorMessage.Add("The given file (1st parameter) can't be found.");
        		}
            }
            else if (splitSettings.OutputDirectory == null)
            {
            	errorMessage.Add("The folder can't be reached or created.");
            	errorMessage.Add("Invalid path");
            	errorMessage.Add("The folder (2nd parameter) can't be reached or created.");
            }
            else if (splitSettings.PageNumbers.Count == 0)
            {
            	if (splitSettings.MultiOutput)
            	{
            		errorMessage.Add($"Please give a natural number {Environment.NewLine}to specify the amount of pages you need in one file.");
            		errorMessage.Add("Wrong page number");
            		errorMessage.Add("Please give a number larger than 0 to specify the amount of pages you need in one file.");
            	}
            	else
            	{
            		errorMessage.Add($"Use numbers (mandatory), commas, hyphens or spaces {Environment.NewLine}to specify page numbers (e.g. \"1-5, 7\").");
            		errorMessage.Add("Wrong page numbers");
            		errorMessage.Add("Please use numbers (mandatory), commas, hyphens or spaces to specify page numbers (3rd parameter, e.g. \"1-5, 7\").");
            	}
            }
            else if (splitSettings.PageNumbers[0] == -1)
            {
            	errorMessage.Add("Please remove the redundant hyphen(s) from page numbers.");
            	errorMessage.Add("Wrong page numbers");
            	errorMessage.Add("Please remove the redundant hyphen(s) from page numbers (3rd parameter).");
            }
            else if (splitSettings.PageNumbers.Count > 1 && splitSettings.MultiOutput)
            {
            	errorMessage.Add("Won't happen in GUI mode.");
            	errorMessage.Add("");
            	errorMessage.Add("If you include '!' to page numbers, you can only have one number (e.g. \"12!\")");
            }
            else if (splitSettings.PageNumbers[0] == splitSettings.PdfLastPage + 1)
            {
            	errorMessage.Add($"The file has only {splitSettings.PdfLastPage} pages. Please give a smaller number.");
            	errorMessage.Add("Page does not exist");
            	errorMessage.Add($"The file has only {splitSettings.PdfLastPage} pages. Please give a smaller number (3rd parameter).");
            }

            return errorMessage;
        }
    }
}