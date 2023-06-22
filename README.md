
# SneakawayUtilities

Share common Unity / C# code across projects


## About

A "utilities" project to share code across multiple Unity projects:

- It lives in its own Unity project, so we can write tests.
- It has own Git repo so code can be edited / pushed back to origin.
- When used in other Unity projects only the `Assets/` folder is [symlinked](https://www.freecodecamp.org/news/symlink-tutorial-in-linux-how-to-create-and-remove-a-symbolic-link/) so it will not cause Unity project or Git (ahem, submodules*) issues.
- Everything is be "namespaced" so protected from pollution.

```cs
// structure of "<Category>Tools" where static methods live
// everything else is a droppable monobehavior
namespace SneakawayUtilities 
{
	public static class MathTools 
    {
		public static int Random()
        {
			// code
		}
	}
}
```







## Instructions

1. Clone to any location on your computer (these steps assume the same parent directory)

```bash
# change into the directory (e.g. where your other projects live)
cd ~/Documents/Github/

# clone the repository
git clone https://github.com/sneakaway-studio/SneakawayUtilities.git
```

2. Add a folder in your Unity project where the files will be linked

```bash
# change into the existing project
cd ~/Documents/Github/CoolProject/Assets/

# add new folder for the symlink (can be any name) and change into it
mkdir Plugins && cd Plugins
```

3. Create a symlink to the project's Asset folder from your Unity project.

```bash
# Mac: create symlink named "SneakawayUtilities" pointing to Assets/
ln -s ../../../SneakawayUtilities/Assets/ SneakawayUtilities

# Windows: 
???
```








## Dependencies

https://github.com/akbiggs/UnityTimer


## To do

- [ ] Import many more scripts inside Graverobbers Passage
- [ ] Switch those scripts in Graverobbers Passage to this repo

 




## References

- [Source for resolutions table](https://github.com/omundy/learn-computing/blob/main/topics/displays.md)
- [Method for Working with Shared Code with Unity and Git](https://prime31.github.io/A-Method-for-Working-with-Shared-Code-with-Unity-and-Git/)
- [Git-submodules in Unity](https://cschnack.de/blog/2019/gitsubm/)
- [The Complete Guide to Creating Symbolic Links (aka Symlinks) on Windows](https://www.howtogeek.com/16226/complete-guide-to-symbolic-links-symlinks-on-windows-or-linux/)
- [What are essential differences in the implementation of Symbolic Links between Windows and Linux?](https://www.serveradminz.com/blog/essential-differences-implementation-symbolic-links-windows-linux/)












<details>
<summary>Former method using submodules</summary>


*Formerly I used Git Submodule to embed the repository in the parent repo but I found submodules (and SourceTree) to be way too complicated to use, and managing branches from all the separate projects was a pain. 


### Installation

The below steps cover two use cases:

1. The submodule ***is already installed*** (look in .gitmodules to confirm) in a "parent" project that you have cloned
2. You need to install this project as a ***new*** submodule inside a "parent" project


#### Option 1: Update the submodule already installed in your project

```bash
# confirm you are in the "parent" project root (e.g. cd ~/Documents/Github/CTS-Viz/)
cd ~/<project_root>
# update the submodule
git submodule update --init --recursive
```


#### Option 2a. Add the repository to the parent

```bash
# confirm you are in the "parent" project root (e.g. cd ~/Documents/Github/CTS-Viz/)
cd ~/<project_root>
# create a folder (for all submodules)
mkdir Submodules
# change into it
cd Submodules
# (optional) make sure GIT LFS is installed
git lfs install
# add the utilities (from remote) as a submodule of project (*Make sure you have read access to the repo or this will fail!*)
git submodule add https://github.com/sneakaway-studio/SneakawayUtilities SneakawayUtilities
```

^ This ensures the code is now shared in both project but tracked by git. However, because it is not inside /Assets then Unity doesn't actually import the code into the **proj**. So, we need to link the code...


#### Option 2b. Link the lib code

```bash
# change into the /Assets dir
cd ../Assets
# (if it doesn't exist) create a Plugins folder and cd into it
mkdir Plugins && cd Plugins
# create a symlink named "SneakawayUtilities" that links to **ASSETS** folder in lib
ln -s ../../Submodules/SneakawayUtilities/Assets/ SneakawayUtilities
```



### Editing the code

- You can create/edit/delete files in any of the following
	- `~/<project>/Submodules`
	- `~/<project>/Assets/Plugins`
	- `SneakawayUtilities/Assets/`
- Source control changes (keep in their own branches)
 	- Command line or Atom in `~/<project>/Submodules` => `<project-name>-edits`
 	- Github Desktop `SneakawayUtilities/` => `main`



## Extra submodule commands


### Move a submodule

```bash
git mv old/submod new/submod
```

### Remove a submodule

```bash
# 1. delete the submodule folder
# 2. delete lines in .gitmodules file pointing to the module
# 3. delete reference in .git folder
rm -rf  ../../.git/modules/Submodules/SneakawayUtilities
```


Add or update https://devconnected.com/how-to-add-and-update-git-submodules/


</details>


