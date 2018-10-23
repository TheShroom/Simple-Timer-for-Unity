# Simple Timer for Unity
This simple C# Unity script allows you to create easy-to-use timers that invoke a function when they finish.

### Sample Code
With this single line of code you can easily create a fully functional timer.
```
TimerManager.CreateTimer(5.0f, () => { Debug.Log("Hello, SimpleTimer!"); });
```
Once this line runs, your timer will be activated and whatever delegate you passed to it will be invoked after x amount of seconds specified in the first parameter of the `CreateTimer` function. (In this case 5.0f, so five seconds)

When a timer has been created you should always delete it when you're done with it to prevent memory leaks.
You can easily delete a created timer by passing it to the `DeleteTimer` function like this:
```
TimerManager.Timer timer = TimerManager.CreateTimer(5.0f, () => { Debug.Log("Hello, SimpleTimer!"); });
// Do stuff...

// We are done with the timer, remove it.
TimerManager.DeleteTimer(timer);
```

### Customization
The Simple Timer also supports customizing a timer to suit your needs.
When the `CreateTimer` function has been called it returns a value of type `Timer`.
This timer value can be used to call functions directly on the actual timer.

You could for example, do something like this if you want to timer the reset when it has finished, so it keeps going forever.
```
TimerManager.Timer timer;

private void Start()
{
    timer = TimerManager.CreateTimer(5.0f, () => { ResetTimer(); });
}

private void ResetTimer()
{
    Debug.Log("Hello, SimpleTimer!!");
    // Do stuff...
    timer.Reset();
    Timer.Start();
}
```

It also let's you use another delegate on the timer called the `OnTimerTicked` delegate. This gets invoked every time the timer updates. (Which is every frame as long as the timer isn't paused)

The way you would do this is:
```
TimerManager.Timer timer = TimerManager.CreateTimer(5.0f, () => { Debug.Log("Hello, SimpleTimer!"); }, () => { Debug.Log("Timer Ticked!") });
// Do stuff...

// We are done with the timer, remove it.
TimerManager.DeleteTimer(timer);
```

Or if you don't need one of the delegates; maybe you don't need to know when the timer finishes, only when it ticks, you could just send null to the delegate:
```
TimerManager.Timer timer = TimerManager.CreateTimer(5.0f, null, () => { Debug.Log("Timer Ticked!") });
// Do stuff...

// We are done with the timer, remove it.
TimerManager.DeleteTimer(timer);
```
