using RAP.Administrator.Domain.Models;
using System;

namespace RAP.Administrator.Domain.Models.Tax
{
    public class TaxAuditEntity
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string? Code { get; set; }
        public string? Dail { get; set; }
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public bool? StatusId { get; set; }
        public string? Browser { get; set; }
        public string? Location { get; set; }
        public string? IP { get; set; }
        public string? OS { get; set; }
        public string? MapURL { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }
    }
}

