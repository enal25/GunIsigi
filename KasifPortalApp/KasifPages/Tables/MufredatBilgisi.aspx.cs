﻿using KasifBusiness.Business.KasifPageOperations;
using KasifBusiness.DB_Operations.DBOperations;
using KasifBusiness.DB_Operations.EntityObject;
using KasifBusiness.Objects.ScreenObjects;
using KasifPortalApp.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static KasifBusiness.DB_Operations.DBObjects.ConstDbCommands;

namespace KasifPortalApp.KasifPages.Tables
{
    public partial class MufredatBilgisi : BasePage
    {
        public string pageTitle = "Müfredat Takibi";
        public string standardErr = "İşlem Başarılı";
        public string pageName = "MufredatTakip-page";

        public override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PageOperations PageOps = new PageOperations();
                List<MufredatTakipObj> lstScreenInfoObj = null;
                string[] paramNames = null;
                object[] paramValues = null;
                if (ksfSI.RoleName.ToUpperInvariant() == RoleNames.OGRENCI.ToString() || ksfSI.RoleName.ToUpper() == RoleNames.VELI.ToString())
                {
                    paramNames = new string[] { "P_HOCA_ID" };
                    paramValues = new object[] { ksfSI.HocaGuid };
                    lstScreenInfoObj = PageOps.RunQueryForPage<MufredatTakipObj>(DbCommandList.GET_MUFREDAT_BILGI, paramNames, paramValues);
                }
                else//Hem Hocaların hem de öğrencilerin müfredat bilgilerini getirir.
                {
                    lstScreenInfoObj = PageOps.RunQueryForPage<MufredatTakipObj>(DbCommandList.GET_MUFREDAT_BILGI, null, null);
                }

                tblRepeater.DataSource = lstScreenInfoObj;
                tblRepeater.DataBind();
            }
            catch (Exception ex)
            {
                standardErr = "İşlem gerçekleştirilirken bir hata oluştu.";
                RaisePopUp(ex.Message, ResultStatus.Error);
            }


        }

        private void RaisePopUp(string msg, ResultStatus resultStatus)
        {
            if (resultStatus == ResultStatus.Success)
            {
                String script = "<script>$(document).ready(function () {showSuccessModal('" + pageTitle + "','" + msg + "','" + Page.GetRouteUrl(pageName, null) + "');});</script>";
                ClientScript.RegisterStartupScript(typeof(Page), "ProcessError", script);
            }
            else
            {
                String script = "<script>$(document).ready(function () {showErrorModal('" + pageTitle + " - Hata','" + msg + "');});</script>";
                ClientScript.RegisterStartupScript(typeof(Page), "ProcessError", script);
            }
        }

        public string GenerateAddUrl()
        {
            return Page.GetRouteUrl(pageName + "-add", null);
        }

        [WebMethod()]
        public static string DeleteCurrentRow(string RowGuid)
        {
            try
            {
                MUFREDAT_TAKIP mufBilgiObj = new MUFREDAT_TAKIP();
                mufBilgiObj.GUID = Convert.ToInt64(RowGuid);
                DbOperations.Delete(mufBilgiObj);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected void OnDataBinding(object sender, EventArgs e)
        {
            if (!UtilityScreenFunctions.ControlActionAuthorized(Eval("HOCA_GUID").ToString(), ksfSI))
            {
                ((System.Web.UI.HtmlControls.HtmlContainerControl)sender).InnerHtml = "";
            }
        }
    }
}