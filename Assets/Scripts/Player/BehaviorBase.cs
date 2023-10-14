using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BehaviorBase : MonoBehaviour, IInitialize<PlayerModel>
{
    protected PlayerModel _playerModel;
    public abstract void Initialize(PlayerModel playerModel);

    public abstract void UpdateBehavior(InputAction action);

}
