using System;
using System.Collections.Generic;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Application.DTOs
{
    public class ReservoirTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<IdealResultDto> IdealResults { get; set; }
        public ICollection<IdealWaterParametersDto> IdealWaterParameters{ get; set; }
    }
}