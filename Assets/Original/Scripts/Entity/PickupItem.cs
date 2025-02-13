using UnityEngine;

public class PickupItem : MonoBehaviour, IPickable, IPhysics
{
    private Rigidbody _rb;
    private Collider _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Pickup(Transform pickupPos)
    {
        OffPhysics();
        SetParent(pickupPos);
        gameObject.transform.position = pickupPos.position;
    }

    public void OffPhysics()
    {
        _rb.isKinematic = true;
        _collider.isTrigger = true;
    }

    public void OnPhysics()
    {
        _rb.isKinematic = false;
        _collider.isTrigger = false;
    }

    public PickupItem GetItem()
    {
        return this;
    }


    public void SetParent(Transform parent)
    {
        gameObject.transform.parent = parent;
    }

    public Rigidbody GetRigidbody()
    {
        return _rb;
    }
}
