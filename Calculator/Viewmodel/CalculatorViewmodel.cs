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
        private CalculatorModel _calculatorModel;
        public CalculatorViewmodel()
        {
            _calculatorModel = new CalculatorModel();
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
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 0, Content = "D", Symbol = Symbol.Clear });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 0, Content = "C", Symbol = Symbol.Clear });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 0, Content = "AC", Symbol = Symbol.Clear });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 0, Content = "/" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 1, Content = "7" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 1, Content = "8" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 1, Content = "9" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 1, Content = "*" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 2, Content = "4" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 2, Content = "5" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 2, Content = "6" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 2, Content = "-" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 3, Content = "1" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 3, Content = "2" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 3, Content = "3" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 3, GridRow = 3, Content = "+" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 0, GridRow = 4, Content = "0" });
            Buttons.Add(new ButtonViewmodel { GridColumn = 1, GridRow = 4, Content = "." });
            Buttons.Add(new ButtonViewmodel { GridColumn = 2, GridRow = 4, GridColumnSpan = 2, Content = "=", Symbol= Symbol.Equal });
        }
    }
}
