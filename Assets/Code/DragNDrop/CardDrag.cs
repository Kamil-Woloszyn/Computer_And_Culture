using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Variables
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;

    void Awake()
    {
        //Getting the components on this gameobject
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        originalPosition = rectTransform.anchoredPosition;
        originalParent = rectTransform.parent;
    }

    /// <summary>
    /// Function for starting the drag event on this gameobject
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; // Optional: semi-transparent while dragging
    }

    /// <summary>
    /// Function for detecting dragging happening and adjusting the position of the rect transform accordingly
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor * 2;
    }

    /// <summary>
    /// Function for finishing dragging of the gameobject
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

       
        if (transform.parent == originalParent)
        {
            rectTransform.anchoredPosition = originalPosition;
            Debug.Log("Snapback - card not dropped in a valid slot.");
        }
    }
}