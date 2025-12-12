## Project Overview
This project is an early-stage prototype demonstrating how behavior trees can be used to control decision-making in a turn-based RPG. 
It showcases basic rpg combat and a starting point for building more complex RPG mechanics.

## Controls

Use the arrow keys or WASD to move.
In combat you can either attack, dodge or use a shield. Dodge only give you chance to dodge the attack while shield will block incoming damage.
Using the shield will also take points. Once you run out of points you will be unable to use the shield.

## Directions

Defeat all the enemies in the dungeon. In order to fight them, you simply have to collide wtih them. All of the enemies use a simple behaviour tree sequence.
The sequences are:
- Attack -> Attack -> Shield (In till the enemy runs out of points to use the Shield)
- Attack -> Attack -> Dodge.

## Credits
Trenton Scott\
LD Montello\
Sai Vignesh Surthani

The Map was made using Inkarnate. https://inkarnate.com/ \
The sprites was made using the RPG Maker MZ character generator.
