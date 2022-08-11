using UnityEngine;

namespace _cov._FieldPile
{
    public class _FieldPileManager : MonoBehaviour
    {

        #region --- Public method ---
        public bool _PrepareFieldPile()
        {
            // -17 -2;
            var tmp = new Vector3(this.transform.position.x - 170, this.transform.position.y, this.transform.position.z);

            return true;
        }
        #endregion
    }
}
