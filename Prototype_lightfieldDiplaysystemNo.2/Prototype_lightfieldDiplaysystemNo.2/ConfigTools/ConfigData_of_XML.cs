using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.Xml;

namespace Prototype_lightfieldDiplaysystemNo2.ConfigTools
{
    public class ConfigData_of_XML
    {
        #region 属性参数

        #region subviewport与mecrohole参数
        /// <summary>
        /// subviewport的宽度
        /// </summary>
        public int subViewportWidth;
        /// <summary>
        /// subviewport高度
        /// </summary>
        public int subViewportHeight;
        /// <summary>
        /// 微孔宽度
        /// </summary>
        public int mecroholeWidth;
        /// <summary>
        /// 微孔高度
        /// </summary>
        public int mecroholeHeight;
        #endregion
        
        #region 屏幕参数
        /// <summary>
        /// 主屏幕水平像素数
        /// </summary>
        public int screenOneWidth_pixel;
        /// <summary>
        /// 主屏幕宽度，单位毫米
        /// </summary>
        public float screenOneWidth;
        /// <summary>
        /// 主屏幕垂直像素数
        /// </summary>
        public int screenOneHeight_pixel;
        /// <summary>
        /// 主屏幕高度，单位毫米
        /// </summary>
        public float screenOneHeight;
        /// <summary>
        /// 次屏幕水平像素数
        /// </summary>
        public int screenTwoWidth_pixel;
        /// <summary>
        /// 次屏幕宽度，单位毫米
        /// </summary>
        public float screenTwoWidth;
        /// <summary>
        /// 次屏幕垂直像素数
        /// </summary>
        public int screenTwoHeight_pixel;
        /// <summary>
        /// 主屏幕高度，单位毫米
        /// </summary>
        public float screenTwoHeight;
        /// <summary>
        /// 次屏幕水平方向与主屏幕位置关系，向左为负，单位毫米
        /// </summary>
        public float screenOffsetX;
        /// <summary>
        /// 次屏幕垂直方向与主屏幕位置关系，向上为负，单位毫米
        /// </summary>
        public float screenOffsetY;
        /// <summary>
        /// 屏幕间距，单位毫米
        /// </summary>
        public float widthBetweenScreens;
        /// <summary>
        /// 两层屏幕是否规格相同
        /// </summary>
        public bool isScreensEqual_to_EachOther;
        #endregion

        #region 显示区域
        public int displayzone_left_pixel;
        public int displayzone_top_pixel;
        public int displayzone_width_pixel;
        public int displayzone_height_pixel;
        #endregion

        #region 其他
        public bool isScaningEnabled;
        public bool isMecroholeEnabled;
        #endregion

        #endregion

        public ConfigData_of_XML()
        {  
            screenOneWidth_pixel = 1366;
            screenOneWidth = 310.0f;
            screenOneHeight_pixel = 768;
            screenOneHeight = 174.0f;
            screenTwoWidth_pixel = 1024;
            screenTwoWidth = 305.0f;
            screenTwoHeight_pixel = 768;
            screenTwoHeight = 228.0f;
            screenOffsetX = -0f;
            screenOffsetY = -0f;
            widthBetweenScreens = 8.0f;

            displayzone_left_pixel = 50;
            displayzone_top_pixel = 50;
            displayzone_width_pixel = 1200;
            displayzone_height_pixel = 700;

            subViewportWidth = 16;
            subViewportHeight = 16;
            mecroholeWidth = 2;
            mecroholeHeight = 2;

            isScaningEnabled = false;
            isMecroholeEnabled = false;

            isScreensEqual_to_EachOther = false;
            
        }

