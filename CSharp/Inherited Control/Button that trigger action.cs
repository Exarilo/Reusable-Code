public class CustomButton : Button
{
  public CustomButton(string text, Action action) : base()
  {
    AutoSize = true;
    Text = text;
    Click += (sender, args) => action();
  }
}
