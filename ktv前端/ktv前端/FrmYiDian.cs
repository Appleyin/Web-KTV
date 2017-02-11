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
    public partial class FrmYiDian : Form
    {
        public FrmYiDian()
        {
            InitializeComponent();
        }
        public static string playState;
        /// <summary>
        /// 已点歌曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmYiDian_Load(object sender, EventArgs e)
        {
            fag();
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        private void fag()
        {
            lv.Items.Clear();
            while (PlayList.SongList[PlayList.SongIndex] != null) ;
            {
                 ListViewItem item = new ListViewItem(PlayList.SongList[PlayList.SongIndex].SongName);
                SongState frm = new SongState();
                frm.SongPlayed();
                playState = PlayList.SongList[PlayList.SongIndex].Playstar == ktv前端.SongState.SongPlayState.unplayer ? "未播放" : "正播放";
                item.SubItems.Add(playState);
                lv.Items.Add(item);
                PlayList.SongIndex++;
            }
            }
    }
}
