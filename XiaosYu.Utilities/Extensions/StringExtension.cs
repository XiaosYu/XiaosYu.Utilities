﻿using XiaosYu.Utilities.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace XiaosYu.Utilities.Extensions
{
    static public partial class Extension
    {
        /// <summary>
        /// 将字符串转为int
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>结果</returns>
        static public int ToInt32(this string str)
            => Convert.ToInt32(str);

        /// <summary>
        /// 将字符串转为double
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>结果</returns>
        static public double ToDouble(this string str)
            => Convert.ToDouble(str);

        /// <summary>
        /// 将字符串转为float
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>结果</returns>
        static public float ToFloat(this string str)
            => Convert.ToSingle(str);

        /// <summary>
        /// 如果字符串是json字符串,直接转换为对象
        /// </summary>
        /// <typeparam name="TResult">对象类型</typeparam>
        /// <param name="str">源字符串</param>
        /// <returns>对象结果</returns>
        static public TResult? ToObject<TResult>(this string str)
            => JsonSerializer.Deserialize<TResult>(str);

        /// <summary>
        /// 通过密钥key进行加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">密码,默认021228</param>
        /// <param name="encoding">编码,默认UTF-8</param>
        /// <returns>加密后字符串的表达形式</returns>
        static public string Encrypt(this string str, string key="021228", Encoding? encoding=null)
        {
            //确认编码
            encoding ??= Encoding.UTF8;
            //创建密钥与源字符串
            var skey = MD5.HashData(encoding.GetBytes(key)).Clone(2);
            var source = encoding.GetBytes(str);
            //获取创建加密
            var result = AesCryptography.Share.Encrypt(source, skey);
            //转换为Base64形式
            return Convert.ToBase64String(result);
		}

		/// <summary>
		/// 通过密钥key进行解密
		/// </summary>
		/// <param name="str">待解密字符串</param>
		/// <param name="key">密码,默认021228</param>
		/// <param name="encoding">编码,默认UTF-8</param>
		/// <returns>解密后字符串的表达形式</returns>
		static public string Decrypt(this string str, string key="021228", Encoding? encoding= null) 
        {
			//确认编码
			encoding ??= Encoding.UTF8;
            //创建密钥压缩
            var skey = MD5.HashData(encoding.GetBytes(key)).Clone(2);
            var source = Convert.FromBase64String(str);
			//获取创建加密
            var result = AesCryptography.Share.Decrypt(source, skey);
            //返回编码形式
            return encoding.GetString(result);
		}

        /// <summary>
        /// 将源字符串转换为byte数组
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="encoding">编码集,默认为UTF-8</param>
        /// <returns>转换的byte数组</returns>
        static public byte[] ToBytes(this string str, Encoding? encoding=null)
            => (encoding ?? Encoding.UTF8).GetBytes(str);

        /// <summary>
        /// 判断str1和str2是否在小写情况下相同
        /// </summary>
        /// <param name="str1">待比较字符串</param>
        /// <param name="str2">比较字符串</param>
        /// <returns>是否相同</returns>
        static public bool IsSimilar(this string str1, string str2)
        {
            return str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase);
        }

        static public byte[] FromBase64String(this string str)
            => Convert.FromBase64String(str);


    }
}
