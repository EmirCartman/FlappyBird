```csharp

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
 
        // kuşun hızını yer çekimini ve her geçtiğimiz engel üzerinden aldığımız puanı tanımlıyoruz 
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

        // oyunun işleyişini buraya kodluyoruz 
        
        private void oyunZamanlayıcıOlayı(object sender, EventArgs e)
        {

            // kuşa yer çekiminin etki etmesi için yazığımız yer
            FlappyBird.Top += yercekimi;

            // kuşun hızı kadar engelleri sola çekecek kod 
            altengel.Left -= kushizi;
            ustengel.Left -= kushizi;
            // skor sayacımız her geçilen engel başına skorumuz arttığı kısım
            scoreText.Text = "Skor :" + sayac;

            // engeller ekranın solundan belli bir mesafe uzaklaştıkça tekrar karşımıza çıkması için burayı yazıyoruz
            // her geçtiğimiz engel için skoru arttırıyoruz bunun için de sayacı 1 arttırıyoruz
            if(altengel.Left < -120)
            {
                altengel.Left = 800;
                sayac++;
            }

            if (ustengel.Left < -100)
            {
                ustengel.Left = 1200;
                sayac++;
            }
            // kuşumuzun yere engellere veya ekranın en üstüne çarptığında oyunu bitirmesi için yazdığımız yer
            if(FlappyBird.Bounds.IntersectsWith(altengel.Bounds)
                || FlappyBird.Bounds.IntersectsWith(ustengel.Bounds)
                || FlappyBird.Bounds.IntersectsWith(yer.Bounds)
                || FlappyBird.Top < -25
                )
            {
                oyunBitir();
            }
            // belli bir engel sayısını geçtikten sonra oyunun zorlaşması için kuşu hızlandırıyoruz
            if(sayac > 5)
            {
                kushizi = 10;
            }
            if (sayac > 10)
            {
                kushizi = 15;
            }

        }

        private void asagıtus(object sender, KeyEventArgs e)
        {
            // space tuşuna bastığımızda kuşun yukarı gitmesini istediğimiz için burayı yazıyoruz
            
            if (e.KeyCode == Keys.Space)
            {
                yercekimi = -10;
            }

        }

        private void yukarıtus(object sender, KeyEventArgs e)
        {
            //space tuşuna basmadığımızda kuşun aşağı gitmesini istediğimiz için burayı yazıyoruz
           if (e.KeyCode == Keys.Space)
            {
                yercekimi = 10;
            }
        }
        // oyunu bitirmek için yazdığımız metot
        private void oyunBitir()
            {
                oyunZamanlayıcı.Stop();
                scoreText.Text += "Oyun Bitti.";
            }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }
    }
}
