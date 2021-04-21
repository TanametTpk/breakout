using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, Damagable
{
    public int hp;
    public float speed;
    public int energy;
    public IconBar healthBar;
    public IconBar energyBar;
    public Animator camAnimator;
    [SerializeField]
    public DeadAction deadAction;
    private SpriteRenderer sprite;

    private void Awake() {
        healthBar.SetValue(hp);
        energyBar.SetValue(energy);
    }

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public bool IshaveEnergy() {
        return energy > 0;
    }

    public bool IsDead() {
        return hp < 1;
    }

    public void WasAttacked(int damage) {
        if (IsDead()) return;

        hp -= damage;
        if (hp < 0) hp = 0;
        
        healthBar.SetValue(hp);
        DisplayDamge();

        if (IsDead()) {
            deadAction.Perform();
        }
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

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("ball")) {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("PlayerReceiveEnergy");
            SetEnergy(energy + 1);
        }
    }

    private void DisplayDamge() {
        string damageSound = hp > 0 ? "PlayerDamaged" : "PlayerDeath";
        FindObjectOfType<AudioManager>().Play(damageSound);

        camAnimator.SetTrigger("shake");

        sprite.color = Color.red;
        StartCoroutine(OnFinishDamage());
    }
    private IEnumerator OnFinishDamage() {
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }
}
