using System;
using System.Drawing;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace PaintModelUtilities{
    public static class Utilities{
        public static double[] getColor(string codColor){
            //Dictionary to translate Sazi colors to RGB colors
            /*Dictionary<string, double[]> colors = new Dictionary<string, double[]>();
            colors.Add("84351", [255.0, 255.0, 255.0]);//White powder
            colors.Add("57459", [85.0, 85.0, 85.0]);//Grey powder
            colors.Add("98606", [255.0, 255.0, 0.0]);//Yellow powder
            colors.Add("2042", [71.0, 113.0, 255.0]);//Blue powder
            colors.Add("2071", [55.0, 55.0, 55.0]);//Black powder*/

            Dictionary<string, double[]> colors = new Dictionary<string, double[]>{
                {"84351", [254, 254, 254]},//White powder
                {"57459", [85, 85, 85]},//Grey powder
                {"98606", [255, 255, 0]},//Yellow powder
                {"2042", [71, 113, 255]},//Blue powder
                {"2071", [55, 55, 55]}//Black powder
            };


            Console.WriteLine($"Color getted: {codColor} = Color painted: {colors[codColor][0]}, {colors[codColor][1]}, {colors[codColor][2]}");

            return colors[codColor];
        }
    }
}