using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDown : MonoBehaviour
{
    private bool color_alpha = true;
    bool is_shooted = false;
    public GameObject laser;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !is_shooted)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
            Blinking_LockOn();
        }
    }

    public void Blinking_LockOn()
    {
        is_shooted = true;
        StartCoroutine(Blinking(5));
        this.GetComponent<AudioSource>().Play();
    }

    public void Reset()
    {
        laser.SetActive(false);
        color_alpha = true;
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.0f);
    }

    IEnumerator Blinking(int cnt)
    {
        int a = cnt;
        while (a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (color_alpha)
            {
                Debug.Log("a");
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
                color_alpha = !color_alpha;
            }
            else
            {
                Debug.Log("b");
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
                color_alpha = !color_alpha;
                a--;
            }
            Debug.Log(a);
        }
        laser.SetActive(true);
        is_shooted = false;
    }
}
