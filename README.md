### NOTICE: Rhein Engine is still in active development, and may have plenty of features missing!

# Rhein.Engine
A C# Rhythm Game Engine that only processes the technical stuff.

## Versions Supported
| .NET Version      | Supported |
| ----------------- | --------- |
| .NET Standard 2.0 | Yes       |
| .NET 4.X          | Yes       |
| .NET 5.0          | Yes       |
| .NET 6.0          | Yes       |

## Using Rhein Engine (without Unity)
Right now, there aren't any precompiled libraries to use (since this isn't quite finished yet, look at the notice above), but what you can do instead (for Visual Studio) is download the source code, add `RheinEngine.csproj` to your solution, and link Rhein Engine to your own project as a dependency.

You should be able to run Rhein Engine without any issues as long as you're using the correct version (by default this is .NET 5.0, you may want to alter the project a bit to an older version if needed).

## Using Rhein Engine (with Unity)
Rhein Engine takes up another thread to enable responsive input, but this makes Rhein Engine almost unusable with Unity. This is because it blocks any and all API calls from other threads. A fix for this is currently being worked on along-side Rhein Engine at the moment.

## Contributing
Any contributions to push the project forward will help, even if it's correcting a small grammar mistake. Just be sure to follow the code guidelines (found at `CODESTYLE.md` at the root directory), or else your pull request won't be approved. For a list of things to do, try looking at the [projects tab](https://github.com/Utubz-Games/RheinEngine/projects) for some guidance. There should be an up-to-date list of what needs to get done before release.
