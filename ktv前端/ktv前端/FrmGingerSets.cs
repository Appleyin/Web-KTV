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
    public partial class FrmGingerSets : Form
    {
        public FrmGingerSets()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 歌星点歌窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGingerSets_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 单击男歌手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmManSinger frm = new FrmManSinger();
            frm.Show();
        }
    }
}
