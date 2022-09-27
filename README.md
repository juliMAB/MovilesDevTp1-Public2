# [Patrones de diseños](https://refactoring.guru/es/design-patterns) implementados en el juego

### [<b>Patron Mediator:</b>](https://refactoring.guru/es/design-patterns/mediator)
- Utilizo el mediator para poder interactuar entre los jugadores y la ui de una manera mas separada, ambos conocen a el mediator de cada jugador, pero no se conocen entre si, tanbien se utiliza en el  <b>**MyGameplayManager.cs**</b> quien se encarga de la interaccion de los jugadores con sus scores entre otras cosas.

### <b>Patron [Observer](https://refactoring.guru/es/design-patterns/observer):</b>
- Utilizo el patron <b>Observer</b> para crear en forma de cascada desde el manager de la escena, en este juego <b>**MyGameplayManager.cs**</b> se encarga de hacer los llamados a el <b>**GameManager.cs**</b>
el cual es el unico encargado de cambiar las escenas y guardar la data entre escenas. De esta manera, el gameplayManager inicializa a las diferentes sub escenas como sera el "tutorial", la descarga y la conduccion.
En el caso de la descarga, esta se inicializa, con un Action, el cual va a ser respondido cuando termine el proceso de descarga.

### [<b>Patron Singleton</b>](https://refactoring.guru/es/design-patterns/singleton)
- Este patron lo utilizo para que solo exista un unico objeto que se encargue especificamente de una cosa, en este caso, mi gamemanager, encargado de almacenar el score de los jugadores y llamar al cambio de escena.

### [<b>State</b>](https://refactoring.guru/es/design-patterns/state)
- Este patron no tenia pensado implementarlo, pero sin querer lo hice cuando realize la pausa, la cual setea pause, que llama a todo aquel script que sea pausable y realiza cierta accion, en el caso del jugador, desactiva el input y lo friza, hasta que se reanude y recupere el contro. 