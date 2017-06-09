﻿using KasifBusiness.Business.KasifPageOperations;
using KasifBusiness.DB_Operations.DBOperations;
using KasifBusiness.DB_Operations.EntityObject;
using KasifBusiness.Objects.ScreenObjects;
using KasifBusiness.Utilities;
using KasifPortalApp.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using static KasifBusiness.DB_Operations.DBObjects.ConstDbCommands;

namespace KasifPortalApp.KasifPages.Tables
{
    public partial class OgrenciBilgisi : BasePage
    {
        public string pageTitle = "Öğrenci Bilgisi";
        public string standardErr = "İşlem Başarılı";
        public string pageName = "OgrBilgi-page";
        public string deleteUrl = "";

        public override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                deleteUrl = pageName + "/DeleteCurrentRow";
                PageOperations PageOps = new PageOperations();
                List<PageOgrBilgiObj> lstScreenInfoObj = null;

                if (ksfSI.RoleName.ToUpperInvariant() == RoleNames.HOCA.ToString())
                {
                    lstScreenInfoObj = PageOps.RunQueryForPage<PageOgrBilgiObj>(DbCommandList.GET_PAGE_OGR_BILGI,
                                                                                new string[] { "P_HOCA_ID" },
                                                                                new object[] { ksfSI.HocaGuid });
                }
                else if (ksfSI.RoleName.ToUpperInvariant() == RoleNames.OGRENCI.ToString() || ksfSI.RoleName.ToUpperInvariant() == RoleNames.VELI.ToString())
                {
                    lstScreenInfoObj = PageOps.RunQueryForPage<PageOgrBilgiObj>(DbCommandList.GET_PAGE_OGR_BILGI,
                                                                                new string[] { "P_OGR_ID" },
                                                                                new object[] { ksfSI.OgrenciGuid });
                }
                else//Tüm öğrencileri getirir.
                {
                    lstScreenInfoObj = PageOps.RunQueryForPage<PageOgrBilgiObj>(DbCommandList.GET_PAGE_OGR_BILGI, null, null);
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

        public string GenerateEditUrl(string key)
        {
            key = KasifHelper.EncryptStringToBytes_Aes(key);
            return Page.GetRouteUrl(pageName + "-edit", new { param = key });
        }

        [WebMethod()]
        public static string DeleteCurrentRow(string RowGuid)
        {
            try
            {
                OGR_BILGI ogrBilgiObj = new OGR_BILGI();
                ogrBilgiObj.GUID = Convert.ToInt64(RowGuid);
                DbOperations.Delete(ogrBilgiObj);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}