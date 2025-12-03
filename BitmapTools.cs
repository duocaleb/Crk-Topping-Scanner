using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crk_Topping_Scanner
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal static class BitmapTools
    {
        internal static PrivateFontCollection privateFonts = new();
        internal static FontFamily cookieRunFont;
        static BitmapTools()
        {
            // Load custom font
            privateFonts.AddFontFile(Path.Combine(Application.StartupPath, "CookieRun Black.ttf"));
            cookieRunFont = privateFonts.Families[0];
        }

        //code from switchonthecode, edits pixel's byte to be fast.
        internal static Bitmap PreprocImage(Bitmap original)
        {
            unsafe
            {
                //create an empty bitmap the same size as original
                Bitmap newBitmap = new(original.Width, original.Height);

                //lock the original bitmap in memory
                BitmapData originalData = original.LockBits(
                   new Rectangle(0, 0, original.Width, original.Height),
                   ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                //lock the new bitmap in memory
                BitmapData newData = newBitmap.LockBits(
                   new Rectangle(0, 0, original.Width, original.Height),
                   ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                //set the number of bytes per pixel
                int pixelSize = 3;

                for (int y = 0; y < original.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);

                    for (int x = 0; x < original.Width; x++)
                    {
                        byte pixCol;
                        if ((oRow[x * pixelSize] * .11) +
                           (oRow[x * pixelSize + 1] * .59) +
                           (oRow[x * pixelSize + 2] * .3) >= 200) // Combining grayscale and bounding into one step
                        {
                            pixCol = 255;
                        }
                        else
                        {
                            pixCol = 0;
                        }


                        //set the new image's pixel to the grayscale version
                        nRow[x * pixelSize] = pixCol; //B
                        nRow[x * pixelSize + 1] = pixCol; //G
                        nRow[x * pixelSize + 2] = pixCol; //R
                    }
                }

                //unlock the bitmaps
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);

                return newBitmap;
            }
        }
        
        internal static void AddTextToImage(Image image, string textToAdd, Font font, Brush brush, PointF location)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawString(textToAdd, font, brush, location);
            }
        }

        internal static Bitmap AddPadding(Bitmap bmp, int padding, Color color)
        {
            Bitmap image = new(bmp.Width + padding * 2, bmp.Height + padding * 2, bmp.PixelFormat);
            Graphics g = Graphics.FromImage(image);
            g.Clear(color);
            g.DrawImageUnscaled(bmp, padding, padding, bmp.Width, bmp.Height);
            g.Dispose();
            return image;
        }

        internal static Bitmap CreateGraphic(Topping topping)
        {
            Bitmap image = new(768, 432);
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "graphics/" + topping.ToppingType.Replace(" ", "").ToLower() + topping.ResonantType.Replace(" ", "").ToLower() + "_topping.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImageUnscaled(toppingGraphic, 35, 70, toppingGraphic.Width, toppingGraphic.Height);
            g.Dispose();
            using (Font font1 = new(cookieRunFont, 55, FontStyle.Bold, GraphicsUnit.Pixel))
            using (Font font2 = new(cookieRunFont, 70, FontStyle.Bold, GraphicsUnit.Pixel))
            using (Font font3 = new(cookieRunFont, 42, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush brush = new(Color.Black)) {
                AddTextToImage(image, topping.ResonantType, font1, brush, new PointF(290, 52));
                AddTextToImage(image, topping.ToppingType, font2, brush, new PointF(290, 109));
                AddTextToImage(image, topping.Stat1 + ": " + topping.Stat1Value + "%", font3, brush, new PointF(290, 215));
                AddTextToImage(image, topping.Stat2 + ": " + topping.Stat2Value + "%", font3, brush, new PointF(290, 265));
                AddTextToImage(image, topping.Stat3 + ": " + topping.Stat3Value + "%", font3, brush, new PointF(290, 315));
            }
            toppingGraphic.Dispose();

            return image;

        }

        internal static Bitmap CreateGraphic(Beascuit beascuit)
        {
            Bitmap image = new(768, 432);
            Bitmap beascuitGraphic = (Bitmap)Image.FromFile(
                Path.Combine(Application.StartupPath, "graphics/" + beascuit.BeascuitType.ToLower() + "_beascuit.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImageUnscaled(beascuitGraphic, 10, 70, beascuitGraphic.Width, beascuitGraphic.Height);
            g.Dispose();

            using (Font font1 = new(cookieRunFont, 45, FontStyle.Bold, GraphicsUnit.Pixel))
            using (Font font2 = new(cookieRunFont, 60, FontStyle.Bold, GraphicsUnit.Pixel))
            using (Font font3 = new(cookieRunFont, 37, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush brush = new(Color.Black))
            {
                AddTextToImage(image, (beascuit.Tainted ? "Tainted " : "") + beascuit.ResonantType, font1, brush, new PointF(267, 60));
                AddTextToImage(image, beascuit.BeascuitType + " Beascuit", font2, brush, new PointF(267, 104));
                AddTextToImage(image, beascuit.Stat1 + ": " + beascuit.Stat1Value + "%", font3, brush, new PointF(267, 180));
                AddTextToImage(image, beascuit.Stat2 + ": " + beascuit.Stat2Value + "%", font3, brush, new PointF(267, 220));
                AddTextToImage(image, beascuit.Stat3 + ": " + beascuit.Stat3Value + "%", font3, brush, new PointF(267, 260));
                AddTextToImage(image, beascuit.Stat4 + ": " + beascuit.Stat4Value + "%", font3, brush, new PointF(267, 300));
            }

            beascuitGraphic.Dispose();

            return image;
        }

        internal static Bitmap CreateGraphicCompact(Topping topping) { 
            Bitmap image = new(400, 400, PixelFormat.Format32bppArgb); 
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "graphics/" + topping.ToppingType.Replace(" ", "").ToLower() + topping.ResonantType.Replace(" ", "").ToLower() + "_topping.png"));
            Graphics g = Graphics.FromImage(image); 
            
            g.Clear(Color.White);
            g.DrawImage(toppingGraphic, (image.Width - toppingGraphic.Width) / 2, 25, (int)(toppingGraphic.Width * 1.1), (int)(toppingGraphic.Height * 1.1));
            g.Dispose(); 
            using (Font font = new(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush brush = new(Color.Black)) { 
                AddTextToImage(image, topping.Stat1 + ": " + topping.Stat1Value + "%", font, brush, new PointF(image.Width / 2 - (topping.Stat1 + ": " + topping.Stat1Value + "%").Length * 9, 265));
                AddTextToImage(image, topping.Stat2 + ": " + topping.Stat2Value + "%", font, brush, new PointF(image.Width / 2 - (topping.Stat2 + ": " + topping.Stat2Value + "%").Length * 9, 305));
                AddTextToImage(image, topping.Stat3 + ": " + topping.Stat3Value + "%", font, brush, new PointF(image.Width / 2 - (topping.Stat3 + ": " + topping.Stat3Value + "%").Length * 9, 345)); 
            }
            
            toppingGraphic.Dispose(); 
            return image; 
        }

        internal static Bitmap CreateGraphicCompact(Beascuit beascuit)
        {
            Bitmap image = new(400, 400, PixelFormat.Format32bppArgb);
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(
            Path.Combine(Application.StartupPath, "graphics/" + beascuit.BeascuitType.ToLower() + "_beascuit.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImage(toppingGraphic, image.Width / 2 - (int)(toppingGraphic.Width * 1.4) / 2, 15, (int)(toppingGraphic.Width * 1.4), (int)(toppingGraphic.Height * 1.4));
            g.Dispose();

            using (Font font = new(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush brush = new(Color.Black))
            {
                AddTextToImage(image, beascuit.Stat1 + ": " + beascuit.Stat1Value + "%", font, brush, new PointF(image.Width / 2 - (beascuit.Stat1 + ": " + beascuit.Stat1Value + "%").Length * 9, 225));
                AddTextToImage(image, beascuit.Stat2 + ": " + beascuit.Stat2Value + "%", font, brush, new PointF(image.Width / 2 - (beascuit.Stat2 + ": " + beascuit.Stat2Value + "%").Length * 9, 265));
                AddTextToImage(image, beascuit.Stat3 + ": " + beascuit.Stat3Value + "%", font, brush, new PointF(image.Width / 2 - (beascuit.Stat3 + ": " + beascuit.Stat3Value + "%").Length * 9, 305));
                AddTextToImage(image, beascuit.Stat4 + ": " + beascuit.Stat4Value + "%", font, brush, new PointF(image.Width / 2 - (beascuit.Stat4 + ": " + beascuit.Stat4Value + "%").Length * 9, 345));
            }

            toppingGraphic.Dispose();

            return image;
        }

    }
}
