using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace MapEditor
{
    //пока что нигде не используется.
    public class ContentLoader
    {
        IObjectResolver container;
        MapEditorContentProvider contentProvider;
        public ContentLoader(IObjectResolver diContainer,MapEditorContentProvider provider)
        {
            container = diContainer;
            contentProvider = provider;
        }

        public void LoadUI()
        {
            UiEditor ui = container.Instantiate(contentProvider.uiEditor);
        }
    }
}
