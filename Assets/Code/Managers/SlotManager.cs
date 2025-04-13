using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler
{
    private DraggableCountry cardInSlot;

    /// <summary>
    /// Function for accepting a card into its slot
    /// </summary>
    /// <param name="card"></param>
    public void AcceptCard(DraggableCountry card)
    {
        cardInSlot = card;
        GameManager.Instance.ShowInputField(card);
    }

    /// <summary>
    /// Function for setting the slot to null
    /// </summary>
    public void ClearSlot()
    {
        cardInSlot = null;
    }

    /// <summary>
    /// LINQ statement for checking if the slot has a card in it and returning the corresponding boolean
    /// </summary>
    /// <returns></returns>
    public bool HasCard() => cardInSlot != null;

    /// <summary>
    /// OnDrop event handler for handling an action of a card being dropped onto the slot
    /// </summary>
    /// <param name="eventData"></param>
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