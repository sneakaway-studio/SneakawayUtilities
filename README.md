
# SneakawayUtilities

Share common Unity / C# code across projects

## About

This project uses the "linked submodule" method to share code across multiple Unity projects...
- In its own Unity project, so we can write tests
- Its own Git repo so code can be edited / pushed back to origin
- Only `Assets/` folder is symlinked so no Unity project / Git submodule issues (submodule duplicates in Github Desktop). Refer to these tutorials for details: [Method for Working with Shared Code with Unity and Git](https://prime31.github.io/A-Method-for-Working-with-Shared-Code-with-Unity-and-Git/) and [Git-submodules in Unity](https://cschnack.de/blog/2019/gitsubm/)


```cs
// structure of "<Category>Tools" where static methods live
// everything else is a droppable monobehavior
namespace SneakawayUtilities {
	public static class MathTools {
		public static int Random(){
			// code
		}
	}
}
```







## To install in a Unity project


### 1. Import the lib as submodule

```bash
# confirm you are in *your* project root
cd ~/<project_root>
# create a folder (for all submodules)
mkdir Submodules
# change into it
cd Submodules
# (optional) make sure GIT LFS is installed
git lfs install
# add the lib project (from remote) as a submodule of proj (*Make sure you have read access to the repo*)
git submodule add https://github.com/sneakaway-studio/SneakawayUtilities SneakawayUtilities
```

^ This ensures the code is now shared in both project but tracked by git. However, because it is not inside /Assets then Unity doesn't actually import the code into the **proj**. So, we need to link the code...


### 2. Link the lib code

```bash
# change into the /Assets dir
cd ../Assets
# (if it doesn't exist) create a Plugins folder and cd into it
mkdir Plugins && cd Plugins
# create a symlink named "SneakawayUtilities" that links to **ASSETS** folder in lib
ln -s ../../Submodules/SneakawayUtilities/Assets/ SneakawayUtilities
```

### 3. Edit the code

- You can create/edit/delete files in any of the following
	- `~/<project>/Submodules`
	- `~/<project>/Assets/Plugins`
	- `SneakawayUtilities/Assets/`
- Source control changes (keep in their own branches)
 	- Command line or Atom in `~/<project>/Submodules` => `<project-name>-edits`
 	- Github Desktop `SneakawayUtilities/` => `main`








## To do

- [ ] Import many more scripts inside Graverobbers Passage
- [ ] Switch those scripts in Graverobbers Passage to this repo





## Extra submodule commands

Move a submodule

```bash
git mv old/submod new/submod
```

Remove a submodule ([i](https://stackoverflow.com/a/1260982/441878))

```bash
git rm <path-to-submodule>
```



Add or update https://devconnected.com/how-to-add-and-update-git-submodules/



## Dependencies

https://github.com/akbiggs/UnityTimer



## Source for resolutions table

learn-computing/topics/graphics.md
