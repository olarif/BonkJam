INCLUDE globals.ink


{globalmood == "": -> firstTalk | -> currentMood }


=== firstTalk ===
Oh hi there, didn’t expect you to come here, usually you don’t dream of this place. #speaker:Ronald #portrait:ronald #layout:left

Wanna hear a joke? #speaker:Shrep #portrait:shrep #layout:left

You don’t seem very concerned with what’s going on here, why don’t I tell you how to get out of here first. #speaker:Ronald #portrait:ronald #layout:left
You need to -

What do you call a fish wearing a bowtie? #speaker:Shrep #portrait:shrep #layout:left
Sofishticated.

Ah yes, very funny, makes me wonder who of us actually is the clown. #speaker:Ronald #portrait:ronald #layout:left
Anyways, as I was saying, you ne-

Singing in the shower is fun until you get soap in your mouth.#speaker:Shrep #portrait:shrep #layout:left
Then it’s a soap opera.

... #speaker:Ronald #portrait:ronald #layout:left
Alright, yo-
    
Why do seagulls fly over the ocean?#speaker:Shrep #portrait:shrep #layout:left
Because if they flew over the bay, we’d call them bagels.

... #speaker:Ronald #portrait:ronald #layout:left
...
Don’t you want to get out of here?

You said it was a dream, so I figure I’ll wake up eventually anyways, so… I don't really care. #speaker:Shrep #portrait:shrep #layout:left

Well, usually you’d be correct with that but not this time. #speaker:Ronald #portrait:ronald #layout:left
And trust me you really want to get out of here.

Well, alright then. #speaker:Shrep #portrait:shrep #layout:left

Okay, so you need to- #speaker:Ronald #portrait:ronald #layout:left
   
Where do boats go when they’re sick?#speaker:Shrep #portrait:shrep #layout:left
To the boat doc.
Alright, I'm done.
For Now.

Haah, look, just collect the tokens of the three basic moods and throw them into the radiation soup. #speaker:Ronald #portrait:ronald #layout:left

The three basic moods?#speaker:Shrep #portrait:shrep #layout:left

