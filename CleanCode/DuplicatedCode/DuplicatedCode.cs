
using System;

namespace CleanCode.DuplicatedCode {
    public class Time {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public Time(int hours, int minutes) {
            Hours = hours;
            Minutes = minutes;
        }

        public static Time GetTime(string str) {
            int time;
            var hours = 0;
            var minutes = 0;
            if (!String.IsNullOrWhiteSpace(str) && Int32.TryParse(str.Replace(":", ""), out time)) {
                hours = time / 100;
                minutes = time % 100;
            } else
                throw new ArgumentNullException(nameof(str));
            if (hours > 24 || hours < 0 || minutes > 59 || minutes < 0) {
                throw new ArgumentException();
            }
            return new Time(hours, minutes);
        }
    }

    class DuplicatedCode {
        public void AdmitGuest(string name, string admissionDateTime) {
            // Some logic 
            // ...

            var time = Time.GetTime(admissionDateTime);
            var hours = time.Hours;
            var minutes = time.Minutes;

            // Some more logic 
            // ...
            if (hours < 10) {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime) {
            // Some logic 
            // ...

            var time = Time.GetTime(admissionDateTime);
            var hours = time.Hours;
            var minutes = time.Minutes;

            // Some more logic 
            // ...
            if (hours < 10) {

            }
        }
    }
}
