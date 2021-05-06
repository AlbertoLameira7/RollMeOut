using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action<GameObject> LinkBallToCamera;
    public static Action EnableExit;

    [SerializeField] private Vector3 _position = Vector3.up;
    [SerializeField] private GameObject _prefab; 

    private GameObject _parent;
    private GameObject _ball;
    private GameObject _fallingBlock;

    void Awake()
    {
        _parent = GameObject.FindGameObjectWithTag("Level");
        _position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        _ball = SpawnBallAtLocation(_position);
    }

    void OnEnable()
    {
        KeyController.KeyPickedUp += PickedUpKey;
        PlayerRespawn.Respawn += ReloadScene;
        FallingBlock.FallingBlockEvent += SelectFallingBlock; 
    }

    void OnDisable()
    {
        KeyController.KeyPickedUp -= PickedUpKey;
        PlayerRespawn.Respawn -= ReloadScene;
        FallingBlock.FallingBlockEvent -= SelectFallingBlock;
    }

    void Start()
    {
        AddBallToCamera();
    }

    GameObject SpawnBallAtLocation(Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity, _parent.transform);
    }

    void AddBallToCamera()
    {
        LinkBallToCamera(_ball);
    }

    void PickedUpKey()
    {
        Debug.Log("Key Picked Up!");
        EnableExit();
        Destroy(_fallingBlock);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SelectFallingBlock(GameObject target)
    {
        _fallingBlock = target;
    }
}