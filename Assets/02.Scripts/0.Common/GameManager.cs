using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Intro, Play, End
    }

    public State state;
    public static GameManager instance;

    [Header("Scene")]
    public GameObject sceneIntro;
    public GameObject scenePlay;
    public GameObject sceneEnd;

    [Header("Reference")]
    public AudioSource audioSource;

    public bool testMode;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (!testMode)
        {
            // Cursor.visible = false;
        }

        Component();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!testMode)
        {
            state = State.Intro;
            StartCoroutine(SceneChange());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state == State.Intro)
            {
                state = State.Play;
            }
            else if (state == State.Play)
            {
                state = State.End;
            }
            StartCoroutine(SceneChange());
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (state == State.End)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
    }

    void Component()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void IntroScene()
    {
        sceneIntro.SetActive(true);
        scenePlay.SetActive(false);
        sceneEnd.SetActive(false);
    }

    void PlayScene()
    {
        sceneIntro.SetActive(false);
        scenePlay.SetActive(true);
        sceneEnd.SetActive(false);
    }

    void EndScene()
    {
        sceneIntro.SetActive(false);
        scenePlay.SetActive(false);
        sceneEnd.SetActive(true);
    }

    public IEnumerator SceneChange()
    {
        switch (state)
        {
            case State.Intro:
                IntroScene();
                break;

            case State.Play:
                PlayScene();
                break;

            case State.End:
                EndScene();
                break;
        }
        yield return new WaitForSeconds(0.5f);
    }
}
