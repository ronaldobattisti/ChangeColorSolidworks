using System;
using System.Drawing;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using PaintModelUtilities;



namespace SolidWorksAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize SolidWorks application
            SldWorks swApp = new SldWorks();

            if (swApp != null)
            {


                swApp.Visible = true;
                Console.WriteLine("SolidWorks opened successfully.");

                // Define file path and document type
                Console.WriteLine("Inputh the code: ");
                /*string code = Console.ReadLine();
                string filePath = @"M:\003-MÁQUINAS\PEÇAS DE MÁQUINAS\" + code + ".SLDASM";*/
                string filePath = @"M:\003-MÁQUINAS\PEÇAS DE MÁQUINAS\384513.SLDPRT";
                Console.WriteLine(filePath);
                int documentType = (int)swDocumentTypes_e.swDocPART;
                int openOptions = (int)swOpenDocOptions_e.swOpenDocOptions_Silent;
                string configurationName = "";
                String paintCode = "";

                // Variables to capture errors and warnings
                int errors = 0;
                int warnings = 0;


                ModelDoc2 swModel = swApp.OpenDoc6(
                filePath,
                documentType,
                openOptions,
                configurationName,
                ref errors,
                ref warnings);

                // Get the custom property manager for the part
                CustomPropertyManager cusPropMgr = swModel.Extension.CustomPropertyManager[""];

                string[] propertyNames = (string[])cusPropMgr.GetNames();
                if (propertyNames != null){
                //For each property write its value
                foreach (string propertyName in propertyNames)
                    {
                        string propertyValue;
                        string propertyResolvedValue;
                        bool wasResolved;
                        cusPropMgr.Get5(propertyName, false, out propertyValue, out propertyResolvedValue, out wasResolved);
                        /*Console.WriteLine($"Property: {propertyName}");
                        Console.WriteLine($"Value: {propertyValue}");
                        Console.WriteLine($"Resolved Value: {propertyResolvedValue}");
                        Console.WriteLine($"Resolved: {wasResolved}\n");*/
                        if (propertyName.ToUpper() == "TRATAMENTO_SUPERFICIAL"){
                            paintCode = propertyResolvedValue.Split("-")[0];
                            Console.WriteLine($"Cor: {paintCode}");
                        }
                    }
                }
                Console.Write("Start delay\n");
                Thread.Sleep(1000);
                Console.Write("End delay\n");
                
                Console.WriteLine("Changing color");
                //double[] color = [67, 0, 2];
                double[] color = Utilities.getColor(paintCode);
                swModel.MaterialPropertyValues = color;
                Console.WriteLine("Color changed");
                swModel.EditRebuild3();

            }
            else
            {
                Console.WriteLine("Failed to open SolidWorks.");
            }

            // Keep the console window open
            /*Console.WriteLine("Press any key to exit.");
            Console.ReadKey();*/
        }
    }
}
