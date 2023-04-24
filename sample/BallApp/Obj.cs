using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    //抽象クラス
    abstract class Obj {

        //フィールド
        private Image image;    //画像データ
        private double posX;    //x座標
        private double posY;    //y座標

        //プロパティ
        public Image Image { get => image; set => image = value; }
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }

        //コンストラクタ
        public Obj(double PosX, double PosY, string Path) {
            this.PosX = PosX;
            this.PosY = PosY;
            Image = Image.FromFile(Path);
        }

        //移動メソッド(抽象メソッド)
        public abstract void Move();
    }
}
