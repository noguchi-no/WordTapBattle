using UnityEngine;
using Random = UnityEngine.Random;

public static class ShuffleSystem
{
    //配列の要素をシャッフルする (Fisher-Yates shuffle)
    public static void Shuffle<T>(this T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);  //[0]～[i]
            T tmp = arr[i];     //swap
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
