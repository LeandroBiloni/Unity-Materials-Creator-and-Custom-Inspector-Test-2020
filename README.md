# Unity-Materials-Creator-and-Custom-Inspector-Test-2020
Custom Windows to create standard materials and apply them to multiple objects at the same time. 
Custom Inspector that allows you to see a dictionary and a Custom Inspector to create waypoints in Edit Mode. 
Project made for Engine Application II

For materials functionality:
-Click on "Custom" on the top menu bar (where "File", "Edit", etc. are found) and click on "Material Creator".
-A window will open where you can specify the name for the material (it will be the file name) and the color.
-"Create" button will create in your Assets folder the material.
-"Apply to objects" button will open a new window where you can drop materials and objects with mesh renderer.
-If you added various materials you can select which one to use checking the "Use this material" box.
-Once you added the materials you can apply them to the objects individually or to all of them.

For checkpoints functionality:
-Add "Player" and "Position Log" scripts to the game object.
-Specify the units after each position will be recorded.
-Move your object around the scene and the positions will be saved in "Recorded Positions" section.
-When you are okay with the positions, click on "Create" button to convert those positions into waypoints.
-Enter PlayMode and press Space to see the object move to the each checkpoint. (It will teleport to each one, you can change its behaviour in the "Player" script).

-Press "Clear Positions" button to delete all recorded positions (not waypoints).
-Press "Clear Waypoints" button to delete all recorded waypoints (not positions).
