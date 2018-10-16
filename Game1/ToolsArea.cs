using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using test1;

namespace Game1
{
    internal class ToolsArea
    {
        int _rows = 3;
        int _columns = 4;

        private Vector2 _dim = new Vector2();

        ItemToChoose[,] _itemsToChoose;
        Texture2D _texture;

        public ItemToChoose[,] ItemsToChoose { get => _itemsToChoose; }//set => _itemsToChoose = value; }

        public ToolsArea(ContentManager content)
        {
            LoadContent(content);
            CalculateDimensions();
            CreateItemsToChoose();

        }

        private void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("numbers");
        }

        private void CreateItemsToChoose()
        {
            var rows = _rows - 1;

            _itemsToChoose = new ItemToChoose[rows, _columns];
            for (int y = 0; y < _columns; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    _itemsToChoose[x, y] = new ItemToChoose(x, y, (int)_dim.X, (int)_dim.Y, _texture);
                }
            }
        }

        private void CalculateDimensions()
        {
            _dim.X = _texture.Width / _columns;
            _dim.Y = _texture.Height / _rows-1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            foreach (var item in _itemsToChoose)
            {
                item.Draw(spriteBatch, _texture, _dim.X, _dim.Y, i);
                ++i;
                //      item.Draw(spriteBatch, _texture, _dim.X,_dim.Y);
            }
        }

        public void Update(Rectangle cursor, CurrentSelectedImage image)
        {
            foreach (var item in _itemsToChoose)
            {
                item.Update(cursor, image);
            }
        }
    }
}