using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameParameters
{
    public class TypeWriteConfiguration
    {
        public const char BREAK_LINE = '|';
    }

    public class AnimationCard
    {
        public const string TRIGGER_Card_To_Front = "CardToFront";
        public const string TRIGGER_Card_To_Back = "CardToBack";
    }

    public class AnimationEnemy
    {
        public const string TRIGGER_DIE = "die";
        public const string TRIGGER_ATTACK = "attack";
        public const string FLOAT_VELOCITY = "velocity";
    }

    public class AnimationPlayer
    {
        public const string FLOAT_VELOCITY = "velocity";
        public const string TRIGGER_INTERACT = "interact";
        public const string TRIGGER_IDLE = "idle";
        public const string TRIGGER_LOSE = "lose";
        public const string TRIGGER_WIN = "win";
        public const string TRIGGER_FISHING = "fishing";
    }

    public class AnimationScenario
    {
        public const string TRIGGER_AUTOMATIC_DOOR_OPEN = "AutomaticDoorOpen";
        public const string TRIGGER_AUTOMATIC_DOOR_CLOSE = "AutomaticDoorClose";
    }

    public class BundleExtension
    {
        public static readonly string[] SFX = {"mp3", "wav"};
    }

    public class BundleNames
    {
        public const string PREFAB_ACHIVEMENTS = "prefab_achivement";
        public const string PREFAB_LEVEL = "prefab_level";
        public const string SCRIT_OBJETS = "data";
        public const string SFX = "sfx";
        public const string SPRITE_ITEM = "sprite_item";
    }

    public class BundlePath
    {
        public const string RESOURCES_RANK = "Sprites/stamp_mark/";
        public const string BUNDLE_ASSETS = "Assets/BundleAssets";
        public const string STREAMING_ASSETS = "Assets/StreamingAssets";

        public const string PREFAB_ACHIVEMENTS = "/Prefabs/Achivements";
        public const string PREFAB_LEVELS = "/Prefabs/Levels";
        public const string SCRIT_OBJETS = "/Data";
        public const string SFX = "/Sounds/SFX";
        public const string SPRITES_STAMPS = "/Sprites/Stamps";
    }

    public class InputName
    {
        public const string AXIS_HORIZONTAL = "Horizontal";
        public const string AXIS_VERTICAL = "Vertical";
        public const string AXIS_MOUSE_HORIZONTAL = "Mouse X";
        public const KeyCode NEXT_TEXT = KeyCode.Space;
        public const KeyCode GAME_MENU = KeyCode.Escape;
    }

    public class PlatformName
    {
        public const string START = "Start";
        public const string END = "End";
        public const string SPOT = "Spot";
    }

    public class SceneName
    {
        public const string MAIN_MENU = "MainMenu";
        public const string LEVEL_1 = "Level1";
        public const string LEVEL_2 = "Level2";
        public const string LEVEL_3 = "Level3";
    }

    public class TagName {
        public const string PLAYER = "Player";
        public const string GROUND = "Ground";
        public const string SPOT = "Spot";
    }
}
