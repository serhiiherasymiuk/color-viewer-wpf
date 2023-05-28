using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ColorViewer
{
    internal class ViewModel
    {
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand clearCommand;
        private ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();
        public IEnumerable<MyColor> Colors => colors;
        public MyColor CurrentColor { get; set; }
        public MyColor SelectedColor { get; set; }
        public ViewModel()
        {
            addCommand = new RelayCommand((o) => AddColor(),(obj) => checkAddButton() != false);
            removeCommand = new RelayCommand((o) => RemoveColor(), (o) => SelectedColor != null);
            clearCommand = new RelayCommand((o) => colors.Clear(), (o) => colors.Any());

            CurrentColor = new MyColor() {A = 255 };
        }
        public ICommand AddCommand => addCommand;
        public ICommand RemoveCommand => removeCommand;
        public ICommand ClearCommand => clearCommand;
        public void RemoveColor()
        {
            if (CurrentColor != null)
                colors.Remove(SelectedColor);
        }
        public void AddColor()
        {
            bool flag = true;
            foreach (MyColor color in colors)
            {
                if(CurrentColor.ColorInfo == color.ColorInfo)
                {
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                colors.Add(CurrentColor.Clone());
            }
        }
        public void Clear()
        {
            if (colors.Any())
                colors.Clear();
        }

        public bool checkAddButton()
        {
            bool flag = true;
            foreach (MyColor color in colors)
            {
                if (CurrentColor.ColorInfo == color.ColorInfo)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
