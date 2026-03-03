Name: Jonathan Rodriguez
NetID: jdr220004
DoS: 3-02-26
Computer Platform: Arch Linux, 6.18.9-arch1-2, AMD Barcelo Integrated Graphics
Unity Version: 6000.0.68f1
Description:
    This is currently stage 1 of a multi part assignment, I assume, where I am making a space trash collection game. 
    Currently for this phase, I have created a scene with a planet, transparent orbital belt, and a script that randomly generates all the objects onto the plane.
    Each object rotates and revolves respectively according to specifications provided.
    There is also a spaceship, which the user controls, and has 2 cameras attached, a forward and rear facing camera toggled by holding and releasing R. I also added a movement script since it helped in testing to see if my rotation and revolution was working correctly (moving the camera manually every time is not fun!).
    For lighting, there is a directional light directly overhead as well as an oscillating spotlight on the nose of the spaceship.
    There is also a basic hud with a health bar and score.
Problems Encountered: 
    For some reason, my rotation and revolution scripts did not work properly when the object spun or revolved on a different plane apart from the y axis. I ended up making separate scripts for rotation and orbiting as well as using different math for the trash orbiting the moon since it was not based on the origin of the scene and instead on the origin of a moving moon.
Assets Used: used a premade spaceship asset, a sputnik satellite asset, and planet/moon materials
Youtube Link: https://youtu.be/JkL-Vld7Nuk

