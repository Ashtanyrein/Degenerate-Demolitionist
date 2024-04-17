// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class ShopItemDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public GameObject GameObjectToDisplaySpriteOn;
//     public Sprite SpriteToDisplayOnGameObject;
//     public GameObject PurchaseItem;
//     public float PurchaseItemPrice;
//     public Transform PurchasedItemsContainer;
//     public float ItemScale = 1f;

//     private GameObject currentDraggedItem;
//     private Vector3 startPosition;
//     private Camera mainCamera;

//     private void Start()
//     {
//         mainCamera = Camera.main;
//     }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         startPosition = transform.position;
//         currentDraggedItem = Instantiate(PurchaseItem, GetMouseWorldPosition(), Quaternion.identity);
//         currentDraggedItem.transform.localScale = Vector3.one * ItemScale;
//         currentDraggedItem.GetComponent<Image>().sprite = SpriteToDisplayOnGameObject;
//         currentDraggedItem.transform.SetParent(GameObjectToDisplaySpriteOn.transform, false);
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         if (currentDraggedItem != null)
//         {
//             currentDraggedItem.transform.position = GetMouseWorldPosition();
//         }
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         if (currentDraggedItem != null)
//         {
//             if (CanPurchaseItem())
//             {
//                 // Perform the purchase logic here
//                 Debug.Log("Item purchased: " + PurchaseItem.name);
//                 currentDraggedItem.transform.SetParent(PurchasedItemsContainer, false);
//             }
//             else
//             {
//                 // Return the item to its original position if the purchase is not made
//                 currentDraggedItem.transform.position = startPosition;
//                 Destroy(currentDraggedItem);
//             }
//         }
//     }

//     private bool CanPurchaseItem()
//     {
//         // Implement your purchase condition logic here
//         // For example, check if the player has enough currency or meets other requirements
//         // Return true if the purchase can be made, false otherwise
//         return true;
//     }

//     private Vector3 GetMouseWorldPosition()
//     {
//         Vector3 mousePos = Input.mousePosition;
//         mousePos.z = 10f; // Adjust the Z value based on your camera's near clip plane
//         return mainCamera.ScreenToWorldPoint(mousePos);
//     }
// }