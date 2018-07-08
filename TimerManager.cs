// Copyright TheShroom 2018 | (https://github.com/TheShroom)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheShroom // Author
{ 
	namespace SimpleTimer // Project name
	{
		public class TimerManager : MonoBehaviour // The only reason we derive from MonoBehaviouris to get access to the Update function. (probably a bad idea)
		{
			public class Timer
			{
				public delegate void OnTimerFinished();
				private OnTimerFinished onTimerFinished;
				private float elapsedTime;
				private float waitTime;
				private bool paused;
				private bool finished;

				internal Timer(float waitTime, Timer.OnTimerFinished onTimerFinished, bool startNow = true)
				{
					SetWaitTime(waitTime);
					this.onTimerFinished = onTimerFinished;
					
					if (startNow)
					{
						Start();
					}
					else
					{
						Pause();
					}
				}

				/// <summary>
				/// Starts the timer. Has the same functionality as Pause().
				/// </summary>
				public void Start()
				{
					Debug.Log("Starting SimpleTimer!"); // TODO (The Shroom): Implement the actual timers.
				}

				/// <summary>
				/// Pauses and resets the timer.
				/// </summary>
				public void Stop()
				{
					Pause();
					Reset();
				}

				/// <summary>
				/// Resets the counter of the timer.
				/// </summary>
				public void Reset()
				{
					SetElapsedTime(0.0f);
				}

				/// <summary>
				/// Pauses the timer and prevents it from counting.
				/// </summary>
				public void Pause()
				{
					paused = true;
				}

				/// <summary>
				/// Unpauses the timer so it starts counting again.
				/// </summary>
				public void Unpause()
				{
					paused = false;
				}

				/// <summary>
				/// Sets the current value of the timer.
				/// </summary>
				public void SetElapsedTime(float newTime)
				{
					elapsedTime = newTime;
				}

				/// <summary>
				/// Returns the current value of the timer.
				/// </summary>
				public float GetElapsedTime()
				{
					return elapsedTime;
				}

				/// <summary>
				/// Sets the amount of seconds the timer will wait before finishing.
				/// </summary>
				public void SetWaitTime(float newTime)
				{
					waitTime = newTime;
				}

				/// <summary>
				/// Returns the amount of seconds the timer will wait before finishing.
				/// </summary>
				public float GetWaitTime()
				{
					return waitTime;
				}

				/// <summary>
				/// Sets the delegate to invoke when the timer finishes.
				/// </summary>
				public void SetDelegate(OnTimerFinished delgt)
				{
					onTimerFinished = delgt;
				}

				internal void Update()
				{
					if (!paused && !finished)
					{
						elapsedTime += Time.deltaTime;
					}

					if (!finished && elapsedTime >= waitTime)
					{
						Finish();
					}
				}

				private void Finish()
				{
					finished = true;
					InvokeFinishedDelegate();
				}

				private void InvokeFinishedDelegate()
				{
					if (onTimerFinished != null) // Only invoke if it has a subscriber. This should technically be impossible, but still.
					{
						onTimerFinished.Invoke();
					}
					else
					{
						Debug.LogError("[SimpleTimer] Timer finished but not subscriber to the onTimerFinished delegate could be found.");
					}
				}
			}

			private static List<Timer> timers = new List<Timer>();

			public static Timer CreateTimer(float waitTime, Timer.OnTimerFinished onTimerFinished, bool startNow = true)
			{
				Debug.Log("Creating SimpleTimer");
				timers.Add(new Timer(waitTime, onTimerFinished, startNow));
				return timers[timers.Count - 1]; // Return a reference to the created timer.
			}

			private void Update()
			{
				foreach (Timer t in timers)
				{
					t.Update();
				}
			}

		}
	}
}