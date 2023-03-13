namespace CompanyClaimApi.Domain
{
    public class CompanyClaimsDto
    {   
        public int CompanyId { get; set; }

        public string? CompanyName { get; set;}

        public int ClaimId { get; set; }

        public string? UCR { get; set; }
    }
}
