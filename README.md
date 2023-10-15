# Very Simple Shooter

### ������� ������� �� ������ ������ ����������� ������� � �������� � ���� ��������� ������ ������ ������ � ����������� � ���� ����������������.

![GamePlay](https://github.com/AleksandrShatokhin/VerySimpleShooter/assets/47788812/5b2197a3-a6c8-4cbe-a7ce-2d9f3ccff5c8)

� �������� ���������� ������� ��������� � ������ ������ � ����� ���� ��������� [__GameController__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Game/GameController.cs).
�������� ������� ��:
* ������� ���������� ��������� ��� ������ � ����� ������ ������,
* ������� ��������� ��������� ���������� � ������ ������ ��� ���

### 1. ���������� ����������

���������� ���������� ����������� � ������� __Input System__ � ���������� ������ ���������� ������������ �� ������.

![������������](https://github.com/AleksandrShatokhin/VerySimpleShooter/assets/47788812/d12298da-20dc-490c-8db6-7c6e648743bb)
_������� �����_

__������ ������ ��� ����������� ���������:__
* [PlayerController](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerController.cs) - 
���� ��������� ��������� � ���� ��������� ��� ����� ������� � �������� ��������� ���� � ���� ������������� ����������.
* [BehaviorBase](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/BehaviorBase.cs) - 
�������� ������������ ����������� ��� ������� ��������� ���������.
* [PlayerMovementBehavior](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerMovementBehavior.cs) - 
�����, ���������� �� �������� ���������.
* [PlayerCameraBehavior](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerCameraBehavior.cs) - 
�����, ���������� �� ����������� ������� ������.
* [PlayerAttackBehavior](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerAttackBehavior.cs) - 
�����, ���������� �� �������� �� ������� �����.
* [PlayerModel](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Player/PlayerModel.cs) - 
�����, � ������� �������� �� ���������� � �������� �������� ��������� ������, ������� ���������� ��� ���������� ����������.

### 2. ��������� ��������� ����������

��� ��������� ��������� ���������� ������������ ������� [__�������__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Factory/Factory.cs).
GameController ����� ������� ������� � ����� ��������� ��������� ���������� � ������ �� ������.
� ���� ������������� ��� ���� ������: ������� � �����. � ���� ������������ ��� ���� ������: �������� � �������.
������������� ��� ���� �� ����� ������ �������, �������� ������� ������ ��� ����, ���� ������ ���������������� �������� ������ ����� ����������.
���� �� ������� ������� ����������� ������� �� �� �����.

### 3. ���� ��������

��� �������� ������, �������� ��������� ���������� � �� ������ ������������ ������� ������� �����.
��� �������� ����� ����� ���: ����, �����, ������.
������ ����� ����� �� ����� ���� ���� � �� ������ ��������.
��� ������ ����� �������� �� ������ ������ ���������� __IPoolable__, ������� ���� ����������� �������� ������ �� ���� � ������� ������ � ���.

* [PoolBullets](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Pools/PoolBullets.cs) - 
����������� �������� ������������ ��������. ��� �������� � ���������������� �������� ��� ���������� ������� [__���������� ����__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Utility/CustomStack.cs).
* [PoolEnemies](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Pools/PoolEnemy.cs) - 
����������� �������� ����������� ������� �������,����� ����� ��������� ����������. � ������� �� ���� ��������
��� ������� ���� ��� ������ ������ ����� [__���������� �������__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Utility/CustomQueue.cs).
* [PoolWeapons](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Pools/PoolWeapon.cs) - 
����������� �������� ����������� ���������� � ��������� ��������� �� ������. ����� ��� � ��� ������ �������� ����� [__���������� �������__](https://github.com/AleksandrShatokhin/VerySimpleShooter/blob/main/Assets/Scripts/Utility/CustomQueue.cs).

### 4. ��������� �����

* �������� � ���� ����������� ��������������
* ��������� ������ ��������� ��������� ���������� (��������������, ����� ������ � �.�.)
* ����������� ������ ���������� ������
* ��������� level-designe ������� �������
=======
# VerySimpleShooter
