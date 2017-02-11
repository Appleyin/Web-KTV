using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ktv前端.SongState;

namespace ktv前端
{
  public   class PlayList
    {
        private static SongState[] songList = new SongState[100];
        public static int SongIndex = 0;//当前播放的歌曲在数组中索引（已点列表）

        internal static SongState[] SongList
        {
            get
            {
                return songList;
            }
            set
            { songList = value;}
        }



        /// <summary>
        /// 点一首歌，相当于歌曲放在数组中
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        internal static bool AddSong(SongState song)
        {
            bool flag = false;
            for (int i = 0;  i <SongList.Length;   i++)
            {
                if (SongList[i]==null)
                {
                    SongList[i] = song;
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// 获取当前播放的歌曲，既然是获取当前播放的歌曲，放回值肯定是Song类型 
        /// </summary>
        /// <returns></returns>
        public static SongState GetPlaySong()
        {
            if (SongList[SongIndex] != null)
            {
                return SongList[SongIndex];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 播放下一曲
        /// </summary>
        public static void Next()
        {
            if (SongList[SongIndex] != null && SongList[SongIndex].Playstar == SongPlayState.again)
            {
                SongList[SongIndex].SongPlayed();
            }
            else
            {
                SongIndex++;
                if (SongList[SongIndex] != null)
                {
                    SongList[SongIndex].SongPlayed();
                }
            }
        }

        /// <summary>
        /// 下一首要播放的歌曲名称
        /// </summary>
        /// <returns></returns>
        public static string NextSongName()
        {
            string songName = "";
            if (SongList[0] != null && SongList[SongIndex + 1] == null)
            {
                songName = "待添加";
            }
            else
            {
                if (SongList[0]!=null)
                {
                    songName = SongList[SongIndex + 1].SongName;
                    return songName;//返回下一首个的名称
                }
            }

            return songName;
        }
        /// <summary>
        /// 歌曲重播
        /// </summary>
        public static void PalyAgain()
        {
            if (SongList[SongIndex]!=null)
            {
                SongList[SongIndex].SongAgain();//获取重播的方法

            }
        }
        /// <summary>
        /// 切歌
        /// </summary>
        public void Cutsong()
        {
            //获取当前播放的歌曲改变播放状态
            if (SongList[SongIndex]!=null)
            {
                SongList[SongIndex].Playstar = SongPlayState.cut;
                SongIndex++;//改变过去取索引，播放下一曲
            }
        }
    }
}
