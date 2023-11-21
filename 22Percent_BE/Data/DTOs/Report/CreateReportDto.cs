using System.ComponentModel.DataAnnotations;

namespace _22Percent_BE.Data.DTOs.Report
{
    public class CreateReportDto
    {
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public DateTime ToTime { get; set; }
    }
}
