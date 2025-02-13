using UnityEngine;
using Zenject;

public class InputControllerInstaller : MonoInstaller
{
    [SerializeField] private MobileInputController _inputController;
/*    [SerializeField] private DeckstopInputController _inputController;*/
    public override void InstallBindings()
    {
        Container.Bind<IInputController>()
            .FromInstance(_inputController)
            .AsSingle();
    }
}