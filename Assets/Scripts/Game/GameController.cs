using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController GetInstance() => _instance;

    [SerializeField] private EnemySpawn _enemySpawner;
    [SerializeField] private int _countEnemy;

    [SerializeField] private IFactory _factory;

    [Header("Parameters for player")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _spawnPositionPlayer;
    [SerializeField] private GameObject _playerPrefab;

    [Header("References to components")]
    private GameObject _player;
    private PlayerController _playerController;

    [Header("Pool components and parameters")]
    [SerializeField] private PoolBullets _poolBullets;
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private PoolWeapon _poolWeapon;
    [SerializeField] private int _countBulletsToPool;
    [SerializeField] private int _countEnemyToPool;
    [SerializeField] private int _countWeaponToPool;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _factory = GetComponent<IFactory>();
        _factory.Initialize(_poolEnemy, _poolWeapon);

        GeneratePlayer();

        _poolBullets.Initialize(_countBulletsToPool);
        _poolEnemy.Initialize(_countEnemyToPool);
        _poolWeapon.Initialize(_countWeaponToPool);

        Invoke("CreateEnemy", 1.0f);
    }

    private void GeneratePlayer()
    {
        _player = Instantiate(_playerPrefab, _spawnPositionPlayer.position, Quaternion.identity);
        _playerController = _player.GetComponent<PlayerController>();
        _playerController.Initialize(_playerInput);
    }

    private void CreateEnemy()
    {
        for (int i = 0; i < _countEnemy; i++)
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
    public PoolEnemy GetPoolEnemies() => _poolEnemy;
    public PoolWeapon GetPoolWeapons() => _poolWeapon;
}
