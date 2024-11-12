using Common.Application;
using Common.Application.SecurityUtil;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.Users.ChangePassword;

public class ChangePasswordCommandHandler : IBaseCommandHandler<ChangePasswordCommand>
{
    public ChangePasswordCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        var currentPasswordHash = Sha256Hasher.Hash(request.CurrentPassword);

        if (user.PasswordHash != currentPasswordHash)
        {
            return OperationResult.Error("کلمه عبور فعلی نامعتبر است");
        }

        var newPasswordHash = Sha256Hasher.Hash(request.NewPassword);

        user.ChangePassword(newPasswordHash);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}
