
# SneakawayUtilities v.3

The third attempt to share code across projects, using the "linked submodule" method below



## Instructions


1. Create a new Unity project for scripts to share, init / publish on Github<br>
	e.g. https://github.com/sneakaway-studio/SneakawayUtilities
2. Import the lib as submodule

```bash
# confirm you are in *your* project root
cd ~/<project_root>
# create a folder (for all submodules)
mkdir Submodules
# change into it
cd Submodules
# add the lib project (from remote) as a submodule of proj
git submodule add https://github.com/sneakaway-studio/SneakawayUtilities SneakawayUtilities
```
^ This ensures the code is now shared in both project but tracked by git. However, because it is not inside /Assets then Unity doesn't actually import the code into the **proj**. So, we need to link the code...


3. Link the lib code

```bash
# change into the /Assets dir
cd ../Assets
# (if it doesn't exist) create a Plugins folder
mkdir Submodules
# create a symlink named "SneakawayUtilities" that links to **ASSETS** folder in lib
ln -s ../../Submodules/SneakawayUtilities/Assets/ SneakawayUtilities
```

4. Keep in mind the following:

- You can create/edit/delete files in either the `~/<project>/Submodules` or `~/<project>/Assets/Plugins` folders.
- The best way to add library files to source control is with the command line inside `~/<project>/Submodules`
- These tutorials: [Method for Working with Shared Code with Unity and Git](https://prime31.github.io/A-Method-for-Working-with-Shared-Code-with-Unity-and-Git/) and [Git-submodules in Unity](https://cschnack.de/blog/2019/gitsubm/)












## Extra submodule commands

Move a submodule

```bash
git mv old/submod new/submod
```

Add or update https://devconnected.com/how-to-add-and-update-git-submodules/



## Dependencies

https://github.com/akbiggs/UnityTimer


## To do

- [ ] Import many more scripts inside Graverobbers Passage
- [ ] Switch those scripts in Graverobbers Passage to this repo
- [ ] Change all to `namespace SneakawayUtilities`
- [ ] FInish setting up the package https://www.youtube.com/watch?v=mgsLb3TKljk&ab_channel=Unity






## Source for resolutions table

learn-computing/topics/graphics.md
