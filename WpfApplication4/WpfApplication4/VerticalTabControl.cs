using System;
using System.Drawing;
using System.Windows.Forms;

public class VerticalTabControl : TabControl
{
    public VerticalTabControl()
    {
        Alignment = TabAlignment.Left; // Установите выравнивание влево для вертикальных вкладок
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        // Rotate the tab control 90 degrees counterclockwise
        e.Graphics.TranslateTransform(0, this.Height);
        e.Graphics.RotateTransform(90);

        foreach (TabPage tab in this.TabPages)
        {
            Rectangle tabRect = this.GetTabRect(this.TabPages.IndexOf(tab));
            tabRect.Offset(2, 2); // Adjust the position
            e.Graphics.DrawString(tab.Text, this.Font, Brushes.Black, tabRect);
        }
    }
}
