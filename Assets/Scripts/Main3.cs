using System;
using TMPro;
using UnityEngine;

public class Main3 : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    public int NumIterations = 1000000;
    public int ArraySize;

    public int[] Array;
    public bool[] BoolMod2Array;
    public bool[] RandomArray;

    void Start()
    {
        Array = new int[ArraySize];
        BoolMod2Array = new bool[ArraySize];
        RandomArray = new bool[ArraySize];

        for (int i = 0; i < ArraySize; i++)
        {
            Array[i] = i;
            BoolMod2Array[i] = i % 2 != 0;
            RandomArray[i] = UnityEngine.Random.value > 0.5f;
        }
    }

    public void RunTest()
    {
        int result = branchTest();
        Debug.Log("Result: " + result);
    }

    int branchTest()
    {
        int value = 0;

        double arrayTimeMod2 = 0.0d;
        double arrayTimeRandom = 0.0d;

        double time = 0.0d;

        for (int t = 0; t < NumIterations; t++)
        {
            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod2Array[i])
                    value += Array[i];
                else
                    value -= Array[i];
            }
            arrayTimeMod2 += Time.realtimeSinceStartupAsDouble - time;


            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (RandomArray[i])
                    value += Array[i];
                else
                    value -= Array[i];
            }
            arrayTimeRandom += Time.realtimeSinceStartupAsDouble - time;

            GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
        }

        ResultText.text = "";

        ResultText.text += "Array Bool Mod2: " + arrayTimeMod2.ToString("F4") + " seconds\n";
        ResultText.text += "Array Bool Random: " + arrayTimeRandom.ToString("F4") + " seconds\n";

        return value;
    }
}
