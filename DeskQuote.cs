using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MegaDesk_Stratton
{
    public class DeskQuote
    {
        public string custName { get; set; }
        public int rush { get; set; }
        public Desk Desk { get; set; }

        private int quote;
        private const int BASECOST = 200;
        private const int PERDRAWER = 50;
        private const int OVERSIZESURFACE = 1;
        private const int OVERSIZESTARTNUM = 1000;
        private const int OVERSIZEHIGHNUM = 2000;
        private DateTime date;
        public DeskQuote()
        {
        }

        public DeskQuote(string customName, int orderOptions, Desk desk)
        {
            this.custName = customName;
            this.rush = orderOptions;
            this.Desk = desk;
        }
        
        public string GetCustName() { return this.custName; }
        public void SetCustName(string name) { custName = name; }
        public void SetDate(DateTime date)
        {
            this.date = date;
        }
        public DateTime GetDate() { return date; }

        public int GetRush() { return rush; }
        public void SetRush(int rushNum) {  rush= rushNum; }
       public void SetDesk(Desk desk) { Desk = desk; }
        public Desk GetDesk() { return Desk; }

        public int GetQuote() { return quote; }
        public void setQuote() { quote = AreaTotalCost() + CalcDrawerCost() + CalcRushCost() + CalcSurfaceCost(); }

        public int AreaTotalCost()
        {
            int oversizedArea = 0;
            if (Desk.GetArea() > OVERSIZESTARTNUM)
            {
                oversizedArea = Desk.GetArea() - OVERSIZESTARTNUM;
            }
                return BASECOST + (OVERSIZESURFACE * oversizedArea);
            
        }
        public int CalcDrawerCost()
        {
            return PERDRAWER * Desk.GetDrawerCount();
        }
        public int CalcRushCost() {
            int[,] rushOrderPriceMap = GetRushOrder();
            int result = 0;
            switch(rush)
            { case 3:
                    if (Desk.GetArea() < OVERSIZESTARTNUM) result = rushOrderPriceMap[0,0];
                    else if (Desk.GetArea() > OVERSIZESTARTNUM && Desk.GetArea() < OVERSIZEHIGHNUM) result = rushOrderPriceMap[0,1];
                    else result = rushOrderPriceMap[0,2];
                    break;
                case 5:
                    if (Desk.GetArea() < OVERSIZESTARTNUM) result = rushOrderPriceMap[1,0];
                    else if (Desk.GetArea() > OVERSIZESTARTNUM && Desk.GetArea() < OVERSIZEHIGHNUM) result = rushOrderPriceMap[1,1];
                    else result = rushOrderPriceMap[1,2];
                    break;
                case 7:
                    if (Desk.GetArea() < OVERSIZESTARTNUM) result = rushOrderPriceMap[2,0];
                    else if (Desk.GetArea() > OVERSIZESTARTNUM && Desk.GetArea() < OVERSIZEHIGHNUM) result = rushOrderPriceMap[2,1];
                    else result =rushOrderPriceMap[2,2];
                    break;
                 default: 
                    result = 0;
                    break;

            }
            return result;
        }
        public int CalcSurfaceCost()
        {
            List<int> materialPriceList = new List<int>() { 200, 100, 50, 300, 125 };
            int result = 0; 
            switch (Desk.GetDesktopMaterial()) 
            { 
                case DesktopMaterial.laminate: result = materialPriceList[1]; break; 
                case DesktopMaterial.oak: result = materialPriceList[0]; break; 
                case DesktopMaterial.pine: result = materialPriceList[2]; break; 
                case DesktopMaterial.rosewood: result = materialPriceList[3]; break; 
                case DesktopMaterial.veneer: result = materialPriceList[4]; break;
        } return result;
            
            
}
        public int CalcSurfaceCost(string selectedSurface)
        {
            int result = 0;
            switch (selectedSurface)
            {
                case "laminate": result = 100; break;
                case "oak": result = 200; break;
                case "pine": result = 50; break;
                case "rosewood": result = 300; break;
                case "veneer": result = 125; break;
            }
            return result;

        }

        public override string ToString()
        {
            return base.ToString()+"\n"+
               "name:" + GetCustName();
        }

        public int[,] GetRushOrder()
        {
            string[] rushPriceStrings = File.ReadAllLines("..\\..\\rushOrderPrices.txt");

            List<int> rushPricesList = new List<int>();

            for (int i = 0; i < rushPriceStrings.Length; i++)
            {
                rushPricesList.Add(Int16.Parse(rushPriceStrings[i]));
            }

            int[,] rushPriceMap = new int[3, 3];

            try
            {
                foreach (int price in rushPricesList)
                {
                    if (rush == 3)
                    {
                        if (Desk.GetArea() < OVERSIZESTARTNUM)
                            rushPriceMap[0, 0] = rushPricesList[0];
                        else if (Desk.GetArea() > OVERSIZESTARTNUM && Desk.GetArea() < OVERSIZEHIGHNUM)
                            rushPriceMap[0, 1] = rushPricesList[1];
                        else
                            rushPriceMap[0, 2] = rushPricesList[2];
                    }
                    else if (rush == 5)
                    {
                        if (Desk.GetArea() < OVERSIZESTARTNUM)
                            rushPriceMap[1, 0] = rushPricesList[3];
                        else if (Desk.GetArea() > OVERSIZESTARTNUM && Desk.GetArea() < OVERSIZEHIGHNUM)
                            rushPriceMap[1, 1] = rushPricesList[4];
                        else
                            rushPriceMap[1, 2] = rushPricesList[5];
                    }
                    else if (rush == 7)
                    {
                        if (Desk.GetArea() < OVERSIZESTARTNUM)
                            rushPriceMap[2, 0] = rushPricesList[6];
                        else if (Desk.GetArea() > OVERSIZESTARTNUM && Desk.GetArea() < OVERSIZEHIGHNUM)
                            rushPriceMap[2, 1] = rushPricesList[7];
                        else
                            rushPriceMap[2, 2] = rushPricesList[8];
                    }
                }
                
            }
            catch
            {
                
            }

            return rushPriceMap;
        }

    }
}
