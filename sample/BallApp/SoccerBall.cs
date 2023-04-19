using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class SoccerBall {

        //フィールド
        private Image image;    //画像データ

        private double posX;    //x座標
        private double posY;    //y座標
        private double moveX;
        private double moveY;

        Random random = new Random();   //乱数インスタンス
 
        //コンストラクタ
        public SoccerBall(double xp, double yp) {
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = xp;
            PosY = yp;

            int rndX = random.Next(-15, 15);
            int rndY = random.Next(-15, 15);

            moveY = (rndX != 0 ? rndX : 1);  //乱数で移動量を設定
            moveX = (rndY != 0 ? rndY : 1);  //乱数で移動量を設定
            
        }

        //プロパティ
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }

        //メソッド
        public void Move() {

            Console.WriteLine("x = {0} , y = {1}", PosX, PosY);

            if(PosX > 740 || PosX < 0){
                moveX = -moveX;
            }

            if(PosY > 520 || PosY < 0){
                moveY = -moveY;
            }

            PosX += moveX;
            PosY += moveY;

        }

    }
}
