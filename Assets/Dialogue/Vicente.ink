INCLUDE globals.ink
{vicenteBeat == false: -> VicenteStart}{vicenteBeat == true: -> Lost}

===VicenteStart===
#speaker:Vicente #portrait:VicentePortrait #layout:left
Well Well Well. If it isn’t the 0.1 student, I imagine you’re here to battle monsters? Well good luck with that, I have no doubt my art monsters are stronger than whatever you could gather.
 -> DONE

===Lost===
#speaker:Vicente #portrait:VicentePortrait #layout:left
Uh why are you back? You won already, there's nothing for you to do here. Oh I know you want another Tiny Vincente, here have another one.
-> DONE

