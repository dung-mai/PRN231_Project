using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class SemesterDTO
    {
        public int Id { get; set; }
        public short? Year { get; set; }
        public string? SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public static implicit operator int(SemesterDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
