
# SneakawayUtilities v.3

The third attempt to share code across projects, using the "linked submodule" method below



## Instructions


#### 1. Create the lib project
e.g. https://github.com/sneakaway-studio/SneakawayUtilities

```bash
# Create new Unity project, add scripts to share, then...
cd ~/<project_root> # change to project root
git init # begin version tracking
git push # publish lib to remote
```


#### 2. Import the lib as submodule
In the project where you want to use scripts from lib...

```bash
# confirm you are in the project root
pwd
# create a folder (for all submodules)
mkdir Submodules
# change into it
cd Submodules
# add the lib project (from remote) as a submodule of proj
git submodule add https://github.com/sneakaway-studio/SneakawayUtilities SneakawayUtilities
```
^ This ensures the code is now shared in both project but tracked by git. However, because it is not inside /Assets then Unity doesn't actually import the code into the **proj**. So, we need to link the code...


#### 3. Link the lib code

```bash
# change into the /Assets dir
cd ../Assets
# (if it doesn't exist) create a Plugins folder
mkdir Submodules
# create a symlink named "SneakawayUtilities" that links to **ASSETS** folder in lib
ln -s ../../Submodules/SneakawayUtilities/Assets/ SneakawayUtilities
```

#### References

- prime31 [A Method for Working with Shared Code with Unity and Git](https://prime31.github.io/A-Method-for-Working-with-Shared-Code-with-Unity-and-Git/)
- xtoff [Git-submodules in Unity (my notes)](https://cschnack.de/blog/2019/gitsubm/) January 24, 2019
- https://devconnected.com/how-to-add-and-update-git-submodules/




## Extra submodule commands

Move a submodule

```bash
git mv old/submod new/submod
```


## Dependencies

https://github.com/akbiggs/UnityTimer


## To do

- [ ] Import many more scripts inside Graverobbers Passage
- [ ] Switch those scripts in Graverobbers Passage to this repo
- [ ] Change all to `namespace SneakawayUtilities`
- [ ] FInish setting up the package https://www.youtube.com/watch?v=mgsLb3TKljk&ab_channel=Unity






## Source for resolutions table

learn-computing/topics/graphics.md
