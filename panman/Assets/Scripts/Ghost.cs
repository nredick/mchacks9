using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; } // respecive ghost movements determine behaviors
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostPacifist pacifist { get; private set; }
    public GhostBehavior initialBehavior; // each ghost has diff initial behavior (alpha scatters, rest in home)
    public Transform target; // usually pacman, in theory could be other things
    public int points = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    { // for restarting round
        this.gameObject.SetActive(true); // turn back on
        this.movement.ResetState(); // reset movement

        this.frightened.Disable(); // never start in frightened or chase mode
        this.chase.Disable();
        this.scatter.Enable();
        this.pacifist.Disable();

        if (this.home != this.initialBehavior) { // turn off home if not set as initial behavior (for all but alpha)
            this.home.Disable();
        }

        if (this.initialBehavior != null) {
            this.initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = this.transform.position.z;
        this.transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { // for getting eaten or eating
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.frightened.enabled) { // ghost is eaten if collides w pacman while frightened
                FindObjectOfType<GameManager>().GhostEaten(this);
            } else { // ghost eats pacman if collides while not frightened
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }

}
