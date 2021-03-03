using System;

namespace Api.Domain.Models
{
    public class CepModel
    {
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = string.IsNullOrEmpty(value) ? "S/N" : value;
            }
        }

        private Guid _cityId;
        public Guid CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }

    }
}