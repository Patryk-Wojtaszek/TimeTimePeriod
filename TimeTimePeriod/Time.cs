using System;
using System.Collections.Generic;
using System.Text;


namespace TimeTimePeriod
{
    public readonly struct Time: IEquatable<Time>, IComparable<Time>
    {
        public readonly long _allSeconds
        {
            get
            {
                return Hours * 3600 + Minutes * 60 + Seconds;
            }
        }
        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get; }
        

        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            if (hours < 0 || hours >= 24 || minutes < 0 || minutes >= 60 || seconds < 0 || seconds >= 60)
            {
                throw new ArgumentOutOfRangeException("Niepoprawny czas.");
            }
          

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;

        }
        public Time(byte hours =0,byte minutes=0)
        {
            if (hours < 0 || hours >= 24 || minutes < 0 || minutes >= 60 )
            {
                throw new ArgumentOutOfRangeException("Niepoprawny czas.");
            }
            Hours = hours;
            Minutes = minutes;
            Seconds = 0;
        }
        public Time(byte hours=0)
        {
            if (hours < 0 || hours >= 24 )
            {
                throw new ArgumentOutOfRangeException("Niepoprawny czas.");
            }
            Hours = hours;
            Minutes = 0;
            Seconds = 0;
        }
        public Time (long _allSeconds)
        {
            if(_allSeconds > 3600*24 || _allSeconds<0)
            {
                throw new ArgumentOutOfRangeException("Niepoprawny czas.");
            }

            Hours = Convert.ToByte(_allSeconds / 3600);
            Minutes = Convert.ToByte(_allSeconds % 3600 / 60);
            Seconds = Convert.ToByte(_allSeconds % 60);
        }

        public Time(string dane)
        {
            string[] tabelka = dane.Split(":");
            byte a = Convert.ToByte(tabelka[0]);
            byte b = Convert.ToByte(tabelka[1]);
            byte c = Convert.ToByte(tabelka[2]);
            if (a < 0 || a >= 24 || b < 0 || b >= 60 || c < 0 || c >= 60)
            {
                throw new ArgumentOutOfRangeException("Niepoprawny czas.");
            }

            Hours = a;
            Minutes = b;
            Seconds = c;
        }
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        public override int GetHashCode()  
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Time time)
            {
                return Equals(time);
            }
            else
            {
                return false;
            }
        }
        public  bool Equals(Time other)
        {
 
          
            if (this._allSeconds==other._allSeconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   
        public int CompareTo(Time other)
        {
            return this._allSeconds.CompareTo(other._allSeconds);
        }
        public static bool operator ==(Time t1, Time t2) => Equals(t1, t2);
        public static bool operator !=(Time t1, Time t2) => !(Equals(t1, t2));
        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2) < 0;
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;
        public static Time operator +(Time t1, Time t2) => Plus(t1, t2);
        public static Time operator + (Time t1, TimePeriod tp1) => Plus(t1, tp1); 
        public static Time operator - (Time t1, Time t2) => Minus(t1, t2);
        public static Time operator -(Time t1, TimePeriod tp1) => Minus(t1, tp1);

        private static Time Minus(Time t1, TimePeriod tp1)
        {
            long a = t1._allSeconds;
            long b = tp1._allSeconds;
            long c = a - b;
            if (c < 3600 * 24)
            {
                byte hours = (Convert.ToByte((c / 3600) + 24));
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);

            }
            else
            {
                byte hours = Convert.ToByte(c / 3600);
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);
            }
        }

        private static Time Minus(Time t1, Time t2)
        {
            long a = t1._allSeconds;
            long b = t2._allSeconds;
            long c = a - b;
            if (c < 3600 * 24)
            {
                byte hours = (Convert.ToByte((c / 3600) + 24));
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);

            }
            else
            {
                byte hours = Convert.ToByte(c / 3600);
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);
            }
        }

        private static Time Plus(Time t1, Time t2)
        {
            long a = t1._allSeconds;
            long b = t2._allSeconds;
            long c = a + b;
            if (c > 3600*24)
            {
                byte hours = (Convert.ToByte((c / 3600)-24));
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);

            }
            else
            {
                 byte hours= Convert.ToByte(c / 3600);
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);
            }
        }
        private static Time Plus(Time t1, TimePeriod tp1)
        {
            long a = t1._allSeconds;
            long b = tp1._allSeconds;
            long c = a + b;
            if (c > 3600 * 24)
            {
                byte hours = (Convert.ToByte((c / 3600) - 24));
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);

            }
            else
            {
                byte hours = Convert.ToByte(c / 3600);
                byte minutes = Convert.ToByte(c % 3600 / 60);
                byte seconds = Convert.ToByte(c % 60);
                return new Time(hours, minutes, seconds);
            }
        }
    }


}
      

