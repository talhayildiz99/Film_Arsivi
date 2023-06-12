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

namespace Film_Arsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-DSQNOEI\SQLEXPRESS03;Initial Catalog=DbFilmArsivim;Integrated Security=True");

        void Filmler()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Ad, Kategori from TblFilmler", baglanti);
            DataTable dataTable= new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource= dataTable;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler();
        }
    }
}
