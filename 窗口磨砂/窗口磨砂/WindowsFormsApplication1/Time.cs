﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time()
        {
            this.hours = 0;
            this.minutes = 0;
            this.seconds = 0;
        }
        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public void SetHours(int hours)
        {
            this.hours = hours;
        }
        public void SetMinutes(int minutes)
        {
            this.minutes = minutes;
        }
        public void SetSeconds(int seconds)
        {
            this.seconds = seconds;
        }
        public int GetHours()
        {
            return this.hours;
        }
        public int GetMinutes()
        {
            return this.minutes;
        }
        public int GetSeconds()
        {
            return this.seconds;
        }
        public static Time operator ++(Time time)
        {
            time.seconds++;
            if (time.seconds >= 60)
            {
                time.minutes++;
                time.seconds = 0;
                if (time.minutes >= 60)
                {
                    time.hours++;
                    time.minutes = 0;
                    time.seconds = 0;
                    if (time.hours >= 24)
                    {
                        time.hours = 0;
                        time.minutes = 0;
                        time.seconds = 0;
                    }
                }
            }
            return new Time(time.hours, time.minutes, time.seconds);
        }
    }
}
