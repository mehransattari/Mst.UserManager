
using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.UserTokens.RemoveToken;

public class RemoveTokenCommandHandler : IBaseCommandHandler<RemoveTokenCommand, string>
{
    private readonly IUserRepository _userRepository;

    public RemoveTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<string>> Handle(RemoveTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdTracking(request.UserId);
        if (user == null)
            return OperationResult<string>.NotFound();

        var token = user.RemoveToken(request.TokenId);
        await _userRepository.Save();
        return OperationResult<string>.Success(token);
    }
}
