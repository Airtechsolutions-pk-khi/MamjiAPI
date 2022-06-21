﻿using MamjiAPI.Models;
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
    
    public class navigationBLL
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public int StatusID { get; set; }
        public string ImagePath { get; set; }
        public string CType { get; set; }
        public string CssClass { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public  List<SubCategory> SubCategories = new List<SubCategory>();
        public class SubCategory
        {
            public int SubCategoryID { get; set; }
            public int CategoryID { get; set; }
            public string Title { get; set; }
            public string ArabicTitle { get; set; }
            public int StatusID { get; set; }
            public string ImagePath { get; set; }
            public string CType { get; set; }
        }

        public List<navigationBLL> GetSubCategory()
        {
            try
            {
                List<navigationBLL> Categories = new List<navigationBLL>();
                List<SubCategory> SubCategories = new List<SubCategory>();
                SqlParameter[] p = new SqlParameter[0];
                _ds = (new DBHelper().GetDatasetFromSP)("sp_Navigation", p);
                if (_ds != null)
                {
                    if (_ds.Tables.Count > 0)
                    {

                        if (_ds.Tables[1] != null)
                        {
                            var subCatList = _ds.Tables[1] == null ? new List<SubCategory>() : JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_ds.Tables[1])).ToObject<List<SubCategory>>();
                            var list = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_ds.Tables[0])).ToObject<List<navigationBLL>>();
                            foreach (var _i in list)
                            {
                                SubCategories = new List<SubCategory>();
                                foreach (var _j in subCatList.Where(x => x.CategoryID == _i.CategoryID).ToList())
                                {
                                    SubCategories.Add(new SubCategory
                                    {
                                        CategoryID = _j.CategoryID,
                                        Title = _j.Title,
                                        ArabicTitle = _j.ArabicTitle,
                                        SubCategoryID = _j.SubCategoryID,
                                        StatusID = _j.StatusID,
                                        ImagePath = _j.ImagePath,
                                        //CType = _i.Title == "Balloons" ? "bl" : _i.Title == "Green Life" ? "gl" : _i.Title == "Luxury Wedding" ? "dm" : ""
                                        CType = _i.Title.ToLower() == "balloons" ? "bl" : _i.Title.ToLower() == "green life" ? "gl" : _i.Title.ToLower() == "​wedding​" ? "dm" : ""
                                    });
                                }

                                Categories.Add(new navigationBLL
                                {
                                    CategoryID = _i.CategoryID,
                                    Title = _i.Title,
                                    ArabicTitle = _i.ArabicTitle,
                                    SubCategories = SubCategories,
                                    //CType = _i.Title == "Baloons" ? "bl" : _i.Title == "Green Life" ? "gl" : _i.Title == "Luxury Wedding" ? "dm" : ""
                                    CType = _i.Title.ToLower() == "balloons" ? "bl" : _i.Title.ToLower() == "green life" ? "gl" : _i.Title.ToLower() == "wedding​" ? "dm" : ""
                                    ,CssClass="active"
                                }) ;
                            }

                        }
                        //Subcategory.CategoryList = Category;
                    }
                }
                return Categories;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }

}