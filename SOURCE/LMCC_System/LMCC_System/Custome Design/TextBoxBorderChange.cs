using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System
{
    public class TextBoxBorderChange :TextBox
    {
        //BOTTOM BORDER TEXT BOX
        public TextBoxBorderChange()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AutoSize = false;
            Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.FromArgb(150, 167, 186) });
        }
    }
}
