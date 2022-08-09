using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runo
{
    class Drawing
    {
        SolidBrush playerBrush = new SolidBrush(Properties.Settings.Default.PlayerColor);
        Graphics g;
        //Bitmap img;
        public void Draw(/*int width, int height, */Control c, Point point)
        {
            //img = new Bitmap(c.Width,c.Height);
            //g = Graphics.FromImage(buffer);
            g = c.CreateGraphics();
            //g = Graphics.FromHwnd(this.Handle);
            g.Clear(Color.White);
            g.FillRectangle(playerBrush, new Rectangle(point, new Size(10,10)));
        }

    }
}
