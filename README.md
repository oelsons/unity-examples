# Unity Examples
I'm building a collection of simple, self-contained scenes with mechanic examples.

Each folder has a Scene with a built mechanic:

## Doors
### | Door
Even a simple door can be tricky if you're just starting gamedev!
So I created this example to see how much stuff you can learn by just having a door in your game.
Just the bare minimum: A door and buttons.

For this simple door, you'll encounter:
- Communication between GameObjects
- Collisions / Triggers
- Quaternions
- Lerp
- Lists
- Interfaces
- Interaction
- Rigidbody
- Player Controller

Also I've made sure to only use in-Unity stuff, no external assets.

### | Door Hinge
This is an example of a Door using Unity's _Hinge_ component to move with physics.
And you can break it too!
Press **Shift** to run at the door.

Notes:
- A hinge doesn't need to be anchored to another object.
- You'd only attach another object if they're going to move together.
- The door also uses the _Limit_ setup.

This scene also has a **Hinge Lock System** (to lock the door) and a Lock Light Indicator.

## Screens And Cameras
### | Camera-Monitor
This shows how to setup a *Handheld Camera* and show its feed on a Monitor.

- Handheld Camera
	- *Use Multiple Cameras in a Scene*
	- *Display in World Space using Render Texture*
- Canvas HUD
	- *Stack Render Textures to show a HUD on the Camera Display*
	- Zoom function

### | Touchscreen
This shows how to create an in-game touchscreen using Canvas.

- *Use a World Space Canvas and make it interactable* 
- *Use New Input System to set clickable Canvas in a FPS*

### | CCTV
This shows how to setup a full **CCTV System** with multiple Cameras.

- *Set many cameras and display them in a Monitor*
- *Creates Render Textures and Materials dynamically via code*
- *Set Camera feed to Buttons*
- *Use Touchscreen System to select Camera feed*
