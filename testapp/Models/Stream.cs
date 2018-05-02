using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace testapp
{
    public class Stream : INotifyPropertyChanged
    {
		private int _id;
		private string _path;

        public int id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public string path { get { return _path; } set { _path = value; OnPropertyChanged(); } }
		public bool isEmpty 
        { 
            get  
            {
                return string.IsNullOrEmpty(path);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
