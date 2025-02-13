using UnityEngine;
using Zenject;

public class PickupLogic : MonoBehaviour
{
    [SerializeField] private float _interactionDistance;

    private IInputController _inputController;
    private IPlayer _player;

    [Inject]
    private void Construct(IInputController inputController, IPlayer player)
    {
        _inputController = inputController;
        _inputController.OnTouchEvent += HandleTouchPickupItem;
        _player = player;
    }

    private void HandleTouchPickupItem(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out IPickable pickable))
            {
                float distanceToPlayer = Vector3.Distance(gameObject.transform.position, transform.position);

                if (distanceToPlayer <= _interactionDistance)
                {
                    if (_player.CanPickupItem())
                    {
                        pickable.Pickup(_player.GetPickupPos());
                        _player.SetCurrentItem(pickable.GetItem());
                    }
                }
                else
                {
                    Debug.Log("Слишком далеко, чтобы поднять предмет");
                }
            }
        }
    }

}
