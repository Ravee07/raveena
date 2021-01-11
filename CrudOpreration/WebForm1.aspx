<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PhoneBookAppp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                
                <tr>
                    <td>
                        Name:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>
                        PhoneNum:<asp:TextBox ID="tctNum" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        Address<asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                    </td>
                </tr>




                <tr>
                    <td>
                        <asp:Button ID="add" runat="server" Text="add" OnClick="add_Click"></asp:Button>
                    </td>
                




                
                    <td>
                        <asp:Button ID="update" runat="server" Text="update" OnClick="update_Click"></asp:Button>

                    </td>
                


                
                    <td>
                        <asp:Button ID="delete" runat="server" Text="delete" OnClick="delete_Click"></asp:Button>
                    </td>

                    <td>
                    
                    <asp:Button ID="DeleteAll" runat="server" Text="DeleteAll" OnClick="DeleteAll_Click" />
                </td>

                </tr>
                <tr>

                    <asp:GridView ID="GridView1" runat="server" style="margin-right: 22px"></asp:GridView>
               
                    
                
                </tr>

               
            </table>
        </div>
    </form>
</body>
</html>