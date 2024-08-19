using CollaborativeNotes.Services;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CollaborativeNotes.Views
{
    public partial class EditorWindow : Window
    {
        private readonly DataAccess _dataAccess;

        public EditorWindow(IDataAccess dataAccess)
        {
            InitializeComponent();
            _dataAccess = (DataAccess)dataAccess;

            this.DataContext = _dataAccess;
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Foreground = _dataAccess.myTheme.myColors[0];
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Foreground = _dataAccess.myTheme.myColors[1];
        }
    }
}
