using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMPictureBoxImage : PictureBox
    {

        protected byte[] _Value = null;

        [DesignOnly(false)]
        [Browsable(false)]
        public virtual byte[] Value
        {
            get { return _Value; }
            set
            {

                _Value = value;
                SetBackgroudImg(value);
            }
        }

        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
                SetTextwithImage();
            }
        }

        /// <summary>
        /// 读取图片字节数
        /// </summary>
        /// <param name="_value">图片字节数</param>
        protected void SetBackgroudImg(byte[] data)
        {
            if (data != null)
            {
                try
                {
                    MemoryStream memStream = new MemoryStream(data);
                    this.BackgroundImage = Image.FromStream(memStream);
                    memStream.Close();
                }
                catch { }
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

        /// <summary>
        /// 设置Text默认值
        /// </summary>
        private void SetTextwithImage()
        {
            if (this.BackgroundImage != null && this.Tag == null)
            {
                byte[] bt = null;
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(this.BackgroundImage);

                    bmp.Save(mostream, this.BackgroundImage.RawFormat);//将图像以指定的格式存入缓存内存流

                    bt = new byte[mostream.Length];

                    mostream.Position = 0;//设置留的初始位置

                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));

                }
                _Value = bt;
            }
            else
            {
                _Value = null;
            }
        }

        public static Bitmap GetThumbnail(string _value, int destHeight, int destWidth)
        {
            Bitmap b = new Bitmap(_value);
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放            
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量          
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量      
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }

        /// <summary>
        /// 获取选择图片的字节数
        /// </summary>
        /// <param name="_value">选择图片的值</param>
        private void GetImg(string _value)
        {
            FileStream fs = new FileStream(_value, FileMode.Open, FileAccess.Read);
            byte[] imagebytes = new byte[fs.Length];//fs.Length文件流的长度，用字节表示
            fs.Read(imagebytes, 0, imagebytes.Length);
            fs.Close();
            Value = imagebytes;
        }

        /// <summary>
        /// 获取Bitmap的字节数
        /// </summary>
        /// <param name="b"></param>
        private void GetBitmap(Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();
            ms.Close();
            Value = bytes;
        }

        /// <summary>
        /// 图片单击事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择文件";
            ofd.Filter = "图片|*.JPG;*.JPEG;*.JPE;*.JFIF;*.bmp;*.GIF;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //缩放图片
                this.Tag = null;
                Bitmap bit = GetThumbnail(ofd.FileName, 480, 640);
                GetBitmap(bit);
                //bit.Save("d:\\1234.jpg", ImageFormat.Jpeg);
                //GetImg(ofd.FileName);//获取文件对话框中选定的文件名的字符串，包括文件路径 
            }
        }
    }
}