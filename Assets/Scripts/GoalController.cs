using UnityEngine;

public class GoalController : MonoBehaviour
{
    public float rotationSpeed = 60f; // Vitesse de rotation

    void Update()
    {
        // Rotation locale sur l'axe Z
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}