using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticCall2._0
{
    class HorizontalVerticalAnimationClass
    {
        private System.Windows.Forms.Panel panel;
        private int PosLeft = 0;
        private int PosTop = 0;

        public HorizontalVerticalAnimationClass(System.Windows.Forms.Panel panel1, int StartPosLeft, int StartPosTop)
        {
            this.panel = panel1;
            this.PosLeft = StartPosLeft;
            this.PosTop = StartPosTop;
            AnimationRun();
        }

        private async void AnimationRun()
        {
            if (PosLeft > panel.Left + 20)
                panel.Left = panel.Left + 20;
            else if (PosLeft > panel.Left + 10)
                panel.Left = panel.Left + 10;
            else if (PosLeft > panel.Left)
                panel.Left = panel.Left + 1;

            if (PosTop > panel.Top + 20)
                panel.Top = panel.Top + 20;
            else if (PosTop > panel.Top + 10)
                panel.Top = panel.Top + 10;
            else if (PosTop > panel.Top)
                panel.Top = panel.Top + 1;

            if (PosLeft < panel.Left - 20)
                panel.Left = panel.Left - 20;
            else if (PosLeft < panel.Left - 10)
                panel.Left = panel.Left - 10;
            else if (PosLeft < panel.Left)
                panel.Left = panel.Left - 1;

            if (PosTop < panel.Top - 20)
                panel.Top = panel.Top - 20;
            else if (PosTop < panel.Top - 10)
                panel.Top = panel.Top - 10;
            else if (PosTop < panel.Top)
                panel.Top = panel.Top - 1;

            await Task.Delay(10);
            AnimationRun();
        }

        public void Open(int SetPosLeft, int SetPosTop)
        {
            PosLeft = SetPosLeft;
            PosTop = SetPosTop;
        }
    }
}
