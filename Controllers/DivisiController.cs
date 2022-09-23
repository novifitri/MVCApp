using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeeApp.Models;

namespace EmployeeApp.Controllers
{
    public class DivisiController : Controller
    {
        protected string connectionString = "Data Source =DESKTOP-4UE3BDQ;Initial Catalog=SistemAbsensi;User ID=test;Password=tes123;";

        public IActionResult Index()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Divisi";
            SqlCommand command = new SqlCommand(query, cnn);
            List<Divisi> Divisi = new List<Divisi>();

            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Divisi divisi = new Divisi();
                            divisi.Id = Convert.ToInt32(reader[0]);
                            divisi.Nama = reader[1].ToString();
                            Divisi.Add(divisi);
                        }
                    }                  
                    reader.Close();
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            return View(Divisi);
        }

        public IActionResult Details(int id)
        {
            Divisi divisi = getDivisiById(id);
            return View(divisi);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Divisi divisi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Nama";
                sqlParameter1.Value = divisi.Nama;

                sqlCommand.Parameters.Add(sqlParameter1);

                try
                {
                    sqlCommand.CommandText =
                    "INSERT INTO Divisi " +
                    "VALUES (@Nama) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction(actionName: "Index", controllerName: "Divisi");
                }
                catch (SqlException ex)
                {
        
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message); ;
                    }
                }
            }
    
            ModelState.AddModelError(string.Empty, "Nama tidak boleh lebih dari 255 karakter");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Divisi divisi = getDivisiById(id);
            return View(divisi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Divisi divisi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Nama";
                sqlParameter1.Value = divisi.Nama;

                sqlCommand.Parameters.Add(sqlParameter1);

                try
                {
                    sqlCommand.CommandText =
                    "UPDATE Divisi " +
                    "SET Nama= @Nama " +
                    "WHERE Id = " + divisi.Id;
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction(actionName: "Index", controllerName: "Divisi");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message); ;
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Divisi gagal diupdate");
            return View();

        }
        public Divisi getDivisiById(int id)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Divisi WHERE Id = " + id;
            SqlCommand command = new SqlCommand(query, cnn);
            Divisi divisi = new Divisi();
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            divisi.Id = Convert.ToInt32(reader[0]);
                            divisi.Nama = reader[1].ToString();
                        }
                    }
                    reader.Close();
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            return divisi;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Divisi divisi = getDivisiById(id);
            return View(divisi);
        }

        [HttpPost]
        public IActionResult Delete(Divisi divisi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                try
                {
                    sqlCommand.CommandText = "DELETE Divisi WHERE Id = " + divisi.Id;
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction(actionName: "Index", controllerName: "Divisi");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message); ;
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server error");
            return View();
        }
    }
}
