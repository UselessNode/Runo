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
    class Player
    {
        public Point PlayerPos;
        public int PlayerLenght { get; set; }
        // При передвижении меняется лишь позиция PlayerPos
        public Point Move(Keys key, int borderX, int borderY, int distanse)
        {
            switch (key)
            {
                case Keys.A: case Keys.Left:
                    if(PlayerPos.X - distanse > 0)
                        PlayerPos.X -= distanse;
                    break;

                case Keys.D: case Keys.Right:
                    if (PlayerPos.X + distanse < borderX)
                        PlayerPos.X += distanse;
                    break;

                case Keys.W: case Keys.Up:
                    if (PlayerPos.Y - distanse > 0)
                        PlayerPos.Y -= distanse;
                    break;

                case Keys.S: case Keys.Down:
                    if (PlayerPos.Y + distanse < borderY)
                        PlayerPos.Y += distanse;
                    break;

                default:
                    break;
            }
            return PlayerPos;
        }
    }
}
