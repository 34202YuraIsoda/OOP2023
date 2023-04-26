using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class TennisBall : Obj {

        //フィールド
        private static int count;   //インスタンスの個数
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
        public static int Count { get => count; set => count = value; }

        //メソッド
        public override void Move(PictureBox pbBar, PictureBox pbBall) {

            //Console.WriteLine("x = {0} , y = {1}", PosX, PosY);

            Rectangle rBar = new Rectangle(pbBar.Location.X, pbBar.Location.Y,
                               pbBar.Width, pbBar.Height);

            Rectangle rBall = new Rectangle(pbBall.Location.X, pbBall.Location.Y,
                                            pbBall.Width, pbBall.Height);

            if (PosY > 540 || PosY < 0 || rBar.IntersectsWith(rBall)){
                MoveY = -MoveY;
            }

            if (PosX > 770 || PosX < 0){
                MoveX = -MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;

        }

        //抽象クラスを継承しているので、不要なメソッドは空にする
        public override void Move(Keys direction) {
        }//（空のメソッドにする）
    }
}
