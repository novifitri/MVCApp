using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Karyawan
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string NIK { get; set; }
        public string Jenis_Kelamin { get; set; }
        public string Tanggal_Lahir { get; set; }
        public string Alamat { get; set; }
        public string Nomor_Telp { get; set; }
        public int Divisi_Id { get; set; }
        public string Divisi_Name { get; set; }
    }
}
