using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ボタンを十字キーで選択、決定するクラス
/// </summary>

public class SelectKeyControl : MonoBehaviour
{
    /// <summary>
    /// 選択するボタン
    /// </summary>
    [SerializeField] private GameObject[] button;
    private List<HomeControler> controlers;

    /// <summary>
    /// 現在選択しているボタンの番号
    /// </summary>
    private int buttonNum;

    /// <summary>
    /// 現在選択しているボタンオブジェクト
    /// </summary>
    private GameObject nowButton;

    // Start is called before the first frame update
    void Start()
    {
        buttonNum = 0;
        nowButton = button[buttonNum];
    }

    // Update is called once per frame
    /// <summary>
    /// ボタン番号を押された矢印によって加減させることで選択するボタンを変更
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.OnArrowDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.OnArrowTop();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.OnArrowLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.OnArrowRight();
        }

        if (buttonNum < button.Length)
        {
            nowButton = button[buttonNum];
        }
        Select();
    }

    /// <summary>
    /// 現在選択されているボタンを選択状態にする
    /// </summary>
    private void Select()
    {
        EventSystem ev = EventSystem.current;
        ev.SetSelectedGameObject(nowButton);
    }


    public void OnArrowTop()
    {
        if (buttonNum != 0)
        {
            buttonNum--;
        }
        else if (buttonNum < 0)
        {
            buttonNum = 0;
        }

        GameManager.GetInstance().PlaySE(0);
    }

    public void OnArrowDown()
    {
        if (buttonNum < button.Length - 1)
        {
            buttonNum++;
        }
        else if (buttonNum < button.Length)
        {
            buttonNum = button.Length - 1;
        }

        GameManager.GetInstance().PlaySE(0);
    }

    public void OnArrowLeft()
    {
        if (buttonNum != 0)
        {
            buttonNum--;
        }
        else if (buttonNum < 0)
        {
            buttonNum = 0;
        }

        GameManager.GetInstance().PlaySE(0);
    }

    public void OnArrowRight()
    {
        if (buttonNum < button.Length - 1)
        {
            buttonNum++;
        }
        else if (buttonNum < button.Length)
        {
            buttonNum = button.Length - 1;
        }

        GameManager.GetInstance().PlaySE(0);
    }

    public void Add(HomeControler controler)
    {
        if (this.controlers == null)
        {
            this.controlers = new List<HomeControler>();
        }
        if (!this.controlers.Contains(controler))
        {
            this.controlers.Add(controler);
            Debug.Log("a");
        }
    }

    public void OnEnable()
    {
        if (this.controlers == null) return;
        foreach (HomeControler con in this.controlers)
        {
            con.gameObject.SetActive(true);
        }
    }

    public void OnDisable()
    {

        if (this.controlers == null) return;
        foreach (HomeControler con in this.controlers)
        {
            if (con.GetTouchButton() == TouchButton.ARROW_DOWN || con.GetTouchButton() == TouchButton.ARROW_TOP ||
            con.GetTouchButton() == TouchButton.ARROW_LEFT || con.GetTouchButton() == TouchButton.ARROW_RIGHT)
            {

            }
            con.gameObject.SetActive(false);

        }
    }

    public Button GetSelectedButton()
    {
        return this.nowButton.GetComponent<Button>();
    }
}
