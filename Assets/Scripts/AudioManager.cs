using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    private NetworkService networkService;

    public ManagerStatus Status
    {
        get; private set;
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting...");
        networkService = service;
        Status = ManagerStatus.Started;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
