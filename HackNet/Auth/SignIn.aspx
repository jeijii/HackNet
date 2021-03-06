﻿<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="HackNet.Auth.SignIn" %>

<asp:Content ID="SignInContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="jumbotron">
		<h1><%= Page.Title %></h1>
		<p>Sign in or register to access our full range of features<span class="blinking">_</span></p>
	</div>
    	<ol class="breadcrumb" style="margin-bottom: 5px;">
		<li><a href="<%= ResolveUrl("~/Auth/signin") %>">Authentication</a></li>
		<li><a href="<%= ResolveUrl("~/Auth/signup") %>">Registration</a></li>
		<li class="active">Details</li>
	</ol>
   	<br />
	<div class="panel panel-default">
		<div class="panel-heading">
			Sign In 
		</div>
		<div class="panel-body">
            <asp:Label ID="Msg" ForeColor="Red" runat="server"/><asp:Label ID="DelayMsg" ForeColor="Orange" runat="server"/>
			<table runat="server" class="formTable">
				<tr>
					<td><strong>Email:</strong></td>
					<td>
						<asp:TextBox ID="Email" runat="server" CssClass="form-control" /></td>
					<td>
						<asp:RequiredFieldValidator
							ID="EmailValidator"
							ControlToValidate="Email"
							ErrorMessage="*"
							runat="server" />
						<asp:RegularExpressionValidator
							ID="EmailRegExValidator"
							ControlToValidate="Email"
							ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
							ErrorMessage="Invalid Email Address"
							runat="server" />
					</td>
				</tr>
				<tr>
					<td><strong>Password:</strong></td>
					<td>
						<asp:TextBox ID="UserPass" CssClass="pwdfield form-control" TextMode="Password" runat="server" />
						<asp:HyperLink NavigateUrl="~/Auth/ResetPassword.aspx" runat="server">Forgot your password?</asp:HyperLink>
					</td>
					<td>
						<asp:RequiredFieldValidator
							ID="UserPassValidator"
							ControlToValidate="UserPass"
							ErrorMessage="*"
							runat="server" />
					</td>
				</tr>
				<tr>
					<td><strong>I am a...</strong></td>
					<td>
						<div class="radio">
							<input type="radio" name="userstate" id="ret" value="returning" checked="checked"><label for="ret">Returning User</label><br>
							<input type="radio" name="userstate" id="new" value="new"><label for="new">New User</label><br>
						</div>
					</td>
				</tr>
			</table>
			<asp:Button ID="LoginButton"
				Text="Sign In"
				CssClass="btn btn-primary loginBtn"
				OnClick="LoginClick"
				CausesValidation="true"
				runat="server" />
			<script>
				$(function () {
					$("#new").on('click', function (e) {
						window.location = "SignUp.aspx"
					});
				});
			</script>
		</div>
	</div>
</asp:Content>
