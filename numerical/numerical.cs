using System;

namespace NumericalIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the degree of the polynomial function:");
            int degree = int.Parse(Console.ReadLine());

            double[] coefficients = new double[degree + 1];
            for (int i = degree; i >= 0; i--)
            {
                Console.WriteLine("Enter the coefficient for x^" + i + ":");
                coefficients[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the lower boundary of the integral:");
            double lowerBound = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the upper boundary of the integral:");
            double upperBound = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of intervals for the integration:");
            int intervals = int.Parse(Console.ReadLine());

            Console.WriteLine("The result of the integration using the Trapezoidal method is: " + TrapezoidalMethod(coefficients, lowerBound, upperBound, intervals));
            Console.WriteLine("The result of the integration using Simpson's method is: " + SimpsonsMethod(coefficients, lowerBound, upperBound, intervals));
            Console.ReadLine();
        }

        static double EvaluateFunction(double[] coefficients, double x)
        {
            double result = 0.0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
            return result;
        }

        static double TrapezoidalMethod(double[] coefficients, double lowerBound, double upperBound, int intervals)
        {
            double h = (upperBound - lowerBound) / intervals;
            double sum = 0.0;

            for (int i = 1; i < intervals; i++)
            {
                sum += EvaluateFunction(coefficients, lowerBound + i * h);
            }

            return h * ((EvaluateFunction(coefficients, lowerBound) + EvaluateFunction(coefficients, upperBound)) / 2 + sum);
        }

        static double SimpsonsMethod(double[] coefficients, double lowerBound, double upperBound, int intervals)
        {
            double h = (upperBound - lowerBound) / intervals;
            double sum1 = 0.0;
            double sum2 = 0.0;

            for (int i = 1; i < intervals; i += 2)
            {
                sum1 += EvaluateFunction(coefficients, lowerBound + i * h);
            }

            for (int i = 2; i < intervals; i += 2)
            {
                sum2 += EvaluateFunction(coefficients, lowerBound + i * h);
            }

            return (h / 3) * (EvaluateFunction(coefficients, lowerBound) + 2 * sum1 + 4 * sum2 + EvaluateFunction(coefficients, upperBound));
        }
    }
}