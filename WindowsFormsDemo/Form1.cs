using Esell.Network;
using Esell.SDK.Config;
using Esell.SDK.Controls;
using Esell.SDK.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {

        AdSlotControl slot;

        AdSlotControl slot2;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放 物联网
            YxfSdkManager.Instance.Dispose();

            if(slot!=null)
            //释放广告位组件
            slot.AdControlDispose();

            if (slot2 != null)
                slot2.AdControlDispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化配置
            ConfigManager.Init();

            // 添加SDK 的广告位。  根据设备类型进行备案---- 由平台控制下发
            ConfigManager.Slots.Add(21465);
            ConfigManager.Slots.Add(21464);


            
            ConfigManager.AppId = "ade3qax24449f80b6";
            ConfigManager.AppKey = "n6b1dls5b7c40ADEQdr3ab1b3c31386";

            //对接方系统设备自己的唯一 标识
            ConfigManager.UniqueCode = "windowsSDk";
            ConfigManager.DeviceName = "windowsSDk";

            //注册SDK
            YxfSdkManager.Instance.Init((initReply=> {

                if (initReply.Code == 0)
                {
                    
                }
            }));


           
            //添加一个广告位
            AdSlotModel adSlotModel = new AdSlotModel();

            //对应上面的SDK 备案的广告位
            adSlotModel.Id = 21465;

            //广告位的分辨率
            adSlotModel.Width = 1920 ;
            adSlotModel.Height = 1080 ;



            slot = new AdSlotControl();
            slot.Init(adSlotModel);

            this.Controls.Add(slot);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.slot.Width = this.slot.Width +100;
            this.slot.Height = this.slot.Height + 100;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.slot.Width = this.slot.Width - 100;
            this.slot.Height = this.slot.Height - 100;
        }
    }
}
