public static void binarizeimg(string imgPath, int RGBpixelsToBinarize)
{
  Bitmap curBitmap = new Bitmap(imgPath);

  if (curBitmap != null)
  {
    Color curColor;
    int ret;
    for (int iX = 0; iX < curBitmap.Width; iX++)
    {
      for (int iY = 0; iY < curBitmap.Height; iY++)
      {
        curColor = curBitmap.GetPixel(iX, iY);
        ret = (int)(curColor.R * 0.299 + curColor.G * 0.578 + curColor.B * 0.114);
        // This is our threshold, you can change it and to try what are different.
        if (ret > RGBpixelsToBinarize)
        {
          ret = 0;
        }
        else
        {
          ret = 255;
        }
        curBitmap.SetPixel(iX, iY, Color.FromArgb(ret, ret, ret));
      }
    }
   //saveBitmap(curBitmap, imgPath);
  }
}
