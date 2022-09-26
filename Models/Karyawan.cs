using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Karyawan
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string NIK { get; set; }
        public string Jenis_Kelamin { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal_Lahir { get; set; }
        public string Alamat { get; set; }
        public string Nomor_Telp { get; set; }
        public Divisi Divisi { get; set; }

        [ForeignKey("Divisi")]
        public int Divisi_Id { get; set; }
    }
}
