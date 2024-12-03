using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMusic;
    [SerializeField] private GameObject Music2;
    void Awake()
    {
        MainMusic.SetActive(false);
        Music2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int Music = ((Ink.Runtime.IntValue)DialogueManager
 .GetInstance()
 .GetVariableState("music")).value;
        if (MainMusic.activeSelf)
        {
            if (Music == 1)
            {
                MainMusic.SetActive(false);
                Music2.SetActive(true);
            }
            else if (Music == 0)
            {
                //
            };
        }
        else if (!MainMusic.activeSelf)
        {
            if (Music == 0)
            {
                MainMusic.SetActive(true);
                Music2.SetActive(false);
            }
            else if (Music != 0)
            {
                //
            };
            if (!Music2.activeSelf)
            {
                MainMusic.SetActive(true);
                Music2.SetActive(false);
                ((Ink.Runtime.IntValue)DialogueManager
 .GetInstance()
 .GetVariableState("music")).value = 0;
            };
        }
    }
}