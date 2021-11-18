using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QThree
{
    class Collection
    {

        public int FTPCheck(string module)
        {
            module = "ftp://125.145.31.85/" + module + "/";
            var ftpRequest = (FtpWebRequest)WebRequest.Create(module);

            ftpRequest.Timeout = 300000;
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

            ftpRequest.Credentials = new NetworkCredential(Form1.id, Form1.pw); //id,pw 수정할것

            try
            {
                using (var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {

                }
            }
            catch (WebException ex)
            {
                //MessageBox.Show("해당 디렉터리가 없습니다.");
                return 0;
            }
            catch (IndexOutOfRangeException ex)
            {
              //  MessageBox.Show("해당 디렉터리가 없습니다.");
                return 0;
            }
            return 1;
        }


        public string Fileread(string fname)
            {
            byte[] data;
            string url = "ftp://125.145.31.86/Setting_info/"+"benchwdm.sdm";

            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(url);

            req.Credentials = new NetworkCredential(Form1.id, Form1.pw);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            try
            {
                //   using(var localfile = File.Open("benchwdm.sdm",FileMode.Create))
                using (var ftpResponse = (FtpWebResponse)req.GetResponse())
                {
                    //    byte[] buffer = new byte[1024];
                    //    int n;
                    //while ((n = ftpstream.Read(buffer, 0, buffer.Length)) > 0)
                    //{
                    //    localfile.Write(buffer, 0, n);

                    //}
                    BinaryReader reader = new BinaryReader(ftpResponse.GetResponseStream(), Encoding.Default);
                    data = reader.ReadBytes(27);

                }
               // byte[] data = File.ReadAllBytes("benchwdm.sdm");
                string str = bytetohex(data);
                return str;


            }
            catch(WebException ex)
            {
                return "";
            }
            
        }
        public void FileUpload(byte[] fname)
        {
            string url = "ftp://125.145.31.86/Setting_info/" + "benchwdmtest.sdm";

            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(url);

            req.Credentials = new NetworkCredential(Form1.id, Form1.pw);
            req.Method = WebRequestMethods.Ftp.UploadFile;
        //    byte[] data = Encoding.UTF8.GetBytes(fname);
       //     string str = ConvertByteToHexString(data);
            //string str = Encoding.UTF8.GetString(data);
            using (var ftpStream = req.GetRequestStream())
            {
                ftpStream.Write(fname, 0, fname.Length);
            }

            using(var resp = (FtpWebResponse)req.GetResponse())
            {
                MessageBox.Show(resp.StatusDescription);
            }

        }
        public string bytetohex(byte[] a)
        {
            string hex = BitConverter.ToString(a);
            return hex.Replace("-", "");
                
        }
        
        public byte[] ConvertHexStringToByte(string convertString)
        {
            byte[] convertArr = new byte[convertString.Length / 2];

            for (int i = 0; i < convertArr.Length; i++)
            {
                convertArr[i] = Convert.ToByte(convertString.Substring(i * 2,2), 16);
            }
            return convertArr;
        }

        

    }
}
