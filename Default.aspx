<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="DynamicDataTest._Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />

    <div class="panel panel-default">
        <div class="panel-heading">Entities </div>
        <div class="panel-body">
            <div class="table-responsive">

                <asp:GridView ID="Menu1" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered table-hover" CellPadding="6">
                    <Columns>
                        <asp:TemplateField HeaderText="Entity Name" SortExpression="TableName">
                            <ItemTemplate>
                                <asp:DynamicHyperLink ID="HyperLink1" runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>


