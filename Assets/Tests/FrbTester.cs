using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// Runs a set of operations a specific number of times and records their results and the time it took to run them. That data is written as two txt files in the project's root.
/// </summary>
public class FrbTester : MonoBehaviour
{
    public int operationsNumber = 1000000;
    public Dropdown Dropdown;

    string stats = "";
    string results = "";

    void Start()
    {
        //Set all the Methods in the DropDown
        Dropdown.options.Clear();
        foreach (string methodName in Enum.GetNames(typeof(Methods)))
            Dropdown.options.Add(new Dropdown.OptionData(methodName));

        StartCoroutine(RunTestsOnMethod(0));
    }

    IEnumerator RunTestsOnMethod(Methods method)
    {
        //Update display
        Dropdown.value = (int)method;

        float lastUpdateDuration = 0;

        Vector4 vec4Result = default(Vector4);
        Vector3 vec3Result = default(Vector3);
        Vector2 vec2Result = default(Vector2);
#if UNITY_2017_2_OR_NEWER
        Vector3Int vec3IntResult = default(Vector3Int);
        Vector2Int vec2IntResult = default(Vector2Int);
#endif
        Quaternion quatResult = default(Quaternion);
        Color32 color32Result = default(Color32);
        Color colorResult = default(Color);
        float fResult = default(float);
        Bounds boundsResult = default(Bounds);

        for (int k = 0; k < 5; k++)//Multiple iterations to allow warmup
        {
            //Data used in tests
            Vector4 vec4 = new Vector4(5, 20, 3, 17);
            Vector3 vec3 = new Vector3(5, 20, 3);
            Vector2 vec2 = new Vector2(5, 20);
#if UNITY_2017_2_OR_NEWER
            Vector3Int vec3Int = new Vector3Int(5, 20, 3);
            Vector2Int vec2Int = new Vector2Int(5, 20);
#endif
            Color32 color32 = new Color32(5, 20, 3, 17);
            Quaternion quat = Quaternion.identity;
            float f = 0.3f;
#if UNITY_2017_2_OR_NEWER
            int j = 3;
#endif
            Bounds bounds = new Bounds(Vector3.one, Vector3.one);



            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //the actual test
            switch (method)
            {
                case Methods.Vec4Plus:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec4 + vec4; break;
                case Methods.Vec4Minus:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec4 - vec4; break;
                case Methods.Vec4Multiply1:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec4 * f; break;
                case Methods.Vec4Multiply2:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = f * vec4; break;
                case Methods.Vec4UniratyNegeation:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = -vec4; break;
                case Methods.Vec4Division:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec4 / f; break;
                case Methods.Vec4Magnitude:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector4.Magnitude(vec4); break;
                case Methods.Vec4MagnitudeProp:
                    for (int i = 0; i < operationsNumber; i++) fResult = vec4.magnitude; break;
                case Methods.Vec4Normalize:
                    for (int i = 0; i < operationsNumber; i++) vec4.Normalize(); break;
                case Methods.Vec4NormalizeStatic:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = Vector4.Normalize(vec4); break;
                case Methods.Vec4NormalizedProp:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec4.normalized; break;
                case Methods.Vec4Distance:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector4.Distance(vec4, vec4); break;
                case Methods.Vec4Scale:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = Vector4.Scale(vec4, vec4); break;
                case Methods.Vec4LerpUnclamped:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = Vector4.LerpUnclamped(vec4, vec4, f); break;
                case Methods.Vec4Lerp:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = Vector4.Lerp(vec4, vec4, f); break;
                case Methods.Vec4Min:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = Vector4.Min(vec4, vec4); break;
                case Methods.Vec4Max:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = Vector4.Max(vec4, vec4); break;
                case Methods.Vec3Plus:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec3 + vec3; break;
                case Methods.Vec3Minus:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec3 - vec3; break;
                case Methods.Vec3Multiply1:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec3 * f; break;
                case Methods.Vec3Multiply2:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = f * vec3; break;
                case Methods.Vec3UniratyNegeation:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = -vec3; break;
                case Methods.Vec3Division:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec3 / f; break;
                case Methods.Vec3Magnitude:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector3.Magnitude(vec3); break;
                case Methods.Vec3MagnitudeProp:
                    for (int i = 0; i < operationsNumber; i++) fResult = vec3.magnitude; break;
                case Methods.Vec3Normalize:
                    for (int i = 0; i < operationsNumber; i++) vec3.Normalize(); break;
                case Methods.Vec3NormalizeStatic:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.Normalize(vec3); break;
                case Methods.Vec3NormalizedProp:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec3.normalized; break;
                case Methods.Vec3Distance:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector3.Distance(vec3, vec3); break;
                case Methods.Vec3LerpUnclamped:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.LerpUnclamped(vec3, vec3, f); break;
                case Methods.Vec3Lerp:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.Lerp(vec3, vec3, f); break;
                case Methods.Vec3Cross:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.Cross(vec3, vec3); break;
                case Methods.Vec3Scale:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.Scale(vec3, vec3); break;
                case Methods.Vec3Min:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.Min(vec3, vec3); break;
                case Methods.Vec3Max:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = Vector3.Max(vec3, vec3); break;
                case Methods.Vec2Plus:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2 + vec2; break;
                case Methods.Vec2Minus:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2 - vec2; break;
                case Methods.Vec2Multiply1:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2 * f; break;
                case Methods.Vec2Multiply2:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = f * vec2; break;
#if UNITY_2018_1_OR_NEWER
                case Methods.Vec2Multiply3:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2 * vec2; break;
#endif
                case Methods.Vec2UniratyNegeation:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = -vec2; break;
                case Methods.Vec2Division1:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2 / f; break;
#if UNITY_2018_1_OR_NEWER
                case Methods.Vec2Division2:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2 / vec2; break;
#endif
                case Methods.Vec2MagnitudeProp:
                    for (int i = 0; i < operationsNumber; i++) fResult = vec2.magnitude; break;
                case Methods.Vec2Normalize:
                    for (int i = 0; i < operationsNumber; i++) vec2.Normalize(); break;
                case Methods.Vec2NormalizedProp:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec2.normalized; break;
#if UNITY_2018_1_OR_NEWER
                case Methods.Vec2Perpendicular:
                for (int i = 0; i < operationsNumber; i++) vec2Result = Vector2.Perpendicular(vec2); break;
#endif
                case Methods.Vec2Distance:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector2.Distance(vec2, vec2); break;
                case Methods.Vec2LerpUnclamped:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = Vector2.LerpUnclamped(vec2, vec2, f); break;
                case Methods.Vec2Lerp:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = Vector2.Lerp(vec2, vec2, f); break;
                case Methods.Vec2Scale:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = Vector2.Scale(vec2, vec2); break;
                case Methods.Vec2Min:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = Vector2.Min(vec2, vec2); break;
                case Methods.Vec2Max:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = Vector2.Max(vec2, vec2); break;
#if UNITY_2017_2_OR_NEWER
                case Methods.Vec3IntPlus:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = vec3Int + vec3Int; break;
                case Methods.Vec3IntMinus:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = vec3Int - vec3Int; break;
                case Methods.Vec3IntMultiply1:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = vec3Int * vec3Int; break;
                case Methods.Vec3IntMultiply2:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = vec3Int * j; break;
                case Methods.Vec3IntMagnitudeProp:
                    for (int i = 0; i < operationsNumber; i++) fResult = vec3Int.magnitude; break;
                case Methods.Vec3IntDistance:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector3Int.Distance(vec3Int, vec3Int); break;
                case Methods.Vec3IntScale:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = Vector3Int.Scale(vec3Int, vec3Int); break;
                case Methods.Vec3IntMin:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = Vector3Int.Min(vec3Int, vec3Int); break;
                case Methods.Vec3IntMax:
                    for (int i = 0; i < operationsNumber; i++) vec3IntResult = Vector3Int.Max(vec3Int, vec3Int); break;
                case Methods.Vec2IntPlus:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = vec2Int + vec2Int; break;
                case Methods.Vec2IntMinus:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = vec2Int - vec2Int; break;
                case Methods.Vec2IntMultiply1:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = vec2Int * vec2Int; break;
                case Methods.Vec2IntMultiply2:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = vec2Int * j; break;
                case Methods.Vec2IntMagnitudeProp:
                    for (int i = 0; i < operationsNumber; i++) fResult = vec2Int.magnitude; break;
                case Methods.Vec2IntDistance:
                    for (int i = 0; i < operationsNumber; i++) fResult = Vector2Int.Distance(vec2Int, vec2Int); break;
                case Methods.Vec2IntScale:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = Vector2Int.Scale(vec2Int, vec2Int); break;
                case Methods.Vec2IntMin:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = Vector2Int.Min(vec2Int, vec2Int); break;
                case Methods.Vec2IntMax:
                    for (int i = 0; i < operationsNumber; i++) vec2IntResult = Vector2Int.Max(vec2Int, vec2Int); break;
#endif

                case Methods.QuaterMultiply:
                    for (int i = 0; i < operationsNumber; i++) quatResult = quat * quat; break;
                case Methods.Color32LerpUnclamped:
                    for (int i = 0; i < operationsNumber; i++) color32Result = Color32.LerpUnclamped(color32, color32, f); break;
                case Methods.Color32Lerp:
                    for (int i = 0; i < operationsNumber; i++) color32Result = Color32.Lerp(color32, color32, f); break;
                case Methods.ImplicitV2V3:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec3; break;
                case Methods.ImplicitV2V4:
                    for (int i = 0; i < operationsNumber; i++) vec2Result = vec4; break;
                case Methods.ImplicitV3V2:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec2; break;
                case Methods.ImplicitV3V4:
                    for (int i = 0; i < operationsNumber; i++) vec3Result = vec4; break;
                case Methods.ImplicitV4V2:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec2; break;
                case Methods.ImplicitV4V3:
                    for (int i = 0; i < operationsNumber; i++) vec4Result = vec3; break;
                case Methods.ImplicitC32C:
                    for (int i = 0; i < operationsNumber; i++) color32Result = Color.magenta; break;
                case Methods.ImplicitCC32:
                    for (int i = 0; i < operationsNumber; i++) colorResult = color32; break;
                case Methods.BoundsExpandV:
                    for (int i = 0; i < operationsNumber; i++) bounds.Expand(Vector3.one); break;
                case Methods.BoundsExpandF:
                    for (int i = 0; i < operationsNumber; i++) bounds.Expand(1f); break;
                default:
                    throw new ArgumentOutOfRangeException(method.ToString());
            }

            stopWatch.Stop();

            boundsResult = bounds;

            lastUpdateDuration = (float)stopWatch.ElapsedTicks / TimeSpan.TicksPerMillisecond;
        }

        stats += String.Format("{0}\n{1:F1} ms\n", method, lastUpdateDuration);

        string result = "";
        result += vec4Result;
        result += "\n";
        result += vec3Result;
        result += "\n";
        result += vec2Result;
        result += "\n";
#if UNITY_2017_2_OR_NEWER
            result += vec3IntResult;
            result += "\n";
            result += vec2IntResult;
            result += "\n";
#endif
        result += quatResult;
        result += "\n";
        result += color32Result;
        result += "\n";
        result += colorResult;
        result += "\n";
        result += boundsResult;
        result += "\n";
        result += fResult;
        result += "\n";
        result += "******************\n";

        results += String.Format("{0}\n{1}\n", method, result);

        //Run next method test or if finished save results and exit
        Methods maxEnumValue = new List<Methods>((Methods[])Enum.GetValues(typeof(Methods))).Max();
        if (method < maxEnumValue)
        {
            method = method + 1;
            yield return new WaitForEndOfFrame();
            StartCoroutine(RunTestsOnMethod(method));
        }
        else
        {
            string statsFilePath = "./Assets/stats.txt";
            File.WriteAllText(statsFilePath, stats);
            UnityEngine.Debug.Log("stats saved as " + statsFilePath);

            string resultsFilePath = "./Assets/results.txt";
            File.WriteAllText(resultsFilePath, results);
            UnityEngine.Debug.Log("results saved as " + statsFilePath);

            Application.Quit();
        }
    }
}

