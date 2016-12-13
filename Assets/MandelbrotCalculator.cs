using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MandelbrotCalculator
{
    const int CALCULATE_LIMIT = 50;

    public static float Calculate(double baseX, double baseY)
    {
        double x = 0.0, y = 0.0, cacheX = 0.0, cacheY = 0.0;

        for (int i = 0; i < CALCULATE_LIMIT; i++)
        {
            cacheX = x * x - y * y + baseX;
            cacheY = x * y * 2.0 + baseY;

            if (cacheX * cacheX + cacheY * cacheY > 4.0)
            {
                return (float)i / CALCULATE_LIMIT;
            }

            x = cacheX;
            y = cacheY;
        }
        return 1f;
    }
}
