using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer
{
    public partial class FormTimer : Form
    {
        // 処理全般にかかわること、イベント-イベントの間も保持したいデータなので
        //メンバ変数に定義
        int endTime; //終了時間
        int nowTime; //現在時間

        public FormTimer()
        {
            InitializeComponent();
        }

        private void FormTimer_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {

            // 残り時間設定のテキストを取得
            if (!int.TryParse(textSetTime.Text, out endTime))
            {
                endTime = 1;
            }

            // 残り時間計算のため、経過時間を初期化
            nowTime = 0;

            // タイマースタート
            timerControl.Start();

        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            // 残り時間の変数を整数型で定義
            int remainingTime;

            // 経過時間に１秒を加える
            nowTime++;
            remainingTime = endTime - nowTime;

            // 残り時間を表示
            textRemainingTime.Text = remainingTime.ToString();

            // <判定> 設定の時間になったか
            if (remainingTime <= 0)
            {
                //   Yesの場合 タイマーを止める
                timerControl.Stop();
                //             終了時間になったことを通知
                MessageBox.Show("時間になりました");
            }
            else
            {
                //   Noの場合
            }
        }
    }
}
