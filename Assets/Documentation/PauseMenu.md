## PauseMenu
> Displays the pause menu and allows the player to resume the game, go to the main menu, and adjust the volume.
### Fields
```cs
Boolean isPaused
```

### Methods
```cs
Void Start
```
> Gets saved volume from PlayerPrefs and sets the volume to the saved volume.
```cs
Void Update
```
> Checks if the player presses the escape key and pauses or resumes the game.
```cs
Void PauseGame
```
> Pauses the game and sets the time scale to 0.
```cs
Void ResumeGame
```
> Resumes the game and sets the time scale to 1.
```cs
Void GoToMainMenu
```
> Goes to the main menu and sets the time scale to 1.
```cs
Void SetVolume
```
> Sets the volume to the value and saves the volume to PlayerPrefs.

