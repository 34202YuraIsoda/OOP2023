using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class Bar {

        private Image image;
        private double posX;
        private double posY;
        private double moveX;

        public Image Image { get => image; set => image = value; }
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public double MoveX { get => moveX; set => moveX = value; }

        public Bar() {
            MoveX = 10;
            PosX = 300;
            PosY = 500;
            Image = Image.FromFile(@"pic\bar.png");
        }

        public void move(int vector) {
            if (MoveX * vector + PosX > 640 || MoveX * vector + PosX < 0) {
                vector = 0;
            }
                PosX += MoveX * vector;
        }

    }
}
