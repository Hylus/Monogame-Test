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
    public class InteractiveItem
    {
        private Rectangle _selectedTextureRect;
        private Rectangle _rect;
        private Texture2D _texture;
        private Vector2 _offsetPos = new Vector2(200,15);
        private Vector2 _dim = new Vector2(60, 60);

        Vector2 origin;

        public float Rotation = 0f;

        public InteractiveItem(ContentManager content, int x, int y)
        {         
            LoadContent(content);
            SetRectPosition(x, y);
        }

        private void SetRectPosition(int x, int y)
        {
            _rect = new Rectangle( (int)(_offsetPos.X + x * _dim.X), (int) (_offsetPos.Y + y * _dim.Y), (int)_dim.X, (int)_dim.Y);
            _selectedTextureRect = new Rectangle(0, 0, 100, 100);
        }

        private void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("question");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,_rect, _selectedTextureRect, Color.White);
            //  spriteBatch.Draw(_texture, _rect, _selectedTextureRect, Color.White, Rotation, origin, SpriteEffects.None, 0f);

        }

        public void Update(Rectangle cursor, CurrentSelectedImage image)
        {
            if (_rect.Intersects(cursor)) //mouse collision
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (_texture == image.Texture && _selectedTextureRect == image.SelectedTextureRect)
                    {
                        Rotation += 45;
                    }
                    else
                    {
                        _texture = image.Texture;
                        _selectedTextureRect = image.SelectedTextureRect;
                        Rotation = 0;
                        origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);
                    }
                }
            }
        }
    }
}
