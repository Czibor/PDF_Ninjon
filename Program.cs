using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PDF_Ninjon
{
    static class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread]
        static void Main(string[] args)
        {
            // If parameters are specified, the program will run without user form
            if (args.Length == 0)
            {
                HideConsoleWindow();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else if (args.Length != 3)
            {
                Console.Error.WriteLine("Please specify the file, the output folder and the page numbers.");
            }
            else
            {
                SplitSettings splitSettings = new SplitSettings();
                splitSettings.InputFile = args[0];
                splitSettings.OutputDirectory = args[1];

                if (args[2].Contains("!"))
	            {
	                splitSettings.MultiOutput = true;
	                string numberString = args[2].Replace("!", "");
	                splitSettings.PageNumbers = splitSettings.GenerateNumberList(numberString);
	            }
	            else
	            {
	                splitSettings.PageNumbers = splitSettings.GenerateNumberList(args[2]);
	            }

	            List<string> errorMessage = Parameters.SearchForErrors(splitSettings);

	            if (errorMessage.Count != 0)
	            {
	            	Console.Error.WriteLine(errorMessage[2]);
	            }
	            else
	            {
	            	if (splitSettings.ChangedPageNumbers != null)
	                {
	                    Console.WriteLine($"The parameter for page numbers has been corrected to this: {Environment.NewLine}{splitSettings.ChangedPageNumbers}");
	                }

                    try
                    {
                        Splitter.SplitPDF(splitSettings);
                        Console.WriteLine("The program ran successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
	            }
            }
        }

        private static void HideConsoleWindow()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, 0);
        }
    }
}