using _Scripts.Base;

namespace _Scripts.Services
{
    public interface IMapService
    {
        void LoadMap(int level);
        void UnloadMap();
    }

    public interface IUIService
    {
        void ShowView();
        UIBaseView GetView();
        void HideView();
    }
}

