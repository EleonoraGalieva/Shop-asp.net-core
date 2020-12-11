"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, amount) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var divmain = document.getElementById("messagesList");
    var div1 = document.createElement("div");
    var div2 = document.createElement("div");
    var h = document.createElement("h3");
    h.style.cssText = "font-size: 16px; font-weight: bold;";
    h.textContent = user;
    div2.appendChild(h);
    div2.innerHTML += msg;
    div1.appendChild(div2);
    divmain.appendChild(div1);
    document.getElementById("messageInput").value = "";
    var comAmount = document.getElementById("comAmount");
    comAmount.textContent = amount.toString() + " comments";
});

connection.start().then(function () {
    var pieId = document.getElementById("pieId").value;
    connection.invoke("JoinPieGroup", pieId);
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var pieId = document.getElementById("pieId").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", pieId, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});