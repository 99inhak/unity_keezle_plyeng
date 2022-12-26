using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    public int one;
    public int ten;
    public int hundred;

    public Image imageOne;
    public Image imageTen;
    public Image imageHundred;

    public Sprite[] numbers;

    public float time;
    public bool timeout;

    AudioSource audioSource;
    public AudioClip last10s;
    bool lastPang;
    bool alert;
    Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = last10s;
        Set();
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (one < 0)
        {
            ten--;
            one = 9;
        }

        if (ten < 0)
        {
            hundred--;
            ten = 9;
        }

        if (hundred == 0)
        {
            if (ten == 0)
            {
                if (one == 0)
                {
                    Number();
                    StopAllCoroutines();
                    Play.instance.play = false;
                    timeout = true;
                    sequence.Kill();
                    transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                }
            }

        }

        if (time > 10 && Play.instance.play)
        {
            time -= Time.deltaTime;

        }

        if (time <= 10 && !lastPang && !alert)
        {
            lastPang = true;
        }

        if (lastPang && Play.instance.play)
        {
            lastPang = false;
            alert = true;
            audioSource.Play();
            Move();
        }

        if (!Play.instance.play)
        {
            audioSource.Stop();
        }

        if (Play.instance.play)
        {
            Number();
        }
    }

    public void Set()
    {
        hundred = 1;
        ten = 2;
        one = 0;
        time = 120;
    }

    public IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        one--;
        Number();
        StartCoroutine(timer());
    }

    void Move()
    {
        sequence = DOTween.Sequence()
        .Append(transform.DORotate(new Vector3(0, 0, 15), 0.5f))
        .Append(transform.DORotate(new Vector3(0, 0, -15), 0.5f))
        .OnComplete(() => Move());

    }

    void Number()
    {
        switch (one)
        {
            case 0:
                imageOne.sprite = numbers[0];
                break;
            case 1:
                imageOne.sprite = numbers[1];
                break;
            case 2:
                imageOne.sprite = numbers[2];
                break;
            case 3:
                imageOne.sprite = numbers[3];
                break;
            case 4:
                imageOne.sprite = numbers[4];
                break;
            case 5:
                imageOne.sprite = numbers[5];
                break;
            case 6:
                imageOne.sprite = numbers[6];
                break;
            case 7:
                imageOne.sprite = numbers[7];
                break;
            case 8:
                imageOne.sprite = numbers[8];
                break;
            case 9:
                imageOne.sprite = numbers[9];
                break;
        }

        switch (ten)
        {
            case 0:
                imageTen.sprite = numbers[0];
                break;
            case 1:
                imageTen.sprite = numbers[1];
                break;
            case 2:
                imageTen.sprite = numbers[2];
                break;
            case 3:
                imageTen.sprite = numbers[3];
                break;
            case 4:
                imageTen.sprite = numbers[4];
                break;
            case 5:
                imageTen.sprite = numbers[5];
                break;
            case 6:
                imageTen.sprite = numbers[6];
                break;
            case 7:
                imageTen.sprite = numbers[7];
                break;
            case 8:
                imageTen.sprite = numbers[8];
                break;
            case 9:
                imageTen.sprite = numbers[9];
                break;
        }

        switch (hundred)
        {
            case 0:
                imageHundred.sprite = numbers[0];
                break;
            case 1:
                imageHundred.sprite = numbers[1];
                break;
            case 2:
                imageHundred.sprite = numbers[2];
                break;
            case 3:
                imageHundred.sprite = numbers[3];
                break;
            case 4:
                imageHundred.sprite = numbers[4];
                break;
            case 5:
                imageHundred.sprite = numbers[5];
                break;
            case 6:
                imageHundred.sprite = numbers[6];
                break;
            case 7:
                imageHundred.sprite = numbers[7];
                break;
            case 8:
                imageHundred.sprite = numbers[8];
                break;
            case 9:
                imageHundred.sprite = numbers[9];
                break;
        }
        imageOne.SetNativeSize();
        imageTen.SetNativeSize();
        imageHundred.SetNativeSize();
    }
}
