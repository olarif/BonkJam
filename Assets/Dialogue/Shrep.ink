INCLUDE globals.ink

Hello sir! #speaker:Shrep #portrait:shrep #layout:left
{ globalmood == "": You're not in a mood yet | I see you're feeling {globalmood}}

{ globalmood == "": -> main | -> alreadyChose }

-> main

=== main ===
What mood are you in today?
+ [<color=\#F8FF30>Horny]
    Boop, go to horny jail
    -> chosen("Horny")
+ [<color=\#5B81FF>Hungry]
    -> chosen("Hungry")
+ [Depressed :(]
    -> chosen("Depressed")
    
=== chosen(mood) ===
~ globalmood = mood
You chose {mood}!
-> END
    
=== alreadyChose ===
You already chose {globalmood}!
Well shit, I don't really care
See ya
-> END