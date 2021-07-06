using System.Windows;
using System.Windows.Input;
using QuizGenerator.Core;
using QuizGenerator.MVVM.View;

namespace QuizGenerator.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CreateViewCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand MoveCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CreateViewModel CreateVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CreateVM = new CreateViewModel();
            CurrentView = HomeVM;

            HomeViewCommand =new RelayCommand((o) =>
            {
                CurrentView = HomeVM;
            });

            CreateViewCommand = new RelayCommand((o) =>
            {
                CurrentView = CreateVM;
            });

            ExitCommand = new RelayCommand((o) =>
            {
                Application.Current.Shutdown();
            });

            MoveCommand = new RelayCommand((o) =>
            {
                var obj = o as UIElement;
                obj.MouseLeftButtonDown += Obj_MouseLeftButtonDown;
            });


        }

        private void Obj_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var o = sender as Window;
                o.DragMove();
            }
        }
    }
}
