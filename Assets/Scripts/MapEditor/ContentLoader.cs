using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace MapEditor
{
    public class ContentLoader
    {
        private IObjectResolver container;
        private LifetimeScope scope;
        private MapEditorContentProvider contentProvider;

        public BlockFactory GameBlockFactory { get; private set; }
        public ContentLoader(LifetimeScope curentScope, IObjectResolver cont, MapEditorContentProvider provider, BlockFactory Bf)
        {
            scope = curentScope;
            container = cont;
            contentProvider = provider;
            GameBlockFactory = Bf;
        }

        public UiEditor LoadUI()
        {
            UiEditor ui = UnityEngine.Object.Instantiate(contentProvider.uiEditor);
            container.InjectGameObject(ui.gameObject);
            //var instantScope = scope.CreateChild(builder => { builder.RegisterComponent(ui); });
            //return instantScope.Container;
            return ui;
        }
        public MapBorderView LoadBorder()
        {
            return container.Instantiate(contentProvider.borderView);
        }
    }
}
