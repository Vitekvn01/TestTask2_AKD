using UnityEngine;

public interface IPickable
{
    public void Pickup(Transform pickupPos);

    public PickupItem GetItem();
}
