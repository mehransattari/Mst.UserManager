
using Common.Application;
using Mst.UserManager.Domain.UserAgg.Enums;

namespace Mst.UserManager.Application.UserAgg.Users.Create;

public record CreateUserCommand(string FirstName,
                                string LastName,
                                string Username,
                                string Password,
                                string? Email,
                                string? PhoneNumber,
                                Gender Gender) : IBaseCommand;
