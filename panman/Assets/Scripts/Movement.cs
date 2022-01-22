using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // need a rigid body to move an object
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    // every object might have diff initial direction
    public Vector2 initialDirection;
    // allows us to selectively do ray casts on certain layets
    // (to determine being blocked by an obstacle)
    public LayerMask obstacleLayer;

    // current state variables
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    // allows for smoother + more responsive direction changes
    public Vector2 nextDirection { get; private set; }
    // for restarting the game / rounds
    public Vector3 startingPosition { get; private set; }

    private void Awake()
    {
        // get the rigid body for this object
        this.rigidbody = GetComponent<Rigidbody2D>(); 
        // restart the position
        this.startingPosition = this.transform.position; 
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    { // called from game manager + when restarting state
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero; // reset
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false; // for ghosts
        this.enabled = true; // disabled script to prevent movement, make sure its not initially disabled
    }

    private void Update() 
    {
        // Try to move in the next direction while it's queued to make movements
        // more responsive
        if (this.nextDirection != Vector2.zero) {
            SetDirection(this.nextDirection);
        }
    }

    private void FixedUpdate() // always called at fixed time intervals (frame independent)
    {
        Vector2 position = this.rigidbody.position;
        // calculate how much we want to translate
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;

        this.rigidbody.MovePosition(position + translation); // now actually move
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    { // pacman moves based on input, ghosts based on AI

        // Only set the direction if the tile in that direction is available
        // otherwise we set it as the next direction so it'll automatically be
        // set when it does become available
        if (forced || !Occupied(direction))
        { // only change direction if you arent blocked
            this.direction = direction;
            this.nextDirection = Vector2.zero; // reset next direction
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        // If no collider is hit then there is no obstacle in that direction
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }

}
