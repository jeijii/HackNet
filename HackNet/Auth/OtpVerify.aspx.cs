﻿using HackNet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HackNet.Auth
{
	public partial class OtpVerify : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["PasswordSuccess"] == null)
				Response.Redirect("~/Default");
		}

		protected void ConfirmOTP(object sender, EventArgs e)
		{
			if (Session["PasswordSuccess"] == null)
			{
				Response.Redirect("~/Default");
				return;
			}

			string email = Session["PasswordSuccess"] as string;
			using (Authenticate a = new Authenticate(email))
			{
				switch (a.Validate2FA(OTPValue.Text))
				{
					case OtpResult.Success:
						Session["PasswordSuccess"] = null;
						FormsAuthentication.SetAuthCookie(email, false);
						Response.Redirect("~/Default");
						break;
					case OtpResult.NotInt:
						Msg.Text = "You entered non-numbers, please check again";
						break;
					case OtpResult.WrongLength:
						Msg.Text = "You entered an OTP with malformed length";
						break;
					case OtpResult.WrongOtp:
						Msg.Text = "OTP Entered does not match, please try again";
						break;
				}
			}
		}

		protected void CancelOTP(object sender, EventArgs e)
		{
			string email = Session["PasswordSuccess"] as string;
			FormsAuthentication.SetAuthCookie(email, false);
			Response.Redirect("~/Default");
		}
	}
}