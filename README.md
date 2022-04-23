# Game-Project
CSE 3902 Project- Name TBD, developed by Destination Ohio

##INTRODUCTION The following repository contains the code for the CSE 3902 Project class by the group Destination Ohio. We are developing our own original game, but for Sprint 2, we have implemented many of the assets from The Legend of Zelda (Nintendo 1986).
    Zelda assets from .
    
##CONTROLS
A - move left
D - move right
Z - use sword
N - use sword
1 - bow and arrow
2 - bomb
3 - boomerang
4 - candle
5 - sword beam
Q - quit
R - reset
P - pause game
I - inventory(when paused)

##CODE STRUCTURE AND DESIGN PATTERNS 
Our code implements the command pattern for keyboard commands, the state pattern for the player animations and movement, state machines for the enemy actions and movement, a sprite factory for ease of animation, and the singleton pattern for several classes like the sprite factory, the object manager, and the level loader. The design patterns are the same as the previous sprints, but have been elaborated and improvised.

##DOCUMENTATION
To document our game design, art, and code design documents, the team operated with a shared Google Drive folder as well as a Trello. The team also used a Discord server for easy voice chat and means of contacting one another over text. 

##ART AND ASSETS
The team is creating our own art for this game. We are creating something with an original story with design elements that come from both Mario and Zelda. 
The following new art was added:
-updated player animations
-new item sprites
-"At dooms gate" music pack
-new backgrounds

New tile sets have been created, but have not yet been implemented in the game. We are going to add more music packs and sounds by the next sprint.

Assets that have yet to be created have been replaced by assets from The Legend of Zelda.

##THE FUTURE
While many bugs and design considerations have been fixed and taken into account for this sprint, there are still some issues that need to be ironed out. 
Smooth and efficient level loading is something we are still working on and will be implented next sprint. We will be working tirelessly to make the perfect game that every member of our team is envisioning.

##.NET CODE QUALITY ANALYSIS WITH ROSLYN
Sidekick physics: warning had to do with the physics object within the sidekick class never being set to anything, so we created the physics object within the sidekick. As a last minute addition, it would not operate as intended, and therefore was never used.
Sidekick sprite: warning with it never being set, suppressed the warning as it is never going to be used, but deleting or commenting leads to lots of compilation errors.
Sidekick stateMachine.Player: another warning about the stateMachine for the sidekick never getting the player class as its .player variable. So, we set the player as its variable which fixed the warning.
SoundManager PlayLayered: a delegate that is created and set, yet never used. Commented it and its instantiation because they may be needed if this part was ever completed, but currently does not work as intended.
Game1.song: deleted because the song will not be played in the Game1 class. Was not needed and is now fixed. Probably left over from some testing use.
Ammo.despawnSprite: deleted, as it was never set to, and with the current implementation, the sprite variable will change based on what is happening, meaning it will automatically switch to the despawnSprite when needed.
Bomb.physics: warning as it was never set to anything, so I deleted it as the current implementation does not require any physics.
HealthBar.StateMachine: another warning for a null variable that will never change, looks like it was just forgotten to be set to anything in the constructor, so I added that.
