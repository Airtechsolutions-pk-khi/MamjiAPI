using MamjiAPI.Models;
using MamjiAPI.Models.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebAPICode.Helpers;


namespace MamjiAPI.Models.BLL
{
    public class loginBLL
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int LicenseID { get; set; }
        public Nullable<bool> DeliveryServices { get; set; }
        public Nullable<double> DeliveryCharges { get; set; }
        public string DeliveryTime { get; set; }
        public Nullable<double> MinOrderAmount { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string Opentime { get; set; }
        public string Closetime { get; set; }
        public string Passcode { get; set; }
        public string Currency { get; set; }
        public Nullable<double> Discounts { get; set; }
        public Nullable<double> Tax { get; set; }
        public Nullable<int> IsPickupAllowed { get; set; }
        public Nullable<int> IsDeliveryAllowed { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public RspAdminLogin login(string Passcode)
        {
            var rsp = new RspAdminLogin();
            try
            {
                var obj = new loginBLL();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@PassCode", Passcode);                
                _ds = (new DBHelper().GetDatasetFromSP)("sp_login",p);
                if (_ds != null)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        obj = _ds.Tables[0].DataTableToList<loginBLL>().FirstOrDefault();
                    }
                }
                return rsp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public int Register()
        //{
        //    try
        //    {
        //        int rtn = 0;
        //        SqlParameter[] p = new SqlParameter[5];
        //        p[0] = new SqlParameter("@FirstName", FirstName);
        //        p[1] = new SqlParameter("@LastName", LastName);
        //        p[2] = new SqlParameter("@Email", Email);
        //        p[3] = new SqlParameter("@Password", Password);
        //        p[4] = new SqlParameter("@ContactNo", ContactNo);
        //        rtn = (new DBHelper().ExecuteNonQueryReturn)("dbo.sp_register", p);

        //        return rtn;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
    }
}