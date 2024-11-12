
using Common.Application;
using Common.Domain.ValueObjects;

namespace Mst.UserManager.Application.UserAgg.Users.RegisterUser;

public record RegisterUserCommand(PhoneNumber PhoneNumber, string Password) : IBaseCommand;
