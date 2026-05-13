using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public void SetItem(Sprite itemSprite)
    {
        icon.sprite = itemSprite;
        icon.color = Color.white;
    }
}