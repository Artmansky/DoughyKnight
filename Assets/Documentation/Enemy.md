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
Void Awake
```
> This method is called when the object is created. It gets the player object, the player's experience, and the death sound.
```cs
Void Start
```
> This method is called when the object is created. It sets the current health to the max health, updates the health bar, and gets the target.
```cs
Void FixedUpdate
```
> This method is called every frame. It moves the enemy towards the player and flips the sprite if needed.
```cs
Void GetTarget
```
> This method gets the target of the enemy, which is the player.
```cs
Void FlipSprite
```
> This method flips the sprite of the enemy.
```cs
Void TakeDamage
```
> This method is called when the enemy takes damage. It decreases the current health, plays the audio, instantiates blood, and checks if the enemy is dead.
```cs
Void Die
```
> This method is called when the enemy dies. It adds experience to the player, plays the death sound, triggers the die animation, and destroys the object.

