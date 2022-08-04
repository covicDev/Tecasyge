using UnityEngine;

namespace _cov._CardGold
{
    public class _CardGoldManager : MonoBehaviour, _ICardGoldManager
    {
        public Camera _CameraMain => Camera.main;
    }
    public interface _ICardGoldManager
    {
        Camera _CameraMain { get; }
    }

}

