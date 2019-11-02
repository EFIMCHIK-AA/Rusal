using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public static class HotKeys
    {
        private static Button _Button;
        private static ToolStripButton _ButtonTool;

        public static void SetButton(Button Button)
        {
            _Button = Button;
        }

        public static void SetButtonTool(ToolStripButton ButtonTool)
        {
            _ButtonTool = ButtonTool;
        }

        public static void StartButton()
        {
            _Button.PerformClick();
        }

        public static void StartButtonTool()
        {
            _ButtonTool.PerformClick();
        }
    }
}
