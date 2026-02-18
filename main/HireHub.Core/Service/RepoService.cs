using HireHub.Core.Data.Interface;

namespace HireHub.Core.Service;

public class RepoService
{
    public RepoService(IUserRepository userRepository, IUserPermissionRepository userPermissionRepository,
        IRoleRepository roleRepository, ICandidateRepository candidateRepository, 
        IDriveRepository driveRepository, IInterviewRepository interviewRepository)
    {
        UserRepository = userRepository;
        UserPermissionRepository = userPermissionRepository;
        RoleRepository = roleRepository;
        CandidateRepository = candidateRepository;
        DriveRepository = driveRepository;
        InterviewRepository = interviewRepository;
    }

    public IUserRepository UserRepository { get; }
    public IUserPermissionRepository UserPermissionRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ICandidateRepository CandidateRepository { get; }
    public IDriveRepository DriveRepository { get; }
    public IInterviewRepository InterviewRepository { get; }
}
