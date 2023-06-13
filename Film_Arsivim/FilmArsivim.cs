using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CefSharp.WinForms;

namespace Film_Arsivim
{
    public partial class FilmArsivim : Form
    {
        public FilmArsivim()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-DSQNOEI\SQLEXPRESS03;Initial Catalog=DbFilmArsivim;Integrated Security=True");
        ChromiumWebBrowser tarayici;
        void Filmler()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from TblFilmler", baglanti);
            DataTable dataTable= new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource= dataTable;
        }
        Color RastgeleRenk()
        {
            Random rnd = new Random();
            int kirmizi = rnd.Next(0,255);
            int yesil = rnd.Next(0,255);
            int mavi = rnd.Next(0,255);

            Color color = Color.FromArgb(kirmizi,yesil, mavi);
            return color;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler();
            tarayici= new ChromiumWebBrowser();
            this.groupBox2.Controls.Add(tarayici);
            tarayici.Dock = DockStyle.Fill;
        }

        private void TxtEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblFilmler (Ad, Kategori, Link) values (@P1, @P2, @P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtFilmAdi.Text);
            komut.Parameters.AddWithValue("@P2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3", TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listeye Eklendi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            tarayici.Load(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje Talha Yıldız Tarafından 12 Haziran 2023'te Kodlandı!","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenkDegistir_Click(object sender, EventArgs e)
        {
            this.BackColor = RastgeleRenk();
        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            //Yapım Aşamasında
        }
    }
}
