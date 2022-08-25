namespace _cov._Struct
{
    public struct _SName
    {
        public static string _TagCardMinion => "_CardMinion";
        public static string _TagCardGold => "_CardGold";
        public static string _TagFieldBattle => "_FieldBattle";
        public static string _TagFieldDraw => "_FieldDraw";

        public static string _SortingLayerCardMinion => "_CardMinionLayer";
        public static string _SortingLayerCardGold=> "_CardGoldLayer";
        public static string _SortingLayerFieldBattle => "_FieldBattleLayer";

        public static string _ResourceCardPatch => "Prefab/Card/";
        public static string _ResourceCardMinion => _ResourceCardPatch + "CardMinion";
        public static string _ResourceCardGold => _ResourceCardPatch + "CardGold";
        public static string _ResourceFieldPile => _ResourceCardPatch + "FieldPile";
        public static string _ResourceFieldSlot => _ResourceCardPatch + "FieldHandSlot";
    }
}
