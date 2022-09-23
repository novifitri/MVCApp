using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeeApp.Models;

namespace EmployeeApp.Controllers
{
    public class AbsensiController : Controller
    {
        protected string connectionString = "Data Source =DESKTOP-4UE3BDQ;Initial Catalog=SistemAbsensi;User ID=test;Password=tes123;";

        public IActionResult Index()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT a.Id, k.Nama, a.Tanggal_Hadir " +
                           "FROM Absensi a JOIN Karyawan k " +
                           "ON a.Karyawan_Id= k.Id ";
            SqlCommand command = new SqlCommand(query, cnn);
            List<Absensi> Absensi = new List<Absensi>();

            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Absensi absensi = new Absensi();
                            absensi.Id = Convert.ToInt32(reader[0]);
                            absensi.Karyawan_Name = reader[1].ToString();
                            absensi.Tanggal_Hadir = Convert.ToDateTime(reader[2]).ToShortDateString();
                            Absensi.Add(absensi);
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
            return View(Absensi);
      
        }

        public Absensi GetAbsensiById(int id)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT a.Id, k.Id, k.Nama, a.Tanggal_Hadir " +
                           "FROM Absensi a JOIN Karyawan k " +
                           "ON a.Karyawan_Id= k.Id WHERE a.Id=" + id;
            SqlCommand command = new SqlCommand(query, cnn);
            Absensi absensi = new Absensi();
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    { 
                        while (reader.Read())
                        {
                            absensi.Id = Convert.ToInt32(reader[0]);
                            absensi.Karyawan_Id = Convert.ToInt32(reader[1]);
                            absensi.Karyawan_Name = reader[2].ToString();
                            absensi.Tanggal_Hadir = Convert.ToDateTime(reader[3]).ToShortDateString();
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
            return absensi;
        }

        public IActionResult Details(int id)
        {
            Absensi absensi = GetAbsensiById(id);
            return View(absensi);
        }

        public List<Karyawan> GetKaryawans()
        {
            List<Karyawan> karyawans = new List<Karyawan>();
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Karyawan ";
            SqlCommand command = new SqlCommand(query, cnn);
            List<Absensi> Absensi = new List<Absensi>();

            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Karyawan k = new Karyawan();
                            k.Id = Convert.ToInt32(reader[0]);
                            k.Nama = reader[1].ToString();
                            karyawans.Add(k);
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
            return karyawans;
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<Karyawan> karyawans = GetKaryawans();
            ViewData["AllEmployee"] = karyawans;
            Absensi absensi = GetAbsensiById(id);
            return View(absensi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Absensi absensi)
        {
            List<Karyawan> karyawans = GetKaryawans();
            ViewData["AllEmployee"] = karyawans;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Karyawan_Id";
                sqlParameter1.Value = absensi.Karyawan_Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@Tanggal_Hadir";
                sqlParameter2.Value = absensi.Tanggal_Hadir;

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);

                try
                {
                    sqlCommand.CommandText =
                    "INSERT INTO Absensi " +
                    "(Karyawan_Id, Tanggal_Hadir) " +
                    "VALUES (@Karyawan_Id, @Tanggal_Hadir) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction("Index");
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
                ModelState.AddModelError(string.Empty, "Bad Request");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Karyawan> karyawans = GetKaryawans();
            ViewData["AllEmployee"] = karyawans;
            Absensi absensi = GetAbsensiById(id);
            return View(absensi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Absensi a)
        {
            List<Karyawan> karyawans = GetKaryawans();
            ViewData["AllEmployee"] = karyawans;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Karyawan_Id";
                sqlParameter1.Value = a.Karyawan_Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@Tanggal_Hadir";
                sqlParameter2.Value = a.Tanggal_Hadir;

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);

                try
                {
                    sqlCommand.CommandText =
                    "UPDATE Absensi " +
                    "SET Karyawan_Id=@Karyawan_Id, Tanggal_Hadir=@Tanggal_Hadir " +
                    "WHERE id = " + a.Id;
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction("Index");
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
            ModelState.AddModelError(string.Empty, "Bad Request");
            return View();
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Absensi absensi = GetAbsensiById(id);
            return View(absensi);
        }

        [HttpPost]
        public IActionResult Delete(Absensi a)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "DELETE Absensi WHERE id = " + a.Id;
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction("index");
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
            return View();
        }
    }
}
