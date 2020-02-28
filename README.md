# Unity Editor Window Navigation Template

Requires Unity 2019.2 or later.

## Description

This Unity project/package contains a template you can build on to create a custom "mutli-page" Editor Window. You can create multiple "panels" for the window (each in a separate file), and use the navigation system provided. Navigation includes the ability to switch between panels smoothly using a "sliding" animation (based on Unity's AnimationCurves).  
  
Disclaimers:  
1. Currently doesn't serialize the windows correctly, so a recompile will crash the windows. This can be fixed by switching the windows over to using ScriptableObjects.  
2. Navigation works in a stack but only supports backwards navigation. No forward navigation if you go back a page, but then want to return to the previous page.

## How to open

Either clone the repository and open the included Unity project in Unity 2019.2 or later.  
  
OR download the Unity package file and import it into your own project.

## Opening the Window:

You can open the custom editor window by going to the top menu bar and selecting `Window > Editor Window Navigation Demo`. This menu item can be changed to your own within `Assets/Editor/Scripts/MenuItems.cs`.  
  
You can also change the window title in `Assets/Editor/Scripts/MainWindow.cs`.  

## Creating your own Panel

You can create your own panel by creating another `.cs` file in the `Assets/Editor/Scripts/Panels` folder. The panel must inherit from `PanelBase` and the panel content can be drawn using standard `GUILayout` methods in the overriden `Render()` method (treating it like the standard `OnGUI` method).  
  
You can also change the background colour of the panel by overriding `GetBackgroundColor()`.  

See the included `WelcomePanel` and `ColourPanel` examples included.

## Navigation

The `WelcomePanel` is created and displayed by default. You can change this on line 33 of `Assets/Editor/Scripts/PanelManager.cs`.  
  
Navigation works using the following methods:  
`PanelManager.Navigate` - Transition to a new panel. The previous panel gets added to the stack, so backwards navigation can be used.  
`PanelManager.ChangePanel` - Transition to a new panel without changing the stack. Use this if you want to transition to a new panel which shouldn't be added to the stack (i.e. the user shouldn't be able to return to it from later panels).  
`PanelManager.Back` - Use this to transition back to the previous panel in the stack.  
`PanelManager.ClearStack` - Remove all previous panels from the stack to prevent the user navigating back. (e.g. after a user logs in via a login panel, you may want to use this to prevent the user going back to the login screen via a back button).


# License

This code is released under MIT license. This means you can use this for whatever you want. Modify, distribute, sell, fork, and use this as much as you like. Both for personal and commercial use. I hold no responsibility if anything goes wrong.  
  
If you use this, you don't need to refer to this repo, or give me any kind of credit but it would be appreciated.