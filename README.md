easel
=====

Rainbow checkers in Unity.

**Easel is currently a work in progress both on the design and implementation. The design is not final and obviously neither is the game's implementation.**

# What is Easel?

Easel is a two player board game. Each player begins the game with an equal assortment of Red, Blue, and Yellow pieces. These pieces are referred to as "Basic" pieces because they represent the three primary colors, Red, Blue, and Yellow. The player's goal is to combine his/her Basic pieces into Compound pieces (representing the secondary colors), and then again into Whole pieces.


## Basic Pieces

Basic pieces move diagonally. They can combine with an opponent's Basic piece.

 * Red + Blue = Purple
 * Blue + Yellow = Green
 * Yellow + Red = Orange

## Compound Pieces

Compound pieces move in their cardinal directions (up, down, left, right). They can only combine with an opponent's Basic piece that is its complement color. When they do, they become Whole pieces.

 * Purple + Yellow
 * Green + Red
 * Blue + Orange
 
## Whole Pieces

Whole pieces are black and can move in any direction. They cannot combine with any other piece. Each whole piece is worth one point to the owner.

## Combining

When a piece moves into a space occupied by another piece with which it can combine, the two combine, forming a new color piece. The new piece is owned *by the player who made the combination move*. For instance, if Player 1 moves his Red piece onto Player 2's Green piece, Player 1 will now own a Whole piece.
