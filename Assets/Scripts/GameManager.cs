using System;
using Cinemachine;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int shotLimit,areaLimit;
    [SerializeField] private CinemachineVirtualCamera vCamera;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Player playerInstance;
    [SerializeField] private GameObject middleRespawn;

    private string state;
    private GameObject closestRespawn = null;
    private World savanna, antarctica, jungle, desert;
    public const string Savanna = "Savanna";
    public const string Antarctica = "Antarctica";
    public const string Desert = "Desert";
    public const string Jungle = "Jungle";
    private static GameManager _shared;

    private void Start()
    {
        savanna = new World(Savanna, _shared.shotLimit, _shared.areaLimit);
        antarctica = new World(Antarctica, _shared.shotLimit, _shared.areaLimit);
        desert = new World(Desert, _shared.shotLimit, _shared.areaLimit);
        jungle = new World(Jungle, _shared.shotLimit, _shared.areaLimit);
    }

    private void Update()
    {
        if(TutorialManager.State != TutorialManager.IN_GAME && Input.GetKeyDown(KeyCode.Return))
            TutorialManager.StartGame();
        
        if(TutorialManager.State < TutorialManager.RESPAWN)
            return;
        
        if (Input.GetMouseButtonDown(2))
        {
            var respawnPoint = closestRespawn == null
                ? middleRespawn
                : closestRespawn;
            Respawn(respawnPoint);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Respawn(middleRespawn);
        }

        ChangeScene();
    }

    private void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync("Openning");
        }

        if (TakenAnimals == 4)
        {
            SceneManager.LoadSceneAsync("EndScreen");
        }
    }

    private void Respawn(GameObject respawn)
    {
        Vector3 position = respawn.transform.position;
        if (TutorialManager.State == TutorialManager.RESPAWN)
            TutorialManager.State++;

        Player player = Instantiate(playerPrefab, position, Quaternion.identity);

        vCamera.Follow = player.spine;
        vCamera.LookAt = player.lookAt;
        player.GetComponent<ZoomInScript>().vCamera = vCamera;
        
        Destroy(playerInstance.gameObject);
        playerInstance = player;
    }

    public static GameObject ClosestRespawn
    {
        get => _shared.closestRespawn;
        set => _shared.closestRespawn = value;
    }

    public static bool AntarcticaPaint => _shared.antarctica.Painted;

    public static bool SavannaPaint => _shared.savanna.Painted;

    public static bool DesertPaint => _shared.desert.Painted;

    public static bool JunglePaint => _shared.jungle.Painted;
    
    public static int TakenAnimals;

    private void Awake()
    {
        if (_shared == null)
        {
            _shared = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Savanna)) State = Savanna;
        if (other.CompareTag(Antarctica)) State = Antarctica;
        if (other.CompareTag(Desert)) State = Desert;
        if (other.CompareTag(Jungle)) State = Jungle;
    }

    public static bool IsWorld(String tag)
    {
        return tag.Equals(Antarctica) || tag.Equals(Savanna) || tag.Equals(Desert) || tag.Equals(Jungle);
    }

    public static String State
    {
        get => _shared.state;
        set {_shared.state = value; UIManager.UpdateProgress();}
    }

    public static int SavannaAreaCounter
    {
        get => _shared.savanna.AreaCounter;
        set {_shared.savanna.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int DesertAreaCounter
    {
        get => _shared.desert.AreaCounter;
        set { _shared.desert.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int JungleAreaCounter
    {
        get => _shared.jungle.AreaCounter;
        set { _shared.jungle.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int AntarcticaAreaCounter
    {
        get => _shared.antarctica.AreaCounter;
        set { _shared.antarctica.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int SavannaShotCounter
    {
        get => _shared.savanna.ShotCounter;
        set { _shared.savanna.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static int DesertShotCounter
    {
        get => _shared.desert.ShotCounter;
        set { _shared.desert.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static int JungleShotCounter
    {
        get => _shared.jungle.ShotCounter;
        set { _shared.jungle.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static int AntarcticaShotCounter
    {
        get => _shared.antarctica.ShotCounter;
        set { _shared.antarctica.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static World CurrWorld()
    {
        switch (State)
        {
            case Antarctica:
                return _shared.antarctica;
            case Desert:
                return _shared.desert;
            case Jungle:
                return _shared.jungle;
            case Savanna:
                return _shared.savanna;
        }

        return null;
    }
    
    public static void ResetCharacter()
    {
        _shared.Respawn(ClosestRespawn);
    }
}
