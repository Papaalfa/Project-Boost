using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheating : MonoBehaviour
{
    CollisionHandler collisionHandler;

    // Start is called before the first frame update
    void Start()
    {
        collisionHandler = GetComponent<CollisionHandler>();        
    }

    // Update is called once per frame
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L)) collisionHandler.LoadNextLevel();
        else if (Input.GetKeyDown(KeyCode.C)) collisionHandler.collisionDisabled = !collisionHandler.collisionDisabled;
    }
}
