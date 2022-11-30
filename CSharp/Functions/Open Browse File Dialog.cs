public static string OpenFile()
{
  OpenFileDialog open = new OpenFileDialog();
  open.Filter = "All files (*.*)|*.*";
  if (open.ShowDialog() == DialogResult.OK)
  {
    return open.FileName;
  }
  return null;
}
