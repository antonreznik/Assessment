<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="assessment_platform_developer.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> RPM Platform Developer Assessment</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
            <div class="container body-content">
                <a class="navbar-brand" runat="server" href="~/">RPM Platform Developer Assessment</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link" runat="server" href="~/">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" runat="server" href="~/Customers">Customers</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div>
            <div class="container body-content">
                <h2>Customer Registry</h2>
                <asp:DropDownList runat="server" ID="CustomersDDL" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="CustomerDropDownList_SelectedIndexChanged" />
            </div>

            <div class="container body-content">
                <div class="card">

                    <div class="card-body">

                        <div class="row justify-content-center">

                            <div class="col-md-6">
                                <h1><asp:Literal ID="PageTitle" runat="server" /></h1>
                                <div class="form-group">
                                    <asp:Label ID="CustomerNameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="CustomerNameRequiredValidator" runat="server" ControlToValidate="CustomerName"
                                        ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerAddressLabel" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="CustomerAddressRequiredValidator" runat="server" ControlToValidate="CustomerAddress"
                                        ErrorMessage="Address is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerEmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="CustomerEmailRequiredValidator" runat="server" ControlToValidate="CustomerEmail"
                                        ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="customer" ID="CustomerEmailRegexValidator" runat="server" ControlToValidate="CustomerEmail"
                                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid email format." CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerPhoneLabel" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="CustomerPhoneRequiredValidator" runat="server" ControlToValidate="CustomerPhone"
                                        ErrorMessage="Phone number is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="customer" ID="CustomerPhoneRegexValidator" runat="server" ControlToValidate="CustomerPhone"
                                        ValidationExpression="^\d{10}$" ErrorMessage="Phone number must be 10 digits." CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerCityLabel" runat="server" Text="City" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerCity" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="CustomerCityRequiredValidator" runat="server" ControlToValidate="CustomerCity"
                                        ErrorMessage="City is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="customer" ID="CustomerCityRegexValidator" runat="server" ControlToValidate="CustomerCity"
                                        ValidationExpression="^[a-zA-Z\s]+$" ErrorMessage="City can only contain letters and spaces." CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerStateLabel" runat="server" Text="Province/State" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="StateDropDownList" runat="server" CssClass="form-control" />
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerZipLabel" runat="server" Text="Postal/Zip Code" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerZip" ValidateEmptyText="True"  runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="CustomerZipRequiredValidator" runat="server" ControlToValidate="CustomerZip"
                                        ErrorMessage="Postal Code/ZIP is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ValidationGroup="customer" ID="CustomZipValidator" runat="server" ControlToValidate="CustomerZip"
                                        ErrorMessage="Invalid ZIP code." CssClass="text-danger" Display="Dynamic" 
                                        OnServerValidate="CustomZipValidator_ServerValidate"></asp:CustomValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerCountryLabel" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="CountryDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="CountryDropDownList_SelectedIndexChanged" />
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="CustomerNotesLabel" runat="server" Text="Notes" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="CustomerNotes" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <h1>Customer contact details</h1>

                                <div class="form-group">
                                    <asp:Label ID="ContactNameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="ContactName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="ContactNameRequiredValidator" runat="server" ControlToValidate="ContactName"
                                        ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="ContactEmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="ContactEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="ContactEmailRequiredValidator" runat="server" ControlToValidate="ContactEmail"
                                        ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="customer" ID="ContactEmailRegexValidator" runat="server" ControlToValidate="ContactEmail"
                                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid email format." CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="ContactPhoneLabel" class="col-form-label" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="ContactPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="customer" ID="ContactPhoneRequiredValidator" runat="server" ControlToValidate="ContactPhone"
                                        ErrorMessage="Phone number is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="customer" ID="ContactPhoneRegexValidator" runat="server" ControlToValidate="ContactPhone"
                                       ValidationExpression="^\d{10}$" ErrorMessage="Phone number must be 10 digits." CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="AddButton" ValidationGroup="customer" class="btn btn-primary btn-md" runat="server" Text="Add" OnClick="AddButton_Click" />
                                    <asp:Button ID="UpdateButton" class="btn btn-primary btn-md" runat="server" Visible="false" Text="Upate" OnClick="UpdateButton_Click" />
                                    <asp:Button ID="DeleteButton" class="btn btn-primary btn-md" runat="server" Visible="false" Text="Delete" CausesValidation="false" OnClick="DeleteButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
