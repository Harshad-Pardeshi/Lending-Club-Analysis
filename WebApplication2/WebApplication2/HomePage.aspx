<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Lending Club : LC</title>
	<!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
        <!-- CUSTOM STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
     <!-- GOOGLE FONTS-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
</head>
    <script type="text/javascript">
    function enableData() {
        alert("Congratss!!! You are elegible to get a loan");
        document.getElementById("div_row1").style.display= 'block';
        //document.getElementById("txtSubGrade").style.visibility = 'block';
    }
</script>
<body>
    
    <div>
        <div id="wrapper">
        <nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href=#>Lending Club</a> 
            </div>
  <div style="color: white;
padding: 15px 50px 5px 50px;
float: right;
font-size: 16px;">  &nbsp;  </div>
        </nav>   
           <!-- /. NAV TOP  -->
                <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">
				<li class="text-center">
                    <img src="assets/img/find_user.png" class="user-image img-responsive"/>
					</li>
				
					
                    <li>
                        <a  href="index.html"><i class="fa fa-dashboard fa-3x"></i> Dashboard</a>
                    </li>
                </ul>
               
            </div>
            
        </nav>  
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper" >
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2>Lending Club</h2>   
                        <h5>Welcome , Love to see you back. </h5>
                       
                    </div>
                </div>
                 <!-- /. ROW  -->
                 <hr />
                <form id="form1" runat="server" role="form">
               <div id="div_row1" class="row" >
               <div class="col-md-12">
                    <!-- Form Elements -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Loan Application Form
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <h3>Check your Eligibility</h3>
                                    
                                        <div class="form-group">
                                            <label>Loan Amount Required</label>
                                            <div class="form-group input-group">
                                                <span class="input-group-addon">$</span>
                                                <asp:TextBox ID="txtLoanAmount" runat="server"  class="form-control"/>
                                                <span class="input-group-addon">.00</span>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label>FICO Score</label>
                                            <asp:TextBox ID="txtFico" runat="server" class="form-control"/>
                                        </div>

                                        <div class="form-group">
                                            <label>Purpose of loan</label>
                                            <asp:TextBox ID="txtTitle" runat="server" class="form-control"/>
                                        </div>

                                        <div class="form-group">
                                            <label>Debt to Income Ratio</label>
                                            <asp:TextBox ID="txtDti" runat="server" class="form-control"/>
                                        </div>

                                        <div class="form-group">
                                            <label>Zip Code</label>
                                            <asp:TextBox ID="txtZipCode" runat="server" class="form-control"/>
                                        </div>

                                        <div class="form-group">
                                            <label>Years of employment</label>
                                            <asp:TextBox ID="txtEmplLen" runat="server" class="form-control"/>
                                        </div>

                                        <div class="form-group">
                                            <label>State</label>
                                            <asp:DropDownList ID="lstState" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="abbreviation" class="form-control"></asp:DropDownList>
                                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/us-states.xml"></asp:XmlDataSource>
                                        </div>
                                        
                                        <asp:Button ID="Button1" runat="server" Text="Check Eligibility" OnClick ="Submit" class="btn btn-primary"/>
                                        <button type="reset" class="btn btn-default">Reset</button>

                                    
                             
                                 
                                </div>
                            </div>
                        </div>
                    </div>
                     <!-- End Form Elements -->
                </div>
            </div>
                <!-- /. ROW  -->
            <div id ="div_row2" class="row" >
                <div class="col-md-12">
                    <!-- Form Elements -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Personal Dtails
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <h3>Enter Additional Details</h3>

                                    <div class="form-group">
                                        <label>Annual Income</label>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon">$</span>
                                            <asp:TextBox ID="txtAnnualIncome" runat="server"  class="form-control"/>
                                            <span class="input-group-addon">.00</span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label>Sub Grade</label>
                                        <asp:TextBox ID="txtSubGrade" runat="server" class="form-control"/>
                                    </div>

                                    <div class="form-group">
                                        <label>Loan period</label>
                                        <asp:DropDownList ID="lstLoanTerm" runat="server" class="form-control">
                                            <asp:ListItem>36</asp:ListItem>
                                            <asp:ListItem>60</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label>Year applied</label>
                                        <asp:TextBox ID="txtIssueYear" runat="server" class="form-control"/>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label>Application Type</label>
                                        <asp:DropDownList ID="lstApplicationType" runat="server" class="form-control">
                                            <asp:ListItem>INDIVIDUAL</asp:ListItem>
                                            <asp:ListItem>JOINT</asp:ListItem>
                                            <asp:ListItem>DIRECT_PAY</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label>Verification Status</label>
                                        <asp:DropDownList ID="lstVerificationStatus" runat="server" class="form-control">
                                            <asp:ListItem>Verified</asp:ListItem>
                                            <asp:ListItem>Not Verified</asp:ListItem>
                                            <asp:ListItem>Source Verified</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group">
                                        <label>Home Ownership</label>
                                        <asp:DropDownList ID="lstHomeOwnership" runat="server" class="form-control">
                                            <asp:ListItem>MORTGAGE</asp:ListItem>
                                            <asp:ListItem>RENT</asp:ListItem>
                                            <asp:ListItem>OWN"</asp:ListItem>
                                            <asp:ListItem>OTHER</asp:ListItem>
                                            <asp:ListItem>ANY</asp:ListItem>
                                            <asp:ListItem>NONE</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label>Open Accounts in past 24 months</label>
                                        <asp:TextBox ID="txtOpenAccounr24Mo" runat="server" class="form-control"/>
                                    </div>

                                    <div class="form-group">
                                        <label>Revolving Balance</label>
                                        <asp:TextBox ID="txtRevolvingBalance" runat="server" class="form-control"/>
                                    </div>

                                    <div class="form-group">
                                        <label>Months since last Delinq</label>
                                        <asp:TextBox ID="txtMthsSinceLastDelinq" runat="server" class="form-control"/>
                                    </div>
                                        
                                        <asp:Button ID="Button2" runat="server" Text="Get Interest Rate" OnClick ="calculateIntrestRates" class="btn btn-primary"/>
                                        <button type="reset" class="btn btn-default">Reset</button>                                 
    </div>
                                
                                
                            </div>
                        </div>
                    </div>
                     <!-- End Form Elements -->
                </div>
            </div>

                <!-- /. ROW  -->
               <div id="div_row_output" class="row" >
               <div class="col-md-12">
                    <!-- Form Elements -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Your intrest Rates
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <h3>Intrest rates by 3 methods</h3>
                                    

                                    <div class="form-group">
                                        <label>Manual Clustring</label>
                                        <asp:TextBox ID="txtManualOutput" runat="server" class="form-control" />
                                    </div>

                                    <div class="form-group">
                                        <label>KNN Clustring</label>
                                        <asp:TextBox ID="txtAlgoClustring" runat="server" class="form-control"/>
                                    </div>

                                    <div class="form-group">
                                        <label>No Clustring</label>
                                        <asp:TextBox ID="txtNoClustring" runat="server" class="form-control" />
                                    </div>
                                  
                                 
                                </div>
                            </div>
                        </div>
                    </div>
                     <!-- End Form Elements -->
                </div>
            </div>
                <!-- /. ROW  -->



                 </form>
    </div>
             <!-- /. PAGE INNER  -->
            </div>
         <!-- /. PAGE WRAPPER  -->
        </div>
     <!-- /. WRAPPER  -->
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
      <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
      <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
 
    </div>
</body>
</html>
