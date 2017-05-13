<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<script type="text/javascript">
    function enableData() {
        alert("In Java Script");
        document.getElementById("lblSubGrade").style.visibility = 'visible';
        document.getElementById("txtSubGrade").style.visibility = 'block';
    }
</script>


<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label ID="lblLoanAmt" runat="server" Text="Loan Amount Required: "></asp:Label>
        <asp:TextBox ID="txtLoanAmount" runat="server"></asp:TextBox>


    </div>
        <p>

        <asp:Label ID="Label1" runat="server" Text="Fico Score :"></asp:Label>
        <asp:TextBox ID="txtFico" runat="server"></asp:TextBox>

        </p>
        <p>
        
        <asp:Label ID="lbltitle" runat="server" Text="Loan Required for: "></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

        </p>
        <p>

        <asp:Label ID="lbldti" runat="server" Text="Debt to Income Ratio: "></asp:Label>
        <asp:TextBox ID="txtDti" runat="server"></asp:TextBox>

        </p>
        <p>

        <asp:Label ID="lblZipCode" runat="server" Text="Zip Code: "></asp:Label>
        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        
        </p>
        <p>
        
        <asp:Label ID="Label2" runat="server" Text="Years you are employed: "></asp:Label>
        <asp:TextBox ID="txtEmplLen" runat="server"></asp:TextBox>
        
        </p>
        <p>
        
        <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>

        <asp:DropDownList ID="selState" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="abbreviation"></asp:DropDownList>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/us-states.xml"></asp:XmlDataSource>
        </p>
        
        <p>

        <asp:Button ID="Button1" runat="server" Text="Check for eligibility" OnClick ="Submit"/>

        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        
        <p>
        <asp:Label ID="txtAmmualIncome" runat="server" Text="Annual Income: "></asp:Label>
        <asp:TextBox ID="txtAnnualIncome" runat="server"></asp:TextBox>
        </p>

        <p>
        <asp:Label ID="lblSubGrade" runat="server" Text="Sub Grade" enable ="false"></asp:Label>
        <asp:TextBox ID="txtSubGrade" runat="server"  enable="false"></asp:TextBox>
        </p>
        <p>
        
        <asp:Label ID="txtTerm" runat="server" Text="Loan period"></asp:Label>
        <asp:DropDownList ID="lstLoanTerm" runat="server">
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
        </asp:DropDownList>

        </p>

        <p>
        <asp:Label ID="lblIssueYear" runat="server" Text="Year applied: "></asp:Label>
        <asp:TextBox ID="txtIssueYear" runat="server"></asp:TextBox>
        </p>

        <p>
        <asp:Label ID="lblApplicaionType" runat="server" Text="Application Type: "></asp:Label>
        <asp:DropDownList ID="lstApplicationType" runat="server">
            <asp:ListItem>"INDIVIDUAL"</asp:ListItem>
            <asp:ListItem>JOINT</asp:ListItem>
            <asp:ListItem>DIRECT_PAY</asp:ListItem>
        </asp:DropDownList>
        </p>


        <p>
        <asp:Label ID="lblTotalAccount" runat="server" Text="Total Accounts: "></asp:Label>
        <asp:TextBox ID="txtTotalAccount" runat="server"></asp:TextBox>
        </p>

        <p>
        <asp:Label ID="lblVerificationStatus" runat="server" Text="Verification Status: "></asp:Label>
        <asp:DropDownList ID="lstVerificationStatus" runat="server">
            <asp:ListItem>"Verified"</asp:ListItem>
            <asp:ListItem>"Not Verified"</asp:ListItem>
            <asp:ListItem>"Source Verified"</asp:ListItem>
        </asp:DropDownList>
        </p>

        <p>
        <asp:Label ID="lblHomeOwnership" runat="server" Text="Home Ownership: "></asp:Label>
        <asp:DropDownList ID="lstHomeOwnership" runat="server">
            <asp:ListItem>"MORTGAGE"</asp:ListItem>
            <asp:ListItem>"RENT"</asp:ListItem>
            <asp:ListItem>"OWN"</asp:ListItem>
            <asp:ListItem>"OTHER"</asp:ListItem>
            <asp:ListItem>"ANY"</asp:ListItem>
            <asp:ListItem>"NONE"</asp:ListItem>
        </asp:DropDownList>
        </p>

        <p>
        <asp:Label ID="lblOpenAccounr24Mo" runat="server" Text="Open Accounts in past 24 months: "></asp:Label>
        <asp:TextBox ID="txtOpenAccounr24Mo" runat="server"></asp:TextBox>
        </p>

        <p>
        <asp:Label ID="lblRevolvingBalance" runat="server" Text="Revolving Balance: "></asp:Label>
        <asp:TextBox ID="txtRevolvingBalance" runat="server"></asp:TextBox>
        </p>

        <p>
        <asp:Label ID="lblMthsSinceLastDelinq" runat="server" Text="Months since last Delinq: "></asp:Label>
        <asp:TextBox ID="txtMthsSinceLastDelinq" runat="server"></asp:TextBox>
        </p>

         <p>
        <asp:Button ID="btnCalculateIntrest" runat="server" Text="Calculate Interest" OnClick ="calculateIntrestRates"/>
        </p>
    </form>
</body>
</html>
