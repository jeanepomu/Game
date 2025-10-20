using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;                // a câmera
    public float parallaxFactor = 0.3f;  // menor valor = fundo mais distante

    private Vector3 startPosition;       // posição inicial do objeto

    void Start()
    {
        startPosition = transform.position;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        float moveX = cam.position.x * parallaxFactor;
        transform.position = new Vector3(startPosition.x + moveX, startPosition.y, startPosition.z);
    }
}
