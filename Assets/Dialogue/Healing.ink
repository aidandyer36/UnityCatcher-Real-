INCLUDE globals.ink

-> HealingPrompt
===HealingPrompt===
Would you like me to heal your monsters?
    +[Yes] -> HealPokemon
    +[No] -> RemindPlayer

===HealPokemon===
There! They should be all better now! Come back when you need healing. Go beat those department heads!
-> DONE

===RemindPlayer===
Well if you need to heal later, come back to me. Now go beat those department heads!
-> DONE