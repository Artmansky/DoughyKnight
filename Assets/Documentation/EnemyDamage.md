## EnemyDamage
> This script is responsible for dealing damage to the player when the enemy collides with the player.
### Fields
```cs
Single damage
```
```cs
Single attackCooldown
```

### Methods
```cs
Void Start
```
> This method is called when the object becomes enabled and active.
```cs
Void OnCollisionEnter2D
```
> This method is called when the Collider2D other enters the trigger and damaged the player.
```cs
Void OnCollisionStay2D
```
> This method is called when the Collider2D other stays in the trigger and damaged the player.

