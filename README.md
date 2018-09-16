# KillSwitch
<!-- Replace this badge with your own-->
[![Build status](https://ci.appveyor.com/api/projects/status/hv6uyc059rqbc6fj?svg=true)](https://ci.appveyor.com/project/madskristensen/extensibilitytools)

Download The Precompiled binary [here](https://github.com/t0nic/killswitch-windows/releases])
---------------------------------------

![Loading image...](https://i.imgur.com/B29zayG.png)

VPN Kill switch which used a listener to detect disconnections

See the [change log](CHANGELOG.md) for changes and road map.

## How To Use

- download the source and compile, or go to releases and download the precompiled binary
- turn on your vpn
- run KillSwitch
- select the interface that your vpn runs on
- if you are disconnected from the vpn
  - close all programs that could expose your (once you turn your internet traffic back on)
  - close KillSwitch
  - restart KillSwitch, and close it after you see that your internet has been enabled.
  - connect to your vpn again and run the program
 
  
## How it works
Once your vpn is connect, and you have selected the proper interface, KillSwitch will begin listening for a change of connection on that interface, and once it does, it will quickly check if your vpn is down, and if it is, KillSwitch will use ipconfig to disable outgoing traffic to stop yourself from leaking your IP.

## Why?
This is for the people who use a VPN that does not come with a premade kill switch.
  

## Contribute/To Do
### If you wanna help or wanna know what is going to be added in the coming releases, here is a list of things that need to be done.
- create linux version
- There is a bug with re-enabling the interface (quick fix by reoping and closing the program)
- Give the option to close all programs with internet traffic besides the vpn
- Auto detect interface
- use multithreading

## Program screenshots
### Selecting the interface and running the scanner/listener
![Loading image....](https://i.imgur.com/yn8bq34.png)
### Dissconnecting from the vpn (we try to avoid this)
![Loading image....](https://i.imgur.com/usPChe2.png)
### Internet connection disabled
![Loading image....](https://i.imgur.com/ZyncrDJ.png) 

## License

