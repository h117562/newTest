using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card1 : MonoBehaviour
{
    public Animator anim;
    float w8_time = 2.0f;
    bool opened = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(HardGameManager.I.firstCard != null && opened)
        {
             w8_time -= Time.deltaTime;
            if(w8_time < 0)
             {
               closeCardInvoke();
               w8_time = 2.0f;
                HardGameManager.I.firstCard = null;
                opened = false;
            }
        }
    }

    public void openCard()
    {
        anim.SetBool("isOpen", true);
        opened = true;
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if (HardGameManager.I.firstCard == null)
        {
            HardGameManager.I.firstCard = gameObject;
        }
        else
        {
            HardGameManager.I.secondCard = gameObject;
            HardGameManager.I.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }

}
