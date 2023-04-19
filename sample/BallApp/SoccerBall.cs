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

        private double moveX = 5.0;  //移動量(x方向)
        private double moveY = 5.0;  //移動量(y方向)

        //コンストラクタ
        public SoccerBall() {
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = 0.0;
            PosY = 0.0;
            
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
