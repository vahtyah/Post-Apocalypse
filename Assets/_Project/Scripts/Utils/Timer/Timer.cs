using System;
using UnityEngine;

public abstract class Timer
{
    protected float initialTime;
    public float Time { get; set; }
    public bool IsRunning { get; protected set; }

    public float Progress => Time / initialTime;

    public Action OnTimerStart = delegate { };
    public Action OnTimerStop = delegate { };

    protected Timer(float value)
    {
        initialTime = value;
        IsRunning = false;
    }

    public virtual void Start()
    {
        Time = initialTime;
        if (!IsRunning)
        {
            IsRunning = true;
            OnTimerStart.Invoke();
        }
    }

    public void Stop()
    {
        if (IsRunning)
        {
            IsRunning = false;
            OnTimerStop.Invoke();
        }
    }

    public void Resume() => IsRunning = true;
    public void Pause() => IsRunning = false;

    public abstract void Tick(float deltaTime);
    public void AddOnTimerFinishedListener(Action _onTimerFinished) => OnTimerStop += _onTimerFinished;
}

public class CountdownTimer : Timer
{
    private bool isFinishWhenStart = false;

    public CountdownTimer(float value, bool isFinishWhenStart = false) : base(value)
    {
        this.isFinishWhenStart = isFinishWhenStart;
    }

    public override void Start()
    {
        base.Start();
        if (isFinishWhenStart)
            Time = 0;
    }

    public override void Tick(float deltaTime)
    {
        if (IsRunning && Time > 0)
        {
            Time -= deltaTime;
        }

        if (IsRunning && Time <= 0)
        {
            Stop();
        }
    }

    public bool IsFinished => Time <= 0;

    public virtual void Reset()
    {
        Time = initialTime;
        IsRunning = true;
    }
}

public class LoopingCountdownTimer : CountdownTimer
{
    public LoopingCountdownTimer(float value) : base(value) { AddOnTimerFinishedListener(Reset); }

    public override void Reset()
    {
        base.Reset();
        Resume();
    }
}

public class StopwatchTimer : Timer
{
    public StopwatchTimer() : base(0) { }

    public override void Tick(float deltaTime)
    {
        if (IsRunning)
        {
            Time += deltaTime;
        }
    }

    public void Reset() => Time = 0;

    public float GetTime() => Time;
}