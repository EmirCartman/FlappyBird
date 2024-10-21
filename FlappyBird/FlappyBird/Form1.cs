using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {


        int kushizi = 8;
        int yercekimi = 10;
        int sayac = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void altengel_Click(object sender, EventArgs e)
        {

        }

        private void oyunZamanlayıcıOlayı(object sender, EventArgs e)
        {


            FlappyBird.Top += yercekimi;
            altengel.Left -= kushizi;
            ustengel.Left -= kushizi;
            scoreText.Text = "Skor :" + sayac;


            if(altengel.Left < -110)
            {
                altengel.Left = 800;
                sayac++;
            }

            if (ustengel.Left < -100)
            {
                ustengel.Left = 950;
                sayac++;
            }

            if(FlappyBird.Bounds.IntersectsWith(altengel.Bounds)
                || FlappyBird.Bounds.IntersectsWith(ustengel.Bounds)
                || FlappyBird.Bounds.IntersectsWith(yer.Bounds)
                || FlappyBird.Top < -25
                )
            {
                oyunBitir();
            }

            if(sayac > 5)
            {
                kushizi = 15;
            }

        }

        private void asagıtus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                yercekimi = -5;
            }

        }

        private void yukarıtus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                yercekimi = 5;
            }
        }
        private void oyunBitir()
            {
                oyunZamanlayıcı.Stop();
                scoreText.Text += "Oyun Bitti.";
            }

    }
}
