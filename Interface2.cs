using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp2;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }


        /**/

       
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        

        ///
        //public DataTable getID(string username, string password)
        //{
        //    string query = $"SELECT ID FROM UserData WHERE Password = '{password}' and username='{username}'";
        //    return dbMan.ExecuteReader(query);

        //}

        public string EntType(int ID)
        {
            string query = $"SELECT TYPE FROM Entertainers WHERE ID = {ID}";
            return dbMan.ExecuteScalar(query).ToString();
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
            string query = $"select HallID from HallProvider\r\nwhere hallname='{name}';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable gethallname(string location)
        {
            string query = $"select HallName from HallProvider where location='{location}';";
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
            string query = @"
    SELECT 
        r.ID AS RequestID, 
        CASE WHEN e.Name IS NULL THEN 'No Entertainer' ELSE e.Name END AS EntertainerName, 
        CASE WHEN er.Type IS NULL THEN 'No Entertainer Type' ELSE er.Type END AS EntertainerType, 
        h.HallName, 
        r.Date AS RequestDate,
        CASE WHEN mo.Fname IS NULL THEN 'No Menu Option' ELSE mo.Fname END AS MenuOption, 
        CASE WHEN mr.Quantity IS NULL THEN 0 ELSE mr.Quantity END AS MenuQuantity, 
        CASE WHEN t.Type IS NULL THEN 'No Transportation' ELSE t.Type END AS TransportationType, 
        CASE WHEN t.ID IS NULL THEN 'No Transportation ID' ELSE CAST(t.ID AS VARCHAR) END AS TransportationID
    FROM 
        Request r
    JOIN 
        Customers c ON r.CustomerID = c.ID
    JOIN 
        HallProvider h ON r.HallID = h.HallID AND r.ProvID = h.ProvID
    LEFT JOIN 
        EntertainmentRequest er ON r.ID = er.RequestID
    LEFT JOIN 
        Entertainers e ON er.EntertainersID = e.ID
    LEFT JOIN 
        MenuRequests mr ON r.ID = mr.RequestID
    LEFT JOIN 
        MenuOption mo ON mr.CatererID = mo.CatererID AND mr.Fname = mo.Fname
    LEFT JOIN 
        transportaionrequest tr ON r.ID = tr.requestid
    LEFT JOIN 
        Transportation t ON tr.Tid = t.ID
    WHERE 
        c.ID = '2'
        AND r.Date >= GETDATE();
";

            return dbMan.ExecuteReader(query);


        }
        public DataTable getaalservedrequests(int cid)
        {
            string query = @"
    SELECT 
        r.ID AS RequestID, 
        CASE WHEN e.Name IS NULL THEN 'No Entertainer' ELSE e.Name END AS EntertainerName, 
        CASE WHEN er.Type IS NULL THEN 'No Entertainer Type' ELSE er.Type END AS EntertainerType, 
        h.HallName, 
        r.Date AS RequestDate,
        CASE WHEN mo.Fname IS NULL THEN 'No Menu Option' ELSE mo.Fname END AS MenuOption, 
        CASE WHEN mr.Quantity IS NULL THEN 0 ELSE mr.Quantity END AS MenuQuantity, 
        CASE WHEN t.Type IS NULL THEN 'No Transportation' ELSE t.Type END AS TransportationType, 
        CASE WHEN t.ID IS NULL THEN 'No Transportation ID' ELSE CAST(t.ID AS VARCHAR) END AS TransportationID
    FROM 
        Request r
    JOIN 
        Customers c ON r.CustomerID = c.ID
    JOIN 
        HallProvider h ON r.HallID = h.HallID AND r.ProvID = h.ProvID
    LEFT JOIN 
        EntertainmentRequest er ON r.ID = er.RequestID
    LEFT JOIN 
        Entertainers e ON er.EntertainersID = e.ID
    LEFT JOIN 
        MenuRequests mr ON r.ID = mr.RequestID
    LEFT JOIN 
        MenuOption mo ON mr.CatererID = mo.CatererID AND mr.Fname = mo.Fname
    LEFT JOIN 
        transportaionrequest tr ON r.ID = tr.requestid
    LEFT JOIN 
        Transportation t ON tr.Tid = t.ID
    WHERE 
        c.ID = '2'
        AND r.Date < GETDATE();
";

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

        public int addtoguestlist(string text1, string text2, string text3, string text4)
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
        public DataTable selectAvailableTransportation(string hallId, string requestedType, string v)
        {
            string query = $@"
    
    SELECT TOP 1 
        t.ID, 
        t.Type, 
        t.Serving_Location, 
        t.Rating 
    FROM 
        HallProviderTransportation hpt
    JOIN 
        Transportation t ON hpt.TransportationID = t.ID
    WHERE 
        hpt.HallID = '{hallId}' 
        AND t.Type = '{requestedType}' 
        AND NOT EXISTS (
            SELECT 1 
            FROM transportaionrequest tr ,Request r
            WHERE tr.Tid = t.ID  and tr.requestid=r.ID
              AND  r.Date= '{v}'
        )
    ORDER BY 
        t.Rating DESC;";

            return dbMan.ExecuteReader(query);
        }
        public DataTable selectAvailableCatererForFood(string hallId, string requestedFood, string requestDate, string quantity)
        {
            string query = $@"
    SELECT TOP 1 
        m.CatererID, 
        c.Rating 
    FROM 
        MenuOption m
    JOIN 
        Caterer c ON m.CatererID = c.ID
    WHERE 
        m.Fname = '{requestedFood}' 
        AND not EXISTS (
            SELECT 1 
            FROM MenuRequests mr
            JOIN Request r ON mr.RequestID = r.ID
            WHERE mr.CatererID = m.CatererID 
            AND mr.Fname = m.Fname
            AND r.Date = '{requestDate}'
        )
    ORDER BY c.Rating DESC;
    ";

            return dbMan.ExecuteReader(query);
        }

        public bool insertFoodMenuRequest(string requestId, string foodName, string catererId , string quantity)
        {
            string query = $"INSERT INTO MenuRequests (RequestID, Fname, CatererID,quantity) VALUES ('{requestId}', '{foodName}', '{catererId}','{quantity}')";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool insertTransportationRequest(string requestId, string transportationId)
        {
            string query = $"INSERT INTO transportaionrequest (RequestID, Tid) VALUES ('{requestId}', '{transportationId}')";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public int insertFoodMenu(int cid, string foodMenu)
        {
            throw new NotImplementedException();
        }
        public DataTable getRequestsforhall(string id)
        {
            string query = "SELECT Request.ID, HallProvider.HallName ,Request.HallApproved, HallProvider.Location , Request.StartTime , Request.EndTime , Request.Date ,Customers.Name,Customers.Telephone\r\nFROM Request , HallProvider , Customers\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND Customers.ID=Request.CustomerID AND HallProvider.ProvID = '" + id + "'";
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

            string query = "SELECT Request.ID, HallProvider.HallName , Request.HallApproved , HallProvider.Location , Request.StartTime , Request.EndTime , Request.Date ,Customers.Name,Customers.Telephone\r\nFROM Request , HallProvider , Customers\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND Customers.ID=Request.CustomerID AND HallProvider.ProvID = '" + id + "' AND Request.Date>='" + formattedDate + "' ";
            return dbMan.ExecuteReader(query);
        }

        public int insertHall(string id, string name, string location, string capacity, string price, string size = "0")
        {
            string query = " INSERT INTO HallProvider ( ProvID, HallName, Location, Capacity,bookingpriceday, Size)\r\nVALUES ('" + id + "', '" + name + "', '" + location + "', '" + capacity + "','" + price + "', '" + size + "');\r\n";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable TablesToDelete(string id)
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd");
            string query = "SELECT HallProvider.HallName , HallProvider.HallID\r\nFROM HallProvider , Request\r\nWHERE Request.ProvID = HallProvider.ProvID AND Request.HallID = HallProvider.HallID AND HallProvider.ProvID= '" + id + "' AND Request.Date<'" + formattedDate + "' union\r\nSELECT HallProvider.HallName , HallProvider.HallID\r\nFROM HallProvider , Request\r\nWHERE   Request.HallID != HallProvider.HallID";
            return dbMan.ExecuteReader(query);
        }
        public int removeHall(string id, string hallid)
        {
            string query = "Delete  from HallProvider where HallID = '" + hallid + "' and ProvID = '" + id + "'\r\n";
            return dbMan.ExecuteNonQuery(query);
        }
        public int ApproveRequest(string RequestID)
        {
            string query = "UPDATE Request SET HallApproved='Y' WHERE ID='" + RequestID + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable selectallridtransporattion(string text)
        {
            string query = $"SELECT t.Type, t.ID FROM Transportation t INNER JOIN transportaionrequest tr ON tr.Tid = t.ID WHERE tr.requestid = '{text}';";
            return dbMan.ExecuteReader(query);
        }


        public DataTable selectallridfood(string text)
        {
            string query = $"SELECT f.Fname, f.CatererID FROM MenuOption f JOIN MenuRequests mr ON mr.CatererID = f.CatererID AND mr.Fname = f.Fname WHERE mr.RequestID = '{text}';";
            return dbMan.ExecuteReader(query);
        }

        public int deletewholerequest(string rid)
        {
            string query = $"delete from request where id='{rid}'";

            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteentertainementrequest(string requestId, string entertainerId)
        {
            string query = $"DELETE FROM EntertainmentRequest WHERE requestid = '{requestId}' AND EntertainersID = '{entertainerId}';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deletefoodrequest(string requestId, string catererId, string fname)
        {
            string query = $"DELETE FROM MenuRequests WHERE RequestID = '{requestId}' AND Fname = '{fname}' AND CatererID = '{catererId}';";
            return dbMan.ExecuteNonQuery(query);

        }
        public int deletetransportationrequest(string tid, string requestId)
        {
            string query = $"DELETE FROM transportaionrequest WHERE Tid = '{requestId}' AND RequestID = '{tid}';";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable getHalls(string id)
        {
            string query = "SELECT HallProvider.HallName , HallProvider.HallID , HallProvider.Capacity ,HallProvider.Size , HallProvider.bookingpriceday " +
                "FROM HallProvider " +
                "WHERE HallProvider.ProvID='" + id + "'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getHallToUpdate(string id, string hallid)
        {
            string query = "SELECT HallProvider.HallName , HallProvider.Capacity ,HallProvider.Size , HallProvider.bookingpriceday " +
                " FROM HallProvider " +
                " WHERE HallProvider.ProvID ='" + id + "' AND HallProvider.HallID = '" + hallid + "'";
            return dbMan.ExecuteReader(query);
        }
        public int insertTransport(string type, string serving, string price, string provid, string hallid)
        {
            string query = "DECLARE @NewID INT; " +
                "INSERT INTO Transportation (Type, Serving_Location , Price) " +
                "VALUES ('" + type + "', '" + serving + "' , '" + price + "'); " +
                "SET @NewID = SCOPE_IDENTITY(); " +
                "SELECT @NewID AS NewIdentityValue;";
            object identity = dbMan.ExecuteScalar(query);

            query = "INSERT INTO HallProviderTransportation (ProvID , HallID , TransportationID) " +
                "VALUES ('" + provid + "' ,'" + hallid + "' , '" + identity.ToString() + "')";

            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getTransportToDelete(string ProvID, string HallID)
        {
            string query = "SELECT Transportation.ID , Transportation.Type , Transportation.Serving_Location , Transportation.Rating , Transportation.Price " +
                "FROM HallProviderTransportation , Transportation " +
                "WHERE\tTransportation.ID = HallProviderTransportation.TransportationID " +
                "AND HallProviderTransportation.ProvID = '" + ProvID + "' AND HallProviderTransportation.HallID = '" + HallID + "' ";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteTransport(string TransportID)
        {
            string query = "DELETE " +
                "FROM Transportation " +
                "WHERE Transportation.ID = '" + TransportID + "'";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateVenueData(string id, string hallid, string name, string capacity, string size, string price)
        {
            string query = $"UPDATE HallProvider " +
                $"SET HallName = '" + name + "', Capacity = '" + capacity + "', " +
                "  Size = '" + size + "',   " +
                " bookingpriceday = '" + price + "' " +
                "WHERE  HallID = '" + hallid + "' AND ProvID = '" + id + "';";
            return dbMan.ExecuteNonQuery(query);    
        }

        //AbdelRahman Functions
        public bool checkpassword(string username, string password)
        {
            string query = $"SELECT Password FROM UserData WHERE  username='{username}'";

            return Password.VerifyPassword(password, dbMan.ExecuteReader(query).Rows[0][0].ToString());

        }


        public DataTable selectroles(string username)
        {
            string query = $"SELECT Role,username FROM UserData WHERE  username='{username}'";
            return dbMan.ExecuteReader(query);

        }

        public int checkusername(string text)
        {
            string query = $"SELECT count(UserName) FROM UserData WHERE UserName = '{text}'";
            return (int)dbMan.ExecuteScalar(query);


        }

        public int InsertUserData(string username, string password, string role)
        {
            DateTime signUpDate = DateTime.Now;
            string query = $"INSERT INTO UserData(UserName,Password,Role,SignUpDate) VALUES ('{username}' , '{password}' , '{role}','{signUpDate}') ;";
            // string query = $"INSERT INTO UserData(UserName,Password,Role,SignUpDate) VALUES ('{username}' , '{password}' , '{role}',GETDATE() ;";

            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertHallProvider(int provid, string hallname, string location, int capacity, int size ,  string price)
        {
            string query = $"INSERT INTO HallProvider(ProvID , HallName , Location , Capacity ,Size , bookingpriceday) VALUES ('{provid}','{hallname}','{location}','{capacity}','{size}' , '{price}') ;";

            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertPayment(string ccn, string cvv, string expirydate)
        {
            string query = $"INSERT INTO Payment VALUES ('{ccn}','{cvv}','{expirydate}') ;";

            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertCustomer(int customerid, string address, int paymentid, decimal budget, string name, string telephone)
        {
            string query = $"INSERT INTO Customers(ID,Address,PaymentID,Budget, Telephone, Name) VALUES ({customerid},'{address}',{paymentid},{budget},'{telephone}','{name}') ;";

            return dbMan.ExecuteNonQuery(query);
        }

        public int GetLatestUserID()
        {
            string query = $"SELECT TOP 1 ID FROM UserData ORDER BY ID DESC;";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int GetLatestPaymentID()
        {
            string query = $"SELECT TOP 1 ID FROM Payment ORDER BY ID DESC;";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int InsertEntertainer(int userid, string name, string type, int priceperhour)
        {
            string query = $"INSERT INTO Entertainers VALUES ({userid},'{name}','{type}',{priceperhour}) ;";

            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertFlorist(int entid, string arrangement)
        {
            string query = $"INSERT INTO Florists VALUES ({entid},'{arrangement}') ;";

            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertPhotographer(int entid, string camera)
        {
            string query = $"INSERT INTO Photographer VALUES ({entid},'{camera}') ;";

            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertMusician(int entid, string bandname, string genre)
        {
            string query = $"INSERT INTO Musician VALUES ({entid},'{bandname}','{genre}') ;";

            return dbMan.ExecuteNonQuery(query);
        }
        public int GetLatestEntertainerID()
        {
            string query = $"SELECT TOP 1 ID FROM Entertainers ORDER BY ID DESC;";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int CheckExistance(string username)
        {
            string query = $"SELECT COUNT(*) FROM UserData WHERE UserName ='{username}';";
            return (int)dbMan.ExecuteScalar(query);

        }



    

        public DataTable ViewBookEnt(int id)
        {
            string query = $"SELECT RequestID,Type as Status FROM EntertainmentRequest WHERE EntertainersID = {id}";
            return dbMan.ExecuteReader(query);
        }

        // the one below got changed
        public DataTable GetRequestIDFromEntReq(int id)
        {
            string query = $"SELECT RequestID , Type AS Status FROM EntertainmentRequest WHERE EntertainersID = {id}";
            return dbMan.ExecuteReader(query);
        }

        public int approveRequestEnt(int reqID)
        {
            string query = "UPDATE EntertainmentRequest SET Type = 'approve' WHERE RequestID = " + reqID;
            return dbMan.ExecuteNonQuery(query);
        }

        public int denyRequestEnt(int reqID)
        {
            string query = "UPDATE EntertainmentRequest SET Type = 'deny' WHERE RequestID = " + reqID;
            return dbMan.ExecuteNonQuery(query);
        }

        public int updatePriceEnt(int reqID, int price)
        {
            string query = $"UPDATE Entertainers SET Price_Per_Hour = '{price}' WHERE ID = {reqID}";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateArrangmentFlorist(int reqID, string arrangment)
        {
            string query = $"UPDATE Florists SET Arrangement = '{arrangment}' WHERE EntertainerID = {reqID}";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateCameraPhotographer(int reqID, string camera)
        {
            string query = $"UPDATE Photographer set Camera = '{camera}' WHERE EntertainerID = {reqID} ";
            return dbMan.ExecuteNonQuery(query);
        }

        //public int deleteEnt(int id) {
        //    string query = $"DELETE FROM Entertainers WHERE ID = {id}";
        //    return dbMan.ExecuteNonQuery(query);
        //}

        public DataTable getDateEnt(int id)
        {
            string query = $"SELECT Date FROM Request WHERE ID  IN (SELECT RequestID FROM EntertainmentRequest WHERE EntertainersID = {id})";
            return dbMan.ExecuteReader(query);
        }



        public DataTable getUpcomingReqLtoH()
        {
            DateTime currentDate = DateTime.Now;
            string query = $"SELECT * FROM Request WHERE Date > '{currentDate}'  order by Price ASC;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getUpcomingReqHtoL()
        {
            DateTime currentDate = DateTime.Now;
            string query = $"SELECT * FROM Request WHERE Date > '{currentDate}'  order by Price DESC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAlreadyDoneLtoHReq()
        {
            DateTime currentDate = DateTime.Now;
            string query = $"SELECT * FROM Request WHERE Date < '{currentDate}'  order by Price ASC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAlreadyDoneHtoLReq()
        {
            DateTime currentDate = DateTime.Now;
            string query = $"SELECT * FROM Request WHERE Date < '{currentDate}'  order by Price DESC;";
            return dbMan.ExecuteReader(query);
        }

        public int getMaxPrice()
        {
            string query = $"SELECT MAX(Price) FROM Request ";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getMinPrice()
        {
            string query = $"SELECT Min(Price) FROM Request ";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getAvgPrice()
        {
            string query = $"SELECT AVG(Price) FROM Request ";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public DataTable getPriceLtoHEnt()
        {
            string query = $"Select * from Entertainers order by Price_Per_Hour ASC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getPriceHtoLEnt()
        {
            string query = $"Select * from Entertainers order by Price_Per_Hour DESC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getMinEntPriceDT()
        {
            string query = $"select Type , MIN(Price_Per_Hour) as Price from Entertainers group by Type order by Price asc;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getMaxEntPriceDT()
        {
            string query = $"select Type , MAX(Price_Per_Hour) as Price from Entertainers group by Type order by Price asc;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAvgEntPriceDT()
        {
            string query = $"select Type , AVG(Price_Per_Hour) as Price from Entertainers group by Type order by Price asc;";
            return dbMan.ExecuteReader(query);
        }

        public int GetTotalPriceReq()
        {
            string query = $"select sum(price) from Request;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getAvgEntPrice()
        {
            string query = "select AVG(Price_Per_Hour) as Price from Entertainers ;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getMinEntPrice()
        {
            string query = "select MIN(Price_Per_Hour) as Price from Entertainers ;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getMaxEntPrice()
        {
            string query = "select MAX(Price_Per_Hour) as Price from Entertainers ;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public DataTable getHallCapHtoL()
        {
            string query = "select * from HallProvider order by Capacity DESC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getHallCapLtoH()
        {
            string query = "select * from HallProvider order by Capacity ASC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getHallSizeLtoH()
        {
            string query = "select * from HallProvider order by Size ASC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getHallSizeHtoL()
        {
            string query = "select * from HallProvider order by Size DESC;";
            return dbMan.ExecuteReader(query);
        }

        public int getHallSizeMaxAdmin()
        {
            string query = "select max(size) from HallProvider;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }
        public int getHallSizeMinAdmin()
        {
            string query = "select min(size) from HallProvider;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }
        public int getHallSizeAvgAdmin()
        {
            string query = "select avg(size) from HallProvider;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getHallCapMaxAdmin()
        {
            string query = "select max(Capacity) from HallProvider;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public int getHallCapMinAdmin()
        {
            string query = "select min(Capacity) from HallProvider;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }
        public int getHallCapAvgAdmin()
        {
            string query = "select avg(Capacity) from HallProvider;";
            return Convert.ToInt32(dbMan.ExecuteScalar(query));
        }

        public DataTable GetTransRatingLtoH()
        {

            string query = "select *  from Transportation order by Rating asc;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetTransRatingHtoL()
        {

            string query = "select *  from Transportation order by Rating DESC;";
            return dbMan.ExecuteReader(query);
        }

        //public DataTable getStatusEnt(int id)
        //{
        //    string query = $"SELECT Type from EntertainmentRequest where EntertainersID = {id};";
        //    return dbMan.ExecuteReader(query);
        //}

        public int deleteEnt(int id, string type)
        {
            string query;
            switch (type)
            {
                case "Musician":
                    {
                        query = $"DELETE FROM Musician WHERE EntertainerID = {id}";
                        return dbMan.ExecuteNonQuery(query);
                      
                    }
                case "Florists":
                    query = $"DELETE FROM Florists WHERE EntertainerID = {id}";
                    return dbMan.ExecuteNonQuery(query);
                    
                case "Photographer":
                    query = $"DELETE FROM Photographer WHERE EntertainerID = {id}";
                    return dbMan.ExecuteNonQuery(query);
                    
            }
            return 0;
        }

        public int AddMenuOption(int id, string name ,int price)
        {
            string query = $"insert into MenuOption values ({id},'{name}',{price})";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getCatReq(int id) {
            string query = $"select * from MenuRequests where CatererID = {id}";
            return dbMan.ExecuteReader(query);
        }

        public int changeCatPrice(int id , string name,int price) {
            string query = $"update MenuOption set Price = {price} where CatererID = {id} AND Fname = '{name}'";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable gethallreqid(string v)
        {
            string query = $"SELECT HallID FROM request r WHERE r.ID = '{v}'";

            return dbMan.ExecuteReader(query);

        }

        public DataTable GetEntertainerPriceData(string entertainerId, string requestId)
        {
            string query = $"SELECT e.Price_Per_Hour * DATEDIFF(HOUR, CAST(r.StartTime AS DATETIME), CAST(r.EndTime AS DATETIME)) AS TotalCost " +
                           "FROM EntertainmentRequest er " +
                           "JOIN Entertainers e ON er.EntertainersID = e.ID " +
                           "JOIN Request r ON r.ID = er.RequestID " +
                           $"WHERE e.ID = '{entertainerId}' AND r.ID = '{requestId}'";


            // Execute the query and load the result into the DataTable
            return dbMan.ExecuteReader(query);





        }
        public DataTable calcpricefood(string catererId, string foodMenu, string requestId)
        {
            string query = $"SELECT m.Price * mr.Quantity FROM MenuRequests mr, MenuOption m, Request r WHERE mr.RequestID = r.ID AND r.ID = '{requestId}' AND m.Fname = '{foodMenu}' AND m.CatererID = '{catererId}'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable calcpricetransport(string transportationId, string requestId)
        {
            string query = $"SELECT t.price " +
                           $"FROM Transportation t, transportaionrequest tr, request r " +
                           $"WHERE tr.requestid = r.ID " +
                           $"AND r.id = '{requestId}' " +
                           $"AND t.Id = '{transportationId}'";
            return dbMan.ExecuteReader(query);
        }

        public int modifyprice(int price,int id)
        {
            string query = $"update request \r\nset price='{price}' \r\nwhere id='{id}'";
            return dbMan.ExecuteNonQuery(query);
        }
        public int modifyduepayment(int price, int id)
        {
            string query = $"update request \r\nset duepayment='{price}' \r\nwhere id='{id}'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deductpayment(int reqid, decimal amount)
        {
            string query = $"update request \r\nset duepayment=duepayment-'{amount}' \r\nwhere id='{reqid}'";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getCatMenu(int id)
        {
            string query = $"select* from MenuOption where CatererID =  {id}";
            return dbMan.ExecuteReader(query);
        }
    }

}



