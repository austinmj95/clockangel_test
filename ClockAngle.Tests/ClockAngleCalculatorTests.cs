using ClockAngle.Services;

namespace ClockAngle.Tests
{
    public class ClockAngleCalculatorTests
    {
        private readonly ClockAngleCalculator _calculator = new();

        [Theory]
        [InlineData(3, 0, 90)]
        [InlineData(12, 0, 0)]
        [InlineData(6, 0, 180)]
        [InlineData(9, 0, 270)]
        [InlineData(0, 0, 0)]
        [InlineData(15, 0, 90)]
        public void Calculate_OnTheHour_ReturnsCorrectAngle(int hour, int minute, double expected)
        {
            var result = _calculator.Calculate(hour, minute);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 15, 187.5)]
        [InlineData(6, 30, 375)]
        [InlineData(9, 45, 562.5)]
        [InlineData(12, 30, 195)]
        public void Calculate_WithMinutes_ReturnsCorrectAngle(int hour, int minute, double expected)
        {
            var result = _calculator.Calculate(hour, minute);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(24, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 60)]
        public void Calculate_InvalidInput_ThrowsArgumentException(int hour, int minute)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Calculate(hour, minute));
        }
    }
}
