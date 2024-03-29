# MageSimulator
Unity game using Leap Motion to cast fire ball ---> mage style guaranteed

To see the video tutorial to understand how to play this game,  please click here:
https://youtu.be/Nm71lszHdkI

#REQUIREMENTS
Leap Motion hardware
Leap Motion SDK
Leap Motion Unity Core Assets
Unity 5.2.X
Windows OS

# BRIEFING
This tutorial will describe how to load and play the Mage Simulator game.

# LOADING THE GAME
There are 2 options for loading this game:

1. The easy way double clicking the .exe file:
Download the project from https://github.com/xzs424/MageSimulator.
Double click MageSimulator.exe in Windows OS.
You are now ready to play the game.

2. The harder way using Unity:
Download the project from https://github.com/xzs424/MageSimulator.
Download and install Unity from https://unity3d.com/get-unity/download.
Download and install the Leap Motion SDK from https://developer.leapmotion.com/downloads.
Download and install the Leap Motion Unity Core Assets Package from https://developer.leapmotion.com/downloads/unity.
Launch Unity, and load the project.
After loading, browse to the Assets > Scenes folder in the Project window and double click on the scene called Demo.
Import the Leap Motion Unity Core Assets package (Insert > Import Package > Custom Package > Browse for the location of the package saved on your computer).
Ensure the Leap Motion is plugged in to your computer with the correct drivers installed. 
Press the start button at the top of Unity.
You are now ready to play the game.

#OBJECTIVE
In Mage Simulator, your goal is to shoot fireballs at the cube targets on the screen.
Your score increases the more cubes you can hit.

#SCORING
You receive a point for every single cube that you are able to hit.
You will also receive a point if you hit a cube that is floating (i.e. has already been hit).
There is no time limit, you just must be able to hit the cubes by manipulating the size and direction of the fireball.

# CONTROLS
In this section, you will learn how to generate a fireball, increase the size of the fireball, shooting/releasing the fireball, manipulating the direction of fireball, and generating a new fireball after you release a fireball.

# Generating a Fireball
Place both hands directly above the Leap Motion controller about 10-15cm, palms facing each other so that your hands are parallel to each other. 
Your palms should be about 7-10cm apart.
This will create a fireball between your hands.

# Increasing the Size of the Fireball
The Leap Motion has roughly up to 20cm of horizontal range detection. 
While your hands are held normal above the Leap Motion and roughly 7-10cm apart, slowly increase the distance between your palms.
The fireball should increase in size.
The fireball can only increase a certain amount; be sure to remain within the Leap Motion detection range.
If you increase the distance between your palms too much, the fireball will drop.

# Releasing/Shooting the Fireball
To shoot/release the fireball, you must first generate a fireball.
Once a fireball is in between your hands, bend your thumbs inwards towards your palms.
The fireball should release and be shot forward.
The fireball has constant acceleration, so it travels faster as distance increases.
The acceleration of the fireball cannot be changed.

# Controlling the Direction of the Fireball Release
The game takes the average of the vector directions between both hands to determine the release direction of the fireball.
In order to change the direction of release, you must first generate a fireball.
Once a fireball is between your hands, adjust the orientation of your fingers (e.g. you can either adjust the pitch, or yaw of your fingers).
Once you are in the desired orientation, bend your thumbs inwards in order to release the fireball.
The direction of release should change.
Note that the orientation of the fingers on both hands do not need to be the same; the average is taken between the 2 vectors.
You can manipulate the fireball to shoot up, down, left, or right using this method.

# Generating a New Fireball after Releasing a Fireball
To generate consecutive fireballs, you can perform one of the following motions:
- Move your hands outside the range of the Leap Motion controller detection range, and then move them back within the range of detection again.
- Face your palms slightly downwards, at about a 45 degree angle so that your palms are facing slightly normal to the Leap Motion controller. Then, readjust your palms so that they are facing each other and your hands are parallel.

If you perform these motions successfully, the fireball (should you be currently holding one) will drop. If you are not holding a fireball, a new fireball should be generated between your palms.

# Restarting the Game
Press 'R' on the keyboard to reload the game.
Note that the game will be reset to its initial state; score will be reset to 0, and cubes will be reset to their original position.
