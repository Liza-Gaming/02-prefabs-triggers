# Space-Shooter-Lecture
A game from the lecture.

## My Changes

- I replaced the location of the score points to the left corner of the screen.
The points doesn't reset between scenes (Singleton design pattern).
- I added a meteor storm. Collision with a meteor cause the spaceship to move to random direction for less then one second, preventing the player control the spaceship.
- I changed the enemy sprite to red tringle.

## New scripts
- [MeteorSpawner](https://github.com/Liza-Gaming/02-prefabs-triggers/blob/main/Assets/Scripts/2-spawners/MeteorSpawner.cs)
- [Laser](https://github.com/Liza-Gaming/02-prefabs-triggers/blob/main/Assets/Scripts/3-collisions/Laser.cs)
- [ScoreManager](https://github.com/Liza-Gaming/02-prefabs-triggers/blob/main/Assets/Scripts/4-levels/ScoreManager.cs)
- I changed [InputAction](https://github.com/Liza-Gaming/02-prefabs-triggers/blob/main/Assets/Scripts/4-levels/ScoreManager.cs)

  **GameObjects:** MeteorSpawner parent of Canvas, ScoreManger and Meteor prefab

  **I added lifetime to prefabs (enemies and meteors) so they will be destroyed after they exit the screen**
  
#### Play Game
 [Game in itch.io](https://lizachep.itch.io/game-week3-a)
 
## Screenshot
https://github.com/user-attachments/assets/7f22abc9-6277-46d8-96ef-69f11fbeb55b


