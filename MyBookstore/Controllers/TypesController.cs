using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBookstore.App_Code;
using System.Data;
using System.Data.SqlClient;
using MyBookstore.Models;

namespace MyBookstore.Controllers
{
    public class TypesController : Controller
    {
        // GET: Types
        [HttpGet]
        public ActionResult Index()
        {
            List<TypesModels> list = new List<TypesModels>();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT typeID, typeName FROM types";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                var type = new TypesModels();
                                type.ID = Convert.ToInt32(row["typeID"].ToString());
                                type.Name = row["typeName"].ToString();
                                list.Add(type);
                            }
                        }
                    }
                }
            }
            return View();
        }

        // GET: Types/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Types/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Types/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Types/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Types/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
