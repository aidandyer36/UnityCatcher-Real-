INCLUDE globals.ink
EXTERNAL beginFight(string pokemonName)
-> ViolinStart

===ViolinStart===
#speaker:Narrator
Would you like to animate the Violin to take it?
    +[Yes] -> ViolinAnimation
    +[No] -> DONE
    
===ViolinAnimation===
#speaker:Narrator
You walk over to the violin and turn it into a creature. It starts to float as it’s bow starts playing a bit of a tune. It then plays a sharp grating tune that hurts your ears. 
It then charges at you as you ready your creatures for a fight.
~beginFight("Cecilio")
-> DONE