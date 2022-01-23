using UnityEngine;

public class PillPellet : Pellet // inherits from pellet
{
    public float duration = 5.0f; // duration of pellet effects

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PillPelletEaten(this);
    }

}
