using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Runo
{
    class Game
    {
        public Game(Form1 form1)
        {
            this.form = form1;
            Initialize();
        }
        private Form1 form;
        private Field field;



        private Player player;
        private Drawing drawing;
        private PictureBox box;



        private System.Windows.Forms.Timer timer;
        private Label positionLabel;
        private NumericUpDown distanceLabel;
        private int distanse = 2;

        public uint FPS;
        DateTime lastChekedTime = DateTime.Now;
        long frameCount = 0;

        void onMapUpdated()
        {
            Interlocked.Increment(ref frameCount);
        }

        double getFPS()
        {
            double secondsElapsed = (DateTime.Now - lastChekedTime).TotalSeconds;
            long count = Interlocked.Exchange(ref frameCount, 0);
            double fps = count / secondsElapsed;
            lastChekedTime = DateTime.Now;
            return fps;
        }

        public enum State { Running = 1, Idle = 0 }
        public State currientState = State.Idle;
        public void KeyPress(object sender, KeyEventArgs e)
        {
            //e.KeyData нажатая клавиша (WASD)
            player.Move(e.KeyData, field.width, field.height, distanse);
            e.SuppressKeyPress = true;
        }

        public void Start()
        {
            field.height = box.Height;//box.Height;
            field.width = box.Width;
            player.PlayerPos = new Point(25, 21);
            timer.Start();
        }

        private void Initialize()
        {
            field = new Field();
            player = new Player();
            drawing = new Drawing();
            timer = form.timer;
            box = form.pictureBox1;
            positionLabel = form.label1;
            distanceLabel = form.numUD;
        }

        internal void timerTick(object sender, EventArgs e)
        {
            drawing.Draw(box, player.PlayerPos);
            positionLabel.Text = player.PlayerPos.ToString();
        }

        public void Stop()
        {
            if(!(timer is null)) 
                timer.Stop();
        }
        internal void ChangeSpeed(object sender, EventArgs e)
        {
            distanse = (int)(sender as NumericUpDown).Value;
        }
        internal void ChangePlayerColor(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.PlayerColor = colorDialog.Color;
                MessageBox.Show($"Установлен цвет {colorDialog.Color}");
                (sender as Button).BackColor = Properties.Settings.Default.PlayerColor;
            }
        }
    }
}
