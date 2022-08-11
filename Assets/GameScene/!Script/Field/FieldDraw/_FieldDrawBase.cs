using UnityEngine;

using _cov._Struct;

namespace _cov._FieldDraw
{
    public class _FieldDrawBase : MonoBehaviour, _IFieldDrawBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;

        public _IFieldDrawBackgroundModerator _FieldDrawBackgroundModerator => this.transform.GetComponent<_FieldDrawBackgroundModerator>();
        public _IFieldDrawPileModerator _FieldDrawPileModerator => this.transform.GetComponent<_FieldDrawPileModerator>();

        public GameObject _FieldPilePrefab => Resources.Load(_SName._ResourceFieldPile, typeof(GameObject)) as GameObject;
        public GameObject _CardMinionPrefab => Resources.Load(_SName._ResourceCardMinion, typeof(GameObject)) as GameObject;
        public GameObject _CardGoldPrefab => Resources.Load(_SName._ResourceCardGold, typeof(GameObject)) as GameObject;

    }
    public interface _IFieldDrawBase
    {
        Transform _GameManager { get; }

        _IFieldDrawBackgroundModerator _FieldDrawBackgroundModerator { get; }
        _IFieldDrawPileModerator _FieldDrawPileModerator { get; }

        GameObject _FieldPilePrefab { get; }
        GameObject _CardMinionPrefab { get; }
        GameObject _CardGoldPrefab { get; }
    }
}
