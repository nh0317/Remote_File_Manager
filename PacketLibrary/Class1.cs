using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PacketLibrary
{
    public enum PacketType
    {
        init = 0,
        beforeSelect,
        beforeExpand,
        directoryInfo,
        fileInfo,
        setPlus,
        fileDetail,
        dirDetail,
        download,
        downloadData,
        fileData,
        exit
    }
    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);

            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;

            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
    [Serializable]
    public class Init : Packet
    {
        public string path=null;
        public int size = 0;
        public Init() { this.Type = (int)PacketType.init; }
        public Init(string path, int size)
        {
            this.path = path;
            this.size = size;
            this.Type = (int)PacketType.init;
        }

    }

    [Serializable]
    public class BeforeExpand : Packet
    {
        public string path=null;
        public int size=0;
        public BeforeExpand(string path)
        {
            this.path = path;
            this.Type = (int)PacketType.beforeExpand;
        }
        public BeforeExpand(int size)
        {
            this.size = size;
            this.Type = (int)PacketType.beforeExpand;
        }
    }
    [Serializable]
    public class DirInfo : Packet
    {
        public int index = 0;
        public string path;
        public DirectoryInfo di = null;
        public DirInfo(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.Type = (int)PacketType.directoryInfo;
        }
        public DirInfo(DirectoryInfo di)
        {
            this.di = di;
            this.Type = (int)PacketType.directoryInfo;
        }
    }
    [Serializable]
    public class FInfo : Packet
    {
        public int index = 0;
        public string path;
        public FileInfo fi = null;
        public FInfo(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.Type = (int)PacketType.fileInfo;
        }
        public FInfo(FileInfo fi)
        {
            this.fi = fi;
            this.Type = (int)PacketType.fileInfo;
        }
    }
    [Serializable]
    public class SetPlus : Packet
    {
        public string path = null;
        public int size = 0;

        public SetPlus(string path)
        {
            this.path = path;
            this.Type = (int)PacketType.setPlus;
        }

        public SetPlus(int size)
        {
            this.size = size;
            this.Type = (int)PacketType.setPlus;
        }
    }

    [Serializable]
    public class BeforeSelect : Packet
    {
        public string path = null;
        public int fSize = 0;
        public int dSize = 0;

        public BeforeSelect(string path)
        {
            this.path = path;
            this.Type = (int)PacketType.beforeSelect;
        }

        public BeforeSelect(int dSize, int fSize)
        {
            this.dSize = dSize;
            this.fSize = fSize;
            this.Type = (int)PacketType.beforeSelect;
        }
    }
    [Serializable]
    public class Download : Packet
    {
        public string path = null;
        public long size = 0;

        public Download(string path)
        {
            this.path = path;
            this.Type = (int)PacketType.download;
        }

        public Download(long length)
        {
            this.size = length;
            this.Type = (int)PacketType.download;
        }
    }

    [Serializable]
    public class DownloadData : Packet
    {

        public byte[] buffer;
        public long index;
        public DownloadData(long index, int buffersize)
        {
            this.index = index;
            this.buffer = new byte[buffersize];
            this.Type = (int)PacketType.downloadData;
        }
        public DownloadData(byte[] buffer, int buffersize)
        {
            this.buffer = new byte[buffersize];
            Array.Copy(buffer, this.buffer, buffersize);
            this.Type = (int)PacketType.downloadData;
        }
    }

    [Serializable]
    public class FileDetail : Packet
    {
        public string path = null;
        public FileInfo fi;

        public FileDetail(string path)
        {
            this.path = path;
            this.Type = (int)PacketType.fileDetail;
        }

        public FileDetail(FileInfo fi)
        {
            this.fi = fi;
            this.Type = (int)PacketType.fileDetail;
        }
    }
   
    [Serializable]
    public class Exit : Packet
    {
        public Exit() { this.Type=(int)PacketType.exit; }
    }
}
