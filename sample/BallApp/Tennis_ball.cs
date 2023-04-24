using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class TennisBall : Obj {

        //フィールド
        private double moveX;   //移動量(x方向)
        private double moveY;   //移動量(y方向)
        private static int count;
        Random random = new Random();   //乱数インスタンス

        //コンストラクタ
        public TennisBall(double xp, double yp)
            : base(xp, yp, @"pic\tennis_ball.png") {

            int rndX = random.Next(-15, 15);
            int rndY = random.Next(-15, 15);

            MoveY = (rndX != 0 ? rndX : 1);  //乱数で移動量を設定
            MoveX = (rndY != 0 ? rndY : 1);  //乱数で移動量を設定

            Count++;

        }

        //プロパティ
        public double MoveX { get => moveX; set => moveX = value; }
        public double MoveY { get => moveY; set => moveY = value; }
        public static int Count { get => count; set => count = value; }

        //メソッド
        public override void Move() {

            Console.WriteLine("x = {0} , y = {1}", PosX, PosY);

            if (PosX > 740 || PosX < 0)
            {
                MoveX = -MoveX;
            }

            if (PosY > 520 || PosY < 0)
            {
                MoveY = -MoveY;
            }

            PosX += MoveX;
            PosY += MoveY;

        }
    }
}
