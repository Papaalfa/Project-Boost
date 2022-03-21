using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting the Application");
            Application.Quit();
        }
    }
}
