﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="UserTable.aspx.cs" Inherits="KasifPortalApp.Management.Tables.UserTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            DtInit();
            $('.delete').click(function (event) {
                event.preventDefault();
                var postData = {
                    "RowGuid":this.getAttribute('dataId'),
                    "RoleGuid":this.getAttribute('dataRoleGuid')
                };
                $.ajax({
                    type: "POST",
                    url: "<%= ResolveClientUrl("~/Management/Tables/UserTable.aspx/DeleteCurrentRow") %>",
                    data: JSON.stringify(postData),
                    contentType: "application/json; charset=utf-8",
                    dataType: "JSON",
                    success: function (result) {
                        alert(result.d);
                        window.location="<%=Page.GetRouteUrl(pageName,null)%>"
                    },
                    failure: function (result) {
                        alert('error');
                    },
                    error: function (result) {
                        alert('error');
                    }
                });

            });
        });

        function DtInit() {
            var oTable = $('#dtTable').dataTable();

            $('.dataTables_filter input').attr("placeholder", "Ara...");
            $(".dataTables_length select").wrap("<div class='input-mini'></div>").chosen({
                disable_search_threshold: 9999999
            });
            $.datepicker.setDefaults({
                dateFormat: "dd-mm-yy"
            });
            oTable.columnFilter({
                "sPlaceHolder": "head:after",
                'sRangeFormat': "{from}{to}",
                'aoColumns': [
                    null,
                    {
                        type: "text",
                    },
                    {
                        type: "text",
                    },
                    {
                        type: "select",
                        bCaseSensitive: true,
                        values: ['Evet','Hayir'],
                    },
                    {
                        type: "text",
                    },
                    {
                        type: "select",
                        bCaseSensitive: true,
                        values: ['5', '6', '7', '8'],
                    },
                    {
                        type: "text",
                    },
                    {
                        type: "text",
                    },
                    {
                        type: "text",
                    },
                    {
                        type: "text",
                    },
                    {
                        type: "text",
                    }
                ]
            });
            $(".dataTable").css("width", '100%');
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <h3>Kullanıcı Bilgisi</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">

    <div class="span12">
        <div class="box box-color box-bordered">
            <div class="box-title">
                <h3 class="pull-left"><i class="icon-table"></i><%=pageTitle %></h3>
                <div class="action pull-right">
                    <a href="<%=GenerateAddUrl()%>" class="btn btn-darkblue" style="padding: 10px; margin-right: 10px;"><i class=" icon-plus" style="margin-right: 10px;"></i>Yeni Ekle</a>
                </div>

            </div>
            <div class="box-content nopadding">
                <asp:Repeater ID="tblRepeater" runat="server">
                    <HeaderTemplate>
                        <table id="dtTable" class="dataTable-scroll-x table table-hover table-nomargin table-bordered usertable dataTable">
                            <thead>
                                <tr class='thefilter'>
                                    <th>Seçenekler</th>
                                    <th>Adı Soyadı</th>
                                    <th>Email</th>
                                    <th>Admin mi?</th>
                                    <th>Rol</th>
                                    <th>Sınıf</th>
                                    <th>Mahalle</th>
                                    <th>Ekleyen</th>
                                    <th>Kayıt Tarihi</th>
                                    <th>Son Giriş</th>
                                    <th>Durum</th>
                                </tr>
                                <tr>
                                    <th>Seçenekler</th>
                                    <th>Adı Soyadı</th>
                                    <th>Email</th>
                                    <th>Admin mi?</th>
                                    <th>Rol</th>
                                    <th>Sınıf</th>
                                    <th>Mahalle</th>
                                    <th>Ekleyen</th>
                                    <th>Kayıt Tarihi</th>
                                    <th>Son Giriş</th>
                                    <th>Durum</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href="#" class="btn" rel="tooltip" title="View"><i class="icon-search"></i></a>
                                <a href="#" class="btn" rel="tooltip" title="Edit"><i class="icon-edit"></i></a>
                                <a class="btn delete" rel="tooltip" title="Delete" dataRoleGuid ="<%#DataBinder.Eval(Container.DataItem,"ROLE_GUID").ToString().Trim() %>" dataId="<%#DataBinder.Eval(Container.DataItem,"GUID").ToString().Trim() %>"><i class="icon-remove"></i></a>
                            </td>
                            <td><%#DataBinder.Eval(Container.DataItem,"NAME").ToString().Trim()%> <%# DataBinder.Eval(Container.DataItem,"SURNAME") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"EMAIL").ToString().Trim() %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"IS_ADMIN").ToString().Trim() %> </td>
                            <td><%#DataBinder.Eval(Container.DataItem,"ROLE_NAME").ToString().Trim() %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"SINIF")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"BOLGE_ADI") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"INSERT_USER") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"INSERT_DATE")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"LAST_LOGIN_DATE") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"USER_STATUS")%></td>

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody></table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>


</asp:Content>
