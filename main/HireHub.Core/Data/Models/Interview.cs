using HireHub.Shared.Common.Models;

namespace HireHub.Core.Data.Models;

using System;

public class Interview : BaseEntity
{
    public Interview() : base("interviews")
    {
    }

    public int InterviewId { get; set; }
    public int DriveCandidateId { get; set; }
    public int InterviewerId { get; set; }
    public DateTime InterviewDate { get; set; }

    // Navigation
    public DriveCandidate? DriveCandidate { get; set; }
    public User? Interviewer { get; set; }
    public Feedback? Feedback { get; set; }
}
