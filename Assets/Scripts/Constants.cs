using UnityEngine;


    public static class Constants
    {
        // Scenes
        // 1 for sandbox 2 for quest;
        public static int modeID = -1;
        
        public struct SCENE
        {
            public const string VR_BASE = "VR Base";
            public const string BASE = "Base";
            public const string CHARACTER_SELECTION = "Character Selection";
            public const string TUTORIAL = "Tutorial";
            public const string ARENAPC = "ArenaPC";
            public const string LoginScene = "LoginScene";
            public const string SANDBOXSCENE = "Sandbox";
        }

        // UI
        public struct UI
        {
            public const string EQUIPMENT = "equipment";
            public const string INVENTORY = "inventory";
            public const string STATS = "stats";
            public const string MENU = "menu";
            public const string CHARACTER_SELECTION = "characterSelection";
            public const string RADIAL_MENU = "radialMenu";
        }
    }
