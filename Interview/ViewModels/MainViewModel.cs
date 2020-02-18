using System;
using System.Globalization;
using System.Windows.Input;
using System.Collections.ObjectModel;

using MvvmHelpers;
using MvvmHelpers.Commands;

using Interview.Models;
using System.Linq;

namespace Interview.ViewModels
{
    public class MainViewModel : BaseViewModel
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

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        private DateTime _año = DateTime.Now;
        public DateTime Año
        {
            get => _año;
            set => SetProperty(ref _año, value);
        }

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }

        private Command saveCommand;
        public ICommand SaveCommand
        {
            get => saveCommand ?? (saveCommand = new Command(SaveWorkflow));
        }

        public MainViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Marca = "Ford",
                    Modelo = "Fiest",
                    Año = Convert.ToDateTime("01/01/2019", CultureInfo.InvariantCulture)
                },
                new Car
                {
                    Marca = "Ford",
                    Modelo = "Fusion",
                    Año = Convert.ToDateTime("01/01/2018", CultureInfo.InvariantCulture)
                },
            };
        }

        private void SaveWorkflow()
        {
            if (string.IsNullOrWhiteSpace(Marca))
            {
                ErrorMessage = "El campo Marca esta vacío.";
                return;
            }
                
            if (string.IsNullOrWhiteSpace(Modelo))
            {
                ErrorMessage = "El campo Modelo esta vacío.";
                return;
            }

            if (Cars.Any(x=>x.Marca == Marca && x.Modelo == Modelo && x.Año.Year == Año.Year))
            {
                ErrorMessage = "Ya se encuentra registrado un Carro con estas caracteristicas.";
                return;
            }

            Cars.Add(new Car
            {
                Año = Año,
                Marca = Marca,
                Modelo = Modelo
            });

            Año = DateTime.Now;
            Marca = string.Empty;
            Modelo = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}