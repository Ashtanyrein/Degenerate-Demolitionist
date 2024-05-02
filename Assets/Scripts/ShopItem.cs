using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Destructible2D.Examples;

public class ShopItemDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject icon;
    public GameObject PurchaseItem;
    public Transform BombParentObject;
    public float ItemScale = 0.5f;
    public GameObject PriceCounter;
        
    private TMPro.TextMeshProUGUI priceCounterNumber;
    private GameManager gameManager;
    private int PurchaseItemPrice;
    private GameObject currentDraggedItem;
    private GameObject instancedItem;
    private Vector3 startPosition;
    private Camera mainCamera;
    private bomb bombScript;

    private void Start()
    {
        mainCamera = Camera.main;
        bombScript = PurchaseItem.GetComponent<bomb>();
        PurchaseItemPrice = bombScript.price;
        priceCounterNumber = PriceCounter.GetComponent<TMPro.TextMeshProUGUI>();
        priceCounterNumber.text = PurchaseItemPrice.ToString();
        gameManager = GetComponentInParent<GameManager>();
        // Get the sprite from the PurchaseItem
        SpriteRenderer spriteRenderer = PurchaseItem.GetComponent<SpriteRenderer>();
        
        if (spriteRenderer != null)
        {
            // Set the image displayed on the icon to the sprite from the PurchaseItem
            Image image = icon.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = spriteRenderer.sprite;
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;

        // Create a new instance of the prefab
        instancedItem = Instantiate(PurchaseItem, GetMouseWorldPosition(), Quaternion.identity);
        instancedItem.transform.localScale = Vector3.one * ItemScale;

        // Get the sprite from the PurchaseItem
        SpriteRenderer spriteRenderer = PurchaseItem.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Set the image displayed on the icon to the sprite from the PurchaseItem
            Image image = icon.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = spriteRenderer.sprite;
            }
        }

        // Set the dragged item to the new instance
        currentDraggedItem = instancedItem;

        // Set the parent of the dragged item to a different game object in the scene
        currentDraggedItem.transform.SetParent(BombParentObject, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentDraggedItem != null)
        {
            currentDraggedItem.transform.position = GetMouseWorldPosition();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentDraggedItem != null)
        {
            if (CanPurchaseItem() && IsOverStructure())
            {
                // Perform the purchase logic here
                Debug.Log("Item purchased: " + PurchaseItem.name + " for $" + PurchaseItemPrice);
                gameManager.budget -= PurchaseItemPrice;
                gameManager.SetItemPurchased(true); // Set the item purchased flag to true
                currentDraggedItem.transform.SetParent(BombParentObject, false);
            }
            else
            {
                // Return the item to its original position if the purchase is not made
                currentDraggedItem.transform.position = startPosition;
                Destroy(currentDraggedItem);
            }
        }
    }

    private bool IsOverStructure()
    {
        // Perform a raycast from the current dragged item position downwards
        return true;
        RaycastHit2D hit = Physics2D.Raycast(currentDraggedItem.transform.position, Vector2.zero);
        
        if (hit.collider != null)
        {
            // Check if the hit object has the tag "structure"
            if (hit.collider.CompareTag("structure"))
            {
                return true;
            }
        }
        return false;
    }

    private bool CanPurchaseItem()
    {
        if(PurchaseItemPrice <= gameManager.budget)
            return true;
        else
            return false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // Adjust the Z value based on your camera's near clip plane
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}