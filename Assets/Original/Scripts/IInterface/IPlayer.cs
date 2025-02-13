using UnityEngine;

public interface IPlayer
{
    public Transform GetPickupPos();

    public void SetCurrentItem(PickupItem pickupItem);

    public bool CanPickupItem();


}
