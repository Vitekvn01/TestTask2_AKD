using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Container.Bind<IPlayer>()
            .To<Player>()
            .FromInstance(_player)
            .AsSingle();
    }
}