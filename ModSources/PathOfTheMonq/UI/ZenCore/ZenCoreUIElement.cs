using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PathOfTheMonq.UI.ZenCore
{
    class ZenCoreUIElement : UIElement
    {
        Color color = new Color(0, 255, 255);

        public override void Draw(SpriteBatch spriteBatch)
        {   
            //assign textury
            spriteBatch.Draw((Texture2D)ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay"), new Vector2(Main.screenWidth + 2, Main.screenHeight - 20) / 2f, color);
        }
    }
}