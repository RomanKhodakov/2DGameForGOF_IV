# RomanKhodakov-2DGameForGOF
Мой четвертый проект по изучению Unity. Создан для тестирования паттернов проектирования, описанных в книге GOF. Архитектура MVC.

В проекте были применены следующие паттерны:

Factory Method - для создания игрока, врагов и пуль, которыми стреляет игрок (PlayerFactory.cs);

Object pool - для повторного использования врагов и пуль (ObjectPull.cs);

Fluent Builder - для конструирования объектов через методы расширения (BuilderExtension.cs);

Bridge - для возможности назначить игроку разные типы атак и перемещения (PlayerBridge.cs);

Composite - для объединения всех Move врагов в один класс (CompositeMoveEnemy.cs);

Decorator - для изменения поведения пуль (ModificationShootType.cs);

Proxy - для проверки перед выстрелом или созданием врага, могут ли они создаваться (EnemySpawnerProxy.cs);

Chain of responsibility - для изменения урона персонажа с изменением его здоровья (PlayerModifier.cs);

Command - для возможности показа UI панелек со счётом и здоровьем (UserInterfaceController.cs);

Interpreter - для округления счёта игрока (PlayerScore.cs);

Iterator - для получения текущих значений параметров врага (итератор в классе Enemy.cs);

Mediator - для связи между Model и View через Controller (Controllers.cs);

Memento - для сохранения положения врагов во времени, чтобы потом запустить процесс возврата времени (TimeBody.cs);

Observer - для получения данных о стокновении врага с объектом (событие в классе Enemy.cs);

State - для перемещения игрока (PlayerState.cs);	

Visitor - для подцепления к врагам умений, в зависимости от типа (EnemyAbilityVisitor.cs);

Repository - для получения начальных данных о врагах из Json файла (EnemyParserFromJson.cs);
