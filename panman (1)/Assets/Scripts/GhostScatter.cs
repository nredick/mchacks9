using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.chase.Enable(); // transition to chase when scattering is done
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        //Debug.Log(true);
        Node node = other.GetComponent<Node>();

        // Do nothing while the ghost is frightened
        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            //Debug.Log(false);
            // Pick a random available direction
            int index = Random.Range(0, node.availableDirections.Count);

            // Prefer not to go back the same direction so increment the index to
            // the next available direction, i.e. dont backwards
            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                // Wrap the index back around if overflowed
                if (index >= node.availableDirections.Count) {
                    index = 0;
                }
            }

            this.ghost.movement.SetDirection(node.availableDirections[index]); // change the direction!
        }
    }

}
