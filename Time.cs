using System;

namespace Lab2
{
    /// <summary>
    /// Время суток, заданное числом секунд, прошедших с начала суток.
    /// </summary>
    public class Time
    {
        private const int SecondsInMinute = 60;
        private const int SecondsInHour = 3600;
        private const int SecondsInDay = 86400;

        private int _seconds;

        public Time(int seconds)
        {
            Seconds = seconds;
        }

        public int Seconds
        {
            get
            {
                return _seconds;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Количество секунд не может быть отрицательным.");
                }

                _seconds = value;
            }
        }

        public override string ToString()
        {
            // Учитываем только время, прошедшее с начала последних суток.
            int secondsToday = _seconds % SecondsInDay;

            int hours = secondsToday / SecondsInHour;
            int minutes = (secondsToday % SecondsInHour) / SecondsInMinute;
            int seconds = secondsToday % SecondsInMinute;

            return $"{hours}:{minutes:D2}:{seconds:D2}";
        }
    }
}
