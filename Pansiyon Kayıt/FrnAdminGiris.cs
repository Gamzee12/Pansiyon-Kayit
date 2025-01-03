using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace proje2
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-01UGQQIK\\SQLEXPRESS;Initial Catalog=\"Keskin Pansiyon\";Integrated Security=True;");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
           
         try
         {
                baglanti.Open();
                string sql = "select * from AdminGiris where Kullanici=@kullaniciadi AND Sifre=@Sifresi";
                SqlParameter prm1 = new SqlParameter("KullaniciAdi", TxtKullaniciAdi.Text.Trim());
                SqlParameter prm2= new SqlParameter("Sifresi", TxtSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();

                da.Fill(dt);

                if (dt.Rows.Count > 0 )
                {

                    FrmAnaForm fr = new FrmAnaForm();
                    fr.Show();
                    this.Hide();
                }   
         }
         catch (Exception)
         {

                MessageBox.Show("Hatali Giris");
               
         }

              
        }
    }
}

