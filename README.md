# HyperTemplate
 A flexible hyper casual game project template that runs on Unity 2020.1.3f 

* Notes
- This project works with events. This is the reason why systems are independent from each other and project is easy to maintain.
- Main systems(like touch and input manager) inherits from a base MainComponent class. That class including event subscription and scheduled awake functions.
- There are 3 awake methods in this class: PreAwake, OnAwake and LateAwake. I set up awake like that because setting script execution order up for getting rid of conflict on awake can be an overwhelming process.
- UI animations done with Sequences in DOTween. For further readings, visit demigiant.com
- Each UI menu is working on their own canvas.
- For adding a new mechanic, create a new class inherits from TouchAction non-MonoBehaviour class. You can 
- There's a singleton AnalyticsManager class for easing getting analytics process.
- 