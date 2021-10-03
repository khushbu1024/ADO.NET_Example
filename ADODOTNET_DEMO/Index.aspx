<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ADODOTNET_DEMO.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"  >
    <div >
    
        <table class="auto-style1" >
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblFname" runat="server" Text="First Name" class="form-control" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFname" runat="server" class="input-group-text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblLname" runat="server" Text="Last Name" class="form-control" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLname" runat="server" class="input-group-text" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblSalary" runat="server" Text="Base Salary" class="form-control"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSalary" runat="server" class="input-group-text" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblAge" runat="server" Text="Age" class="form-control"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" class="input-group-text" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRest" runat="server" Text="Reset" class="btn btn-outline-danger btn-rounded" OnClick="btnRest_Click" />
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-outline-success btn-rounded" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
        
    </div>
        <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView id="gvEmpdata" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Emp_ID" OnRowDeleting="gvEmpdata_RowDeleting"
                    OnRowEditing="gvEmpdata_RowEditing" 
                    OnRowCancelingEdit="gvEmpdata_RowCancelingEdit"
                    OnRowUpdating="gvEmpdata_RowUpdating">

                    <Columns>
                        <asp:BoundField DataField="Emp_ID" HeaderText="Employee Id" />
                        <asp:TemplateField HeaderText="First Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_fname" runat="server" Text='<%# Bind("Emp_Fname") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_lname" runat="server" Text='<%# Eval("Emp_Fname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_lname" runat="server" Text='<%# Bind("Emp_Lname") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_lname" runat="server" Text='<%# Eval("Emp_Lname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                    </Columns>

            </asp:GridView>
            </ContentTemplate>
            
        </asp:UpdatePanel>
    </div>
    </form>
    
</body>
</html>
