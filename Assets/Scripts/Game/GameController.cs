using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController GetInstance() => _instance;

    [Header("Parameters for player")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _spawnPositionPlayer;
    [SerializeField] private GameObject _playerPrefab;

    [Header("References to components")]
    private PlayerController _playerController;
    [SerializeField] private PoolObject _poolObject;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GeneratePlayer();
    }

    private void GeneratePlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _spawnPositionPlayer.position, Quaternion.identity);
        _playerController = player.GetComponent<PlayerController>();
        _playerController.Initialize(_playerInput);
    }

    public PoolObject GetPoolObject() => _poolObject;
}
