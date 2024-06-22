## Enemy
> This class is responsible for the enemy's behavior, such as taking damage, dying, and moving towards the player.
### Fields
```cs
Single maxHealth
```
```cs
Single speed
```
```cs
Single experience
```

### Methods
```cs
Void TakeDamage
```
> This method is called when the enemy takes damage. It decreases the current health, plays the audio, instantiates blood, and checks if the enemy is dead.

