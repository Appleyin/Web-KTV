using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktv前端
{
    
  public  class SongState
    {
      public   enum SongPlayState
        {
            unplayer, played, again, cut//未播放，播放，重播，切歌
        }
        private string songName;

        public string SongName
        {
            get
            { return songName; }
            set
            {songName = value;}
        }
            private string SongUrl;
        public string SongUrl1
        {
            get
            {   return SongUrl; }
            set
            {  SongUrl = value; }
        }

       

        private SongPlayState playStar = SongPlayState.unplayer;//歌曲播放状态默认为未播放
        /// <summary>
        /// 封装播放状态
        /// </summary>
        public  SongPlayState Playstar
        {
            get
            {return playStar; }
            set
            {playStar = value; }
        }

        #region 改变歌曲状态
        /// <summary>
        /// 歌曲改变为播放
        /// </summary>
        public void SongPlayed()
        {
            this.Playstar = SongPlayState.played;
        }
        /// <summary>
        /// 播放状态重播
        /// </summary>
        public void SongAgain()
        {
            this.Playstar = SongPlayState.again;
        }
        /// <summary>
        /// 歌曲状态切歌
        /// </summary>
        public void SongCut()
        {
            this.Playstar = SongPlayState.cut;
        }
        #endregion


    }
}
