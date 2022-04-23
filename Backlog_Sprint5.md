# Backlog Elements From Sprint 5:


## Code:

**Incomplete:**

- TESTING
    - The team did not have enough time for testing Sprint 5.
- Before the content for the game is developed, the team has to test the content of Sprint3 and make sure it is working correctly.
- Debugging
    - While the team debugged for a significant amount of time, more time must be put into debugging. (This coincides with testing).
- As of right now, the object classes implement ICollideable, and therefore implement a Collide() method. However, given the behavior of CollisionDetection and CollisionResolution, these methods have no code inside them (they are doing nothing for each object class). More thought needs to be put into the design of ICollideable, and the team needs to determine what the Collide() methods will do, if they do anything at all. (If they do not perform any functions, they need to be removed and which classes implement ICollideable needs to be rethought).
- Tiles must be placed in specific locations on the game screen when the game is loaded to the first level. 
- Portals were not implemented, but the lower priority of adaptive background and music were added.
- Magic Numbers need to be accounted for. The current UtilityClass has the variables to replace the numbers, but has not been added into the files.

**Complete:**

- Sprint4 fixes
- ItemScroller was implemented
- A grid system for position was implemented
- GameStateMachine was implemented. 
- Physics class was fully debugged. 
- EnemyStateMachine was implemented to account for all common behavior between different enmies
-  Musicians were implemented into the game along with adaptive music code.
-  Adaptive background was added as outlined by the team's additional features.
- The interfaces IUpdateable and IDrawable were expanded upon and implemented by all of the object interfaces/classes that needed them.
- CollisionDetection and CollisionResolution classes were debugged. CollisionDetection communicates with the ObjectManager to cycle through object lists and check for collisions. The CollisionResolution class resolves this collision by using a dictionary to call on command objects. 
- The UI was fully debugged.
- A Physics class was created. This class can be implemented by other classes, and performs calculations to determine the change in vertical or horizontal distance of a sprite’s position. This change is affected by velocity, which is also calculated within Physics. (Note the things that need fixed in the "Incomplete" section).
    - Fixed bugs for moving, jumping, falling for the player.
- Musician sprites and enemy animation sprites were made
- Music for items and implementation were created and approved by the team.
- AI Sidekick code was written, but not tested. 
- Sprite sheets are updated and tile maps are updated as new sprites are made, and the XML files are adjusted. 

## Documentation:

**Complete:**

- Planning
- Backlog
- README File
- Sprint5 Reflection
- Code reviews for all team members
- Trello and Google Drive updates

## Art:

**Incomplete:**
- Multilevel was one of the team's additional features which the team was hoping to get to but did not. The art for it has not been made. 

**Complete:**
- Tiles for level 1 and 2 were created.
- Player animation for sword attacking was created.
- Concept art for the enemies
- Enemy sprites
- background 
- musicians
- breakable tiles

## Music:

**Complete:**

- Music for each item as well as the adaptive aspect of the music has been completed and approved by the team. There is one for the overal game as well as for the musicians.
