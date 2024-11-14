using Common.Application;
using Common.Domain.ValueObjects;

namespace Mst.UserManager.Application.UserAgg.UserAddress.AddAddress;

public record AddAddressCommand(
    long UserId,
    string Shire,
    string City,
    string PostalCode,
    string PostalAddress,
    PhoneNumber PhoneNumber,
    string NationalCode) : IBaseCommand;
