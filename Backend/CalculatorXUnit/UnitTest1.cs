using Domain;
using FluentAssertions;


namespace CalculatorXUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_of_2_and_2_should_be_4()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(2, 2);
            //if (result != 4)
            //    throw new Exception($"The Sum(2,2) was expected but {result} was received");

            result.Should().Be(4);
        }

        [Fact]
        public void Sum_of_2_and_2_should_be_4_v1()
        => new Calculator()
            .Sum(2, 2)
            .Should().Be(4);

    }
}