-> main

=== main ===
Sup nerd
You're dreaming.
You need to collect the three tokens of the core moods
Then you can make some soup with them to wake up
What mood are you in right now?
    
    + [Hungry]
        -> chosen("Hungry")
    + [Horny]
        -> chosen("Horny")
    + [Depressed]
        -> chosen("Depressed")
        
=== chosen(mood) ===
Oh, you're feeling {mood}? Interesting
In that case, please use the door in the middle


-> END