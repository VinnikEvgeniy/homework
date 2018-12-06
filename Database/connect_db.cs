using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using System.Data;
using System.Data.OleDb;
namespace Database
{
   public class connect_db
    {       
            
        // строка подключения к MS Access
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;";
        public OleDbConnection myCon = new OleDbConnection(connectString);
           
        public void insert(ser_con obj)
        { // открываем соединение с БД
            myCon.Open();
            string query = "INSERT INTO std (ФИО, Информатика,ООП,РКСЗ,БД) VALUES ('" + obj.name + "'," + obj.info + "," + obj.OOP + "," + obj.RKSZ + "," + obj.BD + ")";

            OleDbCommand com = new OleDbCommand(query, myCon);
            com.ExecuteNonQuery();
            myCon.Close();

        }
        public DataTable select()
        { // открываем соединение с БД
            myCon.Open();
            string query = "SELECT * FROM std";

            OleDbCommand com = new OleDbCommand(query, myCon);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            myCon.Close();
        }
        public void delete(int id)
        { // открываем соединение с БД
            myCon.Open();
            string query = "DELETE * FROM std WHERE id=" + id+"";

            OleDbCommand com = new OleDbCommand(query, myCon);

            com.ExecuteNonQuery();
            myCon.Close();
            
        }
        public int count() {
            // открываем соединение с БД
            myCon.Open();
            string query = "SELECT Count(*) FROM std";

            OleDbCommand com = new OleDbCommand(query, myCon);   
            
            return Convert.ToInt32(com.ExecuteScalar());
            myCon.Close();
            }


    }
}
