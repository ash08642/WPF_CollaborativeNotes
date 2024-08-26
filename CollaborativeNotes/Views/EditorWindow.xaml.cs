using CollaborativeNotes.Services;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CollaborativeNotes.Views
{
    public partial class EditorWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32", SetLastError = true)]
        public static extern void FreeConsole();

        private readonly DataAccess _dataAccess;

        public EditorWindow(IDataAccess dataAccess)
        {
            AllocConsole();
            InitializeComponent();
            _dataAccess = (DataAccess)dataAccess;

            this.DataContext = _dataAccess;
            openTreeBtn.Visibility = Visibility.Collapsed;
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

        private void openTreeBtn_Click(object sender, RoutedEventArgs e)
        {
            openTreeBtn.Visibility = Visibility.Collapsed;
            closeTreeBtn.Visibility = Visibility.Visible;

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = treeContainer.Width;
            animation.To = 170;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(150));
            treeContainer.BeginAnimation(WidthProperty, animation);
        }

        private void closeTreeBtn_Click(object sender, RoutedEventArgs e)
        {
            closeTreeBtn.Visibility = Visibility.Collapsed;
            openTreeBtn.Visibility = Visibility.Visible;

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = treeContainer.Width;
            animation.To = 30;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(150));
            treeContainer.BeginAnimation(WidthProperty, animation);
        }

        private void closeEditorWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maximizeEditorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void minimizeEditorBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
