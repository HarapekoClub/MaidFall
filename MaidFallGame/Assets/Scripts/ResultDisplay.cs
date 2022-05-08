using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject toHome;

    void Start()
    {
        if (this.gameObject.activeSelf)
        {
            GamePlayManager.GetInstance().SetResult(this);
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.GetInstance().JumpScene("HomeScene");
        }
    }

    public void GameFinish(List<string> newPhotos, Dictionary<string, int> photoCount)
    {
        EventSystem.current.SetSelectedGameObject(toHome);
        string text = "<align=center><color=red>RESULT\n</color></align>";
        text = "<align=center><color=red>RESULT\n</color></align>";
        //text += "hoge";
        if (photoCount["NORMAL_HEART_HEART"] > 0)
        {
            text += "MAID : " + photoCount["NORMAL_HEART_HEART"] + "\n";
        }
        if (photoCount["CHINA_HEART_HEART"] > 0)
        {
            text += "CHINA : " + photoCount["CHINA_HEART_HEART"] + "\n";
        }
        if (photoCount["SCHOOL_HEART_HEART"] > 0)
        {
            text += "SEIFUKU : " + photoCount["SCHOOL_HEART_HEART"] + "\n";
        }
        if (photoCount["WATER_HEART_HEART"] > 0)
        {
            text += "MIZUGI : " + photoCount["WATER_HEART_HEART"] + "\n";
        }
        if (photoCount["OTAKU_HEART_HEART"] > 0)
        {
            text += "OTAKU : " + photoCount["OTAKU_HEART_HEART"] + "\n";
        }

        this.scoreText.text = text;
        // TODO 新規獲得写真を表示する処理を書く
        if (newPhotos.Count == 0)
        {
            return;
        }
        this.photoFrame.SetActive(true);
        Image img;
        Vector2 wh = this.photoFrame.GetComponent<RectTransform>().sizeDelta;
        Vector3 pos = this.photoFrame.transform.position;
        float posx = pos.x;
        foreach (string name in newPhotos)
        {
            wh.x += 75;
            pos.x = pos.x + 0.75f;
            img = Instantiate(Resources.Load<GameObject>("Prefabs/ResultPhoto")).GetComponent<Image>();
            img.gameObject.transform.SetParent(this.photoFrame.transform);
            img.gameObject.transform.localScale = new Vector3(1, 1, 1);
            img.sprite = Resources.Load<Sprite>("Sprites/Photos/" + name);
            this.photoFrame.GetComponent<RectTransform>().sizeDelta = wh;
            this.photoFrame.transform.position = pos;
        }

    }
}