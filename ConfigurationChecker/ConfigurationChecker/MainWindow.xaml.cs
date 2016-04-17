using System.Windows;
using ConfigurationChecker.Controller;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ConfigurationChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog folderPickerDialog = new CommonOpenFileDialog("Select Folder");
            folderPickerDialog.IsFolderPicker = true;
            CommonFileDialogResult folderDialogResult = folderPickerDialog.ShowDialog(this);
            if(folderDialogResult == CommonFileDialogResult.Ok)
            {
                string directoryName = folderPickerDialog.FileName;
                string pattern = @"^.*\.(dll)$";
                DataHandler dataHandler = new DataHandler();
                dataHandler.Update(directoryName, pattern);
                DataGridContent.DataContext = dataHandler;
                DataGridContent.ItemsSource = dataHandler.Content;
            }
        }
    }
}
