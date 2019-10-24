using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    private void Awake()
    {
        GameFlow.Instance.Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        GameFlow.Instance.PostInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        GameFlow.Instance.Refresh();
    }

    private void FixedUpdate()
    {
        GameFlow.Instance.PhysicsRefresh();
    }
}
