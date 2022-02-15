using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerAttack : ISprite
    {
      public Texture2D Texture {get; set;}
      public Vector2 Vector {get; set;}
      
      private int currentFrame;
      private int totalNumberOfFrames;
      private SpriteBatch spriteBatch;
      
      public int Columns {get; set}
      public int Rows {get; set;}
      
      public PlayerAttack(Vector2 vector, Texture2D texture, int columns, int rows, SpriteBatch spritebatch)
      {
        Vector = vector;
        Texture = texture;
        Columns = columns;
        Rows = rows;
        spriteBatch = spritebatch;
        
        totalNumberOfFrames = columns * rows;
        currentFrame = wherever it is;
      }
      
      public void Update()
      {
        currentFrame++;
        if (currentFrame == totalNumberOfFrames)
        {
          currentFrame = wherever it is;
        }
      }
      
      public void Draw(SpriteBatch spriteBatch, Vector2 Vector)
      {
        //Getting the width and height
        int width = texture.Width / Columns;
        int height = texture.Height / Rows;
        int row = currentFrame / Columns;
        int column = currentFrame % Columns;

        //Using the rows and columns to draw the 
        Rectangle sourceRectangle = new Rectangle(column*width, row*height, width, height);
        Rectangle destinationRectangle = new Rectangle((int)Vector.X, (int)Vector.Y, 4*width, 4*height);

        spriteBatch.Begin();
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
      }
      
    }
}
