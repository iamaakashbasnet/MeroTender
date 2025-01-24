namespace MeroTender.Data.Entities;

public class Project
{
    public Guid Id { get; set; }

    public required string ProjectName { get; set; }

    public required string ProjectDescription { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}