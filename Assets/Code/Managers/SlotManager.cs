using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler
{
    private DraggableCountry cardInSlot;

    public void AcceptCard(DraggableCountry card)
    {
        cardInSlot = card;
        GameManager.Instance.ShowInputField(card);
    }

    public void ClearSlot()
    {
        cardInSlot = null;
    }

    public bool HasCard() => cardInSlot != null;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObj = eventData.pointerDrag;

        if (droppedObj != null)
        {
            droppedObj.transform.SetParent(transform, false);
            droppedObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            AcceptCard(droppedObj.GetComponent<DraggableCountry>());
        }
    }
}