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
    private GameObject _player;
    private PlayerController _playerController;
    [SerializeField] private PoolBullets _poolBullets;
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private PoolWeapon _poolWeapon;

    [SerializeField] private EnemySpawn _enemySpawner;

    [SerializeField] private IFactory _factory;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _factory = GetComponent<IFactory>();
        _factory.Initialize(_poolEnemy, _poolWeapon);

        GeneratePlayer();

        CreateEnemy(2);
    }

    private void GeneratePlayer()
    {
        _player = Instantiate(_playerPrefab, _spawnPositionPlayer.position, Quaternion.identity);
        _playerController = _player.GetComponent<PlayerController>();
        _playerController.Initialize(_playerInput);
    }

    private void CreateEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = _factory.CreateEnemy();
            GameObject weapon = _factory.CreateWeapon();

            enemy.GetComponent<IEnemy>().Initialize(_poolBullets, _player.transform);
            enemy.GetComponent<IEnemy>().AttachWeapon(weapon);

            enemy.transform.position = _enemySpawner.GetSpawnPosition();
            enemy.SetActive(true);
        }
    }

    public PoolBullets GetPoolBullets() => _poolBullets;
}
