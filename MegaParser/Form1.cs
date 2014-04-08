 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace FAMassDownloader
{

    public partial class Form1 : Form
    {
        delegate void DownloadProcess(string Login, string Password, string Link);


        MyWebClient client = null;

        public Form1()
        {
            InitializeComponent();

            client = new MyWebClient();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
   

            if (LoginTextBox.Text != "" && PasswordMaskedTextBox.Text != "")
            {
                if (CapchaText.Text != "")
                {
                    if (client.TryToLogin(LoginTextBox.Text, PasswordMaskedTextBox.Text, CapchaText.Text))
                    {

                       
                        if (client.Gotopayments())
                        {
                            client.GetTableData();
                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show("Сессия была завершена! Пожалуйста, обновите защитный код и авторизуйтесь снова!");
                            timer1.Stop();
                        }
                    }
                    else
                    {
                        timer1.Stop();
                        CapchaPic.ImageLocation = client.GetCapcha();  
                    }
                }
                else MessageBox.Show("Укажите секретное слово!", "Проблема!");

            }
            else
            {
                MessageBox.Show("Укажите свои логин и пароль!", "Проблема!");
            }


        }


       
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            CapchaPic.ImageLocation = client.GetCapcha();  
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CapchaPic.ImageLocation = client.GetCapcha();
           
        }
        public class MyWebClient
        {
           System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
           WebBrowser WB = null;
           public MyWebClient()
            {
                WB = new WebBrowser();
              WB.ScriptErrorsSuppressed = true;
                         }
            System.Windows.Forms.HtmlDocument LoadPage(string url)
            {
                WB.Navigate( url);
                while (WB.ReadyState != WebBrowserReadyState.Complete)
                    System.Windows.Forms.Application.DoEvents();
                    System.Windows.Forms.HtmlDocument doc = WB.Document;
                return doc;
            }

           public string GetCapcha()
            {
               System.Windows.Forms.HtmlDocument doc = LoadPage( "https://volgasg.megafon.ru/");
               HtmlElementCollection collection = doc.Images;
               foreach (HtmlElement a in collection ){
                   if (a.GetAttribute("id") == "cryptogram" ){
                       return a.GetAttribute("src");
                   }
               }
                return null;
            }

           public bool TryToLogin(string Login, string Password, string Capcha)
           {
               WB.Document.GetElementById("LOGIN").InnerText = Login;
               WB.Document.GetElementById("passwdId").InnerText = Password;
               WB.Document.GetElementById("codeId").InnerText = Capcha;
               WB.Document.GetElementById("submitBtnId").InvokeMember("click");
               while (WB.ReadyState != WebBrowserReadyState.Complete)
                   System.Windows.Forms.Application.DoEvents();
               HtmlAgilityPack.HtmlDocument HD = new HtmlAgilityPack.HtmlDocument();

               HD.LoadHtml(((dynamic)WB.Document.DomDocument).documentElement.outerHTML);


               HtmlAgilityPack.HtmlNodeCollection messages = HD.DocumentNode.SelectNodes("//div[@id='divMessage']/div/div/div | //div[@id='passwdId-ErrorMessage']");
              if(messages != null){
                  foreach(HtmlNode n in messages){
                       switch(n.InnerText){
                           case "Введен неверный защитный код.":
                               MessageBox.Show(n.InnerText);
                               return false;
                           break;
                           case "Указан неправильный пароль.":
                               MessageBox.Show(n.InnerText);
                               return false;
                           break;

                       }
                     
                  }
                 
                  return true;
              }
                
               return true;

           }

           public bool Gotopayments()
           {

               while (WB.Document.GetElementById("ACCOUNT_INFO") == null && WB.Document.GetElementById("PAYMENTS_INFO") == null) { Application.DoEvents(); Thread.Sleep(200); }
               if (WB.Document.GetElementById("menu_oper_id_PAYMENTS_INFO") != null || WB.Document.GetElementById("PAYMENTS_INFO") != null)
               {
                   WB.Document.GetElementById("menu_oper_id_PAYMENTS_INFO").InvokeMember("click");
                   return true;
               }
               else
                   return false;

           }

           public void GetTableData()
           {
               while (WB.Document.GetElementById("div_payments") == null) { Application.DoEvents(); Thread.Sleep(200); }
               HtmlAgilityPack.HtmlDocument HD = new HtmlAgilityPack.HtmlDocument();

               HD.LoadHtml(((dynamic)WB.Document.DomDocument).documentElement.outerHTML);
              

               HtmlAgilityPack.HtmlNodeCollection table = HD.DocumentNode.SelectNodes("//div[@id='div_payments']/table/tbody/tr");

               Excel.Application app = new Excel.Application();
               app.Workbooks.Add();            
               Excel.Workbook book = app.ActiveWorkbook;
               Excel.Worksheet sheet = book.Worksheets.get_Item(1);
               int row = 1;
               int column = 1;
               if (table != null)
               {
                   foreach (HtmlAgilityPack.HtmlNode node in table)
                   {
                       HtmlAgilityPack.HtmlNodeCollection cells = node.SelectNodes("td");
                       foreach (HtmlAgilityPack.HtmlNode cell in cells)
                       {
                           HtmlAgilityPack.HtmlNodeCollection strings = cell.SelectNodes("div");
                           if (strings.Count > 1)
                           {
                               string result = "";
                               foreach (HtmlAgilityPack.HtmlNode a in strings)
                               {
                                   result += a.InnerText+" ";
                               }
                               sheet.Cells[row, column] = result;

                           }
                           else sheet.Cells[row, column] = strings[0].InnerText;


                           column++;
                       }
                       column = 1;
                       row++;
                   }



               }


             
               app.DisplayAlerts = false;
               book.SaveAs(  Application.StartupPath+"/Data",  Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared ,  Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
               book.Close();
               app.Quit();
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Gotopayments();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (client.Gotopayments())
            {
                client.GetTableData();
            }
            else
            {
                MessageBox.Show("Сессия была завершена! Пожалуйста, обновите защитный код и авторизуйтесь снова!");
            }
        }
    }
}