        /// <summary>
        /// 以特定的文件名或者路径读取XML格式的配置文件。注意，如果该文件不存在将被创建。
        /// </summary>
        /// <param name="nameOfXMLfile"></param>
        public void LoadFromFile(string nameOfXMLfile)
        {
            //尝试读取文件，如果读取文件不成功则创建新的配置文件
            try
            {
                XmlDocument configDataFile = new XmlDocument();
                configDataFile.Load(nameOfXMLfile);
                XmlNode startNode = configDataFile.SelectSingleNode("PrototypeConfigDataForStart");

                this.screenOneWidth_pixel = int.Parse(startNode.SelectSingleNode("screenOneWidth_pixel").InnerText);
                this.screenOneWidth = float.Parse(startNode.SelectSingleNode("screenOneWidth").InnerText);
                this.screenOneHeight_pixel = int.Parse(startNode.SelectSingleNode("screenOneHeight_pixel").InnerText);
                this.screenOneHeight = float.Parse(startNode.SelectSingleNode("screenOneHeight").InnerText);
                this.screenTwoWidth_pixel = int.Parse(startNode.SelectSingleNode("screenTwoWidth_pixel").InnerText);
                this.screenTwoWidth = float.Parse(startNode.SelectSingleNode("screenTwoWidth").InnerText);
                this.screenTwoHeight_pixel = int.Parse(startNode.SelectSingleNode("screenTwoHeight_pixel").InnerText);
                this.screenTwoHeight = float.Parse(startNode.SelectSingleNode("screenTwoHeight").InnerText);
                this.screenOffsetX = float.Parse(startNode.SelectSingleNode("screenOffsetX").InnerText);
                this.screenOffsetY = float.Parse(startNode.SelectSingleNode("screenOffsetY").InnerText);
                this.widthBetweenScreens = float.Parse(startNode.SelectSingleNode("widthBetweenScreens").InnerText);
                
                this.displayzone_left_pixel = int.Parse(startNode.SelectSingleNode("displayzone_left_pixel").InnerText);
                this.displayzone_top_pixel = int.Parse(startNode.SelectSingleNode("displayzone_top_pixel").InnerText);
                this.displayzone_width_pixel = int.Parse(startNode.SelectSingleNode("displayzone_width_pixel").InnerText);
                this.displayzone_height_pixel = int.Parse(startNode.SelectSingleNode("displayzone_height_pixel").InnerText); 
                
                this.subViewportWidth = int.Parse(startNode.SelectSingleNode("subViewportWidth").InnerText);
                this.subViewportHeight = int.Parse(startNode.SelectSingleNode("subViewportHeight").InnerText);
                this.mecroholeWidth = int.Parse(startNode.SelectSingleNode("mecroholeWidth").InnerText);
                this.mecroholeHeight = int.Parse(startNode.SelectSingleNode("mecroholeHeight").InnerText);

                this.isScaningEnabled = bool.Parse(startNode.SelectSingleNode("isScaningEnabled").InnerText);
                this.isMecroholeEnabled = bool.Parse(startNode.SelectSingleNode("isMecroholeEnabled").InnerText);

                this.isScreensEqual_to_EachOther = 
                    (screenOneHeight == screenTwoHeight && 
                    screenOneWidth == screenTwoWidth && 
                    screenOneWidth_pixel == screenTwoWidth_pixel && 
                    screenOneHeight_pixel == screenTwoHeight_pixel);

                Console.WriteLine("update succeed");
            }
            catch
            {
                Console.WriteLine("load failed");
                this.SaveConfigDataToFile(nameOfXMLfile);
                Console.WriteLine("New file was created");
            }
        }

        /// <summary>
        /// 使用该类实例化后初始化数据或者修改过的数据以特定文件名保存为XML文件
        /// </summary>
        /// <param name="nameOfXMLfile"></param>
        public void SaveConfigDataToFile(string nameOfXMLfile)
        {
            //XmlDocument configDataFile = new XmlDocument();
            XmlWriterSettings configDataWriterSettings = new XmlWriterSettings();
            configDataWriterSettings.Indent = true;
            configDataWriterSettings.IndentChars = ("    ");

            try
            {
                XmlWriter configDataWriter = XmlWriter.Create(nameOfXMLfile, configDataWriterSettings);

                // Write XML data.写入配置参数

                configDataWriter.WriteStartElement("PrototypeConfigDataForStart");

                configDataWriter.WriteElementString("screenOneWidth_pixel", this.screenOneWidth_pixel.ToString());
                configDataWriter.WriteElementString("screenOneWidth", this.screenOneWidth.ToString());
                configDataWriter.WriteElementString("screenOneHeight_pixel", this.screenOneHeight_pixel.ToString());
                configDataWriter.WriteElementString("screenOneHeight", this.screenOneHeight.ToString());
                configDataWriter.WriteElementString("screenTwoWidth_pixel", this.screenTwoWidth_pixel.ToString());
                configDataWriter.WriteElementString("screenTwoWidth", this.screenTwoWidth.ToString());
                configDataWriter.WriteElementString("screenTwoHeight_pixel", this.screenTwoHeight_pixel.ToString());
                configDataWriter.WriteElementString("screenTwoHeight", this.screenTwoHeight.ToString());
                configDataWriter.WriteElementString("screenOffsetX", this.screenOffsetX.ToString());
                configDataWriter.WriteElementString("screenOffsetY", this.screenOffsetY.ToString());
                configDataWriter.WriteElementString("widthBetweenScreens", this.widthBetweenScreens.ToString());

                configDataWriter.WriteElementString("displayzone_left_pixel", this.displayzone_left_pixel.ToString());
                configDataWriter.WriteElementString("displayzone_top_pixel", this.displayzone_top_pixel.ToString());
                configDataWriter.WriteElementString("displayzone_width_pixel", this.displayzone_width_pixel.ToString());
                configDataWriter.WriteElementString("displayzone_height_pixel", this.displayzone_height_pixel.ToString());

                configDataWriter.WriteElementString("subViewportWidth", this.subViewportWidth.ToString());
                configDataWriter.WriteElementString("subViewportHeight", this.subViewportHeight.ToString());
                configDataWriter.WriteElementString("mecroholeWidth", this.mecroholeWidth.ToString());
                configDataWriter.WriteElementString("mecroholeHeight", this.mecroholeHeight.ToString());

                configDataWriter.WriteElementString("isScaningEnabled", this.isScaningEnabled.ToString());
                configDataWriter.WriteElementString("isMecroholeEnabled", this.isMecroholeEnabled.ToString());

                configDataWriter.WriteEndElement();
                configDataWriter.Flush();
                configDataWriter.Close();

                Console.WriteLine("Save succeeded");
            }
            catch
            {
                Console.WriteLine("Save failed");
            }
        }
       
    }
}
