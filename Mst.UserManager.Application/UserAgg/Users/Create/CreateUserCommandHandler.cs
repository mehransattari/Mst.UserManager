
using Common.Application;
using Common.Application.SecurityUtil;
using Mst.UserManager.Domain.UserAgg;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.Users.Create;

internal class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = Sha256Hasher.Hash(request.Password);

        var user = new User(request.FirstName, request.LastName, request.Username,
                           passwordHash, request.Email, request.PhoneNumber);

        await UserRepository.AddAsync(user);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}
