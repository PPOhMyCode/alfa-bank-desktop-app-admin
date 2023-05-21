using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.Models;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using ExcelDataReader;
using Microsoft.Win32;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class UploadUsersFileVM: BaseVM
{
    
    public RelayCommand UploadUsersCommand{ protected set; get; }
    public RelayCommand UploadChildrensCommand{ protected set; get; }
    private DataSet ds;
    public UploadUsersFileVM()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        UploadUsersCommand = new RelayCommand(UploadUsers);
    }

    private void UploadUsers(object param)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";
        if(openFileDialog.ShowDialog()!=true)
            return;
        var extension = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.'));
        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
        {
            IExcelDataReader reader;

            reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true 
                }
            };

            var dataSet = reader.AsDataSet(conf);
            var dataTable = dataSet.Tables[0];
            
            foreach (DataRow row in dataTable.Rows)
            {
                var a = row[0];
            }
        }
    }
}