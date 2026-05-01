# Adventure Game

## How to Build and Run

1. Open a terminal in the project root folder.

2. Build the project:
dotnet build

3. Run the game:
dotnet run --project AdventureGame/AdventureGame.Console

The game will launch in the console and display the maze.

## Movement Controls

The player can move using:

W or Up Arrow = Move Up  
S or Down Arrow = Move Down  
A or Left Arrow = Move Left  
D or Right Arrow = Move Right  

Invalid moves (into walls or outside the maze) do not change the player's position and display a message.

## Display Format

The maze is displayed using the following symbols:

@ = Player  
# = Wall (not walkable)  
. = Empty tile  
E = Exit (goal)  
M = Monster  
W = Weapon  
P = Potion  

Below the maze, the game displays:

- Player HP (current / max)  
- Maximum weapon bonus from inventory  
- Last action message (movement, combat, or pickup)


## Win and Lose Conditions

Win Condition:  
The player reaches the exit tile (E).

Lose Condition:  
The player’s HP reaches 0 during combat.


## Battle Rules

- Battle starts automatically when the player moves onto a tile containing a monster.
- The player always attacks first.
- Damage is calculated as:

Base Damage (10) + Highest Weapon Modifier

- If the monster survives, it counterattacks.
- Combat continues in a loop until either the player or the monster reaches 0 HP.
- The player cannot flee from battle.
- After a monster is defeated, the tile becomes empty and can be re-entered.

## Items

Item pickup is automatic when the player steps on a tile containing an item.

Weapons:
- Increase the player’s attack damage.
- The highest weapon modifier in the inventory is used.

Potions:
- Restore player health (up to max health).

After pickup, the tile becomes empty.


## Maze Generation

- The maze is randomly generated using a Random object.
- Size: 10 x 10 grid.
- The exit is placed near the bottom-right of the maze.
- A valid path is generated from the player’s starting position to the exit to ensure it is reachable.
- Walls are placed around the borders.
- Monsters, weapons, and potions are randomly distributed on empty tiles.


## UML Diagram

File: AdventureGame_UML.png

The UML diagram includes:

- GameEngine (controls game flow and logic)
- Maze (grid structure and generation)
- Tile (individual cell with type, item, or monster)
- Player (implements ICharacter, handles movement, health, inventory)
- Monster (implements ICharacter, handles combat)
- Inventory (stores weapons and calculates highest modifier)
- Item (base class)
- Weapon and Potion (derived item types)
- ICharacter interface (shared combat behavior)

It shows relationships such as inheritance, composition, and interface implementation.


## Git Usage

Clone the repository:
git clone <https://github.com/etsucs-scott/project-1-olalekan78552-bot.git>

Navigate to the project folder:
cd project-1-olalekan78552-bot

Build the project:
dotnet build

Run the game:
dotnet run --project AdventureGame/AdventureGame.Console