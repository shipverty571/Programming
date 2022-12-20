using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные об адресе. 
    /// </summary>
    public class Address : ICloneable, IEquatable<Address>
    {
        public EventHandler<EventArgs> AddressChanged;

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        private int _index;

        /// <summary>
        /// Страна/регион.
        /// </summary>
        private string _country;

        /// <summary>
        /// Город (населенный пункт).
        /// </summary>
        private string _city;

        /// <summary>
        /// Улица.
        /// </summary>
        private string _street;

        /// <summary>
        /// Номер дома.
        /// </summary>
        private string _building;

        /// <summary>
        /// Номер квартиры/помещения.
        /// </summary>
        private string _apartment;

        /// <summary>
        /// Количество цифр в поле <see cref="Index"/>.
        /// </summary>
        private readonly int _numberDigitsInIndex = 6;

        /// <summary>
        /// Максимальное количество символов в поле <see cref="Country"/>.
        /// </summary>
        private readonly int _maxCountSymbolsInCountry = 50;

        /// <summary>
        /// Максимальное количество символов в поле <see cref="City"/>.
        /// </summary>
        private readonly int _maxCountSymbolsInCity = 50;

        /// <summary>
        /// Максимальное количество символов в поле <see cref="Street"/>.
        /// </summary>
        private readonly int _maxCountSymbolsInStreet = 100;

        /// <summary>
        /// Максимальное количество символов в поле <see cref="Building"/>.
        /// </summary>
        private readonly int _maxCountSymbolsInBuilding = 10;

        /// <summary>
        /// Максимальное количество символов в поле <see cref="Apartment"/>.
        /// </summary>
        private readonly int _maxCountSymbolsInApartment = 10;

        /// <summary>
        /// Создает экземпляр класса <see cref="Address"/>.
        /// </summary>
        public Address()
        {

        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Address"/>.
        /// </summary>
        /// <param name="index">Почтовый индекс. Должен содержать 6 цифр.</param>
        /// <param name="country">Страна/регион. Должно быть не более 50 символов.</param>
        /// <param name="city">Город (населенный пункт). Должно быть не более 50 символов.</param>
        /// <param name="street">Улица. Должно быть не более 100 символов.</param>
        /// <param name="building">Номер дома. Должно быть не более 10 символов.</param>
        /// <param name="apartment">Номер квартиры/помещения. Должно быть не более 10 символов.</param>
        public Address(int index, string country, string city, 
                        string street, string building, string apartment)
        {
            Index = index;
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
        }

        /// <summary>
        /// Возвращает и задает почтовый индекс.
        /// Должен содержать 6 цифр.
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                ValueValidator.AssertStringLength(nameof(Index), value, _numberDigitsInIndex);
                if (_index != value)
                {
                    _index = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задает название страны/региона.
        /// Должно быть не более 50 символов.
        /// </summary>
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Country), value, _maxCountSymbolsInCountry);
                if (_country != value)
                {
                    _country = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задает название города (населенного пункта).
        /// Должно быть не более 50 символов.
        /// </summary>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                ValueValidator.AssertStringOnLength(nameof(City), value, _maxCountSymbolsInCity);
                if (_city != value)
                {
                    _city = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задает название улицы.
        /// Должно быть не более 100 символов.
        /// </summary>
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Street), value, _maxCountSymbolsInStreet);
                if (_street != value)
                {
                    _street = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задает номер дома.
        /// Должно быть не более 10 символов.
        /// </summary>
        public string Building
        {
            get
            {
                return _building;
            }
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Building), value, _maxCountSymbolsInBuilding);
                if (_building != value)
                {
                    _building = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задает номер квартиры/помещения.
        /// Должно быть не более 10 символов.
        /// </summary>
        public string Apartment
        {
            get
            {
                return _apartment;
            }
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Apartment), value, _maxCountSymbolsInApartment);
                if (_apartment != value)
                {
                    _apartment = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public object Clone()
        {
            Address newAddress = new Address();
            newAddress.Index = Index;
            newAddress.Country = Country;
            newAddress.City = City;
            newAddress.Street = Street;
            newAddress.Building = Building;
            newAddress.Apartment = Apartment;
            return newAddress;
        }

        public bool Equals(Address other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return _index == other._index &&
                   _country == other._country &&
                   _city == other._city &&
                   _street == other._street &&
                   _building == other._building &&
                   _apartment == other._apartment;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() &&
                   Equals((Address)obj);
        }

        public static bool operator ==(Address left, Address right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Address left, Address right)
        {
            return !Equals(left, right);
        }
    }
}
