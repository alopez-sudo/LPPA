using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SuscribeYa
{
	public class Categoria : INotifyPropertyChanged
	{
		public string Nombre { get; set; }

        private bool isCheck;

        public bool IsCheck
        {
            get
            {
                return isCheck;
            }
            set
            {
                if(value != this.isCheck)
                {
                    this.isCheck = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
