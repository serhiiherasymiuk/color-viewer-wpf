using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorViewer
{
    internal class MyColor : INotifyPropertyChanged
    {
        private byte a;
        public byte A
        {
            get => a;
            set
            { 
                a = value;
                OnPropertyChanged(nameof(A));
                OnPropertyChanged(nameof(ColorInfo));
            }
        }
        private byte r;
        public byte R
        {
            get => r;
            set
            {
                r = value;
                OnPropertyChanged(nameof(R));
                OnPropertyChanged(nameof(ColorInfo));
            }
        }
        private byte g;
        public byte G
        {
            get => g;
            set
            {
                g = value;
                OnPropertyChanged(nameof(G));
                OnPropertyChanged(nameof(ColorInfo));
            }
        }
        private byte b;
        public byte B
        {
            get => b;
            set
            {
                b = value;
                OnPropertyChanged(nameof(B));
                OnPropertyChanged(nameof(ColorInfo));
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Color ColorInfo => new Color() { A = A, R = R, G = G, B = B };
        public MyColor Clone()
        {
            MyColor color = (MyColor)this.MemberwiseClone();
            color.A = (byte)this.A;
            color.R = (byte)this.R;
            color.G = (byte)this.G;
            color.B = (byte)this.B;
            return color;
        }
    }
}
