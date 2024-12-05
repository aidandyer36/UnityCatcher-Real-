INCLUDE globals.ink
EXTERNAL beginFight(string pokemonName)
-> MetronomeStart

===MetronomeStart===
#speaker:Narrator
Would you like to animate the Metronome to take it?
    +[Yes] -> MetronomeAnimation
    +[No] -> DONE
    
===MetronomeAnimation===
#speaker:Narrator
You notice a small metronome on a table. It ticks back and forth keeping a pace and you think to yourself “that’ll do” as you turn it into a creature. You go to grab the metronome and the rod starts smacking you. 
~beginFight("Metro Gnome")
-> END