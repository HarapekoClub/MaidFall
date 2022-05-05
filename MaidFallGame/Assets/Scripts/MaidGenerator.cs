using UnityEngine;

public class MaidGenerator : MonoBehaviour
{
    private float interval = 3.0f;
    private float sec;

    void Start()
    {
        this.sec = 6;
    }

    void Update()
    {
        this.sec += Time.deltaTime;
        if (this.sec > this.interval)
        {
            this.Generate();
            this.sec = 0;
        }
    }

    private void Generate()
    {
        // Debug.Log("GENERATE");
        Maid maid = Instantiate(Resources.Load<GameObject>("Prefabs/Maid")).GetComponent<Maid>();
        maid.gameObject.transform.parent = this.gameObject.transform;

        // 本当は乱数で決定
        System.Random random = new System.Random();
        float x = random.Next() % 11 - 5;
        Vector3 pos = new Vector3(x, 3, 0);
        maid.Generated(MaidType.NORMAL, pos);
    }
}

