using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int spelerBeurt = 1;
    public GameObject speler1;
    public GameObject speler2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spelers = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in spelers)
        {
            if (g.GetComponent<TankController>().PlayerNumber == 1)
            {
                speler1 = g;
            }
            else if (g.GetComponent<TankController>().PlayerNumber == 2)
            {
                speler2 = g;
            }
        }
        // de speler die aan de beurt is actief maken.
        Invoke("Init", 0.1f);
        
    }
    void Init()
    {
        if (spelerBeurt == 1)
        {
            // maak speler 1 actief
            Debug.Log("speler1actief");
            speler1.GetComponent<TankController>().ZetActief(true);
            speler2.GetComponent<TankController>().ZetActief(false);
        }
        else if (spelerBeurt == 2)
        {
            // maak speler 2 actief
            Debug.Log("speler2actief");
            speler1.GetComponent<TankController>().ZetActief(false);
            speler2.GetComponent<TankController>().ZetActief(true);
        }
    }
    
    public void WisselBeurt()
    {
        if (spelerBeurt == 1)
        {
            spelerBeurt = 2;
            speler1.GetComponent<TankController>().ZetActief(false);
            speler2.GetComponent<TankController>().ZetActief(true);
        }
        else if (spelerBeurt == 2)
        {
            spelerBeurt = 1;
            speler1.GetComponent<TankController>().ZetActief(true);
            speler2.GetComponent<TankController>().ZetActief(false);
        }
    }
}
