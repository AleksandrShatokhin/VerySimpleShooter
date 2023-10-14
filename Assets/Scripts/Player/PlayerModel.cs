using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Header("Movement control parameters")]
    [SerializeField] private float _speedPlayer;
    [SerializeField] private float _forceJump;

    [Header("Camera control parameters")]
    [Range(10, 100)][SerializeField] private float _sensetivityX;
    [Range(10, 100)][SerializeField] private float _sensetivityY;
    [Range(-90, -10)][SerializeField] private float _upperCameraLimiter;
    [Range(10, 90)][SerializeField] private float _lowerCameraLimiter;

    [Header("Attack control parameters")]
    [SerializeField] private int _countBullet;

    public float SpeedPlayer { get { return _speedPlayer; } }
    public float ForceJump { get { return _forceJump; } }
    public float SensetivityX { get { return _sensetivityX; } }
    public float SensetivityY { get { return _sensetivityY; } }
    public float UpperCameraLimiter { get { return _upperCameraLimiter; } }
    public float LowerCameraLimiter { get { return _lowerCameraLimiter; } }
}
