namespace MeroTender.Data.Entities;

public class Applicant
{
    public Guid Id { get; set; }

    public required string CompanyName { get; set; }

    public required string CompanyRegNumber { get; set; }

    public required string CompanyAddress { get; set; }

    public required string CompanyPhone { get; set; }

    public required string CompanyEmail { get; set; }

    public required float  BiddingRate { get; set; }

    // One-to-many relation with Project
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}