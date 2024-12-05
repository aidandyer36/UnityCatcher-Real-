INCLUDE globals.ink
EXTERNAL beginFight(string pokemonName)
-> SheetStart

===SheetStart===
#speaker:Narrator
Would you like to animate the Piano to take it?
    +[Yes] -> SheetAnimation
    +[No] -> DONE
    
===SheetAnimation===
#speaker:Narrator
The Piano Becomes a creature
~beginFight("Mozama")
-> DONE