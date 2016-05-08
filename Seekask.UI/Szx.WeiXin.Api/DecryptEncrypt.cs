using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Szx.WeiXin.Api
{
    /// <summary>
    /// 
    /// 作者：石忠孝   
    /// 文件名：DecryptEncrypt
    /// 创建时间：2016/5/8 16:28:38
    /// 修改人：石忠孝
    /// 修改时间：2016/5/8 16:28:38
    /// 说明：
    /// 
    /// </summary>
    public static class DecryptEncrypt
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="inData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] EncryptPKCS7(byte[] inData, byte[] key)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = key;
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                try
                {
                    return des.CreateEncryptor().TransformFinalBlock(inData, 0, inData.Length);
                }
                catch
                {
                    return null;
                }
            }
            catch { return null; }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="inData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] DecryptPKCS7(byte[] inData, byte[] key)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = key;
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                try
                {
                    return des.CreateDecryptor().TransformFinalBlock(inData, 0, inData.Length);
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DecryptPKCS7(string inData,string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inData))
                    return null;
                byte[] bykey_j = Encoding.UTF8.GetBytes(key);
                byte[] inData_j = Convert.FromBase64String(inData);
                byte[] byRealData_j = DecryptPKCS7(inData_j, bykey_j);
                inData = ByteArrayToStr(byRealData_j, 0, byRealData_j.Length);
            }
            catch (Exception)
            {

            }
            return inData;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncryptPKCS7(string sData, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sData))
                    return null;
                byte[] bykey = Encoding.UTF8.GetBytes(key);
                byte[] inData = Encoding.UTF8.GetBytes(sData);
                byte[] byRealData = EncryptPKCS7(inData, bykey);
                sData = Convert.ToBase64String(byRealData.ToArray());
            }
            catch (Exception)
            {

            }
            return sData;
        }

        /// <summary>
        /// 16进制转Byte
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexStringToArray(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        /// <summary>
        /// Byte转String
        /// </summary>
        /// <param name="ByteArray"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ByteArrayToStr(byte[] ByteArray, Int32 offset, Int32 length)
        {
            if (ByteArray == null)
                return "";

            if (length > ByteArray.Length - offset)
                return "";

            byte[] buf = new byte[length];
            Array.Copy(ByteArray, offset, buf, 0, length);

            Int32 len = 0;
            foreach (byte b in buf)
            {
                if (b == 0)
                    break;

                len++;
            }

            return Encoding.UTF8.GetString(buf, 0, len);
        }

        /// <summary>
        /// Byte转16进制
        /// </summary>
        /// <param name="ArrayData"></param>
        /// <param name="Offset"></param>
        /// <param name="Len"></param>
        /// <returns></returns>
        public static string ArrayToHexString(byte[] ArrayData, Int32 Offset, Int32 Len)
        {
            string hexString = "";

            if (ArrayData != null)
            {
                for (Int32 i = 0; i < Len; i++)
                {
                    hexString += ArrayData[Offset + i].ToString("X2");
                }
            }

            return hexString;
        }
    }


}
