using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public enum Type
    {
        Character, Cow, Pig, Sheep
    }

    public Type type;

    public Image image;
    public RectTransform posLeft;
    public RectTransform posRight;
    public Sprite[] sprite;

    RectTransform rect;
    public int speed;
    public int num;

    public bool click;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        num = Random.Range(0, 2);

        if (num == 0)
        {
            speed = Random.Range(-100, -89);
        }
        else
        {
            speed = Random.Range(90, 101);

        }

        if (speed > 0)
        {
            rect.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rect.localScale = new Vector3(1, 1, 1);
        }

        StartCoroutine(MoveAni());

    }

    // Update is called once per frame
    void Update()
    {
        if (!click && !Play.instance.end)
        {
            Move();
        }
    }

    void Move()
    {
        if (rect.anchoredPosition.x < posLeft.anchoredPosition.x)
        {
            speed = Random.Range(90, 101);

            rect.localScale = new Vector3(-1, 1, 1);
        }

        if (rect.anchoredPosition.x > posRight.anchoredPosition.x)
        {
            speed = Random.Range(-100, -89);

            rect.localScale = new Vector3(1, 1, 1);
        }

        rect.anchoredPosition += Vector2.right * speed * Time.deltaTime;

    }

    public IEnumerator MoveAni()
    {
        image.sprite = sprite[0];
        image.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        image.sprite = sprite[1];
        image.SetNativeSize();
        yield return new WaitForSeconds(0.2f);

        StartCoroutine(MoveAni());
    }
}
