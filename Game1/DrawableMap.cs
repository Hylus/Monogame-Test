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
    class DrawableMap
    {
        private InteractiveItem[,] mapItems;

        private int _x = 10;
        private int _y = 10;        

        public DrawableMap(ContentManager content)
        {
            CreateDrawableMap(content);
        }

        private void CreateDrawableMap(ContentManager content)
        {
            mapItems = new InteractiveItem[_x,_y];
            for (int y = 0; y < _y; y++)
            {
                for (int x = 0; x < _x; x++)
                {
                    mapItems[x, y] = new InteractiveItem(content, x, y);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _y; y++)
            {
                for (int x = 0; x < _x; x++)
                {
                    mapItems[x, y].Draw(spriteBatch);
                }
            }
        }

        public void Update(Rectangle cursor, CurrentSelectedImage image)
        {
            foreach (var item in mapItems)
            {
                item.Update(cursor, image);
            }
        }
    }
}
