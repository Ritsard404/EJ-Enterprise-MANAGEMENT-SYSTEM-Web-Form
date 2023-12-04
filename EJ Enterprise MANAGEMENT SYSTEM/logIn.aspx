<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="EJ_Enterprise_MANAGEMENT_SYSTEM.Account_MAnagement.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="script/sweetalert.min.js"></script>

    <style>
        body {
            height: 100%
        }

        .wave-group {
            position: relative;
        }

            .wave-group .input {
                font-size: 16px;
                padding: 10px 10px 10px 5px;
                display: block;
                width: 200px;
                border: none;
                border-bottom: 1px solid #515151;
                background: transparent;
            }

                .wave-group .input:focus {
                    outline: none;
                }

            .wave-group .label {
                color: #999;
                font-size: 18px;
                font-weight: normal;
                position: absolute;
                pointer-events: none;
                left: 5px;
                top: 10px;
                display: flex;
            }

            .wave-group .label-char {
                transition: 0.2s ease all;
                transition-delay: calc(var(--index) * .05s);
            }

            .wave-group .input:focus ~ label .label-char,
            .wave-group .input:valid ~ label .label-char {
                transform: translateY(-20px);
                font-size: 14px;
                color: #5264AE;
            }

            .wave-group .bar {
                position: relative;
                display: block;
                width: 200px;
            }

                .wave-group .bar:before, .wave-group .bar:after {
                    content: '';
                    height: 2px;
                    width: 0;
                    bottom: 1px;
                    position: absolute;
                    background: #5264AE;
                    transition: 0.2s ease all;
                    -moz-transition: 0.2s ease all;
                    -webkit-transition: 0.2s ease all;
                }

                .wave-group .bar:before {
                    left: 50%;
                }

                .wave-group .bar:after {
                    right: 50%;
                }

            .wave-group .input:focus ~ .bar:before,
            .wave-group .input:focus ~ .bar:after {
                width: 50%;
            }


        .center-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height:100vh;
        }
    </style>

    <title>Log In</title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container center-container">
            <div class="row">
                <div class="card">
                    <div class="card-body">
                        <div class="row" style="margin: 10px 20px 10px 20px;">
                            <div class="wave-group">
                                <input required="?" id="txtID" type="text" runat="server" class="input" />
                                <span class="bar"></span>
                                <label class="label">
                                    <span class="label-char" style="--index: 0">I</span>
                                    <span class="label-char" style="--index: 1">D</span>
                                </label>
                            </div>
                        </div>
                        <div class="row" style="margin: 10px 20px 10px 20px;">
                            <div class="wave-group">
                                <input required="?" id="txtpassword" type="password" runat="server" class="input" />
                                <span class="bar"></span>
                                <label class="label">
                                    <span class="label-char" style="--index: 0">P</span>
                                    <span class="label-char" style="--index: 1">A</span>
                                    <span class="label-char" style="--index: 2">S</span>
                                    <span class="label-char" style="--index: 3">S</span>
                                    <span class="label-char" style="--index: 4">W</span>
                                    <span class="label-char" style="--index: 5">O</span>
                                    <span class="label-char" style="--index: 6">R</span>
                                    <span class="label-char" style="--index: 7">D</span>
                                </label>
                            </div>
                        </div>
                        <div class="row" style="margin: 30px 0 20px 0; width: 30%;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="login" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script src="../script/jquery/jquery-3.7.1.js"></script>
    <script src="../bootstrap/script/bootstrap.min.js"></script>
    <script src="../bootstrap/script/jquery-3.3.1.slim.min.js"></script>
    <script src="../bootstrap/script/popper.min.js"></script>

</body>
</html>
