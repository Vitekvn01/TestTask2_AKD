using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private Button _dropButton;

    public void SetActiveDropButton()
    {
        _dropButton.gameObject.SetActive(true);
    }

    public void SetDisactiveDropButton()
    {
        _dropButton.gameObject.SetActive(false);
    }

    public Button GetDropButton()
    {
        return _dropButton;
    }
}
