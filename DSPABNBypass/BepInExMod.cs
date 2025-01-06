using ABN;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DSPABNBypass
{
    [BepInPlugin(GUID, Name, Ver)]
    public class DSPABNBypass : BaseUnityPlugin
    {
        const string GUID = "DSPABNBypass";
        const string Name = "DSPABNBypass";
        const string Ver = "1.0.0.0";
        static ManualLogSource StaticLogger;

        [HarmonyPatch(typeof(AbnormalityLogic), nameof(AbnormalityLogic.InitDeterminators))]
        public class AbnormalityLogic_InitDeterminators_Patch
        {
            static bool first = true;
            public static bool Prefix()
            {
                if (first)
                {
                    StaticLogger.LogInfo("<AbnormalityLogic.InitDeterminators> return");
                    first = false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(GameAbnormalityData_0925), nameof(GameAbnormalityData_0925.NothingAbnormal))]
        public class GameAbnormalityData_0925_NothingAbnormal_Patch
        {
            static bool first = true;
            public static bool Prefix(ref bool __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<GameAbnormalityData_0925.NothingAbnormal> return true");
                    first = false;
                }
                __result = true;
                return true;
            }
        }

        [HarmonyPatch(typeof(GameAbnormalityData_0925), nameof(GameAbnormalityData_0925.IsAbnormalTriggerred))]
        public class GameAbnormalityData_0925_IsAbnormalTriggerred_Patch
        {
            static bool first = true;
            public static bool Prefix(ref bool __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<GameAbnormalityData_0925.IsAbnormalTriggerred> return false");
                    first = false;
                }
                __result = false;
                return true;
            }
        }

        [HarmonyPatch(typeof(GameAbnormalityData_0925), nameof(GameAbnormalityData_0925.GetAbnormalityTime))]
        public class GameAbnormalityData_0925_GetAbnormalityTime_Patch
        {
            static bool first = true;
            public static bool Prefix(ref long __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<GameAbnormalityData_0925.GetAbnormalityTime> return 0");
                    first = false;
                }
                __result = 0;
                return true;
            }
        }

        [HarmonyPatch(typeof(GameAbnormalityData_0925), nameof(GameAbnormalityData_0925.GetAbnormalityEvidences))]
        public class GameAbnormalityData_0925_GetAbnormalityEvidences_Patch
        {
            static bool first = true;
            public static bool Prefix(ref long[] __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<GameAbnormalityData_0925.GetAbnormalityEvidences> return null");
                    first = false;
                }
                __result = null;
                return true;
            }
        }

        [HarmonyPatch(typeof(GameAbnormalityData_0925), nameof(GameAbnormalityData_0925.GetAbnormalityDetail))]
        public class GameAbnormalityData_0925_GetAbnormalityDetail_Patch
        {
            static bool first = true;
            public static bool Prefix(ref string __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<GameAbnormalityData_0925.GetAbnormalityDetail> return \"\"");
                    first = false;
                }
                __result = "";
                return true;
            }
        }

        [HarmonyPatch(typeof(GameAbnormalityData_0925), nameof(GameAbnormalityData_0925.GetNearestCheckedAbnormality))]
        public class GameAbnormalityData_0925_GetNearestCheckedAbnormality_Patch
        {
            static bool first = true;
            public static bool Prefix(ref int __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<GameAbnormalityData_0925.GetNearestCheckedAbnormality> return 0");
                    first = false;
                }
                __result = 0;
                return true;
            }
        }

        [HarmonyPatch(typeof(AbnormalityDeterminator), "OnInit")]
        public class AbnormalityDeterminator_OnInit_Patch
        {
            static bool first = true;
            public static bool Prefix(ref bool __result)
            {
                if (first)
                {
                    StaticLogger.LogInfo("<AbnormalityDeterminator.OnInit> return false");
                    first = false;
                }
                __result = false;
                return true;
            }
        }

        internal void Start()
        {
            StaticLogger = Logger;
            StaticLogger.LogInfo($"{Name}@{Ver} started!");
            new Harmony(GUID).PatchAll();
        }
    }
}
