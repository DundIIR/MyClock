

using System.ComponentModel;
using System.Timers;

namespace MyClock
{
    public partial class MainPage : ContentPage
    {
        private ClockViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new ClockViewModel();
            BindingContext = _viewModel;
        }
    }
    public class ClockViewModel : INotifyPropertyChanged
    {
        private double _hourRotation;
        private double _minuteRotation;
        private double _secondRotation;

        public double HourRotation
        {
            get { return _hourRotation; }
            set
            {
                if (_hourRotation != value)
                {
                    _hourRotation = value;
                    OnPropertyChanged("HourRotation");
                }
            }
        }

        public double MinuteRotation
        {
            get { return _minuteRotation; }
            set
            {
                if (_minuteRotation != value)
                {
                    _minuteRotation = value;
                    OnPropertyChanged("MinuteRotation");
                }
            }
        }

        public double SecondRotation
        {
            get { return _secondRotation; }
            set
            {
                if (_secondRotation != value)
                {
                    _secondRotation = value;
                    OnPropertyChanged("SecondRotation");
                }
            }
        }

        public ClockViewModel()
        {
            // Инициализация таймера
            System.Timers.Timer timer = new System.Timers.Timer(1000); // 1000 миллисекунд = 1 секунда
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Обновление углов поворота стрелок в зависимости от текущего времени
            DateTime currentTime = DateTime.Now;
            HourRotation = (currentTime.Hour % 12) * 30; // Каждый час = 30 градусов
            MinuteRotation = currentTime.Minute * 6; // Каждая минута = 6 градусов
            SecondRotation = currentTime.Second * 6; // Каждая секунда = 6 градусов
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}