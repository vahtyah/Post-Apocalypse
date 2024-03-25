using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class ItemSlotCellDrawer<TArray> : TwoDimensionalArrayDrawer<TArray, ItemSlot> where TArray : IList
{
    protected override TableMatrixAttribute GetDefaultTableMatrixAttributeSettings()
    {
        return new TableMatrixAttribute()
        {
            SquareCells = true,
            HideColumnIndices = true,
            HideRowIndices = true,
            ResizableColumns = false
        };
    }

    protected override ItemSlot DrawElement(Rect rect, ItemSlot value)
    {
        var id = DragAndDropUtilities.GetDragAndDropId(rect);
        DragAndDropUtilities.DrawDropZone(rect, value.Item ? value.Item.Icon : null, null, id);

        if (value.Item != null)
        {
            var countRect = rect.Padding(2).AlignBottom(16);
            value.ItemCount = EditorGUI.IntField(countRect, Mathf.Max(1, value.ItemCount));
            GUI.Label(countRect, "/ " + value.Item.ItemStackSize, SirenixGUIStyles.RightAlignedGreyMiniLabel);
        }

        value = DragAndDropUtilities.DropZone(rect, value);
        value.Item = DragAndDropUtilities.DropZone<Item>(rect, value.Item);
        value = DragAndDropUtilities.DragZone(rect, value, true, true);
        return value;
    }
    
    protected override void DrawPropertyLayout(GUIContent label)
    {
        base.DrawPropertyLayout(label);

        var rect = GUILayoutUtility.GetRect(0, 40).Padding(2);
        var id = DragAndDropUtilities.GetDragAndDropId(rect);
        DragAndDropUtilities.DrawDropZone(rect, null as UnityEngine.Object, null, id);
        DragAndDropUtilities.DropZone<ItemSlot>(rect, new ItemSlot(), false, id);
    }
}
#endif