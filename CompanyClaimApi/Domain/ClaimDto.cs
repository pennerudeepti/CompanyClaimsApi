namespace CompanyClaimApi.Domain
{
    public class ClaimDto
    {
        public int ClaimId { get; set; }

        public string? UCR { get; set; }

        public int CompanyId { get; set; }

        public DateTime ClaimDate { get; set; }

        public DateTime LossDate { get; set; }

        public string? AssuredName { get; set; }

        public decimal IncurredLoss { get; set; }

        public bool Closed { get; set; }

        public int DaysOld { get; set; }

        public string? Type { get; set; }
    }
}
