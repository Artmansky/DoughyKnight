## PlayerHealth
> Class that manages the player's health and particle effects when the player takes damage.
### Fields
```cs
Single health
```
```cs
Single maxHealth
```
```cs
GameOverScreen gameOverScreen
```
```cs
Image healthBar
```
```cs
GameObject blood
```
```cs
Animator anime
```

### Methods
```cs
Void Start
```
> Initializes the player's health and the particles that will be used when the player takes damage.
```cs
Void Update
```
> Updates the player's health bar and checks if the player's health is less than or equal to 0.
```cs
Void TakeDamage
```
> Reduces the player's health when the player takes damage, initiates death animation

