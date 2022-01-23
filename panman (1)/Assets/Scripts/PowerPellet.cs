using UnityEngine;

public class PowerPellet : Pellet // inherits from pellet
{
    public float duration = 8.0f; // duration of pellet effects

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
    }

}
