using Common.Domain;
using Common.Domain.Bases;
using Common.Domain.ValueObjects;

namespace Mst.UserManager.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    #region Properties
    public long UserId { get; internal set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
   
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }
    #endregion

    #region Constructors
    private UserAddress()
    {

    }
    public UserAddress(string shire, string city, string postalCode, string postalAddress,
        PhoneNumber phoneNumber, string nationalCode)
    {
        Guard(shire, city, postalCode, postalAddress,
            phoneNumber,  nationalCode);

        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;     
        NationalCode = nationalCode;
        ActiveAddress = false;
    }
    #endregion

    #region Methods
  
    public void Edit(string shire, string city, string postalCode, string postalAddress,
        PhoneNumber phoneNumber,  string nationalCode)
    {
        Guard(shire, city, postalCode, postalAddress,
             phoneNumber, nationalCode);

        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }

    public void SetDeActive()
    {
        ActiveAddress = false;

    }

    public void Guard(string shire, string city, string postalCode, string postalAddress,
        PhoneNumber phoneNumber,  string nationalCode)
    {
        if (phoneNumber is null)
            throw new NullOrEmptyDomainDataException();

        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
     
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

        if (!IranianNationalIdChecker.IsValid(nationalCode))
            throw new InvalidDomainDataException("کدملی نامعتبر است");
    }

    #endregion
}
