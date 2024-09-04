using CollaborativeNotes.Helpers;
using CollaborativeNotes.Services;
using CollaborativeNotes.Views;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CollaborativeNotes
{
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32", SetLastError = true)]
        public static extern void FreeConsole();

        private readonly DataAccess _dataAccess;
        private readonly IAbstractFactory<EditorWindow> _editorFactory;

        public MainWindow(IDataAccess dataAccess, IAbstractFactory<EditorWindow> editorFactory)
        {
            //AllocConsole();
            InitializeComponent();
            _dataAccess = (DataAccess)dataAccess;
            this.DataContext = _dataAccess;
            _editorFactory = editorFactory;
            Title = "Hello";
            //dashboardOption.Visibility = Visibility.Collapsed;
        }

        private void invitationsBtn_Click(object sender, RoutedEventArgs e)
        {
            _editorFactory.Create().Show();
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

        private void themeBtn_Click(object sender, RoutedEventArgs e)
        { 
            optionsPanel.Children.Add(new ThemeViewControl());
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = optionsPanel.Height;
            animation.To = 658;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            optionsPanel.BeginAnimation(HeightProperty, animation);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            optionsPanel.Children.RemoveAt(1);
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = optionsPanel.Height;
            animation.To = 0;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            optionsPanel.BeginAnimation(HeightProperty, animation);
        }
    }
}