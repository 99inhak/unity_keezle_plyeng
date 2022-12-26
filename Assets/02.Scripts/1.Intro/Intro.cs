using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [Header("��ġȰ��")]
    public Image imageTouch;
    public Sprite touchOn;
    public Sprite touchOff;

    [Header("�ִ��÷��̾�")]
    public Image imageMaxPlayer;
    public Sprite maxPlayerOn;
    public Sprite maxPlayerOff;

    [Header("�ð�")]
    public Image imageTime;
    public Sprite timeOn;
    public Sprite timeOff;

    AudioSource audioSource;

    [Header("ȿ����")]
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

    //Ȱ����� �ȳ�
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

    //�÷��̾� �� �ȳ�
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

    //Ȱ���ð� �ȳ�
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
