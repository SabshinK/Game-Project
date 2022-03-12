# Backlog Elements From Sprint 3:


## Code:

**Incomplete:**

- TESTING
    - The team did not have enough time for testing Sprint 3.
- Before the content for Sprint 4 is developed, the team has to test the content of Sprint3 and make sure it is working correctly.
- Debugging
    - While the team debugged for a significant amount of time, more time must be put into debugging. (This coincides with testing).
- As of right now, the object classes implement ICollideable, and therefore implement a Collide() method. However, given the behavior of CollisionDetection and CollisionResolution, these methods have no code inside them (they are doing nothing for each object class). More thought needs to be put into the design of ICollideable, and the team needs to determine what the Collide() methods will do, if they do anything at all. (If they do not perform any functions, they need to be removed and which classes implement ICollideable needs to be rethought).
- Within the object interfaces, there needs to be a declared variable for the size of each object sprite. The team created a variable like this for the position of the objects. For example, in IEnemy, there is a public variable of type Vector2 called Position that can be implemented by every enemy class. This same idea must apply to a variable that indicates the sprite size.
- Tiles must be placed in specific locations on the game screen when the game is loaded to the first level. 

**Complete:**

- Sprint2 fixes
- Reset function in game1.cs
- An ObjectManager was created that handles all of the objects in the game using lists of the object interface types. 
- The interfaces IUpdateable and IDrawable were expanded upon and implemented by all of the object interfaces/classes that needed them.
- CollisionDetection and CollisionResolution classes were created. CollisionDetection communicates with the ObjectManager to cycle through object lists and check for collisions. The CollisionResolution class resolves this collision by using a dictionary to call on command objects. 
- A Physics class was created. This class can be implemented by other classes, and performs calculations to determine the change in vertical or horizontal distance of a sprite’s position. This change is affected by velocity, which is also calculated within Physics. 
    - Incorporates jumping, falling, and horizontal movement.
- A LevelLoader class and reading data through XML files was created. 
    - Sprite sheets are updated and tile maps are updated as new sprites are made, and the XML files are adjusted. 

## Documentation:

**Complete:**

- Planning
- Backlog
- README File
- Sprint3 Reflection
- Code reviews for all team members
- Trello and Google Drive updates

## Art:

**Incomplete:**
- The player sprites for using an item, jumping, and falling have yet to be created, and must be created for Sprint 4.
- The enemy sprites must be made. As of right now, enemies from Zelda are being implemented. They must be replaced by our own original enemies so that original levels can be designed.
- 3 more tiles must be created. 
    - 6 tiles (3 for each level) were created. The final 3 must be made so that all of the levels can be designed and loaded.

**Complete:**
- Tiles for level 1 and 2 were created.
- Player animation for sword attacking was created.
- Concept art for the enemies

## Music:

**Incomplete:**

- An original score is going to be created for the game. Because Sprint 3 focused on the first level, one of the songs needed to be made. For sprint4, music must be made to accompany one or more of the levels.
