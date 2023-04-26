using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar :Obj{

        public Bar(double xp,double yp)
            :base(xp,yp, @"pic\bar.png") {
            MoveX = 10;
        }

        public override void Move() {
        }

        public void Move(Keys direction) {
            if (direction == Keys.Right) {
                if (PosX < 640){
                    PosX += MoveX;
                }
            }
            else if (direction == Keys.Left){
                if (PosX > 0){
                    PosX -= MoveX;
                }
            }

            Console.WriteLine("x:" + PosX + "y:" + PosY);
        }

    }
}
