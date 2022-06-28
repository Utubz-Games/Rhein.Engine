### NOTICE: Rhein Engine is still in active development, and may have plenty of features missing!

# Rhein.Engine
A very cool and versatile .NET framework for making rhythm games!

## Versions Supported
| .NET Version       | Supported |
| ------------------ | --------- |
| .NET Standard 2.0  | No        |
| .NET Standard 2.1  | Yes       |
| .NET Framework 4.X | Yes       |
| .NET 6.0           | Yes       |

## Using Rhein Engine
Right now, there aren't any precompiled library files to use (observe the notice above). What you can get around this by downloading the source code from this repository and adding `Rhein.Engine.csproj` as a dependency to your project.

You will be able to run Rhein Engine without any issues as long as you're using any of the supported versions above.

## Using Rhein Engine (with Unity)
Ahh, Unity. We have a love-hate relationship. Because Unity blocks any API calls from threads other than the main one, it's really difficult to use. Rhein Engine *is* technically usable with it if you start a `Rhein.Game` without starting a new thread, but this requires using Unity's update loop which isn't ideal for rhythm games. One alternative is using a custom input library for Unity (which is currently what I'm doing due to reported input delay from its built-in system), but not everyone has the time to write up some cross-platform C++ code.

I may release a native input library in the future. But at the moment, all we can do is be upset at Unity.

## Contributing
Any contributions to push the project forward will help, even if it's correcting a small grammar mistake. For a list of things to do, try looking at the [projects tab](https://github.com/Utubz-Games/RheinEngine/projects) for some guidance. There should be an up-to-date list of what needs to get done before release.
