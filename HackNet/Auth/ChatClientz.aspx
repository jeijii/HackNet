﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatClientz.aspx.cs" Inherits="HackNet.SignalR.ChatClientz" %>


<!DOCTYPE html>
<html>
<head>
	<title>SignalR Simple Chat</title>
	<style type="text/css">
		.container {
			background-color: #99CCFF;
			border: thick solid #808080;
			padding: 20px;
			margin: 20px;
		}
	</style>
</head>
<body>
	<div class="container">
		<input type="text" id="message" />
		<input type="button" id="sendmessage" value="Send" />
		<input type="hidden" id="displayname" />
		<ul id="discussion"></ul>
	</div>
	<!--Script references. -->
	<script src="../Scripts/jquery-3.1.1.min.js"></script>
	<script src="../SignalR/jquery.color-2.1.2.min.js"></script>
	<script src="../Scripts/jquery.signalR-2.2.1.js"></script>
	<script src="../SignalR/hubs"></script>
	<!--Add script to update the page and send messages.-->
	<script type="text/javascript">
        $(function () {
            // Declare a proxy to reference the hub.
            var chat = $.connection.ChatClientz;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (name, msg) {
                // Html encode display name and message.
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(msg).html();
                // Add the message to the page.
                $('#discussion').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.
            $('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub.
                    chat.server.sendMessage($('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });
            });
        });
	</script>
</body>
</html>
