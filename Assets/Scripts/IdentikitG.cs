using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class IdentikitG : MonoBehaviour
{
    public Image clock;
    public TMP_Text label;
    public GameObject tellIfPaused;
    public float secsLeft = 30f;
    bool didIt = false;

    public GameObject orig;
    public GameObject chinaCopy;

    Image[] origPics = new Image[7];
    Image[] chinaPics = new Image[7];

    public GameObject itogMenu;
    public TMP_Text itog;

    public Sprite[] ears;
    public Sprite[] hairs;
    public Sprite[] mouths;
    public Sprite[] eyes;
    public Sprite[] noses;
    public Sprite[] faces;
    public Sprite[] cheeks;//?

    [SerializeField] int[] answer = new int[7];
    [SerializeField] int[] guess = new int[7];

    void Start()
    {
        origPics[0] = orig.transform.Find("Ear").GetComponent<Image>();
        origPics[1] = orig.transform.Find("Hair").GetComponent<Image>();
        origPics[2] = orig.transform.Find("Mouth").GetComponent<Image>();
        origPics[3] = orig.transform.Find("Eye").GetComponent<Image>();
        origPics[4] = orig.transform.Find("Nose").GetComponent<Image>();
        origPics[5] = orig.transform.Find("Facee").GetComponent<Image>();
        origPics[6] = orig.transform.Find("Cheek").GetComponent<Image>();

        chinaPics[0] = chinaCopy.transform.Find("Ear").GetComponent<Image>();
        chinaPics[1] = chinaCopy.transform.Find("Hair").GetComponent<Image>();
        chinaPics[2] = chinaCopy.transform.Find("Mouth").GetComponent<Image>();
        chinaPics[3] = chinaCopy.transform.Find("Eye").GetComponent<Image>();
        chinaPics[4] = chinaCopy.transform.Find("Nose").GetComponent<Image>();
        chinaPics[5] = chinaCopy.transform.Find("Facee").GetComponent<Image>();
        chinaPics[6] = chinaCopy.transform.Find("Cheek").GetComponent<Image>();

        answer[0] = UnityEngine.Random.Range(0, ears.Length);
        origPics[0].sprite = ears[answer[0]];
        answer[1] = UnityEngine.Random.Range(0, hairs.Length);
        origPics[1].sprite = hairs[answer[1]];
        answer[2] = UnityEngine.Random.Range(0, mouths.Length);
        origPics[2].sprite = mouths[answer[2]];
        answer[3] = UnityEngine.Random.Range(0, eyes.Length);
        origPics[3].sprite = eyes[answer[3]];
        answer[4] = UnityEngine.Random.Range(0, noses.Length);
        origPics[4].sprite = noses[answer[4]];
        answer[5] = UnityEngine.Random.Range(0, faces.Length);
        origPics[5].sprite = faces[answer[5]];
        answer[6] = UnityEngine.Random.Range(0, cheeks.Length);
        origPics[6].sprite = cheeks[answer[6]];
    }

    void Update()
    {
        if(didIt == false){
            if (!tellIfPaused.activeSelf)
            {
                secsLeft -= Time.deltaTime;
                clock.fillAmount = secsLeft / 30f;
                label.text = ((int)secsLeft).ToString();
            }
            if(secsLeft <= 0f)
            {
                TheGameStartsNow();
                didIt = !didIt;
            }
        }
    }
    public void TheGameStartsNow()
    {
        orig.SetActive(false);
        chinaCopy.SetActive(true);
        secsLeft = 0f;
    }
    public void InjImage(string cat)
    {
        string[] temp = cat.Split(' ');
        int im = Convert.ToInt32(temp[0]);
        int spw = Convert.ToInt32(temp[1]);
        Sprite[] sp = new Sprite[2];
        if(im == 0) sp = ears;
        else if(im == 1) sp = hairs;
        else if(im == 2) sp = mouths;
        else if(im == 3) sp = eyes;
        else if(im == 4) sp = noses;
        else if(im == 5) sp = faces;
        else if(im == 6) sp = cheeks;
        else Debug.Log("Something goes wrong.. Dude i cant do that shi");
        chinaPics[im].sprite = sp[spw];
        guess[im] = spw;
    }
    public void Submit()
    {
        chinaCopy.SetActive(false);
        itogMenu.SetActive(true);
        bool equal = true;
        for(int i = 0; i < guess.Length; i++)
        {
            if(guess[i] != answer[i])
            {
                equal = false;
                break;
            }
        }
        if(equal == true) itog.text = "WOW just wow";
        else
        {
            itog.text = "well u messd up with:";
            string[] m = new string[] {" ears ", " hair ", " mouth ", " eyes ", " nose ", " face ", " cheek "};
            for(int i = 0; i < guess.Length; i++)
            {
                if(guess[i] != answer[i])
                {
                    itog.text += m[i];
                }
            }
        }
    }
}
