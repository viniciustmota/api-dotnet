using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class VeiculoModel : BaseModel
    {
        private string _placa;
        public string Placa
        {
            get { return _placa; }
            set
            {
                _placa = value;
            }
        }

        private string _modelo;
        public string Modelo
        {
            get { return _modelo; }
            set
            {
                _modelo = value;
            }
        }

        private string _marca;
        public string Marca
        {
            get { return _marca; }
            set
            {
                _marca = value;
            }
        }

        private int _ano;
        public int Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
            }
        }

        private string _cor;
        public string Cor
        {
            get { return _cor; }
            set
            {
                _cor = value;
            }
        }
    }
}