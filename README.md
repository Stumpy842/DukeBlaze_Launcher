![LogoWithTextMid](https://github.com/user-attachments/assets/93d3dc71-c8aa-4b91-865c-f04c84932a62)

**DukeBlaze** is a Launcher for eDuke32 that will allow you to easily run custom maps and modifications, and build your own collection. 

Unfortunately I have not found on the Internet a convenient launcher for Duke Nukem 3D, which would allow in two clicks to run various user-generated content and even more to compose their own collection. As a result, I came up with the idea of creating such a launcher primarily for myself and my friends. It would allow me to share a ready-made, pre-configured library of user-generated content for the game. It's still in the early stages of development, but the core functionality is already working and I'd like to share the results of my work with you. Hope you'll like it :)

![1](https://github.com/user-attachments/assets/de6ad51c-bc76-4a51-a1f6-1b5fb25c7957)

**How to install**
1) Download the latest [release](https://github.com/dragxnd/DukeBlaze_Launcher/releases/tag/WinRelease) and extract the archive into the eduke32 folder.
2) Run DukeBlazeLauncher.exe and make sure you select the correct version of eduke32.exe in the Settings menu
3) Press RUN button to play

**How to run a map/grp/con/def/zip**
1) Drag and drop the file into the Files field
2) Press RUN button to play

![2](https://github.com/user-attachments/assets/a215d824-cda9-4160-9373-d77f63b0fa46)

**How to make grp/con/def file as main** (-grp/-gamegrp, -h/-mh, -x/-mx) 
1) Drag and drop the file into the Files field
2) Select grp/con/def file
3) Under the Files field, you will now see the "Replace Main" checkbox. Tick it if you want to

![3](https://github.com/user-attachments/assets/8a36473b-a4db-4155-9699-23f76d9cae6f)

**How to save preset to your collection**
1) Select the folder in the preset tree where you want to save your new preset
2) Customise your preset using all available fields (Files, Additional parameters, Description ant etc.).
3) Write the name of the preset in the Preset Name field
4) Click Save Preset button

**How to run saved preset**
1) Select the preset in the preset tree
2) Press RUN button to play

**How to add description to preset**
1) Before saving the preset, click the Description button, add your text and click Save button

**How to read saved description**
1) Select the preset in the preset tree
2) Press Description button

**How to run the mod for another Duke3D.exe file**
1) Select "Custom eDuke32.exe" in the Additional Parameters field

**Where I can find my preset library**

\LauncherData\Description.dat

\LauncherData\Presets.dat

\LauncherData\PresetsSettings.dat

\LauncherData\Settings.dat


**Important! The additional content must be in the folder with the Launcher. I don't know why, but eDuke only works with relative paths**


********** New Version Release - Fork of original **********

This new release has all the functionality of the original and adds several new features and enhancements.

** Accelerator Keys for most functions **
Mnemonic keys are added for all the fields in the main window as well as many of the dialog windows. They work by holding the Alt key while pressing the Accelerator key, just as in most Windows programs.

** Menu Bar with new features **
A menu has been added which features numerous items not previously available. The most notable of these are Load and Save Presets, an enhanced Settings window with lots of additional options, and the ability to prune or sort the preset tree.

** Import Maps feature **
Found under the Tools menu is Import Maps which will allow you to bulk import map files to the presets tree.

** Reload Original Presets **
This menu option will reset the tree to the default, restoring the tree to an empty state.

** Color in Preset Tree **
In the Settings window you can choose to use color to highlight the nodes of the preset tree which will allow you to easily see the path to any item in the tree.

** Features which are currently not implemented **
Language support
Dark mode
