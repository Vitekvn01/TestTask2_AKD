using UnityEngine.UI;

public interface IUIManager
{
    public void SetActiveDropButton();

    public void SetDisactiveDropButton();

    public Button GetDropButton();
}
