using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Viewmodel
{
    public class QueryViewmodel:ViewModelBase
    {
        public RelayCommand DeleteCmd { get; set; }
        public RelayCommand AddCmd { get; set; }
        private DataBaseModel _selectedData;
        public DataBaseModel SelectedData 
        {
            get { return _selectedData; }
            set { _selectedData = value; OnPropertyChanged(); }
        }
        private ObservableCollection<DataBaseModel> _datas;
        public ObservableCollection<DataBaseModel> Datas
        {
            get { return _datas; }
            set { _datas = value; OnPropertyChanged(); }
        }
        public QueryViewmodel()
        {
            LoadData();
            DeleteCmd = new RelayCommand(o => Delete());
            AddCmd = new RelayCommand(o => Add());
        }
        void LoadData()
        {
            Datas = DBManager.Query();           
        }
        void Delete()
        {
            DBManager.Delete(SelectedData);
            var data = Datas.First(x => x.ID == SelectedData.ID);
            Datas.Remove(data);
            MessageBox.Show("Delete Success");
        }
        void Add()
        {
            DataBaseModel dataBaseViewmodel = new DataBaseModel() { ID = 0, Infix = "213", Prefix = "dwef", Postfix = "dqdqf", Decimal = "dqq", Binary = "qqq" };
            Datas.Add(dataBaseViewmodel);
        }
    }
}
