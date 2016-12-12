using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MandelbrotCalculator
{
    double exponent = 2.0;
    int maxIteration = 50;
    double threshold = 2.0;

    public MandelbrotCalculator(double exponent, int maxIteration, double threshold)
    {
        this.exponent = exponent;
        this.maxIteration = maxIteration;
        this.threshold = threshold;
    }

    public float Calculate(double baseX, double baseY)
    {
        var x = 0.0;
        var y = 0.0;
        for (int i = 0; i < maxIteration; i++)
        {
            var a = x == 0 ? 0.0 : Math.Atan2(y, x) * exponent;
            var powed = Math.Pow(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)), exponent);
            x = Math.Cos(a) * powed;
            y = Math.Sin(a) * powed;
            x += baseX;
            y += baseY;
            if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) > threshold)
            {
                return (float)i / maxIteration;
            }
        }
        return 1f;
    }
}
