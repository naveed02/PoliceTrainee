using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace GUI_Task
{
    public partial class frmInsertBulkImages : Form
    {
        static string[] filename = { "" };   
        //string path = string.Empty;

        public frmInsertBulkImages()
        {
            InitializeComponent();
        }

        private void frmInsertBulkImages_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();
            //fileChooser.Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            fileChooser.Filter = "image files All files (*.*)|*.*";
            fileChooser.InitialDirectory = "D:\\Pictures";
            fileChooser.Title = "Select Image";
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = Path.GetDirectoryName(fileChooser.FileName);
                filename = Directory.GetFiles(txtPath.Text);
                
                

                for(int i=0; i<filename.Length; i++)
                {
                //    //filename[i] += Path.GetFileName(path);
                    txtFileName.Text += Path.GetFileNameWithoutExtension(filename[i]) + Environment.NewLine;
                       // txtFileName.Text += filename[i];
                //    //txtFileName.Text += filename[i].Replace("\n", Environment.NewLine);
                //    //break;
                }

                this.Close();
            }
        }

        public string[] imageFileName
        {
            get { return filename; }
            set { filename = value; }
        }

            //SqlConnection con = new SqlConnection(clsGVar.ConString1);
            ////con.Open();

            ////string UserName = txtUsername.Text;
            ////string Password = txtPassword.Text;
 
            //SqlCommand cmd = new SqlCommand("select ID,CapNo,Picture from RecruitCourse", con);
 
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
 
            //System.Data.SqlClient.SqlDataReader dr = null;
            //dr = cmd.ExecuteReader();

            //if (dr.Read())
            //{
            //    SqlConnection con1 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            //    con1.ConnectionString = "Data Source= (Local); Initial Catalog=PoliceTrainee; User ID=sa; Password=smc786";
            //    con1.Open();

            //    for (int i = 0; i < filename.Length; i++)
            //    {
            //        if (Path.GetFileNameWithoutExtension(filename[i]) == dr["CapNo"].ToString())
            //        {
            //            //MessageBox.Show("Matched");
            //            SqlConnection imageCon = new SqlConnection(clsGVar.ConString1);
            //            imageCon.Open();    

            //            //string lSQL = string.Empty;
            //            //lSQL = "UPDATE RecruitCourse SET Picture = " + ;

            //            byte[] imgData;
            //            imgData = 

            //            //if(cboCourseSelection.SelectedValue.ToString() == "1")
            //            //{
            //            SqlCommand imageCmd = new SqlCommand("UPDATE RecruitCourse SET Picture = @DATA WHERE ID = " + txtID.Text.ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString(), con);
            //            imageCmd.Parameters.Add("@DATA", imgData);
            //            //con.Open();
            //            imageCmd.ExecuteNonQuery();

            //            imageCon.Close();
            //        }

            //        else
            //        {
            //            MessageBox.Show("Not Mached");
            //        }
            //    }

        private void frmInsertBulkImages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
