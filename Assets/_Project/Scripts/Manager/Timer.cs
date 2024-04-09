using System;
using UnityEngine;

public class Timer
{
    private static TimerManager manager;

    public static Timer Register(float duration)
    {
        var timer = new Timer(duration);

        if (manager == null)
            manager = TimerManager.Instance;
        if (manager == null)
            throw new Exception("TimerManager is not found in the scene");

        timer.onDone = () => manager.RemoveTimer(timer);
        return timer;
    }

    public float Duration { get; private set; }
    public bool IsCompleted { get; private set; }
    public bool IsPaused => timeElapsedBeforePause.HasValue;
    public bool IsLooped { get; private set; }
    public bool IsCancelled { get; private set; }
    public bool UsesRealTime { get; private set; }
    public bool IsDone => IsCompleted || IsPaused || IsCancelled || isOwnerDestroyed;
    public bool IsRunning => !IsDone;
    public float Progress => GetTimeElapsed() / Duration;
    public float TimeRemaining => Duration - GetTimeElapsed();
    public float Remaining => Duration / GetTimeElapsed();

    private Action onStart;
    private Action<float> onUpdate;
    private Action<float> onProgress;
    private Action onComplete;
    private Action onDone;
    private float startTime;
    private float? timeElapsedBeforePause;
    private MonoBehaviour owner;
    private bool hasOwner;
    private bool isOwnerDestroyed => hasOwner && owner == null;

    private Timer(float duration)
    {
        Duration = duration;
        startTime = GetWorldTime();
    }

    public Timer OnStart(Action onStart)
    {
        this.onStart = onStart;
        return this;
    }

    public Timer OnUpdate(Action<float> onUpdate)
    {
        this.onUpdate += onUpdate;
        return this;
    }

    public Timer OnProgress(Action<float> onProgress)
    {
        this.onProgress += onProgress;
        return this;
    }

    public Timer OnComplete(Action onComplete)
    {
        this.onComplete = onComplete;
        return this;
    }

    public Timer OnDone(Action onDone)
    {
        this.onDone = onDone;
        return this;
    }

    public Timer Loop(bool isLooped = true)
    {
        IsLooped = isLooped;
        return this;
    }

    public Timer UseRealTime(bool useRealTime = true)
    {
        UsesRealTime = useRealTime;
        return this;
    }

    public Timer AutoDestroyWhenOwnerDestroyed(MonoBehaviour owner)
    {
        if (owner == null) return this;
        this.owner = owner;
        hasOwner = owner != null;
        return this;
    }

    public Timer Start()
    {
        if (IsDone) return null;
        manager.RegisterTimer(this);
        onStart?.Invoke();
        return this;
    }

    public Timer StartWithFinish()
    {
        if (IsDone) return null;
        IsCompleted = true;
        onComplete?.Invoke();
        return this;
    }

    public void Restart()
    {
        startTime = GetWorldTime();
        IsCompleted = false;
        IsCancelled = false;
        timeElapsedBeforePause = null;
        manager.RegisterTimer(this);
    }

    public void Cancel() { IsCancelled = true; }

    public void Pause()
    {
        if (IsPaused || IsDone) return;
        timeElapsedBeforePause = GetTimeElapsed();
    }

    public void Resume()
    {
        if (!IsPaused) return;
        if (timeElapsedBeforePause != null) startTime = GetWorldTime() - timeElapsedBeforePause.Value;
        timeElapsedBeforePause = null;
        manager.RegisterTimer(this);
    }

    private float GetTimeElapsed()
    {
        if (IsCompleted) return Duration;
        return timeElapsedBeforePause ?? GetWorldTime() - startTime;
    }

    private float GetFireTime() => startTime + Duration;
    private float GetWorldTime() => UsesRealTime ? Time.realtimeSinceStartup : Time.time;

    public bool Update()
    {
        if (IsDone)
        {
            onDone?.Invoke();
            return false;
        }

        onUpdate?.Invoke(GetTimeElapsed());
        onProgress?.Invoke(Progress);

        if (GetWorldTime() >= GetFireTime())
        {
            onComplete?.Invoke();
            if (IsLooped) startTime = GetWorldTime();
            else
            {
                IsCompleted = true;
                onDone?.Invoke();
                return false;
            }
        }

        return true;
    }
}