using Mst.UserManager.Domain.UserAgg.Repository;
using Mst.UserManager.Domain.UserAgg.Services;
namespace Mst.UserManager.Application.UserAgg;

public class UserDomainService : IUserDomainService
{
    public UserDomainService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get;}

    public bool IsEmailExist(string email)
    {
        var isExist = UserRepository.Exists(x=>x.Email == email);
        return isExist;
    }

    public bool PhoneNumberIsExist(string phoneNumber)
    {
        var isExist = UserRepository.Exists(x => x.PhoneNumber == phoneNumber);
        return isExist;
    }
}
