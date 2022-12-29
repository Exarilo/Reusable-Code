public class MovablePictureBox : PictureBox
{
    private bool isDragging;
    private int currentX;
    private int currentY;
    public bool RestrictToParent { get; set; }
    
    public MovablePictureBox(bool restrictToParent = true)
    {
        RestrictToParent = restrictToParent;
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        isDragging = true;
        currentX = e.X;
        currentY = e.Y;
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (isDragging)
        {
            int newTop = Top + (e.Y - currentY);
            int newLeft = Left + (e.X - currentX);
            if (RestrictToParent)
            {
                if (newTop >= 0 && newTop + Height <= Parent.Height)
                    Top = newTop;
                if (newLeft >= 0 && newLeft + Width <= Parent.Width)
                    Left = newLeft;
            }
            else
            {
                Top = newTop;
                Left = newLeft;
            }
        }
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        isDragging = false;
    }
}
