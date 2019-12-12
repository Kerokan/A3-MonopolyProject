# Monopoly Project
 **Project made by Thibault CHASSEFAIRE and Martin CAM**
 ## Objectives
 
The objective of this project is to create a functionnal Monopoly using Design Patterns.
This Monopoly use most of the old french rules of the game. However the currency used is Euro *(1 euro = 1 franc)*

## Design Patterns
### Singleton

We decided to use a **Singleton** for the board, because it contains all the informations, about the players, the cases, so it can't be duplicated. In order to assure it, the Singleton is the best pattern. Moreover, we only want the solution to run one game at the same time like Tyler said "One fight at a time, fellas"

### Observer

We use an **Observer** pattern for the board : When a player use money, it notify the board and the board verify if the player has enough money. If not, he is removed of the game and all his properties become free again.
When the player decide by himself to use money, we check first if he has enough money, in order to avoid a game where a player would be eliminated because he didn't check if he could buy *Rue de la Paix*

### Moderator

We use a **Moderator** for the interaction between the players and the cases. There is a lot of possible interactions, so we use the board to ensure the connection between the right player and the case he is on. 