Yes, hungry, horny, and depressed.#speaker:Ronald #portrait:ronald #layout:left
The three basic moods, common knowledge really.
Just put yourself into one of the moods and go through the portals over on the right side to collect the token.
So, which mood would you like to pick?
+ [<color=\#F8FF30>Horny]
    -> choseHorny
+ [<color=\#5B81FF>Hungry]
    -> choseHungry
+ [Depressed :(]
    -> choseDepression


=== currentMood ===
~ temp roll = RANDOM(1,8)

{ roll:

- 1:
    What time did the man go to the dentist?#speaker:Shrep #portrait:shrep #layout:left
    Tooth hurt-y.
- 2:
    What do you call cheese that isn’t yours?#speaker:Shrep #portrait:shrep #layout:left
    Nacho cheese.
- 3:
    Have you ever tried to catch a frog?#speaker:Shrep #portrait:shrep #layout:left
    I tried yesterday but I mist.
- 4:
    Singing in the shower is fun until you get soap in your mouth.#speaker:Shrep #portrait:shrep #layout:left
    Then it’s a soap opera.
- 5:
    What do you call a fish wearing a bowtie?#speaker:Shrep #portrait:shrep #layout:left
    Sofishticated.
- 6:
    What did the ocean say to the beach?#speaker:Shrep #portrait:shrep #layout:left
    Nothing, it just waved.
- 7:
    Why do seagulls fly over the ocean?#speaker:Shrep #portrait:shrep #layout:left
    Because if they flew over the bay, we’d call them bagels.
- 8:
    Where do boats go when they’re sick?#speaker:Shrep #portrait:shrep #layout:left
    To the boat doc.
}

Oh hi there, I see you’re currently {globalmood}. #speaker:Ronald #portrait:ronald #layout:left
Would you like to feel something different?
+ [<color=\#F8FF30>Horny]
    -> choseHorny
+ [<color=\#5B81FF>Hungry]
    -> choseHungry
+ [Depressed :(]
    -> choseDepression


=== choseHorny ===
Oh, I see you’re feeling horny.#speaker:Ronald #portrait:ronald #layout:left
I could help you with if you want.

No thanks, I’m not into clownfish, I prefer sharks personally.#speaker:Shrep #portrait:shrep #layout:left

Oh, I see, what a shame. Well then just bonk the eggplants in order of horniness.#speaker:Ronald #portrait:ronald #layout:left

Order of horniness?#speaker:Shrep #portrait:shrep #layout:left

Yeah, just remember that green is the least horny colour and purple is the horniest colour. #speaker:Ronald #portrait:ronald #layout:left
You need to be as horny as possible to collect the token of horniness.
You’ll recognise it through its characteristic white sap.
->END

=== choseHungry ===
Ah, hungry, this one’s easy, just don’t go through the bottom right portal and you’ll be fine. #speaker:Ronald #portrait:ronald #layout:left
And make sure that counter in the top left doesn’t go below zero.
->END

=== choseDepression ===
Ah, so you’re depressed, that sucks, I hope you feel better soon.#speaker:Ronald #portrait:ronald #layout:left

But, I’m not? #speaker:Shrep #portrait:shrep #layout:left

No need to lie to me, I know how you feel, maybe collecting the token of depression will help.#speaker:Ronald #portrait:ronald #layout:left
I hear it’s as blank as a plain white square.
Be careful over there though, there’s a lot of unnecessary stairs and rooms in that place.
->END



=== allTokensCollected ===
~ temp roll = RANDOM(1,8)

{ roll:

- 1:
    What time did the man go to the dentist?#speaker:Shrep #portrait:shrep #layout:left
    Tooth hurt-y.
- 2:
    What do you call cheese that isn’t yours?#speaker:Shrep #portrait:shrep #layout:left
    Nacho cheese.
- 3:
    Have you ever tried to catch a frog?#speaker:Shrep #portrait:shrep #layout:left
    I tried yesterday but I mist.
- 4:
    Singing in the shower is fun until you get soap in your mouth.#speaker:Shrep #portrait:shrep #layout:left
    Then it’s a soap opera.
- 5:
    What do you call a fish wearing a bowtie?#speaker:Shrep #portrait:shrep #layout:left
    Sofishticated.
- 6:
    What did the ocean say to the beach?#speaker:Shrep #portrait:shrep #layout:left
    Nothing, it just waved.
- 7:
    Why do seagulls fly over the ocean?#speaker:Shrep #portrait:shrep #layout:left
    Because if they flew over the bay, we’d call them bagels.
- 8:
    Where do boats go when they’re sick?#speaker:Shrep #portrait:shrep #layout:left
    To the boat doc.
}

You’ve got all the tokens, so it’s time to make soup with them now. #speaker:Ronald #portrait:ronald #layout:left
To do that you need to mix them with the “Creator Mood”.
And after doing so you'll need to jump into the soup to escape this dream.

creator mood?#speaker:Shrep #portrait:shrep #layout:left

Yes, don’t forget to capitalise it. It is the very first mood that there ever was.#speaker:Ronald #portrait:ronald #layout:left

So what is this CREATOR MOOD?#speaker:Shrep #portrait:shrep #layout:left

You don’t need to capitalise all the letters, you daft lit-#speaker:Ronald #portrait:ronald #layout:left

Do you want me to interrupt you with jokes again?#speaker:Shrep #portrait:shrep #layout:left

...#speaker:Ronald #portrait:ronald #layout:left

What did the ocean say to the beach?#speaker:Shrep #portrait:shrep #layout:left
Nothing, it just waved.

...#speaker:Ronald #portrait:ronald #layout:left
Okay you win.

...#speaker:Shrep #portrait:shrep #layout:left

What?#speaker:Ronald #portrait:ronald #layout:left

You haven’t told me what this cREaToR mOoD is called yet.#speaker:Shrep #portrait:shrep #layout:left

...#speaker:Ronald #portrait:ronald #layout:left

What?#speaker:Shrep #portrait:shrep #layout:left

Haah, whatever, prepare yourself even just hearing the name of the creator mood can cause your eardrums to implode.

I shall tense in preparation.#speaker:Shrep #portrait:shrep #layout:left
(tenses in preparation)
Alright, I’m ready

(Inhale)#speaker:Ronald #portrait:ronald #layout:left
(Exhale)
...

...#speaker:Shrep #portrait:shrep #layout:left

(Inhale)#speaker:Ronald #portrait:ronald #layout:left
(Exhale)

...#speaker:Shrep #portrait:shrep #layout:left

(Inhale)#speaker:Ronald #portrait:ronald #layout:left
(Exhale)

...#speaker:Shrep #portrait:shrep #layout:left

(Inhale)#speaker:Ronald #portrait:ronald #layout:left
(Exhale)

...#speaker:Shrep #portrait:shrep #layout:left

(Inhale)#speaker:Ronald #portrait:ronald #layout:left
(Exhale)

...#speaker:Shrep #portrait:shrep #layout:left

Angery.#speaker:Ronald #portrait:ronald #layout:left

That's it?#speaker:Shrep #portrait:shrep #layout:left

You seem surprisingly unfazed.#speaker:Ronald #portrait:ronald #layout:left

Whatever, let’s get on with it. Time to make some radiation mood soup.#speaker:Shrep #portrait:shrep #layout:left
->END

