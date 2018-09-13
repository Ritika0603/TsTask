<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TeamScale.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team Scale</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-inverse bg-dark">
            <%-- <a class="navbar-brand" href="#">Navbar</a>--%>
            <img style="width: 11%;" src="https://www.cqse.eu/images/teamscale/logo-teamscale.png" />
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
            </div>
        </nav>
        <div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>TeamScale Task</h1>
                    <p>In this project, I have created a method to read the data from the database file(.sqlite) and then used inline query(joins) to extract the consolidated data from the database tables.</p>

                    <p>I have created a method to export the data into csv file by downloading the file into the system on page load.</p>

                    <p>
                        After that, I have created 2 web methods :
                    </p>
                    <ul>
                        <li>getUserDetails -  used to fetch the data from database on the basis of id.
                            <input type="number" id="udetails" />
                            <a class="btn btn-primary getdetails"  style="color:#fff;">Get Details</a>
                        </li>
                        <li>getOver50kSalary - used to check if user salary is above 50k/year or not.
                            <input type="number" id="salary" />
                            <a class="btn btn-primary getsalary" style="color:#fff;">Get Salary Detail over 50K</a>
                        </li>
                    </ul>
                    <div class="apidetails">
                        API Results for getdetails :- <div class="tableDetails"></div>
                       
                       
                    </div>
                      <div class="apisalary">
                        API Results for Get Salary Detail :- <div class="salDetails"></div>
                       
                       
                    </div>
                    <br />
                    <br />
                    <div class="col-md-3 downloadrecord" style="cursor: pointer;">
                        <h1>Download records</h1>
                        <img style="width: 30%;" src="images/dlicon.png" class="img-responsive" />
                    </div>

                </div>
            </div>
        </div>

    </form>
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/JSON-to-Table.min.1.0.0.js"></script>
    <script src="scripts/JavaScript.js"></script>
</body>
</html>
