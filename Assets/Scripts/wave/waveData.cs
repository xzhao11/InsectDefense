using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveData : MonoBehaviour
{
    public int numWaves = 5;
    private float[] intensity1;
    private float[] intensity2;
    private float[] intensity3;

    public void Start()
    {
        intensity1 = new float[numWaves];

        for (int i = 0; i < numWaves; i++)
        {
            if ((float)(1 - i * 0.15) > 0)
            {
                intensity1[i] = (float)(1 - i * 0.15);
            }
            else
            {
                intensity1[i] = 0f;
            }
        }

        intensity2 = new float[numWaves];

        for (int j = 0; j < numWaves; j++)
        {
            if ((float)(1 - intensity1[j] - j * 0.05) > 0)
            {
                intensity2[j] = (float)(1 - intensity1[j] - j * 0.05);
            }
            else
            {
                intensity2[j] = 0f;
            }
        }

        intensity3 = new float[numWaves];

        for (int k = 0; k < numWaves; k++)
        {
            if ((float)(1 - intensity1[k] - intensity2[k]) > 0)
            {
                intensity3[k] = (float)(1 - intensity1[k] - intensity2[k]);
            }
            else
            {
                intensity3[k] = 0f;
            }
        }
    }

    public int getNumWaves()
    {
        return numWaves;
    }

    public float getIntensity1(int wave)
    {
        return intensity1[wave];
    }

    public float getIntensity2(int wave)
    {
        return intensity2[wave];
    }

    public float getIntensity3(int wave)
    {
        return intensity3[wave];
    }
}
