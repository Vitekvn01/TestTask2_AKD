using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private Transform _itemPos;
    [SerializeField] private float _forceThrow;


    private PickupItem _currentItem;

    private IUIManager _uIManager;

    [Inject]
    private void Construct(IUIManager uIManager)
    {
        _uIManager = uIManager;
        _uIManager.GetDropButton().onClick.AddListener(DropItem);
    }

    public Transform GetPickupPos()
    {
        return _itemPos;
    }

    public void SetCurrentItem(PickupItem pickupItem)
    {
        _currentItem = pickupItem;
        _uIManager.SetActiveDropButton();
    }

    private void DropItem()
    {
        _currentItem.OnPhysics();

        _currentItem.GetRigidbody().AddForce(transform.forward * _forceThrow);
        _currentItem.GetRigidbody().AddForce(transform.up * _forceThrow/2);

        _currentItem.SetParent(null);

        _currentItem = null;

        _uIManager.SetDisactiveDropButton();
    }

    public bool CanPickupItem()
    {
        if (_currentItem == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
