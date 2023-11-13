using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.DetailScore
{
    public class DetailScoreUpdateMarkDTO
    {
        public int? Id { get; set; }
        public double? Mark { get; set; }
        public string? Comment { get; set; } = "";
    }
}
