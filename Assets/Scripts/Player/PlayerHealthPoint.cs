using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthPoint : MonoBehaviour
{
	public int fullHp = 100;
	public int hp;
	public Text hpText;
	public Slider hpSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	Animator anim;
	AudioSource playerAudio;
	Player player;
	bool isDead;
	bool damaged;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		player = GetComponent <Player> ();
		hp = fullHp;
		hpSlider.maxValue = fullHp;
	}

	void Update ()
	{
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage (int amount)
	{
		if (isDead) {
			return;
		}

		damaged = true;

		hp -= amount;
		hpSlider.value = hp;
		hpText.text = hp.ToString () + "/" + fullHp.ToString();

		//playerAudio.Play ();

		if (hp <= 0 && !isDead) {
			Dying();
		}
	}

	void Dying ()
	{
		isDead = true;
		GameController.instance.GameOver ();

		anim.SetTrigger ("Die");

		playerAudio.clip = deathClip;
		playerAudio.Play ();

		player.enabled = false;
	}

	void Died()
	{
		GameController.instance.Restart ();
	}
}