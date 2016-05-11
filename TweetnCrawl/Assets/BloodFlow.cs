using UnityEngine;
using System.Collections;

public class BloodFlow : MonoBehaviour {
	
	// Update is called once per frame
    public Material BloodMaterial;
    public Color BloodColor;
    Vector3 oldPos;

    float time;
    public float TimeBetweenSplash = 0.1f;
	void Update () {
        if (transform.position != oldPos && time <= Time.time)
        {
            var bloodSpot = (GameObject)Instantiate(gameObject);
            bloodSpot.GetComponent<Rigidbody2D>().isKinematic = true;
            bloodSpot.GetComponent<Collider2D>().enabled = false;
            bloodSpot.GetComponent<Renderer>().material = BloodMaterial;
            bloodSpot.GetComponent<SpriteRenderer>().color = BloodColor;
            bloodSpot.GetComponent<BloodFlow>().enabled = false;
            bloodSpot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f);
            time = Time.time + TimeBetweenSplash;

        }
        oldPos = transform.position;
	}
}
