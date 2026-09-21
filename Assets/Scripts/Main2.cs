using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Main2 : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    public int NumIterations = 1000000;
    public int ArraySize;

    public GameObject Prefab;
    GameObject[] m_gameObjectPool;

    public int[] Array;
    public Vector3[] Position;
    public Vector3[] Direction;
    public float[] Stun;
    public bool[] IsStunned;

    public bool[] BoolMod1Array;
    public bool[] BoolMod2Array;
    public bool[] BoolMod3Array;
    public bool[] BoolMod4Array;
    public bool[] BoolMod5Array;
    public bool[] BoolHalfArray;
    public bool[] RandomArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Array = new int[ArraySize];
        Position = new Vector3[ArraySize];
        Direction = new Vector3[ArraySize];
        Stun = new float[ArraySize];
        IsStunned = new bool[ArraySize];

        BoolMod1Array = new bool[ArraySize];
        BoolMod2Array = new bool[ArraySize];
        BoolMod3Array = new bool[ArraySize];
        BoolMod4Array = new bool[ArraySize];
        BoolMod5Array = new bool[ArraySize];
        BoolHalfArray = new bool[ArraySize];
        RandomArray = new bool[ArraySize];
        m_gameObjectPool = new GameObject[ArraySize];

        for (int i = 0; i < ArraySize; i++)
        {
            Stun[i] = i % 3 == 0 ? 0.0f : 1.0f;
            IsStunned[i] = i % 3 == 0 ? false : true;

            BoolMod1Array[i] = true;
            BoolMod2Array[i] = i % 2 != 0;
            BoolMod3Array[i] = i % 3 != 0;
            BoolMod4Array[i] = i % 4 != 0;
            BoolMod5Array[i] = i % 5 != 0;
            BoolHalfArray[i] = i < ArraySize / 2;
            RandomArray[i] = UnityEngine.Random.value > 0.5f;

            m_gameObjectPool[i] = Instantiate(Prefab);
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
        double time1 = 0.0d;
        double time1b = 0.0d;
        double time2 = 0.0d;
        double time3 = 0.0d;
        double time4 = 0.0d;
        double time5 = 0.0d;
        double time6 = 0.0d;
        double time7 = 0.0d;
        double time8 = 0.0d;

        double time9 = 0.0f;
        double time10 = 0.0d;
        double time11 = 0.0d;

        double arrayTime1 = 0.0d;
        double arrayTime2 = 0.0d;
        double arrayTime3 = 0.0d;
        double arrayTime4 = 0.0d;
        double arrayTime5 = 0.0d;
        double arrayTimeHalf = 0.0d;
        double arrayTimeRandom = 0.0d;

        double gameObjectTime1 = 0.0d;
        double gameObjectTime2 = 0.0d;

        double time = 0.0d;

        for (int t = 0; t < NumIterations; t++)
        {
            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                value += Array[i];
            }
            time1 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i % 1 == 0)
                {
                    value += Array[i];
                }
            }
            time1b += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i % 2 == 0)
                {
                    value += Array[i];
                }
                else
                {
                    value += Array[i];
                }
            }
            time2 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i % 3 == 0)
                {
                    value += Array[i];
                }
                else
                {
                    value += Array[i];
                }
            }
            time3 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i % 4 == 0)
                {
                    value += Array[i];
                }
                else
                {
                    value += Array[i];
                }
            }
            time4 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i % 5 == 0)
                {
                    value += Array[i];
                }
                else
                {
                    value += Array[i];
                }
            }
            time5 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize / 2; i++)
            {
                value += Array[i];
            }
            time6 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                Position[i] += Direction[i] * Stun[i];
            }
            time7 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (IsStunned[i])
                    Position[i] += Direction[i];
            }
            time8 += Time.realtimeSinceStartupAsDouble - time;

            // half
            time = Time.realtimeSinceStartupAsDouble;
            int halfArray = ArraySize / 2;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i < halfArray)
                {
                    value += Array[i];
                }
            }
            time9 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (i < halfArray)
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            time10 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (bValue)
                {
                    value += Array[i];
                }
            }
            time11 += Time.realtimeSinceStartupAsDouble - time;


            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod1Array[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTime1 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod2Array[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTime2 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod3Array[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTime3 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod4Array[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTime4 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolMod5Array[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTime5 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (BoolHalfArray[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTimeHalf += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
            {
                if (RandomArray[i])
                {
                    value += Array[i];
                }
                else
                    value -= Array[i];
            }
            arrayTimeRandom += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
                setGameObjectPos(Vector3.zero, m_gameObjectPool[i]);
            gameObjectTime1 += Time.realtimeSinceStartupAsDouble - time;

            time = Time.realtimeSinceStartupAsDouble;
            for (int i = 0; i < ArraySize; i++)
                setGameObjectPosNullCheck(Vector3.zero, m_gameObjectPool[i]);
            gameObjectTime2 += Time.realtimeSinceStartupAsDouble - time;
        }

        ResultText.text = "";
        ResultText.text += "For loop time: " + time1.ToString("F4") + " seconds\n";
        ResultText.text += "Branching time % 1 " + time1b.ToString("F4") + " seconds " + (time1b / time1).ToString("F2") + "%\n";
        ResultText.text += "Branching time % 2 " + time2.ToString("F4") + " seconds " + (time2 / time1).ToString("F2") + "%\n";
        ResultText.text += "Branching time % 3 " + time3.ToString("F4") + " seconds " + (time3 / time1).ToString("F2") + "%\n";
        ResultText.text += "Branching time % 4 " + time4.ToString("F4") + " seconds " + (time4 / time1).ToString("F2") + "%\n";
        ResultText.text += "Branching time % 5 " + time5.ToString("F4") + " seconds " + (time5 / time1).ToString("F2") + "%\n";
        ResultText.text += "Half loop time: " + time6.ToString("F4") + " seconds\n";
        ResultText.text += "No Branching time: " + time7.ToString("F4") + " seconds\n";
        ResultText.text += "Branching with bool time: " + time8.ToString("F4") + " seconds\n";

        ResultText.text += "i < half: " + time9.ToString("F4") + " seconds\n";
        ResultText.text += "i < half with else: " + time10.ToString("F4") + " seconds\n";
        ResultText.text += "passed value: " + time11.ToString("F4") + " seconds\n";

        ResultText.text += "Array Bool Mod1: " + arrayTime1.ToString("F4") + " seconds\n";
        ResultText.text += "Array Bool Mod2: " + arrayTime2.ToString("F4") + " seconds " + (arrayTime2 / arrayTime1).ToString("F2") + "%\n";
        ResultText.text += "Array Bool Mod3: " + arrayTime3.ToString("F4") + " seconds " + (arrayTime3 / arrayTime1).ToString("F2") + "%\n";
        ResultText.text += "Array Bool Mod4: " + arrayTime4.ToString("F4") + " seconds " + (arrayTime4 / arrayTime1).ToString("F2") + "%\n";
        ResultText.text += "Array Bool Mod5: " + arrayTime5.ToString("F4") + " seconds " + (arrayTime5 / arrayTime1).ToString("F2") + "%\n";
        ResultText.text += "Array Bool Half: " + arrayTimeHalf.ToString("F4") + " seconds " + (arrayTimeHalf / arrayTime1).ToString("F2") + "%\n";
        ResultText.text += "Array Bool Random: " + arrayTimeRandom.ToString("F4") + " seconds " + (arrayTimeRandom / arrayTime1).ToString("F2") + "%\n";

        ResultText.text += "GameObject no null check: " + gameObjectTime1.ToString("F4") + " seconds\n";
        ResultText.text += "GameObject with null check: " + gameObjectTime2.ToString("F4") + " seconds\n";

        return value;
    }

    static void setGameObjectPos(Vector3 pos, GameObject go)
    {
        go.transform.localPosition = pos;
    }

    static void setGameObjectPosNullCheck(Vector3 pos, GameObject go)
    {
        if (go != null)
        {
            go.transform.localPosition = pos;
        }
    }
}
