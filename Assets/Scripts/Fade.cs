using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public float fadeSpeed = 1.5f;

    private SpriteRenderer sr;
    private Color matCol;
    private bool fade = false;
    private float alfa;
    private float fadeAmt;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        alfa = sr.color.a;
        fadeAmt = 1f / (fadeSpeed == 0 ? 1 : fadeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            Color matCol = sr.material.color;
            alfa = matCol.a + Time.deltaTime * fadeAmt;
            sr.material.SetColor("_Color", new Color(matCol.r, matCol.g, matCol.b, alfa));

            print(alfa);
            if (alfa <= 0)
            {
                gameObject.SetActive(false);
                fade = false;
                sr.material.SetColor("_Color", new Color(matCol.r, matCol.g, matCol.b, 0));
            }
            if (alfa >= 1)
            {
                gameObject.SetActive(true);
                fade = false;
                sr.material.SetColor("_Color", new Color(matCol.r, matCol.g, matCol.b, 1));
            }
        }
    }

    public void AltFade()
    {
        gameObject.SetActive(true);
        fade = true;
        fadeAmt = -fadeAmt;
    }

}
