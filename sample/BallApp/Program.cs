using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{

        private Timer moveTimer;    //タイマー用
        private PictureBox ball_pb;
        private PictureBox bar_pb;
        private Bar bar;

        private List<Obj> balls = new List<Obj>();  //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();      //ボール表示用


        static void Main(string[] args) {

            Application.Run(new Program());

        }

        public Program() {

            this.Size = new Size(800, 600);
            this.BackColor = Color.Green;


            this.Text = "サッカーボールの数(0),テニスボールの数(0)";

            this.MouseClick += Program_MouseClick;
            this.KeyDown += Program_KeyDown;


            moveTimer = new Timer();
            moveTimer.Interval = 1; //タイマーのインターバル(ms)
            moveTimer.Tick += MoveTimer_Tick;   //デリゲート登録

            bar = new Bar();
            bar_pb = new PictureBox();
            bar_pb.Size = new Size(150, 10);
            bar_pb.Image = bar.Image;
            bar_pb.Location = new Point((int)bar.PosX, (int)bar.PosY);
            bar_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            bar_pb.Parent = this;
            bar = new Bar();

        }

        //キーが押された時のイベントハンドラ
        private void Program_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.A) {
                bar.move(-1);
                bar_pb.Location = new Point((int)bar.PosX, (int)bar.PosY);    //画像の位置
            }
            else if(e.KeyCode == Keys.D){
                bar.move(1);
                bar_pb.Location = new Point((int)bar.PosX, (int)bar.PosY);    //画像の位置
            }

        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {

            Obj ballObj = null;
            ball_pb = new PictureBox();   //画像を表示するコントロール

            //ボールインスタンスを生成

            if (e.Button == MouseButtons.Left){
                ballObj = new SoccerBall(e.X - 25, e.Y - 25);
                ball_pb.Size = new Size(50, 50); //画像の表示サイズ
            }else if (e.Button == MouseButtons.Right){
                ballObj = new TennisBall(e.X - 12, e.Y - 12);
                ball_pb.Size = new Size(25, 25); //画像の表示サイズ
            }

            ball_pb.Image = ballObj.Image;
            ball_pb.Location = new Point((int)ballObj.PosX, (int)ballObj.PosY);    //画像の位置
            ball_pb.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
            ball_pb.Parent = this;
            balls.Add(ballObj);
            pbs.Add(ball_pb);

            this.Text = "サッカーボールの数(" + SoccerBall.Count + "),テニスボールの数(" + TennisBall.Count + ")";

            moveTimer.Start();  //タイマースタート

        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {

            for (int i = 0; i < balls.Count; i++) {
                balls[i].Move(); //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);    //画像の位置
            }
        }

    }
}
