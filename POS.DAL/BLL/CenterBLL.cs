using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using POS.DAL;
using System.Collections.Generic; 
using System.Transactions;
namespace POS.BLL
{
    public class CenterBLL
    {

        public static int Add(Center newCenter)
        {
            int i = 0;
            //DBTransaction transaction = new DBTransaction();
            //transaction.Begin();

            //if (newCenter.RFRAISERYN == "Y")
            //{
            //    RFRaiser raiser = new RFRaiser();
            //    raiser.RFRAISERCODE = newCenter.CENTERCODE;
            //    raiser.LOCATIONID = newCenter.LOCATIONID;
            //    raiser.SEGMENTNAME = newCenter.CENTERNAME;
            //    raiser.SEGMENTTYPE = newCenter.CENTERTYPEID.ToString();
            //    i = DAL_RFRAISER.SaveItem(raiser, "I",transaction);
            //}
            //if (i < 0)
            //{
            //    transaction.RollBack();
            //    return i;
            //}
            //  newCenter.RFRAISERID = i;
            //i = DAL_CENTER.SaveItem(newCenter, "I",transaction);
            //if (i < 0)
            //{
            //    transaction.RollBack();
            //    return i;
            //}

            //transaction.Commit();

            return i;
        }
        public static int Edit(Center newCenter)
        {
            int i = 0;
            //DBTransaction transaction = new DBTransaction();
            //transaction.Begin();

            //if (newCenter.RFRAISERYN == "N" && newCenter.RFRAISERID > 0)
            //{
            //    i = DAL_RFRAISER.SaveItem(new RFRaiser { RFRAISERID = newCenter.RFRAISERID }, "D", transaction);
            //    newCenter.RFRAISERID = 0;
                
            //}
            //else if (newCenter.RFRAISERYN == "Y" )
            //{
            //    RFRaiser raiser = new RFRaiser();
            //    raiser.RFRAISERCODE = newCenter.CENTERCODE;
            //    raiser.LOCATIONID = newCenter.LOCATIONID;
            //    raiser.SEGMENTNAME = newCenter.CENTERNAME;
            //    raiser.SEGMENTTYPE = newCenter.CENTERTYPEID.ToString();
            //    if (newCenter.RFRAISERID == 0)
            //    {
            //        i = DAL_RFRAISER.SaveItem(raiser, "I", transaction);
            //        newCenter.RFRAISERID = i;
            //    }
            //    else
            //    {
            //        raiser.RFRAISERID = newCenter.RFRAISERID;
            //        i = DAL_RFRAISER.SaveItem(raiser, "U", transaction);
            //    }
            //}

            //if (i < 0)
            //{
            //    transaction.RollBack();
            //    return i;
            //}
            
            //i= DAL_CENTER.SaveItem(newCenter, "U",transaction);

            //if (i < 0)
            //{
            //    transaction.RollBack();
            //    return i;
            //}
            //transaction.Commit();

            return i;
            
        }
        public static int Delete(int Centerid)
        {
            int i = 0;
           // DBTransaction transaction = new DBTransaction();
           // transaction.Begin();


           // Center center = getCenterById(Centerid);
           // if (center.CENTERID < 1)
           // {
           //     return 0;
           // }
           // if (center.RFRAISERID > 0)
           // {
           //    i= DAL_RFRAISER.SaveItem(new RFRaiser { RFRAISERID = center.RFRAISERID }, "D", transaction);
           // }
           // if (i < 0)
           // {
           //     transaction.RollBack();
           //     return i;
           // }

           //i= DAL_CENTER.SaveItem(center, "D",transaction);
           //if (i < 0)
           //{
           //    transaction.RollBack();
           //    return i;
           //}
           //transaction.Commit();

           return i;
           
        }

        //public static int AddCenterToBankAccount(List<BankAccountCenter> bankAccountCenterList)
        //{
        //    BankAccountCenter bankAccountCenter = new BankAccountCenter();
        //    bankAccountCenter.ACCOUNTID = bankAccountCenterList[0].ACCOUNTID;

        //    int errorCode = 0;
        //    DBTransaction transaction = new DBTransaction();
        //    transaction.Begin();

        //    //delete all the center belongs to the bank
        //    errorCode = DAL_BANKACCOUNTCENTER.SaveItem(bankAccountCenter, "D");
        //    //if data deleted succesfully then start insertion
        //    if (errorCode >= 0)
        //    {
        //        foreach (BankAccountCenter item in bankAccountCenterList)
        //        {
        //            errorCode = DAL_BANKACCOUNTCENTER.SaveItem(item, "I");
        //            if (errorCode < 0)
        //            {
        //                transaction.RollBack();                      
        //                return errorCode;
        //            }//end if

        //        }//end foreach
        //    }//end if
        //    else
        //    {
        //        transaction.RollBack();                
        //        return errorCode;
        //    }//end else

        //    transaction.Commit();            
        //    return errorCode;
            
        //}

        public static List<Center> getCenter(int CENTERID, int CENTERTYPEID, int CENTERSUBTYPEID, string CENTERNAME)
        {
            return DAL_CENTER.GetItemList(CENTERID, CENTERTYPEID, CENTERSUBTYPEID, CENTERNAME,-1);
        }

        public static List<Center> CenterGetByBankAccountId(int ACCOUNTID)
        {
            return DAL_CENTER.GetItemList(-1, -1, -1, "", ACCOUNTID);
        }
        
        public static Center getCenterById(int Centerid)
        {
            List<Center> center = DAL_CENTER.GetItemList(Centerid,-1,-1,"",-1);
            if (center.Count == 1)
            {
                return center[0];
            }

            return new Center(); 
        }
        public static Center getCenterDetailById(int Centerid)
        {
            Center center = DAL_CENTER.GetCenterDetail(Centerid);
            return center;
        }
        //public static List<CenterType> getCenterType()
        //{
        //    return DAL_CENTERTYPE.GetItemList(-1);
        //}

        //public static List<CenterSubType> getCenterSubType(int CenterTypeID)
        //{
        //    return DAL_CENTERSUBTYPE.GetItemList(-1,CenterTypeID);
        //}

        //public static List<ShopOpeningClosing> GetOpeningClosing(int shopId,DateTime date)
        //{
        //    return DAL_SHOPOPENINGCLOSING.GetItemList(0, shopId, date);
        //}

        public static int ShopReopen(int shopId, DateTime date, string reopenBy)
        {
            //List<ShopOpeningClosing> lst = GetOpeningClosing(shopId, date);
            //if (lst.Count > 0)
            //{
            //    ShopOpeningClosing temp = lst[0];
            //    temp.CLOSINGTIME = DateTime.MinValue;
            //    temp.REOPENBY = reopenBy;
            //    return DAL_SHOPOPENINGCLOSING.SaveItem(temp, "U");
            //}

            return -1;
        }
    }
}
