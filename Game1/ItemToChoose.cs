using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace test1
{
    public class ItemToChoose
    {
        private Rectangle _rectChunk;
        private Rectangle _rect;
        private Vector2 _offsetPos = new Vector2(50, 100);
        Texture2D _texture;

        Color color = Color.White;

        public ItemToChoose( int x, int y, int width, int height, Texture2D texture)
        {
            _texture = texture;
            SetChunk(x, y, width, height);                        
        }

        private void SetChunk(int x, int y, int width, int height)
        {
            _rectChunk = new Rectangle(
                 x * width,
                 y * height,
                width,
                height);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, float width, float height, int i)
        {
            _rect = new Rectangle(
                (int)(_offsetPos.X),
                (int)(_offsetPos.Y + i*height)+ 30,
                (int) width,
                (int) height);

            spriteBatch.Draw(texture, _rect, _rectChunk, color);
        }

        public void Update(Rectangle cursor, CurrentSelectedImage image)
        {
            if (_rect.Intersects(cursor)) // mouse collision
            {
                color = Color.Yellow;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    image.SelectedTextureRect = _rectChunk;
                    image.Texture = _texture;
                }
            }
            else
            {
                color = Color.White;
            }
        }

    }
}
