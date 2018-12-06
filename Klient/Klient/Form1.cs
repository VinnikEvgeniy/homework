using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using Database;


namespace Klient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ser_con obj = new ser_con();
                obj.name = name.Text;
                obj.info = Convert.ToInt32(info.Text);
                obj.OOP = Convert.ToInt32(oop.Text);
                obj.RKSZ = Convert.ToInt32(rksz.Text);
                obj.BD = Convert.ToInt32(bd.Text);

                connect_db f = new connect_db();
                f.insert(obj);

                MessageBox.Show("Студент успішно добавлений!");
                name.Clear();
                info.Clear();
                oop.Clear();
                rksz.Clear();
                bd.Clear();
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {   
            connect_db f = new connect_db();
            dataGridView1.DataSource=f.select(); 
        }
 

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            connect_db f = new connect_db();
            id = Convert.ToInt32(id_delete.Text);
           f.delete(id);
           MessageBox.Show("Студент успішно видалений!");
           id_delete.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect_db f = new connect_db();
            label7.Text = "На данний момент студентів - " + f.count() + "чол.";
        }
    }
}
