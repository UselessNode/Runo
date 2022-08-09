using System;
using System.Windows.Forms;

namespace Runo
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
            colorButton.BackColor = Properties.Settings.Default.PlayerColor;
            KeyPreview = true;

            game = new Game(this);
            this.KeyDown += game.KeyPress;
            timer.Tick += game.timerTick;
            numUD.ValueChanged += game.ChangeSpeed;
            colorButton.Click += game.ChangePlayerColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (game.currientState == Game.State.Idle)
            {
                game.currientState = Game.State.Running;
                button1.Text = "Стоп";
                game.Start();
            }
            else
            {
                game.currientState = Game.State.Idle;
                button1.Text = "Старт";
                game.Stop();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.Stop();
            Properties.Settings.Default.Save();
        }
    }
}
