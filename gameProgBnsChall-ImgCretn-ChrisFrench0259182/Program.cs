using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading; 

namespace gameProgBnsChall_ImgCretn_ChrisFrench0259182
{
    internal class Program
    {
       
        static int width = 256;
        static int height = 256;
        static Bitmap bmp = new Bitmap(width, height);

      
        static void Main(string[] args)
        {
            Console.WriteLine($"Creating a {width}x{height} pixel gradient image...");

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int red = (int)((double)x / width * 255);
                    int blue = (int)((double)y / height * 255);
                    int green = 0;

                    Color customColor = Color.FromArgb(red, green, blue);
                    bmp.SetPixel(x,y, customColor);
                    //bmp.SetPixel(1-50,1-50, customColor);
                    //bmp.SetPixel(51-150, 51-60, customColor);
                    //bmp.SetPixel(151-160, 60-75, customColor);
                    //bmp.SetPixel(161-200, 76-100, customColor);
                    //bmp.SetPixel(201-225, 101-200, customColor);
                    //bmp.SetPixel(226-256, 201-256, customColor);

                }
            }

            DisplayImageInConsole(bmp);

           
            string filePath = "output_gradient.png";
            try
            {
                bmp.Save(filePath, ImageFormat.Png);
                Console.WriteLine($"\nImage successfully saved to: {Path.GetFullPath(filePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the image: {ex.Message}");
            }
            finally
            {
                bmp.Dispose();
            }

            Console.WriteLine("Program finished. Press any key to exit.");
            Console.ReadKey();
        }

       
        static void DisplayImageInConsole(Bitmap image)
        {
            Console.WriteLine("\n--- Image Representation in Console ---"); // compensating for char aspect ratio vs pixel
            int consoleWidth = Console.WindowWidth - 1;
            int consoleHeight = Console.WindowHeight - 5; 

         
            using (Bitmap consoleBmp = new Bitmap(image, new Size(consoleWidth, consoleHeight))) // Resize the image to display in console


            {
                for (int y = 0; y < consoleHeight; y++)
                {
                    for (int x = 0; x < consoleWidth; x++)
                    {
                        Color pixelColor = consoleBmp.GetPixel(x, y);
                      
                        ConsoleColor consoleColor = GetNearestConsoleColor(pixelColor);// converts colour to closest console colour
                        Console.ForegroundColor = consoleColor;
                                              Console.Write("@");
                    }
                    Console.Write("\n");
                }
            }
            Console.ResetColor(); // Reset color after printing
        }

        
        static ConsoleColor GetNearestConsoleColor(Color color) // converts colour to closest console colour
        {
            ConsoleColor ret = 0;
            double rr = color.R, gg = color.G, bb = color.B, minDiff = double.MaxValue;
            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                string cName = Enum.GetName(typeof(ConsoleColor), cc);
                Color c = Color.FromName(cName);
                double diff = Math.Pow(c.R - rr, 2) + Math.Pow(c.G - gg, 2) + Math.Pow(c.B - bb, 2);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    ret = cc;
                }
            }
            return ret;
        }
    }
}