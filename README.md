# Very Simple Shooter

### Игровой процесс на данный момент максимально простой и включает в себя несколько врагов вокруг игрока и возможность с ними перестреливаться.

![GamePlay](https://github.com/AleksandrShatokhin/VerySimpleShooter/assets/47788812/5b2197a3-a6c8-4cbe-a7ce-2d9f3ccff5c8)

В качестве управления игровым процессом и точкой старта в сцене есть компонент [__GameController__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Game/GameController.cs).
Простыми словами он:
* создает выбранного персонажа для игрока в точку старта игрока,
* создает несколько вражеских персонажей в точках старта для них

### 1. Управление персонажем

Управление персонажем реализовано с помощью __Input System__ и использует подход разделения обязанностей на классы.

![СистемаВвода](https://github.com/AleksandrShatokhin/VerySimpleShooter/assets/47788812/d12298da-20dc-490c-8db6-7c6e648743bb)
_Система ввода_

__Классы работы над управлением персонажа:__
* [PlayerController](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerController.cs) - 
Этот компонент выступает в роли слушателя для ввода игроком и передает услышаный ввод в свои поведенческие компоненты.
* [BehaviorBase](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/BehaviorBase.cs) - 
Является родительским компонентом для классов поведения персонажа.
* [PlayerMovementBehavior](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerMovementBehavior.cs) - 
Класс, отвечающий за движение персонажа.
* [PlayerCameraBehavior](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerCameraBehavior.cs) - 
Класс, отвечающий за управлением камерой игрока.
* [PlayerAttackBehavior](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerAttackBehavior.cs) - 
Класс, отвечающий за действия по команде атаки.
* [PlayerModel](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerModel.cs) - 
Класс, в котором задаются из инспектора и хранятся основные параметры игрока, которые необходимы для управления персонажем.

### 2. Генерация вражеских персонажей

Для генерации вражеских персонажей используется простая [__ФАБРИКА__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Factory/Factory.cs).
GameController через фабрику создает в сцене несколько вражеских персонажеи и выдает им оружие.
В игре представленны два вида врагов: красный и синий. В игре представлены два вида оружия: пистолет и автомат.
Функционально они пока не имеют особой разницы, вариация сделана скорее для того, чтоб видеть функциональность создания разных видов вооружения.
Сама же фабрика достает необходимые объекты из их пулов.

### 3. Пулы объектов

Для стрельбы пулями, создания вражеских персонажей и их оружия используется простая систему пулов.
Для удобства таких пулов три: пули, вражи, оружие.
Каждый класс пулов по своей сути схож и по своему различен.
Все классы пулов работают на основе одного интерфейса __IPoolable__, который дает возможность получить объект из пула и вернуть объект в пул.

* [PoolBullets](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Pools/PoolBullets.cs) - 
Заполняется заданным колличеством объектов. Для хранения и взаимодействиями объектов был разработан простой [__самописный стек__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Utility/CustomStack.cs).
* [PoolEnemies](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Pools/PoolEnemy.cs) - 
Заполняется заданным количеством сначала красных,потом синих вражеских персонажей. В отличии от пула патронов
для данного пула был выбран подход через [__самописную очередь__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Utility/CustomQueue.cs).
* [PoolWeapons](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Pools/PoolWeapon.cs) - 
Заполняется заданным количеством пистолетов и пулеметов чередуясь по одному. Также как и пул врагов работает через [__самописную очередь__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Utility/CustomQueue.cs).

### 4. Ближайшие планы

* Добавить в пулы возможность авторасширения
* Расширить логику поведения вражеских персонажей (патрулирование, поиск игрока и т.д.)
* Проработать разный функционал оружия
* Продумать level-designe игровой комнаты
=======
# VerySimpleShooter
