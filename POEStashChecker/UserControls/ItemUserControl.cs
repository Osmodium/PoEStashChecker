using System.Windows.Forms;
using POEStashChecker.Data;

namespace POEStashChecker.UserControls
{
    public partial class ItemUserControl : UserControl
    {
        public Item PoEItem;

        public ItemUserControl(Item item)
        {
            PoEItem = item;
            InitializeComponent();
            lblName.Text = PoEItem.Name;
            lblChaos.Text = $"{PoEItem.Value.ChaosOrb}";
            lblExalted.Text = $"{PoEItem.Value.ExaltedOrb}";
            pbIcon.Width = item.Icon.Size.Width;
            pbIcon.Height = item.Icon.Size.Height;
            pbIcon.Load(item.Icon.Url);
        }
    }
}
