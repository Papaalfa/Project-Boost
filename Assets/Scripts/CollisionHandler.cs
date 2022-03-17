using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Touched Friendly");
                break;
            case "Fuel":
                Debug.Log("Collected Fuel");
                break;
            case "Finish":
                Debug.Log("Got to the Finish");
                break;
            default:
                Debug.Log("Crashed");
                break;
        }
    }
}
