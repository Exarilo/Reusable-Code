public static void WriteTextInFile(string filePath,string text)
{
  if (File.Exists(filePath))
  {
    File.Delete(filePath);
  }
  using (StreamWriter sw = File.CreateText(filePath))
  {
    sw.WriteLine(text);
  }
}
