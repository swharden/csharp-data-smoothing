﻿namespace DataSmoothing.Tests;

internal static class Plotting
{
    public static void SaveTestImage(string title, double[] data, double[] smooth, string suffix = "")
    {
        ScottPlot.Plot plot = new();
        double[] xs = ScottPlot.Generate.Consecutive(data.Length);
        var points = plot.Add.ScatterPoints(xs, data);
        points.LegendText = "Original";

        var line = plot.Add.ScatterLine(xs, smooth);
        line.LineWidth = 2;
        line.LegendText = "Smooth";

        plot.ShowLegend(ScottPlot.Alignment.LowerRight);
        plot.Title(title);

        string callerName = new System.Diagnostics.StackTrace().GetFrame(1)!.GetMethod()!.Name;
        plot.SavePng($"{callerName}{suffix}.png", 400, 300).ConsoleWritePath();
    }
}