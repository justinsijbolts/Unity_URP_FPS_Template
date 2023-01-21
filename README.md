# Unity URP FPS Template
Built upon Unity 2021.3.9f1

## Documentation

### NextCaption(bool firstCaption, int startingCaption, int endingCaption)
The "NextCaption" function is a method that allows the user to display captions in a Unity game or application. It takes in three parameters: a boolean "firstCaption", an integer "startingCaption", and an integer "endingCaption".

- The "firstCaption" parameter is a boolean that indicates whether or not the current caption being displayed is the first one in the scene.
- The "startingCaption" parameter is an integer that specifies the index of the caption that should be displayed first.
- The "endingCaption" parameter is an integer that specifies the index of the last caption that should be displayed.

The function updates the caption name and caption content text objects with the values of the captionName and captionContent arrays respectively, and sets the caption background color to be visible.

```csharp
    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            NextCaption(false, 3, 999);
        }
    }
```

In the example provided, the method is called within the "Update()" method when the user presses the "3" key, with the firstCaption as false (meaning captions were previously visible in this scene), startingCaption as 3 and endingCaption as 999. This allows the user to jump to a specific caption by pressing the corresponding number key.

The function also uses a Coroutine "TriggerFirstCaption" which is used to fade in and fade out the caption and background color over a specified duration. The caption is displayed for a specified duration before fading out and moving to the next caption.

Once you have a reference to the script component, you can call the "NextCaption" function by using the dot notation to access the function, and passing in the appropriate parameters. Time durations, Characters names and Caption Bodies can be set from within the Inspector. The script is attached to the "CaptionsPanel" GameObject, a child of the "UI" Canvas GameObject in this template.

This function could be used in scenarios where captions need to be displayed in a game or application, such as for a dialogue or tutorial. It can also be used to display subtitles in a video game or application. The NextCaption method can be called at appropriate times to display the captions in the desired order.
