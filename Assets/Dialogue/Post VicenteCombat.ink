INCLUDE globals.ink
{vicenteBeat == false: -> VicenteStart}{vicenteBeat == true: -> Beaten}

===VicenteStart===
#speaker:Vicente #portrait:VicentePortrait #layout:left
Well Well Well. If it isn’t the 0.1 student, I imagine you’re here to battle monsters? Well good luck with that, I have no doubt my art monsters are stronger than whatever you could gather.
 -> DONE

===Beaten===
#speaker:Vicente #portrait:VicentePortrait #layout:left
You have bested me in a game of Mortal Combat.
-> DONE