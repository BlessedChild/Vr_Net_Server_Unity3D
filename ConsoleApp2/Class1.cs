using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Class1
    {
        //数据类型编码算法
        //将int转为低字节在前，高字节在后的byte数组
        public static byte[] InttoByteArray(int n)
        {
            byte[] b = new byte[4];
            b[0] = (byte)(n & 0xff);
            b[1] = (byte)(n >> 8 & 0xff);
            b[2] = (byte)(n >> 16 & 0xff);
            b[3] = (byte)(n >> 24 & 0xff);
            return b;
        }

        //将short转为低字节在前，高字节在后的byte数组
        public static byte[] ShorttoByteArray(short n)
        {
            byte[] b = new byte[2];
            b[1] = (byte)(n & 0xff);
            b[0] = (byte)(n >> 8 & 0xff);
            return b;
        }

        //将int类型网络字节转化为主机字节算法
        public static string ByteArraytoInt(byte[] b)
        {
            int iOutcome = 0;
            int iOutcome1 = 0;
            int iOutcome2= 0;
            byte bLoop;
            for (int i = 0; i < 12; i++)
            {
                if(i < 4)
                {
                    bLoop = b[i];
                    iOutcome += (bLoop & 0xff) << (8 * i);
                }
                if(i > 3 && i < 8)
                {
                    bLoop = b[i];
                    iOutcome1 += (bLoop & 0xff) << (8 * i);
                }
                if(i > 7 && i <12)
                {
                    bLoop = b[i];
                    iOutcome2 += (bLoop & 0xff) << (8 * i);
                }

            }
            string re= iOutcome.ToString() + "/" + iOutcome1.ToString() + "/" + iOutcome2.ToString();
            return re;
        }

        //将short类型的网络字节转化为主机字节算法
        private static short ByteArraytoShort(byte[] b)
        {
            short iOutcome = 0;
            byte bLoop;
            for (int i = 0; i < 2; i++)
            {
                bLoop = b[i];
                iOutcome += (short)((bLoop & 0xff) << (8 * i));
            }
            return iOutcome;
        }


    }
}
