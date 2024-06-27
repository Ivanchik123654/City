using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spisokCheckpointow;
    public int nextChIndex = 0;
    public int complitedCircles = 0;
    public Ypravlenie2 playerScript;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void CheckPointDostigli(GameObject checkPoint)
    {
        if (spisokCheckpointow[nextChIndex] == checkPoint)
        {
            nextChIndex++;  // ++ это += 1 
            checkPoint.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    public void DostigliFinisha(GameObject finish)
    {
        if (nextChIndex == spisokCheckpointow.Count)
        {
            finish.GetComponent<Renderer>().material.color = Color.black;
            complitedCircles++;
            StartCoroutine(timer(2f, finish));
            if (complitedCircles == 3) 
            {
                Debug.Log("Вы победили");
                Time.timeScale = 0f; // останавливает игру
            }   
        }
    }
    private void ResetCheckpoints(GameObject finish)
    {
        foreach (GameObject checkPoint in spisokCheckpointow)
        {
            checkPoint.GetComponent<Renderer>().material.color = Color.white;
        }
        finish.GetComponent<Renderer>().material.color = Color.white;
        nextChIndex = 0;
    }
    IEnumerator timer (float time, GameObject finish)
    {
        yield return new WaitForSeconds (time);
        ResetCheckpoints(finish);
    }
}
