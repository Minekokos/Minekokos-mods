using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using PathOfTheMonq.Systems;

namespace PathOfTheMonq.UI
{
	public class ZenElementIcon : UIElement
	{
		private readonly Texture2D texture;
		private readonly Texture2D hoverTexture;
		private readonly string element;

		public ZenElementIcon(string element)
		{
			this.element = element;
			texture = ModContent.Request<Texture2D>($"PathOfTheMonq/Textures/UI/Elements/{element.ToLower()}").Value;
			hoverTexture = ModContent.Request<Texture2D>($"PathOfTheMonq/Textures/UI/Elements/{element.ToLower()}_outline").Value;

			Width.Set(texture.Width, 0f);
			Height.Set(texture.Height, 0f);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			Vector2 pos = GetDimensions().Position();
			spriteBatch.Draw(IsMouseHovering ? hoverTexture : texture, pos, Color.White);
		}
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsMouseHovering && Main.mouseRight && Main.mouseRightRelease)
            {
                Main.NewText($"Element selected: {element}", Color.Lime);
                ZenMenuSystem.Hide();
            }
        }


        public override void RightClick(UIMouseEvent evt)
        {
            base.RightClick(evt);
            Main.NewText($"Element selected: {element}", Color.Lime);
            ZenMenuSystem.Hide();
        }

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			Main.hoverItemName = element;
		}
	}
}
