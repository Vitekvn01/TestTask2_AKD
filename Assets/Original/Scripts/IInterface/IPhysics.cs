using UnityEngine;

public interface IPhysics
{
   public Rigidbody GetRigidbody();

   public void OnPhysics();

   public void OffPhysics();

   public void SetParent(Transform parent);
}
