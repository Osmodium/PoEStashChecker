using System.Windows.Forms;

namespace POEStashChecker.UserControls
{
    public sealed class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            DoubleBuffered = true;
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            HorizontalScrollingOffset = 0;
            base.OnColumnHeaderMouseClick(e);
        }
    }
}
