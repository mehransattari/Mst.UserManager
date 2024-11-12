
using Common.Application;
using Common.Application.SecurityUtil;
using Mst.UserManager.Domain.UserAgg;
using Mst.UserManager.Domain.UserAgg.Repository;
using Mst.UserManager.Domain.UserAgg.Services;

namespace Mst.UserManager.Application.UserAgg.Users.RegisterUser;

public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>  
{
    private IUserRepository UserRepository { get; }
    private  IUserDomainService DomainService{ get; }

    public RegisterUserCommandHandler(IUserRepository userRepository, IUserDomainService domainService)
    {
        UserRepository = userRepository;
        DomainService = domainService;
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), DomainService);

        UserRepository.Add(user);
        await UserRepository.Save();
        return OperationResult.Success();
    }
}
