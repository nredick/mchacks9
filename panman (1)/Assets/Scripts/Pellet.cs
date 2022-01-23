using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pellet : MonoBehaviour
{
    public int points = 10; // default points

    protected virtual void Eat() // accessible by subclasses, overridable
    { // turns off game object from game manager
        FindObjectOfType<GameManager>().PelletEaten(this); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    { // detect when pellet eaten (i.e. pacman triggers pellet collider box)
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        }
    }

}
