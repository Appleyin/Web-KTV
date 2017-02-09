using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktv前端
{
    class Song
    {
        //歌曲播放状态枚举字段
        public enum SongPlayState
        {

            unplayed, played, again, cut

        }
        //歌曲名称私有字段
        private string songName;

        public string SongName
        {
            get { return songName; }
            set { songName = value; }
        }

        //歌曲路径私有字段
        private string songURL;

        public string SongURL
        {
            get { return songURL; }
            set { songURL = value; }
        }
        //歌曲播放状态字段


        private SongPlayState PlayState = SongPlayState.unplayed;

        internal SongPlayState PlayState1
        {
            get { return PlayState; }
            set { PlayState = value; }
        }








        //重播
        public void SongAgain()
        {
            this.PlayState = SongPlayState.again;


        }
        //切歌
        public void SongCut()
        {
            this.PlayState = SongPlayState.cut;

        }
        //播放
        public void SongPlay()
        {

            this.PlayState = SongPlayState.played;
        }



    }
}
