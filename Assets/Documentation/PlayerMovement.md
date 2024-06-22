## PlayerMovement
> Class that controls the player movement, attack and flip sprite
### Fields
```cs
Single moveSpeed
```
```cs
Boolean isDying
```
```cs
Animator animatorBasic
```
```cs
GameObject attackPoint
```
```cs
Single damage
```
```cs
Single knockbackForce
```
```cs
Single radius
```
```cs
LayerMask enemies
```

### Methods
```cs
Void Start
```
> Start is called before the first frame update
```cs
Void Update
```
> Update is called once per frame, it checks if player clicked attack button or movement keys
```cs
Void FixedUpdate
```
> FixedUpdate is called once per frame, it moves the player based on the movement vector
```cs
Void MovementInput
```
> Method that checks if player is moving and sets the movement vector
```cs
Void FlipSprite
```
> Method that flips the sprite based on the horizontal movement
```cs
Void Attack
```
> Method that checks if player is attacking and calls the Attack method, plus applies knockback direction
```cs
Void endAttack
```
> Method that sets the isAttacking parameter to false
```cs
Void OnDrawGizmos
```
> Method that draws a wire sphere around the attack point

