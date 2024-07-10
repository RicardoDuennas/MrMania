using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // El transform del jugador
    public Vector3 offset; // Offset de la cámara respecto al jugador

    void Start()
    {
        // Encuentra al jugador por su tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Make sure it has the 'Player' tag.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Actualiza la posición de la cámara para seguir al jugador
            transform.position = player.position + offset;
        }
    }
}
