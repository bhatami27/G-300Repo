using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue _currentDialogue;
    int _currentSlideIndex = 0;
    //bool inDialogue = false;



    void Awake()
    {
        GameEvents.DialogueFinished += OnDialogueFinished;
        GameEvents.DialogueInitiated += OnDialogueInitiated;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentSlideIndex < _currentDialogue.DialogueSlides.Length - 1)
            {
                _currentSlideIndex++;
                ShowSlide();
            }
            else
            {
                GameEvents.InvokeDialogueFinished();
            }
        }
    }

    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogueText").gameObject;
        TextMeshProUGUI textComponet = textObj.GetComponent<TextMeshProUGUI>();
        textComponet.text = _currentDialogue.DialogueSlides[_currentSlideIndex];
        //inDialogue = true;
    }

    void OnDialogueInitiated(object sender, EventArgs args)
    {
        _currentSlideIndex = 0;
        ShowSlide();
        //LoadAvatar();
        GetComponent<Canvas>().enabled = true;
    }

    void OnDialogueFinished(object sender, EventArgs args)
    {
        GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(3);
    }

    /*
    void LoadAvatar()
    {
        GameObject avatarObj = transform.Find("NPCImage").gameObject;
        avatarObj.GetComponent<Image>().sprite = _currentDialogue.NPCchar;

    }
    */
}
