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
        public static string playState=null;
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
            
            for (int i = 0; i <PlayList.SongList.Length; i++)
            {
                if (PlayList.SongList[i]!=null)
                {
                    SongState frm = new SongState();
                    frm.SongPlayed();
                    playState = PlayList.SongList[i].Playstar == ktv前端.SongState.SongPlayState.unplayer ? "未播放" : "正播放";
                    DataTable dt = new DataTable();
                    dt.Columns.Add("歌曲");
                    dt.Columns.Add("状态");
                    DataGridView1.DataSource = dt;
                    DataRow dr = dt.NewRow();
                    dr[0] = PlayList.SongList[i].SongName;
                    dr[1] = playState;
                    dt.Rows.Add(dr);
                }

              

            }
           
        }
    }
}
