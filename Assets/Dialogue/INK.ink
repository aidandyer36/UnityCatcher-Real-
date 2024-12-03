INCLUDE globals.ink


{kynnTutorial == false: -> StoryStart}{kynnTutorial == true: -> GoAway}
===StoryStart===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
So if you’re going to graduate you need to beat the department heads, first up is the art department head Vicente Garcia.
But first you need to collect more Monsters. For now I would suggest going to the Music, Philosophy and Physical Education departments.

    -> DONE

===GoAway===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
"Hey. Go away. Get some Monsters."

-> DONE