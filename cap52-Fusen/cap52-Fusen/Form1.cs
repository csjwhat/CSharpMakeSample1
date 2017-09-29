using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cap52_Fusen
{
    public partial class FormFusen : Form
    {
        private int mouseX;
        private int mouseY;

        public FormFusen()
        {
            InitializeComponent();
        }

        // OnKeyDown Escならばアプリケーション終了
        private void textFusenMemo_KeyDown(object sender, KeyEventArgs e)
        {
            // 押されたキーはESC?
            //if (e.KeyCode.Equals(Keys.Escape))
            if (e.KeyCode == Keys.Escape)
            {
                // Yesの場合
                // アプリケーションを終了
                this.Close();
            }
        }

        // MouseMove マウスの左ボタンを押したまま移動したら今現在の位置を設定
        private void textFusenMemo_MouseDown(object sender, MouseEventArgs e)
        {
            // 押されたボタンがマウスの左ボタン？
            if (e.Button == MouseButtons.Left)
            {
                // Yesの場合
                // マウスの横位置（X座標）を記憶
                mouseX = e.X;

                // マウスの縦位置（Y座標) を記憶
                mouseY = e.Y;
            }
        }

        // MouseDown マウスの左ボタンを押されたら、マウスの押された位置を記憶
        private void textFusenMemo_MouseMove(object sender, MouseEventArgs e)
        {
            // 押されたボタンがマウスの左ボタン？
            if (e.Button == MouseButtons.Left)
            {
                // Yesの場合
                // フォームの横位置（X座標）を更新 
                // -> マウスの位置と、少し前の位置の相対距離分だけ移動
                this.Left += e.X - mouseX;

                // フォームの縦位置（Y座標) を更新
                // -> マウスの位置と、少し前の位置の相対距離分だけ移動
                this.Top += e.Y - mouseY;
            }
        }

        // MouseDoubleClick 色の設定を起動してテキストボックスの背景色を変更
        private void textFusenMemo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 色の設定ダイアログを表示
            colorDialogFusen.ShowDialog();

            // テキストボックスの背景色を色の設定ダイアログで指定した値にする。
            textFusenMemo.BackColor = colorDialogFusen.Color;
        }


    }
}
