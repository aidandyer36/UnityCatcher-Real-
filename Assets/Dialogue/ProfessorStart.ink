EXTERNAL beginGame(string starter)
INCLUDE globals.ink

->Begin
===Begin===
#speaker:Professor Kynn 
This world is normal, completely normal. We’re on a normal campus with a normal curriculum. We have a normal student base and normal teachers. 
And we just like everyone else secretly create creatures out of inanimate objects on the campus and have an underground fight club with them…in a normal fashion. 
With a little bit of magic that I honestly don’t want to take the time to explain to you, as well as some love and a little bit of delirium we can turn objects into creatures and do battle with them. 
This is our world and it’s very normal. Welcome to our world, which is totally not a rip off of Pokémon.
->ChooseMajor

===ChooseMajor===
#speaker:Professor Kynn
What is your major?
 +[English] -> English
 +[Education] -> Education
 +[Anthropology] -> Anthropology
 +[Physics] -> Physics
 
===English===
#speaker:Professor Kynn 
Your starter is Fahrenheit 451, an arts type Monster. Is this the starter you want?
    +[Yes] 
        ~pokemon1 = "Celsius 233"
        ~kynnTutorial = true
        -> Farewell
    +[No] -> ChooseMajor
===Education===
#speaker:Professor Kynn 
Your starter is an Apple, a lame type Monster. Is this the starter you want? 
    +[Yes] 
        ~pokemon1 = "Fuji"
        ~kynnTutorial = true
        -> Farewell
    +[No] -> ChooseMajor
===Anthropology===
#speaker:Professor Kynn
Your starter is a Skull, a social type Monster. Is this the starter you want? 
    +[Yes] 
        ~pokemon1 = "Nasull"
        ~kynnTutorial = true
        -> Farewell
    +[No] -> ChooseMajor
===Physics===
#speaker:Professor Kynn
Your starter is a Newton's Cradle, a Maths type Monster. Is this the starter you want?
    +[Yes] 
        ~pokemon1 = "Newdle"
        ~kynnTutorial = true
        -> Farewell
    +[No] -> ChooseMajor

===Farewell===
Well then go off and defeat the department heads for Art, Computer Science, and the other 2! (I didn't want to open the spreadsheet)
 ~beginGame(pokemon1)
 -> END

