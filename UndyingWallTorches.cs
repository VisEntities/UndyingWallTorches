/*
 * Copyright (C) 2024 Game4Freak.io
 * This mod is provided under the Game4Freak EULA.
 * Full legal terms can be found at https://game4freak.io/eula/
 */

using HarmonyLib;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
    [Info("Undying Wall Torches", "VisEntities", "1.0.0")]
    [Description("Removes durability loss from wall torches.")]
    public class UndyingWallTorches : RustPlugin
    {
        #region Fields

        private static UndyingWallTorches _plugin;

        #endregion Fields

        #region Oxide Hooks

        private void Init()
        {
            _plugin = this;
        }

        private void Unload()
        {
            _plugin = null;
        }

        #endregion Oxide Hooks

        #region Harmony Patches

        [AutoPatch]
        [HarmonyPatch(typeof(TorchDeployableLightSource), "TickTorchDurability")]
        public static class TorchDeployableLightSource_TickTorchDurability_Patch
        {
            public static bool Prefix(TorchDeployableLightSource __instance)
            {
                return false;
            }
        }

        #endregion Harmony Patches
    }
}