using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Absensi
    {
        public int Id { get; set; }
        public int Karyawan_Id { get; set; }
        public string Karyawan_Name { get; set; }
        public string Tanggal_Hadir { get; set; }
    }
}
