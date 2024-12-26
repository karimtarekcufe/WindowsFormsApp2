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
        public DataTable getRequestsforhall(string id)
        {
            string query = "SELECT HallProvider.HallName , HallProvider.Location , Request.StartTime , Request.EndTime , Request.Date ,Customers.Name,Customers.Telephone\r\nFROM Request , HallProvider , Customers\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND Customers.ID=Request.CustomerID AND HallProvider.ProvID = '"+id+"'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getID(string username)
        {
            string query = "SELECT UserData.ID\r\nFROM UserData\r\nWHERE UserData.UserName='" + username + "'";
            dbMan.ExecuteReader(query);
            return dbMan.ExecuteReader(query);
        }
        public DataTable getcurrentrequestsforhall(string id)
        {
            string query = "SELECT HallProvider.HallName , HallProvider.Location , Request.StartTime , Request.EndTime , Request.Date ,Customers.Name,Customers.Telephone\r\nFROM Request , HallProvider , Customers\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND Customers.ID=Request.CustomerID AND HallProvider.ProvID = '"+id+"' AND Request.Date>='"+DateTime.Now+"' ";
            return dbMan.ExecuteReader(query);
        }

        public int insertHall(string id,string name, string location , string capacity , string size = "NULL")
        {
            string query = " INSERT INTO HallProvider ( ProvID, HallName, Location, Capacity, Size)\r\nVALUES ('" + id + "', '" + name + "', '" + location + "', '" + capacity + "', '" + size + "');\r\n";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable TablesToDelete(string id)
        {
            string query = "SELECT HallProvider.HallName , HallProvider.HallID\r\nFROM HallProvider , Request\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND HallProvider.ProvID= '"+id+"' AND Request.Date<'"+DateTime.Now+ "' union\r\nSELECT HallProvider.HallName , HallProvider.HallID\r\nFROM HallProvider , Request\r\nWHERE   Request.HallID != HallProvider.HallID";
            return dbMan.ExecuteReader(query);
        }
        public int removeHall(string id , string hallid)
        {
            string query = "Delete  from HallProvider where HallID = '"+hallid+"' and ProvID = '"+id+"'\r\n";
            return dbMan.ExecuteNonQuery(query);
        }
    }
}



