using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPattern : MonoBehaviour
{
    public bool realistic = false;
    public int iterations = 2;


    public GameObject stadium;

    public List<GameObject> realisticPatterns = new List<GameObject>();
    public GameObject realisticPracticeLeft;
    public GameObject realisticPracticeRight;
    public List<GameObject> abstractPatterns = new List<GameObject>();
    public GameObject abstractPracticeLeft;
    public GameObject abstractPracticeRight;

    private List<int> indexes = new List<int>();
    private List<GameObject> patterns;

    private GameObject activePattern = null;

    private int count = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        if (!realistic)
        {
            stadium.SetActive(false);
        }
        
        foreach (GameObject go in realisticPatterns)
        {
            go.SetActive(false);
        }
        realisticPracticeLeft.SetActive(false);
        realisticPracticeRight.SetActive(false);

        foreach (GameObject go in abstractPatterns)
        {
            go.SetActive(false);
        }
        abstractPracticeLeft.SetActive(false);
        abstractPracticeRight.SetActive(false);

        if (realistic)
        {
            for (int i=0; i<realisticPatterns.Count; i++)
            {
                for (int j = 0; j < iterations; j++)
                {
                    indexes.Add(i);
                }
            }

            patterns = realisticPatterns;
            //indexes.Insert(0, patterns.Count);
            patterns.Add(realisticPracticeLeft);
            //indexes.Insert(0, patterns.Count);
            patterns.Add(realisticPracticeRight);

        }
        else
        {
            for (int i = 0; i < abstractPatterns.Count; i++)
            {
                for (int j = 0; j < iterations; j++)
                {
                    indexes.Add(i);
                }
            }

            patterns = abstractPatterns;
            //indexes.Insert(0, patterns.Count);
            patterns.Add(abstractPracticeLeft);
            //indexes.Insert(0, patterns.Count);
            patterns.Add(abstractPracticeRight);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Show()
    {
        if (activePattern != null)
        {
            activePattern.SetActive(false);
        }

        if (count == 0)
        {
            activePattern = patterns[patterns.Count - 2];
        }

        else if (count == 1)
        {
            activePattern = patterns[patterns.Count - 1];
        }

        else
        {
            int nextIndex = Random.Range(0, indexes.Count);
            //Debug.Log(indexes.Count + " " +  nextIndex);
            activePattern = patterns[indexes[nextIndex]];
            indexes.RemoveAt(nextIndex);
        }

        activePattern.SetActive(true);
        count++;

        return activePattern.name;
    }

    // Returns true if we are finished
    // false otherwise
    public bool Hide()
    {
        if (activePattern != null)
        {
            activePattern.SetActive(false);
        }
        activePattern = null;

        return indexes.Count == 0;
    }
}
