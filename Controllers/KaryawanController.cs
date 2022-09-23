using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Models;

namespace EmployeeApp.Controllers
{
    public class KaryawanController : Controller
    {
        protected string connectionString = "Data Source =DESKTOP-4UE3BDQ;Initial Catalog=SistemAbsensi;User ID=test;Password=tes123;";
        public IActionResult Index()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT k.Id, k.Nama, k.NIK, k.Jenis_Kelamin, k.Tanggal_Lahir, k.Alamat, k.Nomor_Telp, d.Nama "
                +"FROM Karyawan k JOIN Divisi d "
                + "ON k.Divisi_Id = d.Id ";
            SqlCommand command = new SqlCommand(query, cnn);
            List<Karyawan> karyawans = new List<Karyawan>();
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Karyawan karyawan = new Karyawan();
                            karyawan.Id = Convert.ToInt32(reader[0]);
                            karyawan.Nama = reader[1].ToString();
                            karyawan.NIK = reader[2].ToString();
                            karyawan.Jenis_Kelamin = reader[3].ToString();
                            karyawan.Tanggal_Lahir = Convert.ToDateTime(reader[4]).ToShortDateString();
                            karyawan.Alamat = reader[5].ToString();
                            karyawan.Nomor_Telp = reader[6].ToString();
                            karyawan.Divisi_Name = reader[7].ToString();
                            karyawans.Add(karyawan);
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
            return View(karyawans);
        }

        public Karyawan getKaryawanById(int id)
        {
            Karyawan karyawan = new Karyawan();
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT * FROM karyawan WHERE Id =" + id;
            SqlCommand command = new SqlCommand(query, cnn);
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            karyawan.Id = Convert.ToInt32(reader[0]);
                            karyawan.Nama = reader[1].ToString();
                            karyawan.NIK = reader[2].ToString();
                            karyawan.Jenis_Kelamin = reader[3].ToString();
                            karyawan.Tanggal_Lahir = Convert.ToDateTime(reader[4]).ToShortDateString();
                            karyawan.Alamat = reader[5].ToString();
                            karyawan.Nomor_Telp = reader[6].ToString();
                            karyawan.Divisi_Id = Convert.ToInt32(reader[7]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            return karyawan;
        }
        public IActionResult Details(int id)
        {
            Karyawan karyawan = getKaryawanById(id);
            return View(karyawan);
        }

        public List<Divisi> getAllDivisi()
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
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            return Divisi;
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Divisi> allDivision = getAllDivisi();
            ViewData["AllDivision"] = allDivision;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Karyawan karyawan)
        {
            string error = "";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Nama";
                sqlParameter1.Value = karyawan.Nama;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@NIK";
                sqlParameter2.Value = karyawan.NIK;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@Jenis_Kelamin";
                sqlParameter3.Value = karyawan.Jenis_Kelamin;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@Tanggal_Lahir";
                sqlParameter4.Value = karyawan.Tanggal_Lahir;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@Alamat";
                sqlParameter5.Value = karyawan.Alamat;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@Nomor_Telp";
                sqlParameter6.Value = karyawan.Nomor_Telp;

                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@Divisi_Id";
                sqlParameter7.Value = karyawan.Divisi_Id;

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);

                try
                {
                    sqlCommand.CommandText =
                    "INSERT INTO Karyawan " +
                    "(Nama, NIK, Jenis_Kelamin, Tanggal_Lahir, Alamat, Nomor_Telp, Divisi_Id) " +
                    "VALUES (@Nama, @NIK, @Jenis_Kelamin, @Tanggal_Lahir, @Alamat, @Nomor_Telp, @Divisi_Id) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    error = ex.Message;
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
            List<Divisi> allDivision = getAllDivisi();
            ViewData["AllDivision"] = allDivision;
            ModelState.AddModelError(string.Empty, error);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Karyawan karyawan = getKaryawanById(id);
            List<Divisi> allDivision = getAllDivisi();
            ViewData["AllDivision"] = allDivision;
            return View(karyawan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = karyawan.Id;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Nama";
                sqlParameter1.Value = karyawan.Nama;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@NIK";
                sqlParameter2.Value = karyawan.NIK;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@Jenis_Kelamin";
                sqlParameter3.Value = karyawan.Jenis_Kelamin;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@Tanggal_Lahir";
                sqlParameter4.Value = karyawan.Tanggal_Lahir;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@Alamat";
                sqlParameter5.Value = karyawan.Alamat;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@Nomor_Telp";
                sqlParameter6.Value = karyawan.Nomor_Telp;

                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@Divisi_Id";
                sqlParameter7.Value = karyawan.Divisi_Id;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);

                try
                {
                    sqlCommand.CommandText =
                    "Update Karyawan " +
                    "SET Nama=@Nama, NIK=@NIK, Jenis_Kelamin=@Jenis_Kelamin, Tanggal_Lahir=@Tanggal_Lahir, " +
                    "Alamat=@Alamat, Nomor_Telp=@Nomor_Telp, Divisi_Id=@Divisi_Id " +
                    "WHERE Id = @Id ";
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
            ModelState.AddModelError(string.Empty, "Karyawan gagal diupdate");
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Karyawan karyawan = getKaryawanById(id);
            return View(karyawan);
        }
        [HttpPost]
        public IActionResult Delete(Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = karyawan.Id;
                sqlCommand.Parameters.Add(sqlParameter);
                try
                {
                    sqlCommand.CommandText = "Delete Karyawan Where ID = @id";
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

            ModelState.AddModelError(string.Empty, "Karyawan gagal dihapus");
            return View();
        }
    }
}
