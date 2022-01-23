using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] // you cant have an animted sprite unless you have a sprite renderer on the same object
public class AnimatedSprite : MonoBehaviour
{
    // reference to sprite renderer
    public SpriteRenderer spriteRenderer { get; private set; }
    // array of sprites to loop through for the animation
    public Sprite[] sprites = new Sprite[0];
    // wait .25s before switching to next sprite image
    public float animationTime = 0.25f;
    // animation frame tracks the index of the sprite that is showing
    public int animationFrame { get; private set; } // publicly readable but not settable
    // maybe for some animations we dont want to loop, just make a var for this in case we want it as an option
    public bool loop = true;

    private void Awake() // called when object initialized
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // repeat the function every .25s
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime);
    }

    private void Advance()
    { 
        // repeatedly called
        if (!this.spriteRenderer.enabled) { // dont want to continue animation if disabled
            return;
        }

        this.animationFrame++; // increment frame

        // loop back to 0 if we are over the max frames and we want to loop
        if (this.animationFrame >= this.sprites.Length && this.loop) { 
            this.animationFrame = 0;
        }
        // prevent index out of range
        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length) {
            this.spriteRenderer.sprite = this.sprites[this.animationFrame];
        }
    }

    public void Restart()
    { // restart the animation
        this.animationFrame = -1;

        Advance();
    }

}
