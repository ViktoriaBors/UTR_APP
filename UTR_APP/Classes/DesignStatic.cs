using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTR_APP.Classes
{
    internal class DesignStatic
    {
        public static void PB_Enter(PictureBox PB)
        {
            PB.Size = new Size(PB.Width + 8, PB.Height + 8);
            PB.Location = new Point(PB.Location.X - 4, PB.Location.Y - 4);
        }

        public static void PB_Leave(PictureBox PB)
        {
            PB.Size = new Size(PB.Width - 8, PB.Height - 8);
            PB.Location = new Point(PB.Location.X + 4, PB.Location.Y + 4);
        }

    }
}
