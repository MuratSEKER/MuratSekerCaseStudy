using Microsoft.AspNetCore.Http;
using MuratSekerCaseStudy.Validations;

namespace MuratSekerCaseStudy.Models
{
    public class HotelFile 
    {
        [ValidateFile(ErrorMessage = "Please select a file to upload")]
        public IFormFile FileToUpload { get; set; }
        public int SelectedFileStorageType { get; set; }
        public int SelectedSortGroup { get; set; }
    }
}
