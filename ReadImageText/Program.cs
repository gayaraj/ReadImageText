using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadImageText
{
    class Program
    {
        static void Main(string[] args)
        {
            String ImagePath = AppDomain.CurrentDomain.BaseDirectory + "SampleImage.bmp";

            ReadTextFromImage(ImagePath);

            // Set Store Image Content text file Path
            String StoreTextFilePath = AppDomain.CurrentDomain.BaseDirectory + "SampleText.txt";

            ReadTextFromImage(ImagePath, StoreTextFilePath);
        }
        private static void ReadTextFromImage(String ImagePath)
        {
            try
            {
                // Grab Text From Image
                MODI.Document ModiObj = new MODI.Document();
                ModiObj.Create(ImagePath);
                ModiObj.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);

                //Retrieve the text gathered from the image
                MODI.Image ModiImageObj = (MODI.Image)ModiObj.Images[0];

                System.Console.WriteLine(ModiImageObj.Layout.Text);

                ModiObj.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Read Text from Image and Store in Text File
        /// </summary>
        /// <param name="ImagePath">specify the Image Path</param>
        /// <param name="StoreTextFilePath">Specify the Store Text File</param>
        private static void ReadTextFromImage(String ImagePath, String StoreTextFilePath)
        {
            try
            {
                // Grab Text From Image
                MODI.Document ModiObj = new MODI.Document();
                ModiObj.Create(ImagePath);
                ModiObj.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);

                //Retrieve the text gathered from the image
                MODI.Image ModiImageObj = (MODI.Image)ModiObj.Images[0];

                // Store Image Content in Text File
                FileStream CreateFileObj = new FileStream(StoreTextFilePath, FileMode.Create);
                //save the image text in the text file 
                StreamWriter WriteFileObj = new StreamWriter(CreateFileObj);
                WriteFileObj.Write(ModiImageObj.Layout.Text);
                WriteFileObj.Close();

                ModiObj.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

