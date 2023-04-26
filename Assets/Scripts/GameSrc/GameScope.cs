using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using UnityEngine;
using GameAssets;
using MapEditor;

namespace Game
{
    public class GameScope: LifetimeScope
    {
        [SerializeField] private GameMapImportSettings gameMapImportSettings;
        protected override void Configure(IContainerBuilder builder)
        {
            IInstaller mapInstaller = new MapInstaller(gameMapImportSettings);

            builder.Register<ISaveSevice, JsonSL>(Lifetime.Singleton);
            mapInstaller.Install(builder);
            builder.Register<CameraMovement>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GameLoop>();
        }
    }
}
