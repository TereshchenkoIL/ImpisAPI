using System;
using System.Collections.Generic;

namespace ImpisAPI.Application.DTOs
{
    public class ReservoirTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SuggestionDto> Suggestions { get; set; }
        public ICollection<IdealResultDto> IdealResults { get; set; }
        public ICollection<ReservoirDto> Reservoirs { get; set; }
    }
}