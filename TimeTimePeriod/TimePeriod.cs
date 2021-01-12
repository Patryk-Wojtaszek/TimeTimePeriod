using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTimePeriod
{
    public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public readonly long _allSeconds;
       // public long Allseconds { get { return _allSeconds; } }
        public long Hours { get => _allSeconds / 3600; }
        public long Minutes { get => _allSeconds % 3600 / 60; }
        public long Seconds { get => _allSeconds % 60; }

        public TimePeriod (long hours, long minutes, long seconds)
        {
            if (hours < 0 || minutes < 0 || minutes >= 60 || seconds < 0 || seconds >= 60)
            {
                throw new ArgumentOutOfRangeException("Źle.");
            }
            _allSeconds = hours * 3600 + minutes * 60 + seconds;
            
        }
        public TimePeriod (long seconds)
        {
            if (seconds <0)
            {
                throw new ArgumentOutOfRangeException("Źle.");
            }
            _allSeconds = seconds;
        }
        public TimePeriod(string dane)
        {
            string[] tabelka = dane.Split(":");
            int a = Convert.ToInt32(tabelka[0]);
            int b = Convert.ToInt32(tabelka[1]);
            int c = Convert.ToInt32(tabelka[2]);
            if (a < 0 || a >= 24 || b < 0 || b >= 60 || c < 0 || c >= 60)
            {
                throw new ArgumentOutOfRangeException("Źle.");
            }
            _allSeconds = a * 3600 + b * 60 + c;
        }
        public TimePeriod (Time t1, Time t2)
        {
            long a = t1._allSeconds;
            long b = t2._allSeconds;

            if (a>b)
            {
                _allSeconds = a - b;
            }
            else
            {
                _allSeconds = b - a;
            }
        }
        public override string ToString() => $"{Hours:D1}:{Minutes:D1}:{Seconds:D1}";
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is TimePeriod tp)
            {
                return Equals(tp);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(TimePeriod other)
        {
            if (this._allSeconds == other._allSeconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CompareTo(TimePeriod other)
        {
            return this._allSeconds.CompareTo(other._allSeconds);
        }

        public static bool operator ==(TimePeriod tp1, TimePeriod tp2) => Equals(tp1, tp2);
        public static bool operator !=(TimePeriod tp1, TimePeriod tp2) => !(Equals(tp1, tp2));
        public static bool operator >(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) > 0;
        public static bool operator >=(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) >= 0;
        public static bool operator <(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) < 0;
        public static bool operator <=(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) <= 0;
        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2) => Plus(tp1, tp2);
        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2) => Minus(tp1, tp2);

        private static TimePeriod Minus(TimePeriod tp1, TimePeriod tp2)
        {
            long a = tp1._allSeconds;
            long b = tp2._allSeconds;
            if (a > b)
            {
                long c = a - b;

                byte hours = (Convert.ToByte(c / 3600));
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new TimePeriod(hours, minutes, seconds);
            }
            else
            {
                long c = b-a; 

                byte hours = (Convert.ToByte(c / 3600));
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new TimePeriod(hours, minutes, seconds);
            }
           
        }

        private static TimePeriod Plus(TimePeriod tp1, TimePeriod tp2)
        {
            long a = tp1._allSeconds;
            long b = tp2._allSeconds;
            long c = a + b;
            byte hours = Convert.ToByte(c / 3600);
            byte minutes = Convert.ToByte(c % 3600 / 60);
            byte seconds = Convert.ToByte(c % 60);
            return new TimePeriod(hours, minutes, seconds);
        }
    }
}
