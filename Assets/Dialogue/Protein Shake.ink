INCLUDE globals.ink
-> BarStart

===BarStart===
#speaker:Narrator, portrait:NarratorPortrait, layout:left
Would you like to animate those bars they use in gymnastics?
    +[Yes] -> BarAnimation
    +[No] -> DONE
    
===BarAnimation===
#speaker:Narrator, portrait:NarratorPortrait, layout:left
The art team said no. Would you want to animate the protein shake left behind instead?
    +[Yes] -> ShakeAnimation
    +[No] -> DONE
    
===ShakeAnimation===
#speaker:Narrator, portrait:NarratorPortrait, layout:left
You might be a little disappointed that you didn’t get the gymnastics bar as your creature but your despair quickly fades as you now see it, your new creature. Descending from the heavens it slowly floats down to you, as beautiful as it is divine you now see it your new creature… a protein shake
-> DONE