# HyperTemplate

 A flexible hyper casual project template including some useful stuff.

### Installation

 - Clone this project.
 - Open it via Unity Hub (recommended versions: 2021.1.4f1 or higher)
 - Enjoy!

### Dependencies
All dependencies are auto-installing via Unity Package Manager, you don't need to do anything. License files can be found under relative directories.

 - [MyBox](https://github.com/Deadcows/MyBox) by [Deadcows](http://deadcow.ru/)
 - [Naughty Attributes](https://github.com/dbrizov/NaughtyAttributes) by [Denis Rizov](https://denisrizov.com/)
 - [DOTween](https://github.com/Demigiant/dotween) by [Demigiant](http://demigiant.com/)
 - [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) by [Newtonsoft](https://www.newtonsoft.com/json)
 - [Joystick Pack](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631) by [Fenerax Studios](https://assetstore.unity.com/publishers/32730)
 - And some other Unity registries.

### Main Features & Workflow
HyperTemplate uses one-scene setup. There are 2 main workflow that I am using:

 1. Unique Levels
 2. Unique Mechanics
 
 Unique Levels workflow allows you to make every level unique - different mechanics, different obstacles for every level. Every level must be made by hand and must be stored as prefab. Place your mechanic inside that prefab and store your levels inside LevelManager.
 
 Unique Mechanics workflow allows you to simply create mechanics, add some randomness factor and every level would be created randomly during runtime. Add your mechanics to scene and store them inside MechanicManager.
 
### To-do list
  
To-do list moved into [Projects](https://github.com/RhodosTheGod/HyperTemplate/projects) section!
