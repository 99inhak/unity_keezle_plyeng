using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerClick : MonoBehaviour
{
    public Player[] players;

    Player character;
    Player cow;
    Player pig;
    Player sheep;

    Image imageChar;
    Image imageCow;
    Image imagePig;
    Image imageSheep;

    public Sprite[] spriteChar;
    public Sprite spriteCow;
    public Sprite spritePig;
    public Sprite[] spriteSheep;


    public GameObject clickEffect;
    public GameObject effectArea;

    AudioSource audioSource;
    public AudioClip[] volceClips;
    // Start is called before the first frame update
    void Start()
    {
        Setting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Setting()
    {
        character = players[0];
        cow = players[1];
        pig = players[2];
        sheep = players[3];
        imageChar = character.GetComponent<Image>();
        imageCow = cow.GetComponent<Image>();
        imagePig = pig.GetComponent<Image>();
        imageSheep = sheep.GetComponent<Image>();
        audioSource = GameManager.instance.audioSource;
    }

    public void OnClickCharacter()
    {
        character.click = true;
        character.GetComponent<Button>().enabled = false;
        character.StopAllCoroutines();
        StartCoroutine(CharacterClick());
    }
    public void OnClickCow()
    {
        cow.click = true;
        cow.GetComponent<Button>().enabled = false;
        cow.StopAllCoroutines();
        StartCoroutine(CowClick());
    }
    public void OnClickPig()
    {
        pig.click = true;
        pig.GetComponent<Button>().enabled = false;
        pig.StopAllCoroutines();
        StartCoroutine(PigClick());
    }
    public void OnClickSheep()
    {
        sheep.click = true;
        sheep.GetComponent<Button>().enabled = false;
        sheep.StopAllCoroutines();
        StartCoroutine(SheepClick());
    }

    public void End()
    {
        character.click = true;
        character.GetComponent<Button>().enabled = false;
        character.StopAllCoroutines();
        cow.click = true;
        cow.GetComponent<Button>().enabled = false;
        cow.StopAllCoroutines();
        pig.click = true;
        pig.GetComponent<Button>().enabled = false;
        pig.StopAllCoroutines();
        sheep.click = true;
        sheep.GetComponent<Button>().enabled = false;
        sheep.StopAllCoroutines();
        StartCoroutine(CharacterEnd());
        StartCoroutine(CowEnd());
        StartCoroutine(PigEnd());
        StartCoroutine(SheepEnd());

    }

    IEnumerator CharacterClick()
    {
        audioSource.PlayOneShot(volceClips[0]);
        GameObject obj = Instantiate(clickEffect, character.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        imageChar.sprite = spriteChar[0];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[1];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[0];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[1];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[0];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        character.GetComponent<Button>().enabled = true;
        character.click = false;
        if (!Play.instance.end)
        {
            StartCoroutine(character.MoveAni());

        }
    }
    IEnumerator CharacterEnd()
    {
        GameObject obj = Instantiate(clickEffect, character.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        imageChar.sprite = spriteChar[0];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[1];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[0];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[1];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageChar.sprite = spriteChar[0];
        imageChar.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator CowClick()
    {
            audioSource.PlayOneShot(volceClips[1]);
        GameObject obj = Instantiate(clickEffect, cow.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        Vector3 scale = cow.transform.localScale;
        imageCow.sprite = spriteCow;
        imageCow.SetNativeSize();
        cow.transform.DOScale(0, 1);
        yield return new WaitForSeconds(1f);

        if (!Play.instance.end)
        {
            cow.transform.localScale = scale;
            cow.GetComponent<Button>().enabled = true;
            cow.click = false;
            StartCoroutine(cow.MoveAni());
        }

    }

    IEnumerator CowEnd()
    {
        GameObject obj = Instantiate(clickEffect, cow.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        Vector3 scale = cow.transform.localScale;
        imageCow.sprite = spriteCow;
        imageCow.SetNativeSize();
        yield return new WaitForSeconds(1f);
    }

    IEnumerator PigClick()
    {
            audioSource.PlayOneShot(volceClips[2]);
        GameObject obj = Instantiate(clickEffect, pig.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        Vector3 scale = pig.transform.localScale;
        imagePig.sprite = spritePig;
        imagePig.SetNativeSize();
        pig.transform.DOScale(0, 1);
        yield return new WaitForSeconds(1f);

        if (!Play.instance.end)
        {
            pig.transform.localScale = scale;
            pig.GetComponent<Button>().enabled = true;
            pig.click = false;
            StartCoroutine(pig.MoveAni());

        }
    }

    IEnumerator PigEnd()
    {
        GameObject obj = Instantiate(clickEffect, pig.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        Vector3 scale = pig.transform.localScale;
        imagePig.sprite = spritePig;
        imagePig.SetNativeSize();
        yield return new WaitForSeconds(1f);

    }

    IEnumerator SheepClick()
    {
        audioSource.PlayOneShot(volceClips[3]);
        GameObject obj = Instantiate(clickEffect, sheep.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        imageSheep.sprite = spriteSheep[0];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[1];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[0];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[1];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[0];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        sheep.GetComponent<Button>().enabled = true;
        sheep.click = false;
        if (!Play.instance.end)
        {
            StartCoroutine(sheep.MoveAni());

        }
    }

    IEnumerator SheepEnd()
    {
        GameObject obj = Instantiate(clickEffect, sheep.transform.position, Quaternion.identity, effectArea.transform);
        Destroy(obj, 1);
        imageSheep.sprite = spriteSheep[0];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[1];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[0];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[1];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
        imageSheep.sprite = spriteSheep[0];
        imageSheep.SetNativeSize();
        yield return new WaitForSeconds(0.2f);
    }
}
