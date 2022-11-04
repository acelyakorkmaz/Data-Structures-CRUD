using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acelya_korkmaz
{
    public partial class Form1 : Form
    {
        public class dugum
        {
            public string ad;
            public int fiyat;
            public int kodu;
            public dugum sonraki;
            public dugum onceki;


        }
        dugum anadugum;
        dugum ilk = null;
        //dugum son = null;
        public Form1()
        {
            //  ilk = new dugum();
            // son = new dugum();
            InitializeComponent();
        }

        private void EKLE_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //    dataGridView1.ColumnCount = 3;
            //    dataGridView1.Columns[0].Name = "Kod";
            //    dataGridView1.Columns[1].Name = "Adı";
            //    dataGridView1.Columns[2].Name = "Fiyat";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (anadugum == null)
            {
                anadugum = new dugum();
                anadugum.ad = textBox2.Text;
                anadugum.fiyat = Convert.ToInt32(textBox3.Text);
                anadugum.kodu = Convert.ToInt32(textBox1.Text);


            }
            else
            {

                bool yenieklenecekmi = true;

                int yeniurunkodu = Convert.ToInt32(textBox1.Text);
                dugum kontrol = anadugum;
                dugum sondugum = anadugum;
                while (kontrol != null)
                {
                    if (kontrol.kodu == yeniurunkodu)
                    {
                        yenieklenecekmi = false;
                    }

                    if (kontrol.sonraki == null)
                    {
                        sondugum = kontrol; // en sonu sonraki null olan kayıt> son düğüm
                    }
                    kontrol = kontrol.sonraki;


                }


                if (yenieklenecekmi)
                {


                    dugum yeni = new dugum();
                    yeni.ad = textBox2.Text;
                    yeni.fiyat = Convert.ToInt32(textBox3.Text);
                    yeni.kodu = Convert.ToInt32(textBox1.Text);
                    yeni.onceki = new dugum();
                    yeni.onceki = sondugum; 

                    sondugum.sonraki = new dugum();
                    sondugum.sonraki = yeni; 

                }
                else
                {
                    MessageBox.Show("bu ürün eklenmiş");
                }


            }
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
            dataGridView1.Rows.Clear();
            ilk = anadugum;
            while (ilk != null)
            {
                DataGridViewRow dr = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dr.Cells[0].Value = ilk.kodu;
                dr.Cells[1].Value = ilk.ad;
                dr.Cells[2].Value = ilk.fiyat.ToString();
                dataGridView1.Rows.Add(dr);
              
                ilk = ilk.sonraki;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox4.Text);
            dugum kontrol = anadugum;

            while (kontrol != null)
            {
                if (kontrol.kodu == no)
                {


                    dugum gecici = kontrol.onceki;
                    if (kontrol.sonraki != null)
                    {
                        if (gecici != null)
                        {

                            kontrol.sonraki.onceki = gecici;
                            gecici.sonraki = kontrol.sonraki;

                        }
                        else
                        {
                            kontrol.sonraki.onceki = new dugum();
                            anadugum = kontrol.sonraki;
                        }
                    }
                    else
                    {
                        if (gecici != null)
                        {
                            gecici.sonraki.onceki = gecici;
                            gecici.sonraki = null;
                        }
                        else
                        {
                            anadugum = null;
                        }
                    }


                    //   kontrol.onceki.sonraki = kontrol.sonraki;

                }


                kontrol = kontrol.sonraki;


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox4.Text);
            dugum kontrol = anadugum;

            while (kontrol != null)
            {
                if (kontrol.kodu == no)
                {
                    textBox5.Text = kontrol.ad;
                    textBox6.Text = kontrol.fiyat.ToString();
                }


                kontrol = kontrol.sonraki;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox7.Text);
            dugum kontrol = anadugum;

            while (kontrol != null)
            {
                if (kontrol.kodu == no)
                {
                    kontrol.ad = textBox8.Text;
                    kontrol.fiyat = Convert.ToInt32(textBox9.Text);
                }


                kontrol = kontrol.sonraki;


            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox7.Text);
            dugum kontrol = anadugum;

            while (kontrol != null)
            {
                if (kontrol.kodu == no)
                {
                    textBox8.Text = kontrol.ad;
                    textBox9.Text = kontrol.fiyat.ToString();
                }


                kontrol = kontrol.sonraki;


            }
        }
    }
}
