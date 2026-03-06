namespace ClockAngle.Services
{
    public class ClockAngleCalculator
    {
        public double Calculate(int hour, int minute)
        {
            if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
                throw new ArgumentException("Invalid time values");

            int normalizedHour = hour % 12;
            double minuteAngle = minute * 6;
            double hourAngle = normalizedHour * 30 + minute * 0.5;

            return hourAngle + minuteAngle;
        }
    }
}
