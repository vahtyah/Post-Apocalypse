using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseUISlotDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI nameOfItem;
    [SerializeField] private TextMeshProUGUI descriptionOfItem;
    [SerializeField] private UIInventoryManager uiInventory;
    private UISlot uiSlotBegin;
    private GameObject dragInstance;
    private Image dragImage;

    private void Start()
    {
        dragInstance = new GameObject("DragInstance");
        dragImage = dragInstance.AddComponent<Image>();
        dragImage.raycastTarget = false;
        dragInstance.transform.SetParent(transform);
        dragImage.transform.localScale = Vector3.one;
        dragInstance.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject is not { } targetObj) return;
        var targetSlot = targetObj.GetComponent<UISlot>();
        if (targetSlot == null || targetSlot.Item == null) return;
        uiSlotBegin = targetSlot;
        dragInstance.SetActive(true);
        dragImage.sprite = uiSlotBegin.Item.Icon;
        uiSlotBegin.ClearImage();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (uiSlotBegin != null && uiSlotBegin.Item != null && dragInstance.activeSelf)
        {
            dragInstance.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (uiSlotBegin == null) return;
        if (eventData.pointerCurrentRaycast.gameObject is { } targetObj)
        {
            var targetSlot = targetObj.GetComponent<UISlot>();
            if (targetSlot != null && targetSlot != uiSlotBegin)
                uiSlotBegin.SwapItem(targetSlot);
        }
        uiSlotBegin.UpdateUI();
        dragInstance.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject is not { } targetObj) return;
        var targetSlot = targetObj.GetComponent<UISlot>();
        if(targetSlot == null || targetSlot.Item == null) return;
        SetTextSlotSelected(targetSlot.Item.Name, targetSlot.Item.Description);
        uiInventory.SlotSelected = targetSlot;
    }

    public void SetTextSlotSelected(string nameString, string descriptionString)
    {
        nameOfItem.SetText(nameString);
        descriptionOfItem.SetText(descriptionString);
    }
}