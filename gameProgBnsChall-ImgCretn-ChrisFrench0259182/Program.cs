using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameProgBnsChall_ImgCretn_ChrisFrench0259182
{
    internal class Program
    {

        static Bitmap bmp = new Bitmap(width, height);
        static int width = 256;
        static int height = 256;

        static void Main(string[] args)
        {


                // Loop through each pixel and set its color
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        // Example: Create a gradient effect
                        int red = (int)((double)x / width * 255);
                        int blue = (int)((double)y / height * 255);
                        int green = 0;

                        Color customColor = Color.FromArgb(red, green, blue);
                       bmp.SetPixel(x, y, customColor);
                    }
                }

                
                //pictureBox.Image = bitmap;
           
            
            string filePath = "output_gradient.png";

            try
            {
                // Save the bitmap to a file (e.g., PNG format)
                bmp.Save(filePath, ImageFormat.Png);
                Console.WriteLine($"Image successfully saved to: {System.IO.Path.GetFullPath(filePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the image: {ex.Message}");
            }
            finally
            {
                // Clean up the bitmap resources
                bmp.Dispose();
            }

            // Keep the console window open
            Console.ReadKey();





        }
        }
    }






