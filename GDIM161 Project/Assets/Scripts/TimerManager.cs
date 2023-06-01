using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    private float time = 0;
    public float bestTime = float.MaxValue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartTimer()
    {
        StartCoroutine("TimerCoroutine");
    }

    public void StopTimer()
    {
        StopCoroutine("TimerCoroutine");
        if (time < bestTime)
        {
            bestTime = time;
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    public float GetTime()
    {
        return time;
    }

    public void ResetTimer()
    {
        time = 0;
    }
}
