using System;

namespace ImpisAPI.Application.DTOs
{
    public class SuggestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public ReservoirTypeDto Type { get; set; }
    }
}