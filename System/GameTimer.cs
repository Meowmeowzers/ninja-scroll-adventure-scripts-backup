using System;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    float _startTime;
    float _elapsedTime;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartTimer()
    {
        _startTime = Time.time;
    }

    public void StopTimer()
    {
        _elapsedTime = Time.time - _startTime;
    }

    public string GetFormattedTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(_elapsedTime);
        return string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }

    public float GetElapsedTime() => _elapsedTime;

}
