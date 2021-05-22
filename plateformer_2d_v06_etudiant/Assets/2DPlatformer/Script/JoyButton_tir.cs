using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton_tir : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool TirPressed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        TirPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TirPressed = false;
    }
}
