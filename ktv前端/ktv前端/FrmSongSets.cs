﻿using System;
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
    public partial class FrmSongSets : Form
    {
        public FrmSongSets()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 金曲排行榜单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmSongSequence frm = new FrmSongSequence();
            frm.Show();
        }
        /// <summary>
        /// 歌星点歌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void FrmSongSets_Load(object sender, EventArgs e)
        {

        }
    }
}
