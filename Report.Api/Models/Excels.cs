using Report.Api.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Report.Api.Models
{
    public class Excels
    {
        [Key]
        public Guid UUID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public FileStatus FileStatus { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
