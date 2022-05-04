using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static GameManager GetInstance()
    {
        if (GameObject.FindWithTag("GameManager") == null)
        {
            // ここに生成の呪文を追加
        }

        return instance;
    }
}
