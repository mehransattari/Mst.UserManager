using Common.Application;
using Microsoft.AspNetCore.Http;
using Mst.UserManager.Domain.UserAgg.Enums;

namespace Mst.UserManager.Application.UserAgg.Users.Edit;

public record EditUserCommand(long UserId,
                              string FirstName,
                              string LastName,
                              string Username,
                              string Password,
                              string? Email,
                              string? PhoneNumber,
                              Gender Gender,
                              IFormFile? ProfilePhotoUrl) : IBaseCommand;
