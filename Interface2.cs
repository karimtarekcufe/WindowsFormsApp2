using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBapplication
{
    internal class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }


        /**/

        public int checkpasssword(string username,string password)
        {
             string query = $"SELECT count(Password) FROM UserData WHERE Password = '{password}' and username='{username}'";
            return (int)dbMan.ExecuteScalar(query);

        }
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public DataTable selectroles(string username, string password)
        {
            string query = $"SELECT Role,username FROM UserData WHERE Password = '{password}' and username='{username}'";
            return dbMan.ExecuteReader(query);

        }

        public int checkusername(string text)
        {
            string query = $"SELECT count(UserName) FROM UserData WHERE UserName = '{text}'";
            return (int)dbMan.ExecuteScalar(query);


        }
    }
}



