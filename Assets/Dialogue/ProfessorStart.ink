INCLUDE globals.ink
->Begin
===Begin===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
This world is normal, completely normal. We’re on a normal campus with a normal curriculum. We have a normal student base and normal teachers. And we just like everyone else secretly create creatures out of inanimate objects on the campus and have an underground fight club with them…in a normal fashion. With a little bit of magic that I honestly don’t want to take the time to explain to you, as well as some love and a little bit of delirium we can turn objects into creatures and do battle with them. This is our world and it’s very normal. Welcome to our world, which is totally not a rip off of Pokémon.
->ChooseMajor

===ChooseMajor===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
What is your major?
 +[English] -> English
 +[Education] -> Education
 +[Anthropology] -> Anthropology
 +[Physics] -> Physics
 
===English===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
Your starter is Fahrenheit 451, an arts type Monster. Is this the starter you want?
    +[Yes] -> DONE
        ~pokemon1 = "Fahrenheit451"
        ~kynnTutorial = true
        -> DONE
    +[No] -> Begin
===Education===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
Your starter is an Apple, a lame type Monster. Is this the starter you want? 
    +[Yes] -> DONE
        ~pokemon1 = "Apple"
        ~kynnTutorial = true
        -> DONE
    +[No] -> Begin
===Anthropology===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
Your starter is a kull, a social type Monster. Is this the starter you want? 
    +[Yes] -> DONE
        ~pokemon1 = "Skull"
        ~kynnTutorial = true
        -> DONE
    +[No] -> Begin
===Physics===
#speaker:Professor Kynn #portrait:KynnPortrait #layout:left
Your starter is a Newton's Cradle, a Maths type Monster. Is this the starter you want?
    +[Yes] -> DONE
        ~pokemon1 = "Newton's Cradle"
        ~kynnTutorial = true
        -> DONE
    +[No] -> Begin
    

