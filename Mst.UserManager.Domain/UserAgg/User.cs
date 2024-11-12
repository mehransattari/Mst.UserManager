using Common.Domain;
using Common.Domain.Bases;
using Mst.UserManager.Domain.UserAgg.Enums;
using Mst.UserManager.Domain.UserAgg.Services;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

namespace Mst.UserManager.Domain.UserAgg;

public class User : AggregateRoot
{
    #region Properties
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime? LastLogin { get; private set; }
    public Gender Gender { get; private set; }

    public List<UserRole> UserRoles { get; private set; } = new();
    public List<UserPermission> UserPermissions { get; private set; } = new();
    public List<UserAddress> Addresses { get; private set; } = new();
    public List<Token> Tokens { get; } = new();

    public string? ProfilePhotoUrl { get; private set; }

    #endregion

    #region Constructors
    public User()
    {

    }

    public User(string firstName, string lastName, string username, string passwordHash,
        string? email, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = false;
    }
    #endregion

    #region User Methods
    public void Guard(string? phoneNumber, string? email, IUserDomainService userDomainService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

        if (!string.IsNullOrWhiteSpace(email) && !email.IsValidEmail())
        {
            throw new InvalidDomainDataException(" ایمیل  نامعتبر است");
        }

        if (phoneNumber != PhoneNumber && userDomainService.PhoneNumberIsExist(phoneNumber))
        {
            throw new InvalidDomainDataException("شماره موبایل تکراری است");
        }

        if (email != Email && userDomainService.IsEmailExist(email))
        {
            throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
   
    public void UpdateProfile(string email, string phoneNumber, string profilePhotoUrl, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);

        Email = email;
        PhoneNumber = phoneNumber;
        ProfilePhotoUrl = profilePhotoUrl;
    }


    public void Edit(string firstName, string lastName, string userName, string? phoneNumber,
        string? email, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        FirstName = firstName;
        LastName = lastName;
        Username = userName;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }

    public void SetIsActive()
    {
        IsActive = true;
    }

    public void SetIsNotActive()
    {
        IsActive = false;
    }

    public void SetLastLogin()
    {
        LastLogin = DateTime.UtcNow;
    }

    public void ChangePassword(string newPassword)
    {
        NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));

        PasswordHash = newPassword;
    }

    public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomainService)
    {
        return new User(string.Empty, string.Empty, string.Empty, password, string.Empty, phoneNumber);
    }

    public void SetProfilePhotoUrl(string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
            imageName = "avatar.png";

        ProfilePhotoUrl = imageName;
    }

    #endregion

    #region UserRoles
    public void SetRoles(List<UserRole> userRoles)
    {
        userRoles.ForEach(x=> x.UserId = Id);
        UserRoles.Clear();
        UserRoles.AddRange(userRoles);
    }
    #endregion

    #region UserPermission
    public void SetPermissions(List<UserPermission> userPermissions)
    {
        userPermissions.ForEach(x => x.UserId = Id);
        UserPermissions.Clear();
        UserPermissions.AddRange(userPermissions);
    }
    #endregion

    #region UserToken
    public void AddToken(string hashJwtToken, string hashRefreshToken,
    DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);

        if (activeTokenCount == 3)
            throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

        var token = new Token(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
        token.UserId = Id;
        Tokens.Add(token);
    }

    public string RemoveToken(long tokenId)
    {
        var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
        if (token == null)
            throw new InvalidDomainDataException("invalid TokenId");

        Tokens.Remove(token);
        return token.HashJwtToken;
    }
    #endregion

    #region UserAddress
    public void AddAddress(UserAddress userAddress)
    {
        userAddress.UserId = Id;
        Addresses.Add(userAddress);
    }

    public void DeleteAddress(long addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);

        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");

        Addresses.Remove(oldAddress);
    }

    public void EditAddress(UserAddress address, long addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);

        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");

        oldAddress.Edit(address.Shire, address.City, address.PostalCode, 
                        address.PostalAddress, address.PhoneNumber,
                        address.NationalCode);
    }

    public void SetActiveAddress(long addressId)
    {
        var currentAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (currentAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");

        foreach (var address in Addresses)
        {
            address.SetDeActive();
        }
        currentAddress.SetActive();
    }
    #endregion
}
