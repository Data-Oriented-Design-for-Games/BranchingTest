using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BranchTest : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    public int NumIterations = 1000000;
    public int ArraySize;

    public int[] Array;
    public bool[] BoolAlwaysTrueArray;
    public bool[] BoolMod2Array;
    public bool[] BoolHalfArray;
    public bool[] RandomArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Array = new int[ArraySize];
        BoolAlwaysTrueArray = new bool[ArraySize];
        BoolMod2Array = new bool[ArraySize];
        BoolHalfArray = new bool[ArraySize];
        RandomArray = new bool[ArraySize];

        for (int i = 0; i < ArraySize; i++)
        {
            Array[i] = i;
            BoolAlwaysTrueArray[i] = true;
            BoolMod2Array[i] = i % 2 != 0;
            BoolHalfArray[i] = i < ArraySize / 2;
            RandomArray[i] = UnityEngine.Random.value > 0.5f;
        }
    }

    public void RunTest()
    {
        int result = branchTest(true);
        Debug.Log("Result: " + result);
    }

    int branchTest(bool bValue)
    {
        int value = 0;

        double arrayTime1 = 0.0d;
        double arrayTime2 = 0.0d;
        double arrayTimeHalf = 0.0d;
        double arrayTimeRandom = 0.0d;

        double time = 0.0d;

        GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();

        for (int t = 0; t < NumIterations; t++)
        {
            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolAlwaysTrueArray[i])
                    value += Array[i];
                else
                    value -= Array[i];
            }
            arrayTime1 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod2Array[i])
                    value += Array[i];
                else
                    value -= Array[i];
            }
            arrayTime2 += Time.realtimeSinceStartupAsDouble - time;


            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolHalfArray[i])
                    value += Array[i];
                else
                    value -= Array[i];
            }
            arrayTimeHalf += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (RandomArray[i])
                    value += Array[i];
                else
                    value -= Array[i];
            }
            arrayTimeRandom += Time.realtimeSinceStartupAsDouble - time;

        }

        ResultText.text = "";

        ResultText.text += "Array Bool Mod2: " + arrayTime2.ToString("F4") + " seconds " + (arrayTime2 * 100.0f / arrayTime1).ToString("F1") + "%\n";
        ResultText.text += "Array Bool Half: " + arrayTimeHalf.ToString("F4") + " seconds " + (arrayTimeHalf * 100.0f / arrayTime1).ToString("F1") + "%\n";
        ResultText.text += "Array Bool Random: " + arrayTimeRandom.ToString("F4") + " seconds " + (arrayTimeRandom * 100.0f / arrayTime1).ToString("F1") + "%\n";

        return value;
    }
}
