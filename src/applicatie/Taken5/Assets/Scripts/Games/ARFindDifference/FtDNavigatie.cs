using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FtDNavigatie : MonoBehaviour {
    public GameObject Intro;
    public GameObject AR;
    public GameObject Hints;
    public GameObject images;
    int currentImage;

    public void ToIntro()
    {
        Intro.SetActive(true);
        AR.SetActive(false);
        Hints.SetActive(false);
    }
    public void ToAr()
    {
        Intro.SetActive(false);
        AR.SetActive(true);
        Hints.SetActive(false);
    }
    public void ToHints()
    {
        AR.SetActive(false);
        Hints.SetActive(true);
        currentImage = -1;
        NextImg();
    }
    public void ToOplossing()
    {
        AR.SetActive(false);
    }

    public void NextImg()
    {
        var imgs = images.GetComponentsInChildren<Image>(true);

        currentImage = (currentImage + 1) % imgs.Length; //+1 en de rest ervan nemen

        for (int i=0; i<imgs.Length; i++)
        {
            if (i == currentImage)
            {
                imgs[i].gameObject.SetActive(true);
            }
            else
            {
                imgs[i].gameObject.SetActive(false);
            }
        }
    }
}
