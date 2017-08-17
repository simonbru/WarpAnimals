using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace YourProjectName {
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper) {
            ControlEvents.KeyPressed += this.ControlEvents_KeyPress;
        }

        /*********
        ** Private methods
        *********/
        /// <summary>The method invoked when the player presses a keyboard button.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void ControlEvents_KeyPress(object sender, EventArgsKeyPressed e) {
            
            if (Context.IsWorldReady) { // save is loaded
                if (e.KeyPressed == Keys.K) {
                    warpAllAnimalsHome();
                }

            }
        }

        private void warpAllAnimalsHome() {
            Farm farm = Game1.getFarm();
            var animalsOutside = new List<FarmAnimal>(farm.animals.Values);
            this.Monitor.Log($"Warp {animalsOutside.Count} animals home.");
            animalsOutside.ForEach(animal => {
                animal.warpHome(farm, animal);
            });
        }
    }
}
