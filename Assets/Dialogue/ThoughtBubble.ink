INCLUDE globals.ink
-> ThoughtStart

===ThoughtStart===
#speaker:Narrator, portrait:NarratorPortrait, layout:left
You begin to think harder about what you want.
    +[Think More] -> ThoughtAnimation
    +[Take something else] -> DONE
    
===ThoughtAnimation===
#speaker:Narrator, portrait:NarratorPortrait, layout:left
You think even harder.
 +[Think Harder] -> ThoughtBubbleSpawn

===ThoughtBubbleSpawn===
You continue to think over your options for a new creature, you wonder and ponder and ponder some more, you really are indecisive aren't you? Eventually you notice something, you’ve already created the creature! You look above you and see a white bubble with three black dots on it, you somehow accidentally created a thought bubble as a creature. The thought bubble drops down on you and attacks.
-> DONE