/// <summary>
/// A list of methods to test in the script bellow
/// </summary>
public enum Methods
{
    //Vector4
    Vec4Plus,
    Vec4Minus,
    Vec4Multiply1,
    Vec4Multiply2,
    Vec4UniratyNegeation,
    Vec4Division,
    Vec4Magnitude,
    Vec4MagnitudeProp,
    Vec4Normalize,
    Vec4NormalizeStatic,
    Vec4NormalizedProp,
    Vec4Distance,
    Vec4LerpUnclamped,
    Vec4Lerp,
    Vec4Scale,
    Vec4Min,
    Vec4Max,
    //Vector3
    Vec3Plus,
    Vec3Minus,
    Vec3Multiply1,
    Vec3Multiply2,
    Vec3UniratyNegeation,
    Vec3Division,
    Vec3Magnitude,
    Vec3MagnitudeProp,
    Vec3Normalize,
    Vec3NormalizeStatic,
    Vec3NormalizedProp,
    Vec3Distance,
    Vec3LerpUnclamped,
    Vec3Lerp,
    Vec3Cross,
    Vec3Scale,
    Vec3Min,
    Vec3Max,
    //Vector2
    Vec2Plus,
    Vec2Minus,
    Vec2Multiply1,
    Vec2Multiply2,
#if UNITY_2018_1_OR_NEWER
    Vec2Multiply3,
#endif
    Vec2UniratyNegeation,
    Vec2Division1,
#if UNITY_2018_1_OR_NEWER
    Vec2Division2,
#endif
    Vec2MagnitudeProp,
    Vec2Normalize,
    Vec2NormalizedProp,
#if UNITY_2018_1_OR_NEWER
    Vec2Perpendicular,
#endif
    Vec2Distance,
    Vec2LerpUnclamped,
    Vec2Lerp,
    Vec2Scale,
    Vec2Min,
    Vec2Max,
#if UNITY_2017_2_OR_NEWER
    //Vector3Int
    Vec3IntPlus,
    Vec3IntMinus,
    Vec3IntMultiply1,
    Vec3IntMultiply2,
    Vec3IntMagnitudeProp,
    Vec3IntDistance,
    Vec3IntScale,
    Vec3IntMin,
    Vec3IntMax,
    //Vector2Int
    Vec2IntPlus,
    Vec2IntMinus,
    Vec2IntMultiply1,
    Vec2IntMultiply2,
    Vec2IntMagnitudeProp,
    Vec2IntDistance,
    Vec2IntScale,
    Vec2IntMin,
    Vec2IntMax,
#endif

    //Quaternion
    QuaterMultiply,
    //Color32
    Color32LerpUnclamped,
    Color32Lerp,
    //Vector implicit operators
    ImplicitV2V3,
    ImplicitV2V4,
    ImplicitV3V2,
    ImplicitV3V4,
    ImplicitV4V2,
    ImplicitV4V3,
    ImplicitC32C,
    ImplicitCC32,
    //Bounds
    BoundsExpandV,
    BoundsExpandF
}
