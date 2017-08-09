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
            int iOutcome3= 0;
            int iOutcome4= 0;
            int iOutcome5= 0;
            int iOutcome6= 0;
            int iOutcome7= 0;
            byte bLoop;
            for (int i = 0; i < 32; i++)
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
                if (i > 11 && i < 16)
                {
                    bLoop = b[i];
                    iOutcome3 += (bLoop & 0xff) << (8 * i);
                }
                if (i > 15 && i < 20)
                {
                    bLoop = b[i];
                    iOutcome4 += (bLoop & 0xff) << (8 * i);
                }
                if (i > 19 && i < 24)
                {
                    bLoop = b[i];
                    iOutcome5 += (bLoop & 0xff) << (8 * i);
                }
                if (i > 23 && i < 28)
                {
                    bLoop = b[i];
                    iOutcome6 += (bLoop & 0xff) << (8 * i);
                }
                if (i > 27 && i < 32)
                {
                    bLoop = b[i];
                    iOutcome7 += (bLoop & 0xff) << (8 * i);
                }

            }
            string re= iOutcome.ToString() + "/" + iOutcome1.ToString() + "/" + iOutcome2.ToString() + "/" + iOutcome3.ToString() + "/" + iOutcome4.ToString() + "/" + iOutcome5.ToString() + "/" + iOutcome6.ToString() + "/" + iOutcome7.ToString();
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

        public static string[] ServerToClient_string(byte[][] b)
        {
            if(b.Length > 0)
            {
                int[][] iOutcome = new int[2][]{new int[14], new int[14]};
                byte bLoop;
                for (int ib = 0; ib < b.Length; ib++)
                {
                    for (int i = 0; i < 56; i++)
                    {
                        if (i < 4)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][0] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 3 && i < 8)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][1] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 7 && i < 12)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][2] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 11 && i < 16)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][3] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 15 && i < 20)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][4] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 19 && i < 24)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][5] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 23 && i < 28)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][6] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 27 && i < 32)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][7] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 31 && i < 36)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][8] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 35 && i < 40)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][9] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 39 && i < 44)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][10] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 43 && i < 48)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][11] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 47 && i < 52)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][12] += (bLoop & 0xff) << (8 * i);
                        }
                        if (i > 51 && i < 56)
                        {
                            bLoop = b[ib][i];
                            iOutcome[ib][13] += (bLoop & 0xff) << (8 * i);
                        }
                    }
                }

                string[] re = new string[2];
                re[0] = iOutcome[0][0].ToString() + "/" + iOutcome[0][1].ToString() + "/" + iOutcome[0][2].ToString() + "/" + iOutcome[0][3].ToString() + "/" + iOutcome[0][4].ToString() + "/" + iOutcome[0][5].ToString() + "/" + iOutcome[0][6].ToString() + "/" + iOutcome[0][7].ToString();
                re[1] = iOutcome[1][0].ToString() + "/" + iOutcome[1][1].ToString() + "/" + iOutcome[1][2].ToString() + "/" + iOutcome[1][3].ToString() + "/" + iOutcome[1][4].ToString() + "/" + iOutcome[1][5].ToString() + "/" + iOutcome[1][6].ToString() + "/" + iOutcome[1][7].ToString();
                return re;
            }
            else
            {
                string[] res = new string[2];
                res[0] = "no messages";
                return res;
            }
        }

        public static byte[] ServerToClient_Byte(byte[][] b)
        {
            byte[] ToClient = new byte[112];
            byte bLoop;

            for (int ib = 0; ib < b.Length; ib++)
            {
                for (int i = 0; i < 56; i++)
                {
                    bLoop = b[ib][i];
                    ToClient[ib * 56 + i] += bLoop;
                }
            }

            return ToClient;
        }
    }
}
