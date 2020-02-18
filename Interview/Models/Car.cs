using System;
using MvvmHelpers;

namespace Interview.Models
{
    public class Car : ObservableObject
    {
        private string _marca;
        public string Marca
        {
            get => _marca;
            set => SetProperty(ref _marca, value);
        }

        private string _modelo;
        public string Modelo
        {
            get => _modelo;
            set => SetProperty(ref _modelo, value);
        }

        private DateTime _año;
        public DateTime Año
        {
            get => _año;
            set => SetProperty(ref _año, value);
        }
    }
}
