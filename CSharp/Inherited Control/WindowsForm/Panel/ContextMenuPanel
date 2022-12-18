using System.Windows.Forms;
using System;

public class ContextMenuPanel : Panel
{
    private ContextMenuStrip contextMenu;

    public ContextMenuPanel()
    {
        // Initialisez le menu contextuel ici
        contextMenu = new ContextMenuStrip();

        // Ajoutez les options de menu pour copier et coller
        contextMenu.Items.Add("Copier").Click += new EventHandler(CopyMenuItem_Click);
        contextMenu.Items.Add("Coller").Click += new EventHandler(PasteMenuItem_Click);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButtons.Right)
        {
            contextMenu.Show(this, e.Location);
        }
    }

    private void CopyMenuItem_Click(object sender, EventArgs e)
    {
        // Copiez le contenu du panel ici
        Clipboard.SetText(GetPanelContent());
    }

    private void PasteMenuItem_Click(object sender, EventArgs e)
    {
        // Collez le contenu du presse-papiers ici
        SetPanelContent(Clipboard.GetText());
    }

    private string GetPanelContent()
    {
        // Récupérez le contenu du panel ici
        return "aaa";
    }

    private void SetPanelContent(string content)
    {
        // Insérez le contenu dans le panel ici
    }
}
