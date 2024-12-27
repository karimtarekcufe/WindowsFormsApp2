using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
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

        public int checkpasssword(string username, string password)
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

        public DataTable selectgenre()
        {

            string query = "select distinct genre from Musician\r\n";
            return dbMan.ExecuteReader(query);
        }

        public DataTable selectcamera()
        {
            string query = "select distinct camera  from Photographer";
            return dbMan.ExecuteReader(query);

        }

        public DataTable selectflower()
        {
            string query = "select distinct arrangement from Florists\r\n";
            return dbMan.ExecuteReader(query);
        }

        public DataTable selectfood()
        {
            string query = "select distinct fname from MenuOption";
            return dbMan.ExecuteReader(query);
        }



        public DataTable gethallid(string name)
        {
            string query = $"select hallid from HallProvider\r\nwhere hallname='{name}';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable gethallname(string location)
        {
            string query = $"select hallname from HallProvider where location='{location}';";
            return dbMan.ExecuteReader(query);
        }
        public int IsHallBooked(string hallName, DateTime date, string startTime, string endTime)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            string startTimeString = TimeSpan.Parse(startTime).ToString(@"hh\:mm\:ss");
            string endTimeString = TimeSpan.Parse(endTime).ToString(@"hh\:mm\:ss");

            string query = $@"
        SELECT COUNT(*) 
        FROM Request
        WHERE HallID = (
            SELECT HallID 
            FROM HallProvider 
            WHERE HallName = '{hallName}'
        )
          AND Date = '{dateString}'
          AND (
              ('{startTimeString}' >= StartTime AND '{startTimeString}' < EndTime) OR
              ('{endTimeString}' > StartTime AND '{endTimeString}' <= EndTime) OR
              ('{startTimeString}' <= StartTime AND '{endTimeString}' >= EndTime)
          )";

            return (int)dbMan.ExecuteScalar(query);
        }


        internal DataTable selecttransportation(int v)
        {
            string query = $"select distinct Type from Transportation,HallproviderTransportation\r\nwhere Id=TransportationID and hallid='{v}'";
            return dbMan.ExecuteReader(query);

        }

        public DataTable gethallocation()
        {
            string query = $"select location from HallProvider;";
            return dbMan.ExecuteReader(query);
        }


        public DataTable selectcid(string text)
        {
            string query = $"select id from userdata where username='{text}'";
            return dbMan.ExecuteReader(query);
        }

        public int inssertrequest(int cid, string text1, string text2, string text3, string text4, string text, int originalprice)
        {
            string query = $@"
        INSERT INTO Request (CustomerID, StartTime, EndTime, Date, Price, HallID, ProvID, DuePayment)
        VALUES 
        ({cid}, '{text1}', '{text2}', '{text}', {originalprice}, '{text3}', '{text4}', {originalprice});
        
        SELECT SCOPE_IDENTITY();";

            object result = dbMan.ExecuteScalar(query);

            return Convert.ToInt32(result);
        }

        public DataTable gethallinfo(string text)
        {
            string query = $"select hallid, provid from HallProvider where hallname = '{text}'";
            return dbMan.ExecuteReader(query);
        }

        public DataTable gethallbookingprice(string hallid, string provid)
        {
            string query = $"select bookingpriceday from HallProvider where HallID='{hallid}' and provid='{provid}'";
            return dbMan.ExecuteReader(query);
        }

        public int insertMusician(int id, string musician)
        {
            string query = $"insert into EntertainmentRequest values('{id}','{musician}','music')";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable selectappropriatemusician(string musician, string datereq)
        {
            string query = $"\r\nselect TOP 1 EntertainerID\r\nfrom Musician\r\nWhere genre='{musician}' and EntertainerID not in(\r\nselect EntertainersID from EntertainmentRequest ,request\r\nwhere requestid= ID and CONVERT(date, Date)='{datereq}' \r\n) ";
            return dbMan.ExecuteReader(query);

        }
        public int insertPhotographer(int id, string photographerID)
        {
            string query = $"insert into EntertainmentRequest values('{id}','{photographerID}','photographer')";
            return dbMan.ExecuteNonQuery(query);
        }

        public int insertFlorist(int id, string floristID)
        {
            string query = $"INSERT INTO EntertainmentRequest (RequestID, EntertainersID, Type) VALUES ('{id}', '{floristID}', 'florist')";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getasssignedrequestdate(int req)
        {
            string query = $"select date from Request\r\nwhere id='{req}'";
            return dbMan.ExecuteReader(query);


        }
        public DataTable selectAppropriatePhotographer(string cameraType, string requestDate)
        {
            string query = $@"
        SELECT TOP 1 EntertainerID
        FROM Photographer
        WHERE Camera = '{cameraType}'
        AND EntertainerID NOT IN (
            SELECT EntertainersID 
            FROM EntertainmentRequest, Request
            WHERE RequestID = ID 
            AND Date = '{requestDate}'
        )";

            return dbMan.ExecuteReader(query);
        }






        public DataTable selectAppropriateFlorist(string arrangementType, string requestDate)
        {
            string query = $@"
        SELECT TOP 1 EntertainerID
        FROM Florists
        WHERE Arrangement = '{arrangementType}'
        AND EntertainerID NOT IN (
            SELECT EntertainersID
            FROM EntertainmentRequest, Request
            WHERE RequestID = ID
            AND Date = '{requestDate}'
        )";

            return dbMan.ExecuteReader(query);
        }

        public DataTable getaalunservedrequests(int cid)
        {
            string query = "SELECT r.ID AS RequestID, " +
                   "c.Name AS CustomerName, " +
                   "e.Name AS EntertainerName, er.Type, h.HallName, r.Date " +
                   "FROM Request r " +
                   "JOIN Customers c ON r.CustomerID = c.ID " +
                   "JOIN HallProvider h ON r.HallID = h.HallID AND r.ProvID = h.ProvID " +
                   "JOIN EntertainmentRequest er ON r.ID = er.RequestID " +
                   "JOIN Entertainers e ON er.EntertainersID = e.ID " +
                   "LEFT JOIN Musician m ON e.ID = m.EntertainerID " +
                   "LEFT JOIN Florists f ON e.ID = f.EntertainerID " +
                   "LEFT JOIN Photographer p ON e.ID = p.EntertainerID " +
                   $"WHERE c.ID = '{cid}' " +
                   "AND r.HallID = h.HallID " +
                   "AND r.ProvID = h.ProvID " +
                   "AND r.Date <= GETDATE()";
            return dbMan.ExecuteReader(query);


        }
        public DataTable getaalservedrequests(int cid)
        {
            string query = "SELECT r.ID AS RequestID, " +
                   "c.Name AS CustomerName, " +
                   "e.Name AS EntertainerName, er.Type, h.HallName, r.Date " +
                   "FROM Request r " +
                   "JOIN Customers c ON r.CustomerID = c.ID " +
                   "JOIN HallProvider h ON r.HallID = h.HallID AND r.ProvID = h.ProvID " +
                   "JOIN EntertainmentRequest er ON r.ID = er.RequestID " +
                   "JOIN Entertainers e ON er.EntertainersID = e.ID " +
                   "LEFT JOIN Musician m ON e.ID = m.EntertainerID " +
                   "LEFT JOIN Florists f ON e.ID = f.EntertainerID " +
                   "LEFT JOIN Photographer p ON e.ID = p.EntertainerID " +
                   $"WHERE c.ID = '{cid}' " +
                   "AND r.HallID = h.HallID " +
                   "AND r.ProvID = h.ProvID " +
                   "AND r.Date > GETDATE()";
            return dbMan.ExecuteReader(query);


        }

        public DataTable selectallidmusician(int cid)
        {
            string query = $"select ID\r\nfrom request\r\nwhere CustomerID='{cid}'and date>=getdate()";
            return dbMan.ExecuteReader(query);
        }

        public int checkcapacity(string text)
        {
            string query = $"select count(*)+2 from guestlist where RequestID = '{text}' ";
            return (int)dbMan.ExecuteScalar(query);

        }

        public DataTable getassignedhallidcsapacity(string text)
        {
            string query = $" select capacity from HallProvider h,Request r where h.HallID =r.HallID and h.ProvID=r.ProvID\r\n and r.ID='{text}'";

            return dbMan.ExecuteReader(query);
        }

        public int addtoguestlist(string text1, string text2, string text3,string text4)
        {
            string query = $"INSERT INTO GuestList (RequestID, GuestName, Phone, Address)\r\nVALUES\r\n    ('{text1}', '{text2}', '{text3}', '{text4}')\r\n  \r\n  ";
                return dbMan.ExecuteNonQuery(query);



        }

        public DataTable showguestlist(string text)
        {
            string query = $"SELECT Guestname,phone,Address\r\nfrom GuestList\r\nwhere Requestid='{text}'\r\n";
            return dbMan.ExecuteReader(query);


        }

        public DataTable selctguestname(string text)
        {
            string query = $"SELECT Guestname,id\r\nfrom GuestList\r\nwhere Requestid='{text}'\r\n;";
            return dbMan.ExecuteReader(query);

        }

        public int deleteguest(string selectedValue)
        {
            string query = $"delete from GuestList where id='{selectedValue}'";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable selectallridentertainers(string text, string type)
        {
            string query = $"SELECT e.ID, e.Name FROM EntertainmentRequest er, Entertainers e WHERE e.ID = er.EntertainersID AND er.RequestID = '{text}' AND er.Type = '{type}'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectAvailableTransportation(string hallId, string requestedType)
        {
            string query = $"SELECT TOP 1 t.ID, t.Type, t.Serving_Location, t.Rating FROM HallProviderTransportation hpt JOIN Transportation t ON hpt.TransportationID = t.ID WHERE hpt.HallID = '{hallId}' AND t.Type = '{requestedType}' ORDER BY t.Rating DESC;";

            return dbMan.ExecuteReader(query);
        }

        public bool insertTransportationRequest(string requestId, string transportationId)
        {
            string query = $"INSERT INTO transportaionrequest (RequestID, Tid) VALUES ('{requestId}', '{transportationId}')";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        internal void insertFoodMenu(int cid, string foodMenu)
        {
            throw new NotImplementedException();
        }
        public DataTable getRequestsforhall(string id)
        {
            string query = "SELECT Request.ID, HallProvider.HallName ,Request.HallApproved, HallProvider.Location , Request.StartTime , Request.EndTime , Request.Date ,Customers.Name,Customers.Telephone\r\nFROM Request , HallProvider , Customers\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND Customers.ID=Request.CustomerID AND HallProvider.ProvID = '" + id+"'";
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
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd");

            string query = "SELECT Request.ID, HallProvider.HallName , Request.HallApproved , HallProvider.Location , Request.StartTime , Request.EndTime , Request.Date ,Customers.Name,Customers.Telephone\r\nFROM Request , HallProvider , Customers\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND Customers.ID=Request.CustomerID AND HallProvider.ProvID = '"+id+"' AND Request.Date>='"+formattedDate+"' ";
            return dbMan.ExecuteReader(query);
        }

        public int insertHall(string id,string name, string location , string capacity , string size = "NULL")
        {
            string query = " INSERT INTO HallProvider ( ProvID, HallName, Location, Capacity, Size)\r\nVALUES ('" + id + "', '" + name + "', '" + location + "', '" + capacity + "', '" + size + "');\r\n";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable TablesToDelete(string id)
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd");
            string query = "SELECT HallProvider.HallName , HallProvider.HallID\r\nFROM HallProvider , Request\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND HallProvider.ProvID= '"+id+"' AND Request.Date<'"+formattedDate+ "' union\r\nSELECT HallProvider.HallName , HallProvider.HallID\r\nFROM HallProvider , Request\r\nWHERE   Request.HallID != HallProvider.HallID";
            return dbMan.ExecuteReader(query);
        }
        public int removeHall(string id , string hallid)
        {
            string query = "Delete  from HallProvider where HallID = '"+hallid+"' and ProvID = '"+id+"'\r\n";
            return dbMan.ExecuteNonQuery(query);
        }
        public int ApproveRequest( string RequestID)
        {
            string query = "UPDATE Request SET HallApproved='Y' WHERE ID='"+RequestID+"'";
            return dbMan.ExecuteNonQuery(query);
        }
    }
}



