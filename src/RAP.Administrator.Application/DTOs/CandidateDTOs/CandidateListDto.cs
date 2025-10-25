namespace RAP.Administrator.Application.DTOs.CandidateDTOs
{
    public class CandidateListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PositionName { get; set; }
        public string TeamName { get; set; }
        public bool IsDefault { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public List<CandidateAuditDto>? Audits { get; set; }
    }
}
