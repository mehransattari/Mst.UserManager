using Common.Application;
using Common.Domain.ValueObjects;


namespace Mst.UserManager.Application.UserAgg.UserAddress.EditAddress;

public record EditAddressCommand(
    long UserId,
    long Id,
    string Shire,
    string City,
    string PostalCode,
    string PostalAddress,
    PhoneNumber PhoneNumber, 
    string NationalCode) : IBaseCommand;
