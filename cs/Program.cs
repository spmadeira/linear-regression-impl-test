using System;
using System.IO;
using System.Linq;

var data = File.ReadAllLines("./data.txt");

var parsedData = data.Select(d =>
{
    var values = d.Split(";");
    var x = double.Parse(values[0]);
    var y = double.Parse(values[1]);
    return (x,y);
}).ToList();

var model = LinearRegressionModel.BuildModel(parsedData);
Console.WriteLine($"Prediction for 0.015: {model.Predict(0.015)}");