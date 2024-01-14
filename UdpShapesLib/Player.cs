using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpShapesLib {
    public enum Shape { Circle, Square, Triangle, Diamond, Rectangle }

    public enum ShapeSize { Small, Medium, Large}

    public class Player {
        public string Name { get; }
        public Shape Shape { get; }
        public ShapeSize ShapeSize { get; }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Player (string name, Shape shape, byte red, byte green, byte blue, ShapeSize size) {
            Name = name;
            Shape = shape;
            
            Red = red;
            Green = green;
            Blue = blue;

            ShapeSize = size;
        }
        public Player (BinaryReader reader) {
            Name = reader.ReadString ();
            Shape = (Shape) reader.ReadByte ();

            Red = reader.ReadByte ();
            Green = reader.ReadByte ();
            Blue = reader.ReadByte ();

            ShapeSize = (ShapeSize)reader.ReadByte();

            X = reader.ReadInt32 ();
            Y = reader.ReadInt32 ();
        }

        public void Move (BinaryReader reader) {
            X = reader.ReadInt32 ();
            Y = reader.ReadInt32 ();
        }

        public void Draw (Graphics g) {

            
            Brush brush = new SolidBrush (Color.FromArgb (Red, Green, Blue));
            Font font = new Font(FontFamily.GenericMonospace, 12);
          
            
            g.ResetTransform ();
            g.TranslateTransform (X, Y);  
            g.DrawString(Name, font, new SolidBrush(Color.Black),new Point(0,-40));

            if (ShapeSize == ShapeSize.Small)
            {
                if (Shape == Shape.Circle)
                    g.FillEllipse(brush, 0, 0, 30, 30);
                else if (Shape == Shape.Square)
                    g.FillRectangle(brush, 0, 0, 30, 30);
                else if (Shape == Shape.Triangle)
                    g.FillPolygon(brush, new[] { new Point(15, 0), new Point(30, 30), new Point(0, 30) });
                else if (Shape == Shape.Diamond)
                    g.FillPolygon(brush, new[] { new Point(15, 0), new Point(30, 15), new Point(15, 30), new Point(0, 15) });
                else if (Shape == Shape.Rectangle)
                    g.FillRectangle(brush, 0, 0, 90, 30);
            }
            else
                if (ShapeSize == ShapeSize.Medium)
            {
                if (Shape == Shape.Circle)
                    g.FillEllipse(brush, 0, 0, 50, 50);
                else if (Shape == Shape.Square)
                    g.FillRectangle(brush, 0, 0, 50, 50);
                else if (Shape == Shape.Triangle)
                    g.FillPolygon(brush, new[] { new Point(25, 0), new Point(50, 50), new Point(0, 50) });
                else if (Shape == Shape.Diamond)
                    g.FillPolygon(brush, new[] { new Point(25, 0), new Point(50, 25), new Point(25, 50), new Point(0, 25) });
                else if (Shape == Shape.Rectangle)
                    g.FillRectangle(brush, 0, 0, 150, 50);
            }
            else
                if (ShapeSize == ShapeSize.Large)
            {
                if (Shape == Shape.Circle)
                    g.FillEllipse(brush, 0, 0, 75, 75);
                else if (Shape == Shape.Square)
                    g.FillRectangle(brush, 0, 0, 75, 75);
                else if (Shape == Shape.Triangle)
                    g.FillPolygon(brush, new[] { new Point(35, 0), new Point(70, 70), new Point(0, 70) });
                else if (Shape == Shape.Diamond)
                    g.FillPolygon(brush, new[] { new Point(35, 0), new Point(70, 35), new Point(35, 70), new Point(0, 35) });
                else if (Shape == Shape.Rectangle)
                    g.FillRectangle(brush, 0, 0, 225, 75);
            }


           
        }

        public byte[] EnterMessage () {
            MemoryStream stream = new MemoryStream ();
            BinaryWriter writer = new BinaryWriter (stream);
            writer.Write (Message.Enter);
            writer.Write (Name);
            writer.Write ((byte) Shape);
            writer.Write (Red);
            writer.Write (Green);
            writer.Write (Blue);
            writer.Write((byte)ShapeSize);
            writer.Write (X);
            writer.Write (Y);
            return stream.ToArray ();
        }

        public byte[] ExistMessage () {
            MemoryStream stream = new MemoryStream ();
            BinaryWriter writer = new BinaryWriter (stream);
            writer.Write (Message.Exist);
            writer.Write (Name);
            writer.Write ((byte) Shape);
            writer.Write (Red);
            writer.Write (Green);
            writer.Write (Blue);
            writer.Write((byte)ShapeSize);
            writer.Write (X);
            writer.Write (Y);
            return stream.ToArray ();
        }

        public byte[] MoveMessage () {
            MemoryStream stream = new MemoryStream ();
            BinaryWriter writer = new BinaryWriter (stream);
            writer.Write (Message.Move);
            writer.Write (Name);
            writer.Write (X);
            writer.Write (Y);
            return stream.ToArray ();
        }

        public byte[] LeaveMessage () {
            MemoryStream stream = new MemoryStream ();
            BinaryWriter writer = new BinaryWriter (stream);
            writer.Write (Message.Leave);
            writer.Write (Name);
            return stream.ToArray ();
        }

        public bool Contains (Point point) =>
            point.X >= X && point.X < X + 50 &&
            point.Y >= Y && point.Y < Y + 50;
    }
}
