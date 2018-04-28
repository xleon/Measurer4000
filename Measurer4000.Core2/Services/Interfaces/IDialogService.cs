using System;
using Measurer4000.Core.Models;

namespace Measurer4000.Core.Services.Interfaces
{
    public interface IDialogService
    {
        void OpenFileDialog(Action<string> onFileDialogSuccess, Action<Exception> onFileDialogError);
        void CreateDialog(EnumTypeDialog type, string text, string title="");
    }
}
