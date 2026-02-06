using UnityEngine;
using System.Collections.Generic;

public class ConnectBrandG : MonoBehaviour
{
    public int countOfBrands;
    public List<ScriptableConnection> sc;

    [SerializeField] List<GameObject> chkTags = new List<GameObject>();
    [SerializeField] List<GameObject> logos = new List<GameObject>();

    void Start()
    {
        int i = 0;
        int[] m = new int[countOfBrands];
        while(i < countOfBrands)
        {
            int j = Random.Range(0, sc.Count);
            bool ist = false;
            foreach(int k in m)
            {
                if(k == j)
                {
                    ist = true;
                    break;
                }


            }
            if(!ist)
            {
                chkTags.Add(Instantiate(sc[j].nameB, new Vector3(-1.7f, 1.0f - 1.5f * i, 0), Quaternion.identity));
                logos.Add(sc[j].logo);
                m[i] = j;
                i++;
            }
        }
        ShuffleArray(logos);
        for(int l = 0; l < countOfBrands; l++)
        {
            Instantiate(logos[l], new Vector3(1.7f, 1.0f - 1.5f * l, 0), Quaternion.identity);
        }
    }

    void ShuffleArray(List<GameObject> array)
    {
        int n = array.Count;
        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(i, n);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
    void Update()
    {
        bool itN = true;
        foreach(GameObject t in chkTags)
        {
            if(t.tag != "On")
                itN = false;
        }
        if(itN)
            Debug.Log("Good");
    }
}

