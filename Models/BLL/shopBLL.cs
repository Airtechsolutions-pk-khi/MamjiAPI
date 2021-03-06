using MamjiAPI.Models;
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
    public class shopBLL
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public double? Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public double? Barcode { get; set; }
        public bool? InStock { get; set; }
        public string Image { get; set; }
        public string HoveredImage { get; set; }
        public int? StatusID { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsFeatured { get; set; }
        public int? StockQty { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public int? Row_Counter { get; set; }
        public int? Stars { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public List<shopBLL> GetAll(string Category)
        {
            try
            {
                var lst = new List<shopBLL>();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Category", Category);
                _dt = (new DBHelper().GetTableFromSP)("sp_GetshopList",p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<shopBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<shopBLL> BestProducts()
        {
            try
            {
                var lst = new List<shopBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetBestProducts");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<shopBLL>>(); 
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}