using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Model;

namespace Calculator.Viewmodel
{
    class CalculatorViewmodel:ViewModelBase
    {
        public RelayCommand InsertCmd { get; set; }
        public RelayCommand QueryCmd { get; set; }
        private CalculatorModel _calculatorModel;
        public CalculatorViewmodel()
        {
            _calculatorModel = new CalculatorModel();
            InsertCmd = new RelayCommand(o => Insert());
            QueryCmd = new RelayCommand(o => Query());
            Loadcalculator();
        }
        public string Content
        {
            get { return _calculatorModel.Content; }
            set { _calculatorModel.Content = value; OnPropertyChanged(); }
        }
        public string Preorder
        {
            get { return _calculatorModel.Preorder; }
            set { _calculatorModel.Preorder = value; OnPropertyChanged(); }
        }
        public string Postorder
        {
            get { return _calculatorModel.Postorder; }
            set { _calculatorModel.Postorder = value; OnPropertyChanged(); }
        }
        public string Decimal
        {
            get { return _calculatorModel.Decimal; }
            set { _calculatorModel.Decimal = value; OnPropertyChanged(); }
        }
        public string Binary
        {
            get { return _calculatorModel.Binary; }
            set { _calculatorModel.Binary = value; OnPropertyChanged(); }
        }
        private ObservableCollection<ButtonViewmodel> _buttons;
        public ObservableCollection<ButtonViewmodel> Buttons 
        { 
            get { return _buttons; } 
            set { _buttons = value; OnPropertyChanged(); }
        }

        public void Loadcalculator()
        {
            Buttons = new ObservableCollection<ButtonViewmodel>();
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 0, Content = "D", PressBtn = new RelayCommand(o => Clear()) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 0, Content = "C", PressBtn = new RelayCommand(o => Clear()) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 0, Content = "AC", PressBtn = new RelayCommand(o => Clear()) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 0, Content = "/", PressBtn = new RelayCommand(o=> Print("/")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 1, Content = "7", PressBtn = new RelayCommand(o => Print("7")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 1, Content = "8", PressBtn = new RelayCommand(o => Print("8")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 1, Content = "9", PressBtn = new RelayCommand(o => Print("9")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 1, Content = "*", PressBtn = new RelayCommand(o => Print("*")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 2, Content = "4", PressBtn = new RelayCommand(o => Print("4")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 2, Content = "5", PressBtn = new RelayCommand(o => Print("5")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 2, Content = "6", PressBtn = new RelayCommand(o => Print("6")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 2, Content = "-", PressBtn = new RelayCommand(o => Print("-")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 3, Content = "1", PressBtn = new RelayCommand(o => Print("1")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 3, Content = "2", PressBtn = new RelayCommand(o => Print("2")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 3, Content = "3", PressBtn = new RelayCommand(o => Print("3")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 3, Content = "+", PressBtn = new RelayCommand(o => Print("+")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 4, Content = "0", PressBtn = new RelayCommand(o => Print("0")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 4, Content = ".", PressBtn = new RelayCommand(o => Print(".")) });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 4, GridColumnSpan = 2, Content = "=", PressBtn = new RelayCommand(o => Calculate()) });
        }
        void Print(string str)
        {
            if (Content == "0")
                Content = str;
            else
                Content += str;
        }
        void Clear()
        {
            Content = "0";
        }
        void Calculate()
        {
            Postorder = NotationCoverter.InfixToPostfix(Content);
        }
        void Insert()
        {

        }
        void Query()
        {

        }
    }
}
