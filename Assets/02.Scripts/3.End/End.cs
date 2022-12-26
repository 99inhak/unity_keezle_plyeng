using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class End : MonoBehaviour
{
    AudioSource audioSource;

    public Image numberImage;
    public Sprite[] numberSprite;

    public Image fanfare;
    public Image sentence;
    public Image clock;
    public Image quit;
    public Image character;
    public Image[] apples;
    public GameObject apple;

    public Sprite[] spriteChar;

    public AudioClip countClip;
    public AudioClip sentenceClip;
    public AudioClip fanfareClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameManager.instance.audioSource;
        audioSource.clip = null;
        audioSource.Stop();
        StartCoroutine(EndPlay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EndPlay()
    {
        audioSource.PlayOneShot(fanfareClip);
        fanfare.transform.DOMoveY(-200, 30).SetEase(Ease.Linear);
        character.DOFade(1, 1.5f);
        for (int i = 0; i < apples.Length; i++)
        {
            apples[i].DOFade(1, 1.5f).OnComplete(() =>
            {
                apple.transform.DOMoveY(-2.3f, 1.5f).OnComplete(() =>
                {
                    apple.GetComponent<Animator>().enabled = true;
                });
            });
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CharacterAni());
        sentence.DOFade(1, 1f);
        audioSource.PlayOneShot(sentenceClip);
        yield return new WaitForSeconds(sentenceClip.length);

        quit.DOFade(1, 1f);
        clock.transform.DOMoveY(-4.5f, 1f).OnComplete(() =>
        {
            StartCoroutine(CountNumber());
        }
        );
    }

    IEnumerator CountNumber()
    {
        for (int i = 5; i > -1; i--)
        {
            numberImage.sprite = numberSprite[i];
            numberImage.SetNativeSize();
            audioSource.PlayOneShot(countClip);
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator CharacterAni()
    {
        character.sprite = spriteChar[1];
        character.SetNativeSize();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CharacterEatAni());
    }

    IEnumerator CharacterEatAni()
    {
        character.sprite = spriteChar[2];
        character.SetNativeSize();
        yield return new WaitForSeconds(0.5f);
        character.sprite = spriteChar[3];
        character.SetNativeSize();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CharacterEatAni());
    }
}
