# Otiose
**A 2D Action Roleplaying Game Made In C# using MonoGame 3.6 and .Net Core 2.0**
<br />
<br />
<p align="center">
<img src="https://i.imgur.com/H5lkdYN.gif"><img src="https://i.imgur.com/m9MWYNC.gif"><img src="https://i.imgur.com/M4hthaz.gif"><img src="https://i.imgur.com/R6WyHH4.gif"><img src="https://i.imgur.com/y8aO1tB.gif">
</p>

### Goals of the Project's Codebase
+ Anyone with a windows or linux machine should be able to do a `git clone` 
and have the entire solution compiled from source and playing in minutes.
+ Everything in plaintext or readable, no meta file obscuration, only .cs, .xml, .json, .png, .config,  etc..
+ Have documentation so that anyone interested in the project could get an overall
idea of the underlying systems involved by reading the `README.md` files located throughout.
+ Support both Visual Studio, and Rider IDEs on Windows and Linux.
+ Use open source software that is freely available to everyone.

<br />

### Goal of the Project's Gameplay
+ Playable with a Keyboard & Mouse or standard playstation/xbox style controller.
+ 2+ players simultaneously playing locally (net play a huge stretch).
+ fun
+ ...


<p align="center">
<img src="https://i.imgur.com/XcV08aS.gif"><img src="https://i.imgur.com/Yn8RA1o.gif"><img src="https://i.imgur.com/ex7frKD.gif">
</p>

### What is Otiose?
A game in a similiar vein as Squaresoft's [Secret of Mana](https://en.wikipedia.org/wiki/Secret_of_Mana) & [Seiken Densetsu 3](https://en.wikipedia.org/wiki/Seiken_Densetsu_3) for the SNES as well as [Legend of Mana](https://en.wikipedia.org/wiki/Legend_of_Mana) for the Playstation.  
<br />
But most of all it is just a way for me to practice programming while making something I find interesting.






<p align="center">
<img src="https://i.imgur.com/IppX9hV.gif">
</p>

### Why MonoGame?
+ I wanted to make a game that is primarily code and wanted to use a language I may find myself working in. 
My options boiled down to an XNA port (C#) or libGDX (Java). The games that have been released with XNA is sold me on MonoGame.
+ The Unity/Unreal/etc game engines seem to prioritize 3D games and I don't like that the click & drag interfaces hide things from you.
+ C# is a very cool language.
+ Open source!


<p align="center">
<img src="https://i.imgur.com/mMJ0NGj.gif">
</p>

<br />

## Compiling From Source

### Requirements
+ MonoGame 3.6
+ .NET Core 2.0
+ .NET Portable Class Library


### Troubleshooting
+ Core/Third-Party project has missing Dependency
  +  NuGet Package: Try removing and uninstalling it and then reinstalling it from the NuGet Manager.
  +  Project: Remove it and reference it again in the dependancy/reference manager of the project.
