# Data-Visualisation-Game

## Overview
Crime data visualisation across England's counties demonstrated in an educational guessing game.
A crime category is picked before the game begins and then player's must compete to guess which of two selected counties has the lowest crime cases for that crime category. 

### Data
The crime data that was used within this project was sourced from https://data.police.uk/data/. This provided crime data on recorded cases by police forces across England, detailing the types of crimes commited, the total number of cases by crime category, and the years in which the data was recorded.  

## How It Works
Crime data is parsed and queryed from the dataset by police force name, year, and crime type. A map of England made up of county gameobjects each hold a reference to it's corresponding crime data from the dataset. This data is then pulled and displayed when a county is clicked on.  

## How To Play
### Guessing Game
- 1 ) Pick a crime category and a year to pull crime data from
- 2 ) Select a county on the map that you believe has the fewest number of cases for the crime category you chose
- 3 ) Player two now also makes their choice by selecting a county
- 4 ) Once both players have made their guess the results are presented along with a fact about one of the countys that was guessed
- 5 ) Players repeat step 2 to 4 until the final round is reached and the game is over

![Screenshot (232)](https://user-images.githubusercontent.com/55750961/201859583-bf3f5f5a-86c1-4df0-a56f-6ad02a75c3bc.png)
![Screenshot (234)](https://user-images.githubusercontent.com/55750961/201859618-d466ce07-2dc5-48fc-acb7-1e7179b97262.png)

### Visualisation Mode
- 1 ) Pick a crime category and a year to visualise 
- 2 ) Click a county on the map to reveal data for the entirety of England. The number of cases for the selected county according to the crime category and year will also be displayed.
- 3 ) Repeat steps 1 to 2 for any other crime data you want to see visualised

![Screenshot (229)](https://user-images.githubusercontent.com/55750961/201858081-7923d2fb-71b9-4d3a-a50b-fec412fe6c0a.png)

## How To Run
### In-editor
- 1 ) Run the Game scene
- 2 ) Choose either "PLAY THE GAME" to start the guessing game, or "SHOW DATA" to load the visualisation mode 

![Screenshot (231)](https://user-images.githubusercontent.com/55750961/201858634-3131f494-4151-4712-b73e-9f464afc45ec.png)

## Version and Dependencies
- Made with Unity 2022.1.16f1
