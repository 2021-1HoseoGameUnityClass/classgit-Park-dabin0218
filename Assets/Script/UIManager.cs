using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;

    public static UIManager instance { get { return _instance; } }

    [SerializeField]
    private GameObject[] playerHP_Objs = null;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    public void PlayerHP()
    {
        int minusHP = 3 - DataManager.instance.playerHP;
        for(int i = 0; i < minusHP; i++)
        {
            playerHP_Objs[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
