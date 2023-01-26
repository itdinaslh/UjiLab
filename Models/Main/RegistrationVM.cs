using System.ComponentModel.DataAnnotations;
using UjiLab.Domain.Entities;

namespace UjiLab.Models
{
    public class RegistrationVM
    {
#nullable disable
        public Client Client { get; set; }

        [Required(ErrorMessage = "KTP PIC wajib diupload")]
        public IFormFile KTP { get; set; }

        [Required(ErrorMessage = "Scan file surat kuasa wajib diupload")]
        public IFormFile SuratKuasa { get; set; }

#nullable enable

        public IFormFile? Izin { get; set; }
    }
}
