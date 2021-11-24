using System;
using System.Collections.Generic;

namespace ImpisAPI.Application.DTOs
{
    public class PeriodDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public ICollection<IdealWaterParametersDto> IdealParameters { get; set; }
        public ICollection<IdealResultDto> IdealResults{ get; set; }
    }
}