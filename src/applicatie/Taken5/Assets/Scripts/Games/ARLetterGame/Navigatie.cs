using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigatie : MonoBehaviour {
    public GameObject Intro;
    public GameObject AR;
    public GameObject Hints;
    public GameObject Oplossing;

    public void ToIntro()
    {
        Intro.SetActive(true);
        AR.SetActive(false);
        Hints.SetActive(false);
        Oplossing.SetActive(false);
    }
    public void ToAr()
    {
        Intro.SetActive(false);
        AR.SetActive(true);
        Hints.SetActive(false);
        Oplossing.SetActive(false);
    }
    public void ToHints()
    {
        AR.SetActive(false);
        Hints.SetActive(true);
    }
    public void ToOplossing()
    {
        AR.SetActive(false);
        Oplossing.SetActive(true);
    }
}
