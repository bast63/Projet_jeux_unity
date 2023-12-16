using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float diameter = 5f; // Diamètre de la trajectoire circulaire
    public float rotationSpeed = 2f; // Vitesse de rotation autour de l'axe Y
    public float selfRotationSpeed = 110f; // Vitesse de rotation sur lui-même

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcul de la position sur la trajectoire circulaire
        float angle = Time.time * rotationSpeed;
        float x = Mathf.Cos(angle) * (diameter / 2);
        float y = initialPosition.y; // Maintenir la position sur l'axe Y
        float z = Mathf.Sin(angle) * (diameter / 2);

        // Mise à jour de la position de l'objet
        transform.position = new Vector3(initialPosition.x + x, y, initialPosition.z + z);

        // Rotation locale sur l'axe Y
        transform.Rotate(Vector3.up, -selfRotationSpeed * Time.deltaTime);
    }
}
