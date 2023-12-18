using UnityEngine;

public class Coincontroller : MonoBehaviour
{
    public float moveSpeed = 2f; // Vitesse de déplacement de l'ascenseur
    public float maxHeight = 5f; // Hauteur maximale de l'ascenseur
    public float minHeight = 0f; // Hauteur minimale de l'ascenseur

    private bool isMovingUp = true; // Indique si l'ascenseur monte ou descend

    // Update is called once per frame
    void Update()
    {
        // Déplace le coin vers le haut ou vers le bas
        if (isMovingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // Vérifie si le coin atteint la hauteur maximale ou minimale, puis inverse la direction
        if (transform.position.y >= maxHeight)
        {
            isMovingUp = false;
        }
        else if (transform.position.y <= minHeight)
        {
            isMovingUp = true;
        }
    }
}
