using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    private const string PATH = "Sprites/Photos/";
    private const float INTERVAL = 5.0f;
    private Image image;

    private float sec;

    void Start()
    {
        this.image = this.gameObject.GetComponent<Image>();
        this.image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    void Update()
    {
        if (this.sec > INTERVAL)
        {
            this.image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
    }

    public void Shot(string name)
    {
        this.sec = 0;
        this.image.sprite = Resources.Load<Sprite>(PATH + name);
        this.image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }

}