using UnityEngine;
using Zenject;

public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] private UIManager _UIManager;

    public override void InstallBindings()
    {
        Container.Bind<IUIManager>()
            .To<UIManager>()
            .FromInstance(_UIManager)
            .AsSingle();
    }
}