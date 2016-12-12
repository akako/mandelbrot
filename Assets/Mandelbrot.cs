using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mandelbrot : MonoBehaviour
{
    [SerializeField]
    float _Exponent = 2f;
    [SerializeField]
    int _MaxIteration = 16;
    [SerializeField]
    float _Threshold = 2f;

    [SerializeField]
    Transform container;
    [SerializeField]
    GameObject prefab;

    void Update()
    {
        for (var i = 0; i < 1000; i++)
        {
            var obj = Instantiate(prefab);
            var pos2d = new Vector2(0.00001f * UnityEngine.Random.Range(-200000, 200000), 0.00001f * UnityEngine.Random.Range(-200000, 200000));
            float mandelbrotResult = mandelbrot(pos2d);
            if (mandelbrotResult == 0f)
            {
                continue;
            }
            obj.GetComponent<Renderer>().material.color = new Color(mandelbrotResult, 0f, 1f - mandelbrotResult);
            obj.transform.position = new Vector3(pos2d.x, pos2d.y, mandelbrotResult);
            obj.transform.SetParent(container);
        }
    }

    // 複素数の積
    Vector2 cmul(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x * b.x - a.y * b.y, a.x * b.y + a.x * b.y);
    }

    // 複素数の累乗
    Vector2 cpow(Vector2 v, float p)
    {
        float a = v.x == 0 ? 0 : (float)Math.Atan2(v.y, v.x) * p;
        return new Vector2((float)Math.Cos(a), (float)Math.Sin(a)) * (float)Math.Pow(v.magnitude, p);
    }

    // マンデルブロ集合を計算
    float mandelbrot(Vector2 c)
    {
        Vector2 z = Vector2.zero;
        for (int i = 0; i < _MaxIteration; i++)
        {
            z = cpow(z, _Exponent);
            z += c;
            if (z.magnitude > _Threshold)
            {
                return (float)i / _MaxIteration;
            }
        }
        return 1f;
    }
}
