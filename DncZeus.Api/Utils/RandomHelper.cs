/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;

namespace DncZeus.Api.Utils
{
    /// <summary>
    /// 隨機數幫助類
    /// </summary>
    public static class RandomHelper
    {
        #region 生成指定長度的隨機字符串
        /// <summary>
        /// 生成指定長度的隨機字符串
        /// </summary>
        /// <param name="intLength">隨機字符串長度</param>
        /// <param name="booNumber">生成的字符串中是否包含數字</param>
        /// <param name="booSign">生成的字符串中是否包含符號</param>
        /// <param name="booSmallword">生成的字符串中是否包含小寫字母</param>
        /// <param name="booBigword">生成的字符串中是否包含大寫字母</param>
        /// <returns></returns>
        public static string GetRandomizer(int intLength, bool booNumber, bool booSign, bool booSmallword, bool booBigword)
        {
            //定義  
            Random ranA = new Random();
            int intResultRound = 0;
            int intA = 0;
            string strB = "";

            while (intResultRound < intLength)
            {
                //生成隨機數A，表示生成類型  
                //1=數字，2=符號，3=小寫字母，4=大寫字母  

                intA = ranA.Next(1, 5);

                //如果隨機數A=1，則運行生成數字  
                //生成隨機數A，範圍在0-10  
                //把隨機數A，轉成字符  
                //生成完，位數+1，字符串累加，結束本次循環  

                if (intA == 1 && booNumber)
                {
                    intA = ranA.Next(0, 10);
                    strB = intA.ToString() + strB;
                    intResultRound = intResultRound + 1;
                    continue;
                }

                //如果隨機數A=2，則運行生成符號  
                //生成隨機數A，表示生成值域  
                //1：33-47值域，2：58-64值域，3：91-96值域，4：123-126值域  

                if (intA == 2 && booSign == true)
                {
                    intA = ranA.Next(1, 5);

                    //如果A=1  
                    //生成隨機數A，33-47的Ascii碼  
                    //把隨機數A，轉成字符  
                    //生成完，位數+1，字符串累加，結束本次循環  

                    if (intA == 1)
                    {
                        intA = ranA.Next(33, 48);
                        strB = ((char)intA).ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }

                    //如果A=2  
                    //生成隨機數A，58-64的Ascii碼  
                    //把隨機數A，轉成字符  
                    //生成完，位數+1，字符串累加，結束本次循環  

                    if (intA == 2)
                    {
                        intA = ranA.Next(58, 65);
                        strB = ((char)intA).ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }

                    //如果A=3  
                    //生成隨機數A，91-96的Ascii碼  
                    //把隨機數A，轉成字符  
                    //生成完，位數+1，字符串累加，結束本次循環  

                    if (intA == 3)
                    {
                        intA = ranA.Next(91, 97);
                        strB = ((char)intA).ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }

                    //如果A=4  
                    //生成隨機數A，123-126的Ascii碼  
                    //把隨機數A，轉成字符  
                    //生成完，位數+1，字符串累加，結束本次循環  

                    if (intA == 4)
                    {
                        intA = ranA.Next(123, 127);
                        strB = ((char)intA).ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }

                }

                //如果隨機數A=3，則運行生成小寫字母  
                //生成隨機數A，範圍在97-122  
                //把隨機數A，轉成字符  
                //生成完，位數+1，字符串累加，結束本次循環  

                if (intA == 3 && booSmallword == true)
                {
                    intA = ranA.Next(97, 123);
                    strB = ((char)intA).ToString() + strB;
                    intResultRound = intResultRound + 1;
                    continue;
                }

                //如果隨機數A=4，則運行生成大寫字母  
                //生成隨機數A，範圍在65-90  
                //把隨機數A，轉成字符  
                //生成完，位數+1，字符串累加，結束本次循環  

                if (intA == 4 && booBigword == true)
                {
                    intA = ranA.Next(65, 89);
                    strB = ((char)intA).ToString() + strB;
                    intResultRound = intResultRound + 1;
                    continue;
                }
            }
            return strB;

        }
        #endregion
    }
}
