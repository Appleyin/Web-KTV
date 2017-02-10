using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ktv前端
{

    public partial class FrmZhuchuangti : Form
    {
        int play = 1;//全局的播放为1  ，暂停0
        public FrmZhuchuangti()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripButton11.Margin = new System.Windows.Forms.Padding(50, 0, 10, 0);
            lalShijian.Text = DateTime.Now.ToString("HH:mm:ss");
          
        }
        /// <summary>
        /// 单击主菜单返回按钮退出单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出

        }
        /// <summary>
        /// 暂停/播放按钮单击播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            if (play==0)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();//暂停
                play = 1;
            }
            else if (play==1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();//播放
                play = 0;
            }
        }
        /// <summary>
        /// 重唱按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
           axWindowsMediaPlayer1.Ctlcontrols.stop();
          axWindowsMediaPlayer1.Ctlcontrols.play();
        }




        
        /// <summary>
        /// 时间控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lalNewshijian.Text = DateTime.Now.ToString("HH:mm:ss");



        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("服务以呼出，请等待！","提示",MessageBoxButtons.OK);
        }
        /// <summary>
        /// 点歌按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            FrmSongSets Frm = new FrmSongSets();
            Frm.Show();
        }
    }
}
