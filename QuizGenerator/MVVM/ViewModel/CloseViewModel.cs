using System.Windows;
using QuizGenerator.Core;

namespace QuizGenerator.MVVM.ViewModel
{
    class CloseViewModel: ObservableObject
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }

        public CloseViewModel()
        {

            CloseCommand = new RelayCommand((o) =>
            {
                Application.Current.Shutdown();
            });

        }

    }
}
