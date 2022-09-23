using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Models;
using System.Data.SqlClient;

namespace EmployeeApp.Controllers
{
    public class ProfileController : Controller
    {
        protected string connectionString = "Data Source =DESKTOP-4UE3BDQ;Initial Catalog=SistemAbsensi;User ID=test;Password=tes123;";

        public IActionResult Index()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT p.Id, p.Username, p.Email, k.Nama "
                           +"FROM Profile p JOIN Karyawan k "
                           +"ON p.Karyawan_Id = k.Id ";
            SqlCommand command = new SqlCommand(query, cnn);
            List<Profile> profiles = new List<Profile>();
            
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Profile profile = new Profile();
                            profile.Id = Convert.ToInt32(reader[0]);
                            profile.Username = reader[1].ToString();
                            profile.Email = reader[2].ToString();
                            profile.Karyawan_Name = reader[3].ToString();
                            profiles.Add(profile);
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
            return View(profiles);
        }

        public Profile GetProfileById(int id)
        {
            Profile profile = new Profile();
            SqlConnection cnn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Profile WHERE id= "+ id;
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
                            profile.Id = Convert.ToInt32(reader[0]);
                            profile.Username = reader[1].ToString();
                            profile.Email = reader[2].ToString();
                            profile.Password = reader[3].ToString();
                            profile.Karyawan_Id = Convert.ToInt32(reader[4]);
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
            return profile;
        }

        public IActionResult Details(int id)
        {
            Profile profile = GetProfileById(id);
            return View(profile);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            Profile profile = GetProfileById(id);
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profile profile)
        {
            if (profile.Password.Length == 8)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = sqlTransaction;

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@Username";
                    sqlParameter1.Value = profile.Username;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Email";
                    sqlParameter2.Value = profile.Email;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter3.ParameterName = "@Password";
                    sqlParameter3.Value = profile.Password;

                    SqlParameter sqlParameter4 = new SqlParameter();
                    sqlParameter4.ParameterName = "@Karyawan_Id";
                    sqlParameter4.Value = profile.Karyawan_Id;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);
                    sqlCommand.Parameters.Add(sqlParameter4);

                    try
                    {
                        sqlCommand.CommandText =
                        "INSERT INTO Profile " +
                        "(Username, Email, Password, Karyawan_Id) " +
                        "VALUES (@Username, @Email, @Password, @Karyawan_Id) ";
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                        return RedirectToAction(actionName: "Index");
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
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Password harus 8 karakter");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Profile profile = GetProfileById(id);
            return View(profile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Profile profile)
        {
            if (profile.Password.Length == 8)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = sqlTransaction;

                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Id";
                    sqlParameter.Value = profile.Id;

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@Username";
                    sqlParameter1.Value = profile.Username;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@Email";
                    sqlParameter2.Value = profile.Email;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter3.ParameterName = "@Password";
                    sqlParameter3.Value = profile.Password;

                    SqlParameter sqlParameter4 = new SqlParameter();
                    sqlParameter4.ParameterName = "@Karyawan_Id";
                    sqlParameter4.Value = profile.Karyawan_Id;

                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);
                    sqlCommand.Parameters.Add(sqlParameter4);

                    try
                    {
                        sqlCommand.CommandText =
                        "UPDATE Profile " +
                        "SET Username=@Username, Email=@Email, Password=@Password, Karyawan_id=@Karyawan_Id " +
                        "WHERE Id = @id ";
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                        return RedirectToAction(actionName: "Index");

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
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Password harus 8 karakter");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Profile profile = GetProfileById(id);
            return View(profile);
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Profile profile)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = profile.Id;
                sqlCommand.Parameters.Add(sqlParameter);
                try
                {
                    sqlCommand.CommandText = "Delete Profile Where ID = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return RedirectToAction(actionName: "Index");

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
