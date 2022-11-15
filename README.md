# Data-Visualisation-Game

## Overview
Crime data visualisation across England's counties demonstrated in an educational guessing game.
A crime category is picked before the game begins and then player's must compete to guess which of two selected counties has the lowest crime cases for that crime category. 

## Change from Develop
### Game Section
#### 1. [ADD] Add "score to win" as public variable 
- Note: Can change at game system object.
#### 2. [ADD] Show status "Select Crime Name & Year Below" at score bar when non-select.
- Note: Must select categories and year every round
#### 3. [ADD] Able to select crime type and year by press crime tpe button or slide a year slider
- Note: In case that slide a year slider first, Crime type will be chosen as "Theft"
#### 4. [ADD] Random crime type and year button
- Note: In case that slide a year slider first, Crime type will be chosen as "Theft"
#### 5. [BUG] Number of Round is wrong
- Main Problem: **Next_Button_Pressed do more than one time when press button**
- Troubleshoot: Change from increment to sum of score plus 1
#### 6. [BUG] Can select crime type in result screen
- Troubleshoot: Move Activate_Buttons() to next button pressed
- Note: Also change from Activate_Deactive_Buttons to Activate_Buttons(bool) to prevent ISSUE#5
#### 7. [BUG] Can spam next button while delay from WIN animation
- Troubleshoot: Disable next button until delay finished.
#### 8. [CHANGE] Result UI will show city of both player.
#### 9. [CHANGE] Minor Color Adjustment.

### Visualize Section
#### 10. [ADD] Show Type of crime select before select city on the map
- Note: It is on bottom-left
#### 11. [ADD] Show detail of city, year and number of case after click the city 
- Note: It is on top-left
#### 12. [CHANGE] Resolution of Data Visualization Canvas same as Game canvas (2560x1440)
#### 13. [CHANGE] Minor Color Adjustment.







