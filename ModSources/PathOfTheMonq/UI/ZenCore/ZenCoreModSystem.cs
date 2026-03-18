using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using System.Collections.Generic;

namespace PathOfTheMonq.UI.ZenCore
{
    [Autoload(Side = ModSide.Client)] //making UI client-side so it does not make a mess in MP
    public class ZenCoreModSystem : ModSystem
    {
        internal ButtonUIState ButtonUIState; //-ElementButton1- stands for -MenuBar- in Tmod wiki
        private UserInterface _ButtonUIState;

        public override void Load()
        {
            ButtonUIState = new ButtonUIState();
            ButtonUIState.Activate();

            _ButtonUIState = new UserInterface();
            _ButtonUIState.SetState(ButtonUIState);
        }


        //do not touch code below, nobody does not know why it does not work without it, even on wiki they say it
        public override void UpdateUI(GameTime gameTime)
        {
            _ButtonUIState?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "PathOfTheMonq: A very cool description",
                    delegate
                    {
                        _ButtonUIState.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}