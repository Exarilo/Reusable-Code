using System.Drawing;
using System.Windows.Forms;

namespace MyApplication
{
    public class LinkLabel : Label
    {
        // Ajoutez une propriété pour stocker le lien Web
        private string _link;

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public LinkLabel()
        {
            // Modifiez le comportement du label lorsque l'utilisateur passe la souris dessus
            this.MouseEnter += (sender, e) => this.Cursor = Cursors.Hand;
            this.MouseLeave += (sender, e) => this.Cursor = Cursors.Default;

            // Ouvrez le lien Web lorsque l'utilisateur clique sur le label
            this.Click += (sender, e) => System.Diagnostics.Process.Start(_link);

            // Affichez le texte du label en couleur lorsque l'utilisateur passe la souris sur le label
            this.LinkArea = new LinkArea(0, this.Text.Length);
            this.LinkColor = Color.Blue;
            this.ActiveLinkColor = Color.Red;
            this.VisitedLinkColor = Color.Purple;
        }
    }
}
