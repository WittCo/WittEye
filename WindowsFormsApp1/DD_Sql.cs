using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DD_Sql
    {
        public void ConnSQL()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=AW-PRODTS\\WINCCPLUSMIG2014;Initial Catalog=WittEyE;User ID=sa;Password=demo123-";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {             
                MessageBox.Show("Connection Open  !");
                cnn.Close();
            }
        }

        /*
        public void InsertSQLDatei()
        {
            SqlCommand cmd;
            string connetionString;
            SqlConnection cnn;
            SqlDataAdapter adapt;
            connetionString = "Data Source=AW-PRODTS\\WINCCPLUSMIG2014;Initial Catalog=WittEyE;User ID=sa;Password=demo123-";
            cnn = new SqlConnection(connetionString);

            if (eB_NummerTextBox.Text != "" && iBC_ArtikelNummerTextBox.Text != "")
            {
                cmd = new SqlCommand("insert into IBC_EB(EB_Nummer,IBC_ArtikelNummer) values(@EB_Nummer,@IBC_ArtikelNummer)", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@EB_Nummer", eB_NummerTextBox.Text);
                cmd.Parameters.AddWithValue("@IBC_ArtikelNummer", iBC_ArtikelNummerTextBox.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Record Inserted Successfully");

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }

        }

        public void DisplaySQLDatai()
        {
            string connetionString;
            SqlConnection cnn;
            SqlDataAdapter adapt;
            connetionString = "Data Source=AW-PRODTS\\WINCCPLUSMIG2014;Initial Catalog=WittEyE;User ID=sa;Password=demo123-";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from IBC_EB", cnn);
            adapt.Fill(dt);
            iBC_EBDataGridView.DataSource = dt;
            cnn.Close();

        }

        public void ClearData()
        {
            txt_Name.Text = "";
            txt_State.Text = "";
            ID = 0;
        }

        public void DeleteItem()
        {
            SqlCommand cmd;
            string connetionString;
            SqlConnection cnn;
            SqlDataAdapter adapt;
            connetionString = "Data Source=AW-PRODTS\\WINCCPLUSMIG2014;Initial Catalog=WittEyE;User ID=sa;Password=demo123-";
            cnn = new SqlConnection(connetionString);

            if (ID != 0)
            {
                cmd = new SqlCommand("delete IBC_EB where ID=@id", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Record Deleted Successfully!");


            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
           
        }


    }


   
    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        txt_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        txt_State.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
    }
    */
    }
}
