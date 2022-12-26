 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Food : MonoBehaviour
{
    Image image;
    public Sprite[] foodSprite;
    public GameObject effect;

    AudioSource audioSource;
    public AudioClip[] voices;
    public AudioClip touch;

    RectTransform rect;
    [SerializeField]
    float rectL;
    float rectR;

    int random;
    public int num;
    public int num2;
    Rigidbody2D rigidbody;
    CircleCollider2D circleCollider2D;
    bool end;
    public bool start;
    bool click;
    public float downspeed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Component();

        FoodNum();
        Setting();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.GetComponent<RectTransform>().anchoredPosition.y < -(Screen.height / 2) - 100)
        {
            DestroyObject(gameObject);
        }

        if (Play.instance.end && !end)
        {
            downspeed = 0;

            end = true;
            StartCoroutine(Click());
        }
        else
        {
            if (!click)
            {
                downspeed = Play.instance.speed;
                rect.anchoredPosition += Vector2.down * downspeed * Time.deltaTime;
                Move();
            }
        }
        
    }

    public void OnClick()
    {

        StartCoroutine(Click());
    }

    void Move()
    {
        if (rect.anchoredPosition.x < rectL)
        {
            speed = Random.Range(90, 101);

            //rect.localScale = new Vector3(-1, 1, 1);
        }

        if (rect.anchoredPosition.x > rectR)
        {
            speed = Random.Range(-100, -89);

            //rect.localScale = new Vector3(1, 1, 1);
        }

        rect.anchoredPosition += Vector2.right * speed * Time.deltaTime;

    }


    IEnumerator Click()
    {
        click = true;
        circleCollider2D.isTrigger = true;
        downspeed = 0;
        image.raycastTarget = false;
        transform.DOKill();
        transform.DOScale(1.2f, 1f)
        .OnPlay(() =>
        {
            this.GetComponent<Image>().DOFade(0, 1f);
            GameObject obj = Instantiate(effect, transform.position, Quaternion.identity, transform.parent);
            DestroyObject(obj, 1f);
        });

        if (!Play.instance.end)
        {
            audioSource.PlayOneShot(voices[num]);
            audioSource.PlayOneShot(touch);
        }
        yield return new WaitForSeconds(0.5f);
        DestroyObject(gameObject, 0.5f);
    }

    void FoodNum()
    {
        transform.DOShakeScale(1, 0.3f, 2, 30).SetLoops(-1, LoopType.Restart);
        if (transform.GetComponent<RectTransform>().anchoredPosition.x < 0 && transform.GetComponent<RectTransform>().anchoredPosition.x > -480f)
        {
            //transform.DOMoveX(Random.Range(-4, 1), Random.Range(1, 4)).SetLoops(Random.Range(10, 15), LoopType.Yoyo);
            if (!start)
            {
                num = Play.instance.num;
            }
        }
        else if (transform.GetComponent<RectTransform>().anchoredPosition.x > 0 && transform.GetComponent<RectTransform>().anchoredPosition.x < 480)
        {
            //transform.DOMoveX(Random.Range(1, 5), Random.Range(1, 4)).SetLoops(Random.Range(10, 15), LoopType.Yoyo);
            if (!start)
            {
                num = Play.instance.num2;
            }
        }
        else if (transform.GetComponent<RectTransform>().anchoredPosition.x < -480)
        {
            //transform.DOMoveX(Random.Range(-8, -4), Random.Range(1, 4)).SetLoops(Random.Range(10, 15), LoopType.Yoyo);
            if (!start)
            {
                num = Play.instance.num3;
            }
        }
        else if (transform.GetComponent<RectTransform>().anchoredPosition.x > 480)
        {
            //transform.DOMoveX(Random.Range(5, 9), Random.Range(1, 4)).SetLoops(Random.Range(10, 15), LoopType.Yoyo);
            if (!start)
            {
                num = Play.instance.num4;
            }
        }
    }

    void Setting()
    {
        image.sprite = foodSprite[num];
        downspeed = Play.instance.speed;

        Speed();
        image.SetNativeSize();
    }
    void Component()
    {
        image = GetComponent<Image>();
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rect = GetComponent<RectTransform>();
        audioSource = GameManager.instance.audioSource;
        rectL = rect.anchoredPosition.x - Random.Range(30, 101);
        rectR = rect.anchoredPosition.x + Random.Range(30, 101);
    }

    void Speed()
    {
        num2 = Random.Range(0, 2);

        if (num2 == 0)
        {
            speed = Random.Range(-100, -89);
        }
        else
        {
            speed = Random.Range(90, 101);

        }
    }
}
