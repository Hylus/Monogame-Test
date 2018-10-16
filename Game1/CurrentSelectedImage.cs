using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using test1;

namespace Game1
{
    public class CurrentSelectedImage
    {
        private ContentManager _content;
        private Rectangle _rect;
        private Rectangle _selectedTextureChunk;

        private Texture2D _texture;
        private Texture2D _tmpTexture;

        Color color = Color.White;

        public Rectangle SelectedTextureRect { get => _selectedTextureChunk; set => _selectedTextureChunk = value; }
        public Texture2D Texture { get => _texture; set => _texture = value; }

        public CurrentSelectedImage(ContentManager Content)
        {
            this._content = Content;
            LoadContent();
            SetRectPosition();
        }

        private void SetRectPosition()
        {
            _rect = new Rectangle(15, 15, 60, 60);
            _selectedTextureChunk = new Rectangle(0,0, _texture.Width,_texture.Height);
        }

        private void LoadContent()
        {
            _texture = _content.Load<Texture2D>("question");
            _tmpTexture = _content.Load<Texture2D>("question");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rect, _selectedTextureChunk, color);
        }

        public void CalculateItemsPositions(GraphicsDevice graphicsDevice)
        {
            _rect.X = (graphicsDevice.Viewport.Width / 2) - (_rect.Size.X / 2);
            _rect.Y = graphicsDevice.Viewport.Height / 2 - _rect.Size.Y / 2;
        }

        public void CalculateItemsSize(GraphicsDevice graphicsDevice)
        {
            _rect.Height = graphicsDevice.Viewport.Height / 6;
            _rect.Width = graphicsDevice.Viewport.Width / 3;
        }

        public void Update(Rectangle cursor)
        {
            if(_rect.Intersects(cursor)) //mouse collision
            {                                
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    _selectedTextureChunk = new Rectangle(0, 0, _texture.Width, _texture.Height);
                    _texture = _tmpTexture;
                    color = Color.Red;
                }
            }
            else
            {
                color = Color.White;
            }
        }

    }
}