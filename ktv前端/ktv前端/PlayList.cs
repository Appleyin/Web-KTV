using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktv前端
{
    class PlayList
    {
        public static int num = 0;
        private static Song[] songList = new Song[50];

        public static Song[] SongList
        {
            get { return PlayList.songList; }

        }


        private static int songIndex = 0;

        public static int SongIndex
        {
            get { return PlayList.songIndex; }

        }





        //当前播放歌曲名称
        public static String PlayingSongName()
        {
            string songName = "";


            if (SongList[SongIndex] != null)
            {
                songName = SongList[SongIndex].SongName;


            }



            return songName;

        }
        // 当前播放的歌曲
        public static Song GetPlayingSong()
        {
            if (SongList[songIndex] != null)
            {
                return SongList[songIndex];

            }
            else
            {
                return null;

            }

        }
        //播放下一首歌曲
        public static void GeiNextSong()
        {

            if (SongList[songIndex] != null)
            {
                SongList[songIndex].SongPlay();

            }
            else
            {
                songIndex++;
            }

        }
        //下一首歌曲名称
        public static string GetPlayingSongName()
        {
            string nextSongName = "";
            if (SongList[SongIndex + 1] != null)
            {
                nextSongName = SongList[SongIndex + 1].SongName;


            }
            return nextSongName;



        }
        //点播一首歌曲
        public static bool AddSong(Song song)
        {
            bool success = false;
            for (int i = 0; i < SongList.Length; i++)
            {
                if (SongList[i] == null)
                {
                    SongList[i] = song;
                    success = true;
                    break;


                }


            }

            return success;


        }
        //重放当前歌曲
        public static void PlayAgain()
        {
            if (SongList[songIndex] != null)
            {
                SongList[songIndex].SongAgain();


            }

        }
        //切歌

        public static void CutSong(int index)
        {
            if (GetPlayingSongName() != "")
            {

                num = 0;
                int i;
                if (index == -1)
                {
                    i = SongIndex;


                }
                else
                {
                    i = index;



                }

                while (SongList[i] != null)
                {
                    SongList[i] = SongList[i + 1];
                    i++;
                    if (i == SongList.Length)
                    {
                        SongList[i] = null;


                    }

                }

            }
            else
            {

                num = 1;

            }
            PlayList.GeiNextSong();
        }

    }
}
