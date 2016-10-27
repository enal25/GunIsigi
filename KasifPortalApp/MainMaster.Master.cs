﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KasifPortalApp
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        public string pageTitle;
        public string brandUrl;
        public string btnOk="Tamam";

        protected void Page_Load(object sender, EventArgs e)
        {
            brandUrl = Page.GetRouteUrl("home-page", null);
        }
    }
}