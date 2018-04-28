using System;
using System.Windows;
using Measurer4000.Core.Models;
using Measurer4000.Core.Services.Interfaces;
using Microsoft.Win32;

namespace Measurer4000.Services
{
    public class FileDialogService : IDialogService
    {
        public void OpenFileDialog(Action<string> onFileDialogSuccess, Action<Exception> onFileDialogError)
        {
            try
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Solution Files (*.sln)|*.sln";

                if (fileDialog.ShowDialog() == true)
                {
                    onFileDialogSuccess?.Invoke(fileDialog.FileName);
                }
            }
            catch(Exception e)
            {
                CreateDialog(EnumTypeDialog.Error, e.Message);
            }
            
        }

        public void CreateDialog(EnumTypeDialog type, string text, string title = "")
        {
            MessageBoxImage messageImage;
            switch (type)
            {
                case EnumTypeDialog.Information:
                    messageImage = MessageBoxImage.Information;
                    break;
                case EnumTypeDialog.Warning:
                    messageImage = MessageBoxImage.Warning;
                    break;
                default:
                    messageImage = MessageBoxImage.Error;
                    break;
            }
            MessageBox.Show(text, title, MessageBoxButton.OK, messageImage);
        }
    }
}
