using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBookstore.App_Code;
using MyBookstore.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookstore.Controllers
{
    public class ExperimentController : Controller
    {
        // GET: Experiment
        [HttpGet]
        public ActionResult Index()
        {
            List<AuthorsModels> list = new List<AuthorsModels>();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT ExperimentID, LastName, FirstName, Phone, Address FROM ExpTable";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                var exp = new AuthorsModels();
                                exp.ID = Convert.ToInt32(row["ExperimentID"].ToString());
                                exp.LN = row["LastName"].ToString();
                                exp.FN = row["FirstName"].ToString();
                                exp.Phone = row["Phone"].ToString();
                                exp.Address = row["Address"].ToString();
                                list.Add(exp);
                            }
                        }
                    }
                }
            }
            return View();
        }

        // GET: Experiment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Experiment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experiment/Create
        [HttpPost]
        public ActionResult Create(ExperimentModels exp)
        {
            //try
            //{
            //    // TODO: Add insert logic here
            //
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"INSERT INTO ExpTable VALUES (@ExperimentID, @LastName, @FirstName, @Phone, @Address)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ExperimentID", exp.ID);
                    cmd.Parameters.AddWithValue("@LastName", exp.LN);
                    cmd.Parameters.AddWithValue("@FirstName", exp.FN);
                    cmd.Parameters.AddWithValue("@Phone", exp.Phone);
                    cmd.Parameters.AddWithValue("@Address", exp.Address);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Experiment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) // record is not selected
            {
                return RedirectToAction("Index");
            }

            ExperimentModels exp = new ExperimentModels();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT LastName, FirstName, Phone, Address 
                                FROM ExpTable WHERE ExperimentID=@ExperimentID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ExperimentID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) // record is existing
                        {
                            while (dr.Read())
                            {
                                exp.LN = dr["LastName"].ToString();
                                exp.FN = dr["FirstName"].ToString();
                                exp.Phone = dr["Phone"].ToString();
                                exp.Address = dr["Address"].ToString();
                                
                            }

                            return View(exp);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }

            return View();
        }

        // POST: Experiment/Edit/5
        [HttpPost]
        public ActionResult Edit(ExperimentModels exp)
        {
            //try
            //{
            //    // TODO: Add update logic here
            //
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"UPDATE ExpTable SET LastName=@LastName, FirstName=@FirstName, Phone=@Phone, Address=@Address WHERE ExperimentID=@ExperimentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                         cmd.Parameters.AddWithValue("@LastName", exp.LN);
                         cmd.Parameters.AddWithValue("@FirstName", exp.FN);
                      cmd.Parameters.AddWithValue("@Phone", exp.Phone);
                    cmd.Parameters.AddWithValue("@Address", exp.Address);
                    cmd.Parameters.AddWithValue("@ExperimentID", exp.ID);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Experiment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"DELETE FROM ExpTable
                                WHERE ExperimentID=@ExperimentID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("ExperimentID", id);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");

                }
            }
            return View();
        }

        // POST: Experiment/Delete/5
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
