using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MandelbrotTerrain : MonoBehaviour
{
    double baseX = -1.75;
    double baseY = 0.0;
    double size = 10.0;
    MandelbrotCalculator calculator;

    void Start()
    {
        calculator = new MandelbrotCalculator(2.0, 20, 2.0);
        StartCoroutine(UpdateTerrainCoroutine());
    }

    IEnumerator UpdateTerrainCoroutine()
    {
        while (true)
        {
            size *= 0.98;

            var terrain = GetComponent<Terrain>();
            var terrainData = terrain.terrainData;

            var heights = new float[terrainData.heightmapWidth, terrainData.heightmapHeight];

            for (int y = 0; y < terrainData.heightmapHeight; y++)
            {
                for (int x = 0; x < terrainData.heightmapWidth; x++)
                {
                    var coordinateX = baseX - size / 2.0 + (double)x / terrainData.heightmapWidth * size;
                    var coordinateY = baseY - size / 2.0 + (double)y / terrainData.heightmapHeight * size;
                    heights[x, y] = calculator.Calculate(coordinateX, coordinateY);
                }
            }
            terrainData.SetHeights(0, 0, heights);
            yield return null;
        }
    }
}
