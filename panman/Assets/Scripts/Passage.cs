using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Passage : MonoBehaviour
{
    public Transform connection; // where we are connecting to

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = this.connection.position;
        position.z = other.transform.position.z; // dont want to change z pos (determines draw order)
        other.transform.position = position; // object colliding with pacman
    }

}
