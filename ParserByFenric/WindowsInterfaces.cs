using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ViewModel;

namespace ParserByFenric
{

    //класс, в котором реализуются интерфейсы
    public class UIServices : IUIServices
    {


        YNC IConfirmInterface.ConfirmFunc(string s)
        {
            MessageBoxResult mes = MessageBox.Show(s, "Требуется подтверждение", MessageBoxButton.YesNoCancel);
            switch (mes)
            {
                case MessageBoxResult.Yes: return YNC.Yes;
                case MessageBoxResult.No: return YNC.No;
                default: return YNC.Cancel;
            }
        }

        string ISaveFileInterface.SaveFileFunc()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "New file",
                    Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*"
                };
                if (saveFileDialog.ShowDialog() == true)
                    return saveFileDialog.FileName;
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK);
                return null;
            }

        }

        List<string> IOpenFileInterface.OpenFileFunc()
        {
            try
            {
                List<string> Input_files = new List<string>();
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    Multiselect = true
                };
                if (openFileDialog.ShowDialog() == true)
                    foreach (string filename in openFileDialog.FileNames)
                        Input_files.Add(filename);
                if (openFileDialog.FileNames.Count() > 1)
                    MessageBox.Show("Файлы успешно добавлены", "", MessageBoxButton.OK);
                else
                    MessageBox.Show("Файл успешно добавлен", "", MessageBoxButton.OK);
                return Input_files;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK);
                return null;
            }
        }

        void IErrorInterface.ErrorFunc()
        {
            MessageBox.Show("", "Непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        void IErrorInterface.ErrorFunc(string s)
        {
            MessageBox.Show(s, "Непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        void IErrorInterface.ErrorFunc(string s1, string s2)
        {
            MessageBox.Show(s1, s2, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public YN SimpleConfirmFunc(string s)
        {
            MessageBoxResult mes = MessageBox.Show(s, "Требуется подтверждение", MessageBoxButton.YesNo);
            switch (mes)
            {
                case MessageBoxResult.Yes: return YN.Yes;
                case MessageBoxResult.No: return YN.No;
                default: return YN.No;
            }
        }
    }
}
