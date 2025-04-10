using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;

    public int index = 0;
    public SpriteRenderer frontImage;


    public Animator anim;



    
    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.isMatched();
        }
    }


    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 1.0f);
    }


    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }



    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }


    void CloseCardInvoke()
    {
        anim.SetBool("isOepn", false);
        front.SetActive(false);
        back.SetActive(true);
    }



    public void Setting(int number)
    {
        index = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{index}");
    }


}
