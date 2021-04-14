using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

//Modelo de regressão linear usando o método do minimo quadrado (least square)
public class LinearRegressionModel
{
    public double Intercept { get; init; }
    public double Slope { get; init; }

    private LinearRegressionModel(double intercept, double slope)
    {
        Intercept = intercept;
        Slope = slope;
    }

    public static LinearRegressionModel BuildModel(ICollection<(double x, double y)> data, int turns = 10)
    {
        double intercept = 1;
        double slope = 1;

        var currentTurn = 0;
        int direction = 1;
        double step = 1;

        double currentSsr = CalculateSsr(intercept, slope, data);
        double previousSsr;

        //Calculate intercept
        while (currentTurn <= turns){
            intercept += direction*step;
            previousSsr = currentSsr;
            currentSsr = CalculateSsr(intercept, slope, data);

            if (currentSsr > previousSsr){
                direction *= -1;
                step /= 2;
                currentTurn++;
            }
        }

        currentTurn = 0;
        direction = 1;
        step = 1;

        //Calculate slope
        while (currentTurn <= turns){
            slope += direction*step;
            previousSsr = currentSsr;
            currentSsr = CalculateSsr(intercept, slope, data);

            if (currentSsr > previousSsr){
                direction *= -1;
                step /= 2;
                currentTurn++;
            }
        }

        return new LinearRegressionModel(intercept, slope);
    }

    public double Predict(double value)
    {
        return value * Slope + Intercept;
    }

    public IEnumerator<double> Predict(IEnumerable<double> values)
    {
        using var enumerator = values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            yield return Predict(enumerator.Current);
        }
    }

    private static double CalculateSsr(double i, double s, ICollection<(double x, double y)> data){
        var squareResiduals = new List<double>();

        foreach((double x, double y) in data){
            var predicted = (s*x + i);
            var actual = y;
            var squareResidual = Math.Pow(predicted-actual, 2);
            squareResiduals.Add(squareResidual);
        }

        return squareResiduals.Sum();
    }
}