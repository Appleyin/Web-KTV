using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ktv前端
{
    public partial class FrmManSinger : Form
    {
        public FrmManSinger()
        {
            InitializeComponent();
        }
        SqlDataAdapter sda;
        DataSet ds;
        DataView dv;
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmManSinger_Load(object sender, EventArgs e)
        {
            #region DataGridVeiw Style
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(158)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.EnableHeadersVisualStyles = false;
            this.DataGridView1.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.RowTemplate.ReadOnly = true;
            #endregion
            DataGridView1.AutoGenerateColumns = false;
            AddData();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void AddData()
        {
            string sql = @"select s.song_id,s.song_name,sty.songtype_name,g.singer_name,song_play_count ,g.singer_sex,s.song_url
                                    from dbo.song_info  s,dbo.singer_info  g,dbo.song_type  sty 
                                    where s.singer_id=s.singer_id and s.singer_id=g.singer_id and sty.songtype_id=s.songtype_id and g.singer_sex='男'
                                    ";
            sda = new SqlDataAdapter(sql, DBHelper.Connection);
            ds = new DataSet();
            sda.Fill(ds,"data");
            DataGridView1.DataSource = ds.Tables["data"];


        }
        /// <summary>
        /// 点击查询按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (kong())
            {
                showhca();
            }
        }
        /// <summary>
        /// 显示查询
        /// </summary>
        private void showhca()
        {
            string name = textBox1.Text;
            dv = new DataView(ds.Tables["data"]);
            dv.RowFilter = string.Format("singer_name like'%{0}%'", name);
            DataGridView1.DataSource = dv;
        }

        /// <summary>
        /// 判断非空
        /// </summary>
        /// <returns></returns>
        private bool kong()
        {
            bool flag = true;
            if (textBox1.Text.Trim().Equals(string.Empty))
            {
                flag = false;
            }
            return flag;
        }
        SongState song = new SongState();
        
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            song.SongName = DataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            //song.SongUrl1= DataGridView1.SelectedRows[0].Cells["song_url"].Value.ToString();
            PlayList.AddSong(song);
            string sql = string.Format("update dbo.song_info set song_play_count=song_play_count+1 where  song_name='{0}'",DataGridView1.SelectedRows[0].Cells["Name"].Value.ToString());
            SqlCommand cmd = new SqlCommand(sql,DBHelper.Connection);
            try
            {
                DBHelper.OpenConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show("已添加到播放列表","提示");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.ClosedConnection();
            }


        }

     

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmYiDian frm = new FrmYiDian();
            frm.Show();
        }
    }
}
