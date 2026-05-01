# Adventure Game

## How to Build and Run

Open a terminal in the main project folder and run:

dotnet build

Then run the console project:

dotnet run --project AdventureGame.Console

## Movement Controls

The player can move using either WASD or the arrow keys:

W or Up Arrow = move up  
S or Down Arrow = move down  
A or Left Arrow = move left  
D or Right Arrow = move right  

Moving into a wall or outside the maze does not move the player. A short error message is displayed.

## Display Format

The maze is displayed using symbols:

@ = Player  
# = Wall  
. = Empty tile  
E = Exit  
M = Monster  
W = Weapon  
P = Potion  

The game also displays the player's current HP, maximum HP, highest weapon bonus, and the latest game message.

## Win and Lose Conditions

The player wins by reaching the exit tile (E).

The player loses if their HP reaches 0.

## Battle Rules

Battle starts automatically when the player moves onto a monster tile. The player attacks first each round. Damage is calculated as base damage (10) plus the highest weapon modifier. If the monster survives, it counterattacks. Battle continues until either the player or the monster reaches 0 HP. There is no fleeing. After a monster is defeated, the tile becomes empty.

## Items

Item pickup is automatic. Weapons increase the player's attack damage by adding a modifier. Potions restore health. After an item is picked up, the tile becomes empty.

## Maze Generation

The maze is randomly generated with a minimum size of 10x10. The exit is guaranteed to be reachable. Walls, monsters, weapons, and potions are placed randomly.

## UML Diagram

File: AdventureGame_UML.png

The UML diagram shows the main classes in the project including GameEngine, Maze, Tile, Player, Monster, Inventory, Item, Weapon, Potion, and ICharacter. It also illustrates relationships such as inheritance, composition, and interface implementation.

## Git Usage

To clone the repository:

git clone <https://github.com/etsucs-scott/project-1-olalekan78552-bot.git>

Navigate into the project folder:

cd project-1-olalekan78552-bot

Build the project:

dotnet build

Run the game:

dotnet run --project AdventureGame/AdventureGame.Console