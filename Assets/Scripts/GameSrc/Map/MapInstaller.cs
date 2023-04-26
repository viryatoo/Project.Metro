using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using MapEditor;
using GameAssets;

namespace Game
{
    public class MapInstaller : IInstaller
    {
        private GameMapImportSettings importSettings;
        public MapInstaller(GameMapImportSettings settings)
        {
            importSettings = settings;
        }
        public void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(importSettings);
            builder.RegisterInstance(importSettings.mapEditorContentProvider);
            builder.Register<ContentLoader>(Lifetime.Singleton);
            builder.Register<BlockFactory>(Lifetime.Singleton);
            builder.Register<GameMapImporter>(Lifetime.Singleton);
        }
    }
}
