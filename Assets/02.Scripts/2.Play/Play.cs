using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Play : MonoBehaviour
{
    public static Play instance;

    public bool play;
    public bool end;

    public Timer timer;

    AudioSource audioSource;
    public AudioClip bgm;
    public AudioClip boom;
    public AudioClip goEnd;

    public PlayerClick playerClick;

    public Image[] backgrounds;
    public Image[] grass;
    public float backgroundTimer;
    public int stage;

    Sequence sequence;

    public GameObject food;
    float foodCreateTime;
    public GameObject foodSpawn;

    Vector3 position;
    Vector3 position2;
    Vector3 position3;
    Vector3 position4;

    public int num;
    public int num2;
    public int num3;
    public int num4;
    int random;
    int random2;
    int random3;
    int random4;

    public int curNum;
    public int curNum2;
    public int curNum3;
    public int curNum4;
    bool check;
    public float speed;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameManager.instance.audioSource;
        audioSource.clip = bgm;
        audioSource.Play();
        audioSource.loop = enabled;
        play = true;
        stage = 0;
        StartCoroutine(RandomNumber());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeout && !end)
        {
            StopAllCoroutines();
            StartCoroutine(Timeout());
        }

        backgroundTimer += Time.deltaTime;

        if (backgroundTimer > 40  && stage < 2)
        {
            BackgroundChange();
        }
    }


    void BackgroundChange()
    {
        sequence = DOTween.Sequence()
       .Append(backgrounds[stage].DOFade(0, 1).SetEase(Ease.Linear))
       .Join(grass[stage].DOFade(0, 1).SetEase(Ease.Linear));

        stage++;

        sequence = DOTween.Sequence()
        .Append(backgrounds[stage].DOFade(1, 0.5f).SetEase(Ease.Linear))
        .Join(grass[stage].DOFade(1, 0.5f).SetEase(Ease.Linear));
        backgroundTimer = 0;
    }

    IEnumerator Timeout()
    {
        end = true;
        timer.timeout = false;
        End();
        audioSource.PlayOneShot(boom);
        yield return new WaitForSeconds(boom.length);
        audioSource.PlayOneShot(goEnd);
        yield return new WaitForSeconds(goEnd.length);
        StopAllCoroutines();
        GameManager.instance.state = GameManager.State.End;
        StartCoroutine(GameManager.instance.SceneChange());
    }

    void End()
    {
        playerClick.End();
    }



    IEnumerator FoodCreate()
    {
        position = new Vector3(Random.Range(0.05f, 0.25f), 1.2f, 0.5f);
        position2 = new Vector3(Random.Range(0.5f, 0.75f), 1.2f, 0.5f);
        position3 = new Vector3(Random.Range(0.25f, 0.5f), 1.2f, 0.5f);
        position4 = new Vector3(Random.Range(0.75f, 0.95f), 1.2f, 0.5f);
        yield return new WaitForSeconds(foodCreateTime);
        Vector3 pos = Camera.main.ViewportToWorldPoint(position);
        Vector3 pos2 = Camera.main.ViewportToWorldPoint(position2);
        Vector3 pos3 = Camera.main.ViewportToWorldPoint(position3);
        Vector3 pos4 = Camera.main.ViewportToWorldPoint(position4);
        GameObject Obj = Instantiate(food, pos, Quaternion.identity, foodSpawn.transform);
        GameObject Obj2 = Instantiate(food, pos2, Quaternion.identity, foodSpawn.transform);
        GameObject Obj3 = Instantiate(food, pos3, Quaternion.identity, foodSpawn.transform);
        GameObject Obj4 = Instantiate(food, pos4, Quaternion.identity, foodSpawn.transform);
        StartCoroutine(RandomNumber());
    }

    IEnumerator RandomNumber()
    {
        if (GameManager.instance.state == GameManager.State.Play)
        {
            random = Random.Range(0, 8);
            random2 = Random.Range(0, 8);
            random3 = Random.Range(0, 8);
            random4 = Random.Range(0, 8);

            if (random != random2 && random != random3 && random != random4 && random2 != random3 && random2 != random4 && random3 != random4)
            {
                if (!check)
                {
                    check = true;

                    num = curNum;
                    num2 = curNum2;
                    num3 = curNum3;
                    num4 = curNum4;
                    StartCoroutine(FoodCreate());
                }
                else
                {
                    if (curNum != random && curNum2 != random2 && curNum3 != random3 && curNum4 != random4)
                    {
                        curNum = random;
                        curNum2 = random2;
                        curNum3 = random3;
                        curNum4 = random4;
                        num = curNum;
                        num2 = curNum2;
                        num3 = curNum3;
                        num4 = curNum4;
                        StartCoroutine(FoodCreate());
                    }
                    else
                    {
                        StartCoroutine(RandomNumber());
                    }
                }
            }
            else
            {
                StartCoroutine(RandomNumber());
            }
        }

        switch (stage)
        {
            case 0:
                foodCreateTime = Random.Range(1.0f, 1.4f);
                break;
            case 1:
                //foodCreateTime = Random.Range(0.75f, 1.25f);
                foodCreateTime = Random.Range(1.0f, 1.4f);
                break;
            case 2:
                //foodCreateTime = Random.Range(0.5f, 1f);
                foodCreateTime = Random.Range(1.0f, 1.4f);
                break;
        }

        yield return new WaitForSeconds(foodCreateTime);
    }
}
