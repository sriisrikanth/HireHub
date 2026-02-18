using HireHub.Core.Data.Models;
using HireHub.Shared.Common.Models;

namespace HireHub.Core.DTO;

public class Response<T> : BaseResponse where T : class
{
    public T? Data { get; set; } = null;
}

public class AdminDashboardDetails
{
    public int TotalUsers { get; set; }
    public int TotalCandidates { get; set; }
    public int TotalPanelMembers { get; set; }
    public int TotalMentors { get; set; }
    public int TotalHrs { get; set; }
    public int TotalInterviews { get; set; }
    public int TotalCandidatesHired { get; set; }
    public int TotalCandidatesRejected { get; set; }
}

public class UserDTO
{
    public int UserId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public string RoleName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class CandidateDTO
{
    public int CandidateId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Address { get; set; }
    public string? College { get; set; }
    public string? PreviousCompany { get; set; }
    public string CandidateExperienceLevel { get; set; } = null!;
    public List<string> TechStack { get; set; } = [];
    public string? ResumeUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class DriveDTO
{
    public int DriveId { get; set; }
    public string DriveName { get; set; } = null!;
    public DateTime DriveDate { get; set; }
    public int TechnicalRounds { get; set; }
    public string DriveStatus { get; set; } = null!;
    public string CreatorName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
}

public class DriveCandidateDTO
{
    public int DriveCandidateId { get; set; }
    public int CandidateId { get; set; }
    public int DriveId { get; set; }
    public string CandidateStatus { get; set; } = null!;
    public int? StatusSetBy { get; set; }
}

public class HrDTO
{
    public int UserId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public string RoleName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public List<DriveDTO> CreatedDrives { get; set; } = [];
    public List<DriveDTO> ParticipatedDrives { get; set; } = [];
    public List<DriveCandidateDTO> RecruitedCandidates { get; set; } = [];
}

public class RoundDTO
{
    public int RoundId { get; set; }
    public int DriveCandidateId { get; set; }
    public int InterviewerId { get; set; }
    public string Type { get; set; } = null!;
    public string RoundStatus { get; set; } = null!;
    public string RoundResult { get; set; } = null!;
}

public class DriveDTOForCandidate
{
    public int DriveId { get; set; }
    public string DriveName { get; set; } = null!;
    public DateTime DriveDate { get; set; }
    public int TechnicalRounds { get; set; }
    public string DriveStatus { get; set; } = null!;
    public string CreatorName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public List<RoundDTO> Rounds { get; set; } = [];
    public string CandidateStatus { get; set; } = null!;
}

public class CandidateCompleteDetailsDTO
{
    public int CandidateId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Address { get; set; }
    public string? College { get; set; }
    public string? PreviousCompany { get; set; }
    public string CandidateExperienceLevel { get; set; } = null!;
    public List<string> TechStack { get; set; } = [];
    public string? ResumeUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<DriveDTOForCandidate> Drives { get; set; } = [];
}