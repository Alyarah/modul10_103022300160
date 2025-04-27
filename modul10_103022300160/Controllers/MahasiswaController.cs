using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace modul10_103022300160.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Alya Rahmadayani Supriadi", NIM = "103022300160" },
            new Mahasiswa { Nama = "Sheila Nabilla Chantika Yudho", NIM = "103022300099" },
            new Mahasiswa { Nama = "Riyanda Wiesya Bella", NIM = "103022300001" },
            new Mahasiswa { Nama = "Shinta Alya Aulya Ningrum", NIM = "103022300049" }
        };

        [HttpGet]
        public ActionResult<List<Mahasiswa>> Get()
        {
            return daftarMahasiswa;
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
                return NotFound();

            return daftarMahasiswa[index];
        }

        [HttpPost]
        public ActionResult<List<Mahasiswa>> Post([FromBody] Mahasiswa mhs)
        {
            daftarMahasiswa.Add(mhs);
            return Ok("Berhasil ditambahkan");
        }

        [HttpDelete("{index}")]
        public ActionResult<List<Mahasiswa>> Delete(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
                return NotFound();
            daftarMahasiswa.RemoveAt(index);
            return Ok("Berhasil dihapus");
        }

    }
}
