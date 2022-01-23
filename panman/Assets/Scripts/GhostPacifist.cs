using UnityEngine;

public class GhostPacifist : GhostBehavior
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer white;

    public bool transparent { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        this.body.enabled = false; // normal body goes away
        this.eyes.enabled = false;
        //this.blue.enabled = false; // blue stays off
        this.white.enabled = true; // turns white on

    }

    public override void Disable()
    {
        base.Disable();

        this.body.enabled = true;
        this.eyes.enabled = true;
        this.white.enabled = false; // turns off
    }

    private void OnEnable()
    {
        this.ghost.movement.speedMultiplier = 0.5f; // slower when frightened
        //this.IgnoreLayerCollision(6, 7, true);; // turns off collision between ghost and pacman layers
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMultiplier = 1.0f; // move normal speed
        //this.IgnoreLayerCollision(6, 7, false); // turns on collision between ghost and pacman layers
        this.ghost.chase.Enable(); // transition to chase
        this.ghost.scatter.Disable(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            // Find the available direction that moves farthest from pacman
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                // If the distance in this direction is greater than the current
                // max distance then this direction becomes the new farthest
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance) // check if that is the direction going away from pacman
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log(true);
        }
    }*/

}
