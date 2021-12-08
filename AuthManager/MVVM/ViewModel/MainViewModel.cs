using AuthManager.Core;
using System;


namespace AuthManager.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }

        public RelayCommand ResidentsViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public DiscoveryViewModel DiscoveryVM { get; set; }

        public ListOfResidentsViewModel ResidentsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscoveryVM = new DiscoveryViewModel();
            ResidentsVM = new ListOfResidentsViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVM;
            });

            ResidentsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ResidentsVM;
            });
        }
    }
}
