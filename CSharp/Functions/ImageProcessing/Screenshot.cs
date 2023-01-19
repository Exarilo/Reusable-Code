using System.Drawing;

public static void captureScreen(string fileName, int x, int y, int width, int height)
{
  Rectangle rect = new Rectangle(x, y, width, height);
  Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
  Graphics g = Graphics.FromImage(bmp);
  g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
  bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
 }
