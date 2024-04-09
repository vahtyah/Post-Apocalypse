using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

    public class TimerManager : Singleton<TimerManager>
    {
        private List<Timer> timers = new List<Timer>();

        private void Update() { UpdateAllTimers(); }

        public void RegisterTimer(Timer timer) { timers.Add(timer); }

        public void RemoveTimer(Timer timer) { timers.Remove(timer); }

        private void UpdateAllTimers()
        {
            var i = 0;
            while (i < timers.Count)
            {
                if (!timers[i].Update())
                    continue;
                i++;
            }
        }

        public void PauseAllTimers()
        {
            foreach (var timer in timers)
            {
                timer.Pause();
            }
        }

        public void ResumeAllTimers()
        {
            foreach (var timer in timers)
            {
                timer.Resume();
            }
        }

        public void CancelAllTimers()
        {
            foreach (var timer in timers)
            {
                timer.Cancel();
            }
        }
    }
