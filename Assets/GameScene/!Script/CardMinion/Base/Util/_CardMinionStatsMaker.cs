using UnityEngine;

namespace _cov._CardMinion._CardMinionMaker
{
    public class _CardMinionStatsMaker : MonoBehaviour, _ICardMinionStatsMaker
    {
        private Sprite[] _spritesOfMinons => GameObject.Find("GameManager").GetComponentInChildren<_Table._TableSpriteMinion>()._SpritesOfMinons;

        /// <summary>
        /// Method makes minion.
        /// </summary>
        /// <param name="tierLever">Level of minion</param>
        /// <returns>_SCardMinionStruct with all stats.</returns>
        public _SCardMinionStruct _MakeMinion(int tierLever)
        {
            switch (tierLever)
            {
                case 1:
                    return this._getMinionStats_Lvl_1();
                case 2:
                    return this._getMinionStats_Lvl_1();
                case 3:
                    return this._getMinionStats_Lvl_1();
                default:
                    throw new System.Exception("Wrong tierLevel");
            }
        }
        private _SCardMinionStruct _getMinionStats_Lvl_1()
        {
            //_SCardMinionStruct tmpStruct = new _SCardMinionStruct();

            int[] val = new int[4];

            int gold = Random.Range(1, 4);

            int length = 6;
            int ticket = Random.Range(0, length);

            switch (ticket)
            {
                case 0:
                    val = new int[] { 3, 0, 1, gold };
                    break;
                case 1:
                    val = new int[] { 2, 1, 1, gold };
                    break;
                case 2:
                    val = new int[] { 2, 0, 2, gold };
                    break;
                case 3:
                    val = new int[] { 1, 2, 1, gold };
                    break;
                case 4:
                    val = new int[] { 1, 1, 2, gold };
                    break;
                case 5:
                    val = new int[] { 1, 0, 4, gold };
                    break;
                default:
                    Debug.Log("Error! _getMinionStats_Lvl_1() ");
                    break;
            }

            int randSprite = UnityEngine.Random.Range(0, this._spritesOfMinons.Length);

            return new _SCardMinionStruct() { _Image = this._spritesOfMinons[randSprite], _Attack = val[0], _Armor = val[1], _Life = val[2], _Gold = val[3] };
        }

        /*
        private _MinonStatsStruct _getMinionStats_Lvl_2()
        {
            _MinonStatsStruct tmp = new _MinonStatsStruct() { _Attack = 1, _Gold = 0 };

            int[] val = new int[4];

            int gold = 2;

            // 4 0 2
            // 3 1 2
            // 3 0 3
            // 2 2 2
            // 2 1 3
            // 2 0 4 -1
            // 1 3 2 
            // 1 2 3 
            // 1 1 4 -1
            // 1 0 5 -1

            int length = 10;
            int ticket = UnityEngine.Random.Range(0, length);

            switch (ticket)
            {
                // 4 0 2
                case 0:
                    val = new int[] { 4, 0, 2, gold };
                    break;

                // 3 1 2
                case 1:
                    val = new int[] { 3, 1, 2, gold };
                    break;

                // 3 0 3
                case 2:
                    val = new int[] { 3, 0, 3, gold };
                    break;

                // 2 2 2
                case 3:
                    val = new int[] { 2, 2, 2, gold };
                    break;

                // 2 1 3
                case 4:
                    val = new int[] { 2, 1, 3, gold };
                    break;

                // 2 0 4
                case 5:
                    val = new int[] { 2, 0, 4, gold };
                    break;

                // 1 3 2
                case 6:
                    val = new int[] { 1, 3, 2, gold };
                    break;

                // 1 2 3
                case 7:
                    val = new int[] { 1, 2, 3, gold };
                    break;

                // 1 1 4
                case 8:
                    val = new int[] { 1, 1, 4, gold };
                    break;

                // 1 0 5
                case 9:
                    val = new int[] { 1, 0, 5, gold };
                    break;

                default:
                    Debug.Log("Error! _getMinionStats_Lvl_1() ");
                    break;
            }

            int randSprite = UnityEngine.Random.Range(0, this._SpritesOfMinons.Length);

            return new _MinonStatsStruct() { _Portrait = this._SpritesOfMinons[randSprite], _Attack = val[0], _Armor = val[1], _Life = val[2], _Gold = val[3] };
        }
        private _MinonStatsStruct _getMinionStats_Lvl_3()
        {
            _MinonStatsStruct tmp = new _MinonStatsStruct() { _Attack = 1, _Gold = 0 };

            // int[,] val = new int[4];
            int[,] val = new int[,]
            {
        // 5 0 3
        { 5, 0, 3 },
        // 4 1 3
        { 4, 1, 3 },
        // 4 2 2
        { 4, 2, 2 },
        // 4 1 3
        { 4, 1, 3 },
        // 4 0 4
        { 4, 0, 4 },
        // 3 2 3
        { 3, 2, 3 },
        // 3 1 4
        { 3, 1, 4 },
        // 3 0 5
        { 3, 0, 5 },
        // 2 3 3
        { 2, 3, 3 },
        // 2 2 4
        { 2, 2, 4 },
        // 2 1 5
        { 2, 1, 5 },
        // 1 4 3
        { 1, 4, 3 },
        // 1 3 4
        { 1, 3, 4 },
        // 1 2 5
        { 1, 2, 5 },
        // 1 1 6
        { 1, 1, 6 },
        // 1 0 7
        { 1, 0, 7 }
            };


            int gold = 3;

            // t a l - 15
            // 5 0 3
            // 4 1 3
            // 4 2 2
            // 4 1 3
            // 4 0 4
            // 3 2 3
            // 3 1 4
            // 3 0 5
            // 2 3 3
            // 2 2 4
            // 2 1 5
            // 1 4 3
            // 1 3 4
            // 1 2 5
            // 1 1 6
            // 1 0 7

            int length = val.GetLength(0);
            int i = UnityEngine.Random.Range(0, length);

            int randSprite = UnityEngine.Random.Range(0, this._SpritesOfMinons.Length);

            return new _MinonStatsStruct() { _Portrait = this._SpritesOfMinons[randSprite], _Attack = val[i, 0], _Armor = val[i, 1], _Life = val[i, 2], _Gold = gold };
        }
        */

    }
    public interface _ICardMinionStatsMaker
    {
        _SCardMinionStruct _MakeMinion(int tierLever);
    }
}
