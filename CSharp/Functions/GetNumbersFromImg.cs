public static string getNumberFromImg(string imgPath)
{
  if (string.IsNullOrEmpty(imgPath))
  {
    throw new ArgumentException($"'{nameof(imgPath)}' cannot be null or empty.", nameof(imgPath));
  }

  using (var engine = new TesseractEngine(@"tessdata/", "eng"))
  {
    engine.SetVariable("tessedit_char_whitelist", "0123456789");
    engine.SetVariable("tessedit_char_blacklis", "$%^*={};<>\\~`");
    engine.SetVariable("matcher_avg_noise_size", "1");
    engine.SetVariable("textord_heavy_nr", "true");

    using (var img = Pix.LoadFromFile(imgPath))
    using (var page = engine.Process(img, Tesseract.PageSegMode.SingleLine))
    using (var iterator = page.GetIterator())
    {
      Console.WriteLine(page.GetText());
      iterator.Begin();

      do
      {
        var text = iterator.GetText(Tesseract.PageIteratorLevel.Word);
        if (text == null)
          return "-1";
        if (text.Contains(" "))
          return "";
        if (text != null)
          text = text.Trim(' ');
        else
          text = "";
        return text;
     }
     while (iterator.Next(Tesseract.PageIteratorLevel.Word));
    }
  }
}
