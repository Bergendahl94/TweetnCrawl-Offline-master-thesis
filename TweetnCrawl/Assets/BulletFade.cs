using UnityEngine;
using System.Collections;

public class BulletFade : MonoBehaviour
{



    public float FadeTime = 5f;

    void Start()
    {
        if (FadeTime >= 0)
        {
            StartCoroutine(Fade());
        }

    }

    public IEnumerator Fade()
    {
        var portion = FadeTime / 5;
        yield return new WaitForSeconds(portion*4);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(portion / 2);
        gameObject.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(portion / 1.5f);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(portion / 1);
        gameObject.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(portion / 0.5f);

        Destroy(gameObject);
        yield return null;
    }

}

