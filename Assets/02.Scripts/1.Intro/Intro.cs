using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [Header("터치활동")]
    public Image imageTouch;
    public Sprite touchOn;
    public Sprite touchOff;

    [Header("최대플레이어")]
    public Image imageMaxPlayer;
    public Sprite maxPlayerOn;
    public Sprite maxPlayerOff;

    [Header("시간")]
    public Image imageTime;
    public Sprite timeOn;
    public Sprite timeOff;

    AudioSource audioSource;

    [Header("효과음")]
    public AudioClip opening;
    public AudioClip objectLight;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameManager.instance.audioSource;
        StartCoroutine(IntroPlay());
    }

    IEnumerator IntroPlay()
    {
        audioSource.PlayOneShot(opening);
        yield return new WaitForSeconds(opening.length);

        ActivityInfo();
        yield return new WaitForSeconds(2f);
        PlayerInfo();
        yield return new WaitForSeconds(2f);
        TimeInfo();
    }

    //활동방법 안내
    void ActivityInfo()
    {
        imageTouch.transform.DOScale(1.1f, 0.5f).OnComplete(() =>
        {
            imageTouch.transform.DOScale(1.0f, 0.5f).OnComplete(() =>
            {
                imageTouch.transform.DOScale(1.1f, 0.5f).OnComplete(() =>
                {
                    imageTouch.transform.DOScale(1.0f, 0.5f).OnComplete(() =>
                    {
                        imageTouch.sprite = touchOff;
                    });
                });
            });
        }).OnPlay(() =>
        {
            audioSource.PlayOneShot(objectLight);
            imageTouch.sprite = touchOn;
        });
    }

    //플레이어 수 안내
    void PlayerInfo()
    {
        imageMaxPlayer.transform.DOScale(1.1f, 0.5f).OnComplete(() =>
        {
            imageMaxPlayer.transform.DOScale(1.0f, 0.5f).OnComplete(() =>
            {
                imageMaxPlayer.transform.DOScale(1.1f, 0.5f).OnComplete(() =>
                {
                    imageMaxPlayer.transform.DOScale(1.0f, 0.5f).OnComplete(() =>
                    {
                        imageMaxPlayer.sprite = maxPlayerOff;
                    });
                });
            });
        }).OnPlay(() =>
        {
            audioSource.PlayOneShot(objectLight);
            imageMaxPlayer.sprite = maxPlayerOn;
        });
    }

    //활동시간 안내
    void TimeInfo()
    {
        imageTime.transform.DOScale(1.1f, 0.5f).OnComplete(() =>
        {
            imageTime.transform.DOScale(1.0f, 0.5f).OnComplete(() =>
            {
                imageTime.transform.DOScale(1.1f, 0.5f).OnComplete(() =>
                {
                    imageTime.transform.DOScale(1.0f, 0.5f).OnComplete(() =>
                    {
                        imageTime.sprite = timeOff;
                        GameManager.instance.state = GameManager.State.Play;
                        StartCoroutine(GameManager.instance.SceneChange());
                    });
                });
            });
        }).OnPlay(() =>
        {
            audioSource.PlayOneShot(objectLight);
            imageTime.sprite = timeOn;
        });
    }
}
