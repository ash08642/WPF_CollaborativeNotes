using CollaborativeNotes.Helpers;
using CollaborativeNotes.Services;
using CollaborativeNotes.Views;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CollaborativeNotes
{
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32", SetLastError = true)]
        public static extern void FreeConsole();

        private readonly IDataAccess _dataAccess;
        private readonly IAbstractFactory<EditorWindow> _editorFactory;

        public MainWindow(IDataAccess dataAccess, IAbstractFactory<EditorWindow> editorFactory)
        {
            InitializeComponent();
            _dataAccess = dataAccess;
            _editorFactory = editorFactory;
            Title = "Hello";
            AllocConsole();
        }

        private void newFileBtn_Click(object sender, RoutedEventArgs e)
        {
            _editorFactory.Create().Show();
        }
    }
}