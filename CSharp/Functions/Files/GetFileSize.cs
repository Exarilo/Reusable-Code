public static long GetFileSize(string filePath)
{
   FileInfo file = new FileInfo(filePath);
    return file.Length;
}
