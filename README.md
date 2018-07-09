# Simple Timer for Unity
This simple C# Unity script allows you to create easy-to-use timers that invoke a function when they finish.
With this script in your hands, the days of writing custom timers everywhere are long gone.

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

### Documentation
The documentation for the SimpleTimer can be found inside the actual script file.
Everything is commented so that you won't have any problems understanding how to use it.
If something isn't commented, it will probably be soon.

### Last Notes
Feel free to use this script for whatever you'd like. You can modify it if you'd like too as well. As long as you keep the copyright notice on top with a note below saying that you modified it. There's however no need to credit me in the actual game or anything like that, just in the source code.
