# Mc(Hack)fee Antivirus 2022 - Pan(demic)-Man

Winner of the "Achievement Unlocked: most fun and creative game dev hack" _and_ the "Best Design: most aesthetic hack sporting nice UI/UX" superlatives @ [McHacks 9](https://www.mchacks.ca)! 

This project was built for [McHacks 9](https://www.mchacks.ca), a virtual, 36-hour hackathon. Our goal was to learn more about game development, so we created a COVID-themed spoof of the classic '80s arcade game: Pac-Man. 

Try the game [HERE](https://pacdemic-man-2vsjz.ondigitalocean.app)!

_Project made with_ ❤️ _by [Nathalie](https://github.com/nredick), [Elinor](https://github.com/elinorpd) and [Alex](https://github.com/allu5662)._

## ✍️ Project Description

Oh no! Pac-Man is being hunted by COVID-19 variants: Alpha (Pink), Beta (Beta), Delta (Orange), and Omicron (Green). Classic game pieces ('sprites') like ghosts, power pellets, and fruits have been replaced by things we are all now unfortunately familiar with: COVID-19 variants, face-masks, vaccine syringes, hand sanitizer, and more.

<!-- In the hopes of creating an educational gamespace, there are informative messages about COVID safety between game rounds.-->

## 💡 Inspiration
This project was inspired by our desire to dive into the world of game development, an area our team was unfamiliar with. We approached this hackathon with learning being the main end goal of our project. The idea for the game itself was, in no small part, inspired by the realities of the current pandemic and of course, Pac-Man. 

## ⚙️ How we built it
The game was built on the Unity game development platform using C# and is largely based on a tutorial by Zigorous ([YouTube](https://youtu.be/TKt_VlMn_aA), [Github](https://github.com/zigurous/unity-pacman-tutorial)). We would like to credit the original author and emphasize that we approached this hackathon purely as a learning experience. 

- The pills, syringe, and hand sanitizer required individual function implementations in C# for the "ghost" reactions to the power-ups 
- Fun(?), appropriately themed game over text was added 
- Animation of of Pacdemic-Man death scene was created 
- Custom sprites were added for most of the game pieces 

The sprites were custom made by our team just for this project, see them in all of their glory below!

## 🚧 Challenges we ran into
The Unity platform has a big learning curve, especially since no one on our team was familiar with C#. We ran into quite a few roadblocks trying to find settings and functions we had never used before. 

## 🏆 Accomplishments that we're proud of
We're definitely very proud of the game as a whole and the creativity that went into making it possible. 

## 🧠 What we learned
We learned a lot more about the game development process, the Unity platform, and the rules of Pac-Man. The physics behind the movements of Pac-Man and ghosts was particularly fun to learn about and code! 

And at least for some of us, that game development is not a career path we'll be pursuing. 

## 🎮 Gameplay 

- Like the original Pac-Man game, the goal is to accumulate as many points as possible
- Gameplay begins immediately!
- Move pacdemic-man with the  `W` `A` `S` `D` keys or `up` `down` `left` `right` arrow keys 
- Edible variants move at half-speed 

| Item           | Bonus                                   |
|----------------|-----------------------------------------|
| Vaccine        | +1 life                                 |
| Pill           | 5s immunity & slower variants & +25 pts |
| Mask           | edible variants & +50 pts               |
| Hand Sanitizer | +15 pts                                 |
| Pellets        | +10 pts                                 |

## Custom Sprites

**COVID-19 "Ghost" Variants:**

| ![alpha](demos/alpha.png) |    ![beta](demos/beta.png)    |
|:-------------------------------:|:-----------------------------------:|
|          Alpha Variant          |             Beta Variant            |
| ![delta](demos/delta.png) | ![omicron](demos/omicron.png) |
|          Delta Variant          |           Omicron Variant           |

**Vulnerable ghosts:**

![dead](demos/edible.png)

**Face-mask "power pellets":** 

![dead](demos/mask.png)

**Vaccine syringe, hand sanitizer, and pill -themed "fruits":**

![syringe](demos/syringe.png)
![sanitizer](demos/sanitizer.png)
![pill](demos/pill.png)

## 📦 Demo
[![demo](https://img.youtube.com/vi/GJLHuS9S7uQ/0.jpg)](https://www.youtube.com/watch?v=GJLHuS9S7uQ "Click to play on YouTube")

## 🧹 Repository Organization

```
.
├── README.md
├── custom_sprites
│   ├── Fruit_Pill.png
│   ├── Fruit_Sanitizer.png
│   ├── Fruit_Syringe.png
│   ├── Ghost_Alpha.png
│   ├── Ghost_Beta.png
│   ├── Ghost_Delta.png
│   ├── Ghost_Omicron.png
│   ├── mask.png
│   ├── pacman_0.png
│   ├── pacman_1.png
│   ├── pacman_10.png
│   ├── pacman_11.png
│   ├── pacman_2.png
│   ├── pacman_3.png
│   ├── pacman_4.png
│   ├── pacman_5.png
│   ├── pacman_6.png
│   ├── pacman_7.png
│   ├── pacman_8.png
│   ├── pacman_9.png
│   ├── pacmans.png
│   └── pill.png
├── demos
│   ├── alpha.png
│   ├── beta.png
│   ├── delta.png
│   ├── edible.png
│   ├── mask.png
│   ├── omicron.png
│   ├── pill.png
│   ├── sanitizer.png
│   └── syringe.png
└── panman
    ├── Assets
    ├── Library
    ├── Logs
    ├── Packages
    ├── ProjectSettings
    ├── Temp
    └── UserSettings

10 directories, 32 files
```
