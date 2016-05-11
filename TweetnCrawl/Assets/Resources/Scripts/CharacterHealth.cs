using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {
	
	public int health = 100;
	public Texture2D HB;
	public Texture2D HBOutline;
	public Transform Player;
	public AudioClip[] list;

	public float x;
	public float y;
	public float w;
	public float h;

	public Material mat;
	
	void OnGUI() {
		if (Event.current.type.Equals(EventType.Repaint)) {
			Rect box = new Rect(x, y, w, h);
			Graphics.DrawTexture(box, HB, mat);
			Graphics.DrawTexture(box, HBOutline, mat);

		}
	}
	
	void Start () {
		Player = transform;

	}
	
	void Update () {

		float healthy = 1f-(health/100f);
		if (healthy == 0) {
			healthy = 0.1f;
				}
		mat.SetFloat ("_Cutoff", healthy);

		if (health <= 0) {
			//no damage method is implemented yet so the enemy cannot die as of now.
			print("Blaaah you killed me!");
			PlayerDeath();
			GameObject.Find("Game_Over_Panel").GetComponent<GameOver>().gameover();
			
		}
	}
	
	public void receiveDamage (int dmg) {
		health = health - dmg;
		Debug.Log("Recieved this amount of damage "+dmg.ToString()+" now health="+health.ToString() );
		StartCoroutine(RandomSound());
        StartCoroutine(OnHitEffect());

	}
	
	public void PlayerDeath () {

        Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<OldCharacterController>().DeathState;
        Player.GetComponent<Renderer>().enabled = true;
        Player.transform.GetChild(0).GetComponent<Renderer>().enabled = false;

	}

    public IEnumerator OnHitEffect()
    {

        yield return new WaitForSeconds(0.003f);
        GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(0.003f);
        GetComponent<Renderer>().material.color = Color.red;
        Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<OldCharacterController>().HurtState;
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(0.003f);
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.003f);
        Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<OldCharacterController>().HurtState;
        GetComponent<Renderer>().material.color = Color.black;
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(0.003f);
        Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<OldCharacterController>().HurtState;
        GetComponent<Renderer>().material.color = Color.white;

        yield return null;
    }

	protected virtual IEnumerator RandomSound() {
		GetComponent<AudioSource>().PlayOneShot(list[Random.Range(0,list.Length)]);

		yield return null;
		
	}

    public void Heal(int amount) 
    {
        if (health + amount > 100)
        {
            health = 100;
        }
        else
        {
            health += amount;
        }

        StartCoroutine(PickupFlash());
    }

    public Material PickUpFlashMaterial;
    public Color PickUpFlashColor;
    public float PickUpFlashDuration = 2f;
    public IEnumerator PickupFlash()
    {
        var oldMaterial = GetComponent<Renderer>().material;
        var oldColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material = PickUpFlashMaterial;
        GetComponent<Renderer>().material.color = PickUpFlashColor;

        yield return new WaitForSeconds(PickUpFlashDuration);

        GetComponent<Renderer>().material = oldMaterial;
        GetComponent<Renderer>().material.color = oldColor;

        yield return null;
    }

}
