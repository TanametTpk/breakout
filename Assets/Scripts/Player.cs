using UnityEngine;

public class Player : MonoBehaviour, Damagable
{
    public Knockback knockback;
    public int hp;
    public float speed;
    public int energy;
    public float knockbackForce = 10;
    public IconBar healthBar;
    public IconBar energyBar;
    public Animator camAnimator;

    private void Awake() {
        healthBar.SetValue(hp);
        energyBar.SetValue(energy);
    }

    public bool IshaveEnergy() {
        return energy > 0;
    }

    public bool IsDead() {
        return hp < 1;
    }

    public void WasAttacked(int damage) {
        hp -= damage;
        if (hp < 0) hp = 0;
        Debug.Log("HP:" + hp);
        healthBar.SetValue(hp);
        camAnimator.SetTrigger("shake");

        if (IsDead()) EndGame("You are already dead!", "You are so Noob eiei.");
    }

    public void useEnegy(int usageEnegy)
    {
        int remainEnergy = energy - usageEnegy;
        SetEnergy(remainEnergy);
    }

    public void SetEnergy(int energy) {
        this.energy = energy;
        if (this.energy < 0) this.energy = 0;

        energyBar.SetValue(this.energy);
    }

    private void EndGame(string title, string description) {
        EndScreen config = new EndScreen();

        config.title = title;
        config.description = description;
        config.isVictory = false;

        FindObjectOfType<GameManager>().ShowEndScreen(config);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Enemy")) {
            Vector2 difference = other.transform.position - transform.position;
            knockback.perform(difference.normalized * -knockbackForce);
        }
        else if (other.gameObject.tag.Equals("ball")) {
            Destroy(other.gameObject);
            SetEnergy(energy + 1);
        }
    }
}
