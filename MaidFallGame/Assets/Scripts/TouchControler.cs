using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TouchButton touchButton;
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (touchButton)
        {
            case TouchButton.ARROW_TOP:
                this.OnArrowTop();
                break;
            case TouchButton.ARROW_DOWN:
                this.OnArrowDown();
                break;
            case TouchButton.ARROW_LEFT:
                this.OnArrowLeft();
                break;
            case TouchButton.ARROW_RIGHT:
                this.OnArrowRight();
                break;
            case TouchButton.A:
                this.OnA();
                break;
            case TouchButton.B:
                this.OnB();
                break;
            case TouchButton.F1:
                this.OnF1();
                break;
            case TouchButton.F2:
                this.OnF2();
                break;
            case TouchButton.F3:
                this.OnF3();
                break;
        }
    }

    protected virtual void OnArrowTop()
    {
        Debug.Log("arrow top");
    }

    protected virtual void OnArrowDown()
    {
        Debug.Log("arrow down");
    }

    protected virtual void OnArrowLeft()
    {
        Debug.Log("arrow left");
        GameManager.GetInstance().PlaySE(0);
    }

    protected virtual void OnArrowRight()
    {
        Debug.Log("arrow right");
        GameManager.GetInstance().PlaySE(0);
    }

    protected virtual void OnA()
    {

    }

    protected virtual void OnB()
    {

    }

    protected virtual void OnF1()
    {

    }

    protected virtual void OnF2()
    {

    }

    protected virtual void OnF3()
    {

    }
}