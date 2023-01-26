public static DateTime GetFileCreationTime(string filePath)
{
  FileInfo file = new FileInfo(filePath);
  return file.CreationTime;
}
