# KillSwitch
<!-- Replace this badge with your own-->
[![Build status](https://ci.appveyor.com/api/projects/status/hv6uyc059rqbc6fj?svg=true)](https://ci.appveyor.com/project/madskristensen/extensibilitytools)

Download The Precompiled binary [here](https://github.com/t0nic/killswitch-windows/releases])
---------------------------------------

![alt text](https://i.imgur.com/B29zayG.png)

VPN Kill switch which used a listener to detech a change

See the [change log](CHANGELOG.md) for changes and road map.

## How To Use

- download the source and compile, or go to releases and download the precompiled binary
- turn on your vpn
- run KillSwitch
- select the interface that your vpn runs on
- surf with easy
  
## How it works
Once your vpn is connect, and you have selected the proper interface, KillSwitch will begin listening for a change of connection on that interface, and once it does, it will quickly check if your vpn is down, and if it is, KillSwitch will use ipconfig to disable outgoing traffic to stop yourself from leaking your IP.

## Why?
This is for the people who use a VPN that does not come with a premade kill switch.
  

## Contribute
do et

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools 2015](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)
