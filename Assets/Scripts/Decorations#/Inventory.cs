using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public InventorySlot[] slots;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(Sprite itemSprite)
    {
        if (slots == null || slots.Length == 0)
        {
            Debug.LogError("Slots array is empty!");
            return;
        }

        slots[0].SetItem(itemSprite);

        Debug.Log("Key added to slot 1");
    }
}