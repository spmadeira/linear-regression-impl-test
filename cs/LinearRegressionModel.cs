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

    public static LinearRegressionModel BuildModel(ICollection<(double x, double y)> data)
    {
        (double x, double y) sums = data
            .Aggregate(
                (0d, 0d),
                (m, d) => (m.Item1 + d.x, m.Item2 + d.y));

        (double x, double y) means = (sums.x / data.Count, sums.y / data.Count);

        //Σ(X - X̄)²
        var ssX = data
            .Select(d => (d.x - means.x) * (d.x - means.x))
            .Sum();

        //Σ(X - X̄)(Y - Y̅)
        var sCo = data
            .Select(d => (d.x - means.x) * (d.y - means.y))
            .Sum();

        var slope = sCo / ssX;
        var intercept = means.y - (slope * means.x);

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
}