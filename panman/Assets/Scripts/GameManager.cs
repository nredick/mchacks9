using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public Text gameOverText;
    public Text scoreText;
    public Text livesText;

    // increase multiplier for each ghost eaten
    public int ghostMultiplier { get; private set; } = 1;
    // can read score + lives but not set it
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start() // autmatically called at start
    {
        NewGame();
    }

    private void Update() // checks for input
    {
        if (this.lives <= 0 && Input.anyKey) { // if no lives left
            NewGame(); // press any key to start a new game!
        }
    }

    private void NewGame() // called from start to make a new game
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound() // called at new game, and when all pellets eaten
    {
        this.gameOverText.enabled = false;

        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true); // turned to false when eaten, so set them all back on
        }

        ResetState();
    }

    private void ResetState() 
    {
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].ResetState();
        }

        this.pacman.ResetState(); // turns pacman back on
    }

    private void GameOver() // called when out of lives
    {
        this.gameOverText.enabled = true;

        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(false); // get rid of ghosts
        }

        this.pacman.gameObject.SetActive(false);
    }

    private void SetLives(int lives) // to update lives
    {
        this.lives = lives;
        this.livesText.text = "x" + lives.ToString();
    }

    private void SetScore(int score) // to update score
    {
        this.score = score;
        this.scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void PacmanEaten() // death
    {
        this.pacman.DeathSequence();

        SetLives(this.lives - 1);

        // dont reset state when die bc dont want pellets back
        if (this.lives > 0) {
            Invoke(nameof(ResetState), 5.0f); // 3s grace period before restarting round
        } else {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost) // for when ghost is eaten
    {
        int points = ghost.points * this.ghostMultiplier; // ghosts are more valuable the more youve eaten
        SetScore(this.score + points); // get points for eating the ghosts!

        this.ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet) // for when pellet is eaten
    {
        pellet.gameObject.SetActive(false); // get rid of it

        SetScore(this.score + pellet.points); // get points

        if (!HasRemainingPellets()) // eaten all pellets -> new round
        {
            this.pacman.gameObject.SetActive(false); // avoid being killed before restarting
            Invoke(nameof(NewRound), 3.0f); // start new round w grace period 3s
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for (int i = 0; i < this.ghosts.Length; i++) { // able to eat ghosts
            this.ghosts[i].frightened.Enable(pellet.duration); // enable the frightened state for pellet duration
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier)); // if you eat two ghosts in a row, cancel previous to restart the effects
        Invoke(nameof(ResetGhostMultiplier), pellet.duration); // reset multiplier after pellet runs out
    }

    public void PillPelletEaten(PillPellet pellet)
    {
        /*for (int i = 0; i < this.ghosts.Length; i++) { // able to eat ghosts
            this.ghosts[i].frightened.Enable(pellet.duration); // enable the frightened state for pellet duration
        }
        CancelInvoke(nameof(ResetGhostMultiplier)); // if you eat two ghosts in a row, cancel previous to restart the effects
        Invoke(nameof(ResetGhostMultiplier), pellet.duration); // reset multiplier after pellet runs out
        */
        PelletEaten(pellet);
    }

    public void SyringePelletEaten(SyringePellet pellet)
    {
        // increment lives by 1
        SetLives(this.lives + 1);

        PelletEaten(pellet);
    }

    private bool HasRemainingPellets()
    { // checks if any pellets are still active
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }

}
