using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;

    public SpriteRenderer frontImage;

    public void Setting(int number)
    {
        index = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{index}");
    }
}
