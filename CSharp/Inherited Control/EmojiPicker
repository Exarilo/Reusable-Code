using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;

namespace MyNameSpace
{
    public class ToolStripDropDownEmojisButton : ToolStripDropDownButton
    {
        private Panel panel;
        Form currentForm;
        private bool isOpen;
        private ListView listViewEmojis;
        public event EventHandler EmojiClick;
        private EventHandler handlerClosePanel;

        public ToolStripDropDownEmojisButton() : base()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add("1F642", Bitmap("path"));
            imageList.Images.Add("1F609", Bitmap("path"));

            listViewEmojis = new ListView();
            listViewEmojis.Activation = ItemActivation.OneClick;
            listViewEmojis.MultiSelect = false;
            listViewEmojis.LargeImageList = imageList;
            listViewEmojis.View = View.Tile;
            listViewEmojis.TileSize = new Size(30, 30);

            for (int i = 0; i < imageList.Images.Count; i++)
            {
                ListViewItem lst = new ListViewItem();
                lst.Tag = imageList.Images.Keys[i];
                lst.ImageIndex = i;
                listViewEmojis.Items.Add(lst);
            }
            listViewEmojis.Dock = DockStyle.Fill;

            Click += new EventHandler(DropDownCliked);
        }

        protected void DropDownCliked(object sender, EventArgs e)
        {
            currentForm = Application.OpenForms.Cast<Form>().Last();
            bool panelExist = currentForm.Controls.Contains(panel);

            if (!panelExist)
            {
                panel = new Panel();
                panel.Name = "ToolStripPanelEmojis";
                panel.MaximumSize = new Size(400, 200);
                Point toolStripPosition = GetPositionInForm(Parent);
                panel.Location = new Point(toolStripPosition.X + Bounds.X, toolStripPosition.Y + Bounds.Height);

                if (panel.Location.X + panel.MaximumSize.Width >= currentForm.Width)
                {
                    panel.Location = new Point(panel.Location.X - panel.MaximumSize.Width + Bounds.Width, panel.Location.Y);
                }

                currentForm.Controls.Add(panel);
                panel.Controls.Add(listViewEmojis);
                OpenPanel();
                panel.BringToFront();

            }
            else
            {
                if (isOpen)
                {
                    OpenPanel();
                }
                else
                {
                    ClosePanel();
                }
            }

        }

        private void OpenPanel()
        {
            BackColor= Color.White;
            listViewEmojis.ItemActivate += HandleEmojiClick;
            panel.Size = panel.MaximumSize;
            isOpen = false;
            listViewEmojis.Focus();
            handlerClosePanel = (s, e) => {
                ClosePanel();
                currentForm.Click -= handlerClosePanel;
                listViewEmojis.LostFocus -= handlerClosePanel;
            };
            listViewEmojis.LostFocus += handlerClosePanel;
            currentForm.Click += handlerClosePanel;
        }

        public void ClosePanel()
        {
            BackColor = default(Color);
            listViewEmojis.ItemActivate -= HandleEmojiClick;
            panel.Size = panel.MinimumSize;
            isOpen = true;
        }

        public Point GetPositionInForm(Control ctrl)
        {
            Point p = ctrl.Location;
            Control parent = ctrl.Parent;
            while (!(parent is Form))
            {
                p.Offset(parent.Location.X, parent.Location.Y);
                parent = parent.Parent;
            }
            return p;
        }

        private void HandleEmojiClick(object sender, EventArgs e)
        {
            this.OnEmojiClick(listViewEmojis.SelectedItems[0].Tag, EventArgs.Empty);
        }

        protected virtual void OnEmojiClick(object strEmojiUnicode, EventArgs e)
        {
            string strEmojiFormat = "emoji{U+"+strEmojiUnicode+"}";
            EventHandler handler = this.EmojiClick;
            if (handler != null)
            {
                handler(strEmojiFormat, e);
            }
        }
    }
}
