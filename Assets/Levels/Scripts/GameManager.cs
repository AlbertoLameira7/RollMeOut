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

    void Awake()
    {
        _parent = GameObject.FindGameObjectWithTag("Level");
        _ball = SpawnBallAtLocation(_position);
    }

    void OnEnable()
    {
        KeyController.KeyPickedUp += PickedUpKey;
        DeathPlaneController.Respawn += ReloadScene;
    }

    void OnDisable()
    {
        KeyController.KeyPickedUp -= PickedUpKey;
        DeathPlaneController.Respawn -= ReloadScene;
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
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}