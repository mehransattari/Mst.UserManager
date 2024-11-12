using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Mst.UserManager.Application._Utilities;
using Mst.UserManager.Domain.UserAgg.Repository;
using Mst.UserManager.Domain.UserAgg.Services;

namespace Mst.UserManager.Application.UserAgg.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    public EditUserCommandHandler(
        IUserRepository userRepository,
        IUserDomainService userDomainService,
        IFileService fileService)
    {
        UserRepository = userRepository;
        UserDomainService = userDomainService;
        FileService = fileService;
    }

    private IUserRepository UserRepository { get; }
    private IUserDomainService UserDomainService { get; }
    private IFileService FileService { get; }


    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        var oldProfilePhotoUrl = user.ProfilePhotoUrl;

        user.Edit(request.FirstName, request.LastName, request.Username, request.PhoneNumber,
                  request.Email, request.Gender, UserDomainService);

        if (request.ProfilePhotoUrl != null)
        {
          var imageName =  await FileService.SaveFileAndGenerateName(request.ProfilePhotoUrl,
                                                                     Directories.ProfilePhotoUrl);

            user.SetProfilePhotoUrl(imageName);
        }

        if(oldProfilePhotoUrl is not null && oldProfilePhotoUrl == "avatar.png")
           FileService.DeleteFile(Directories.ProfilePhotoUrl, oldProfilePhotoUrl);

        await UserRepository.Save();

        return OperationResult.Success();

    }
}
