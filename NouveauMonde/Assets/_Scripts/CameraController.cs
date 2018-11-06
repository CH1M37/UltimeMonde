using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerUp = player.transform.up;
        transform.RotateAround(playerPos, playerUp, Time.deltaTime * Input.GetAxisRaw("Camera") * rotationSpeed);
    }
}

