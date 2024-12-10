using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public AudioSource textAudio;

    private int index;

    public bool lastDialogue;

    public UnityEngine.UI.Image fade;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        lastDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if (textComponent.text == lines[index]) {
                NextLine();
            }
            else {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        //Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            if (c != ' ')
            {
                textAudio.Play();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
            if (lastDialogue)
            {
                fade.CrossFadeAlpha(255f, 3f, false);
                Invoke("LoadCredits", 3.0f);
            }
        }
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
