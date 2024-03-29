﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class MandelbrotTerrain : MonoBehaviour
{
    [SerializeField]
    double baseX = -1.75;
    [SerializeField]
    double baseY = 0.0;
    [SerializeField]
    double renderArea = 10.0;

    TerrainData terrainData;

    void Start()
    {
        terrainData = GetComponent<Terrain>().terrainData;
        StartCoroutine(UpdateTerrainCoroutine());
    }

    IEnumerator UpdateTerrainCoroutine()
    {
        var heights = new float[terrainData.heightmapWidth, terrainData.heightmapHeight];

        while (true)
        {
            renderArea *= 0.98;
            var startX = baseX - renderArea / 2.0;
            var startY = baseY - renderArea / 2.0;
            var renderAreaPerWidth = renderArea / terrainData.heightmapWidth;
            var renderAreaPerHeight = renderArea / terrainData.heightmapHeight;

            for (int x = 0; x < terrainData.heightmapWidth; x++)
            {
                for (int y = 0; y < terrainData.heightmapHeight; y++)
                {
                    heights[x, y] = MandelbrotCalculator.Calculate(
                        startX + x * renderAreaPerWidth,
                        startY + y * renderAreaPerHeight);
                }
            }

            terrainData.SetHeights(0, 0, heights);

            yield return null;
        }
    }
}
