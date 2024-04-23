# Unity Examples
This will be a collection of simple, self-contained scenes with mechanic examples

## Door
Even a simple door can be tricky if you're just starting gamedev!
So I created this example to see how much stuff you can learn by just having a door in your game.
Just the bare minimum: A door and buttons.

For this simple door, you'll encounter:
- Communication between GameObjects
- Collisions / Triggers
- Quaternions
- Lerp
- Lists
- Events
- Interaction
- Rigidbody
- Player Controller

Also I've made sure to only use in-Unity stuff, no external assets.

## DoorHinge
This is an example of a Door using Unity's _Hinge_ component to move with physics.
And you can break it too!
Press **Shift** to run at the door.

Notes:
- A hinge doesn't need to be anchored to another object.
- You'd only attach another object if they're going to move together.
- The door also uses the _Limit_ setup.
